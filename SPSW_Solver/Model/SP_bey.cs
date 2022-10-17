using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicModel;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SPSW_Solver.BasicModel;
using SPSW_Solver.UI.Selection;

namespace SPSW_Solver.Model
{
    [DataContract]
    public class SPBey : IPolygonRenderable
    {
        #region Members
        [DataMember]
        protected SPSW_Simple_Model _model;
        [DataMember]
        protected int _floorIndex;
        [DataMember]
        protected int _rowIndex;
        [DataMember]
        protected PlateFamily _platesection;
        [DataMember]
        protected bool _selected = false;
        protected Polygon2D _renderPolygon;
        [DataMember]
        protected RectangleSection _trussesSection; 
        [DataMember]
        protected VirtualTrussesGroup _trussGroup;
        [DataMember]
        protected Angle _theoriticalAngle = Angle.FromDegrees(45);
        [DataMember]
        protected Angle _actualVerticalAngle = Angle.FromDegrees(45);
        [DataMember]
        protected int _numOfStrips;
        #endregion

        #region Properties
        public SPSW_Simple_Model Model
        {
            get { return _model; }
        }
        public int FloorIndex
        {
            get { return _floorIndex; ; }
        }
        public int RowIndex
        {
            get { return _rowIndex; }
        }
        public PlateFamily PlateSection
        {
            get { return _platesection; }
            set { _platesection = value; }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public Polygon2D RenderPolygon
        {
            get {
                if ((object)_renderPolygon == null)
                    SetRenderPolygon();
                return _renderPolygon;
            }
            set { _renderPolygon = value; }
        }
        
        public VirtualTrussesGroup TrussGroup
        {
            get { return _trussGroup; }
        }
        public Angle TheoriticalVerticalAngle
        {
            get { return _theoriticalAngle; }
            set { _theoriticalAngle = value; }
        }
        public RectangleSection TrussesSection
        {
            get { return _trussesSection; }
            set { _trussesSection = value; }
        }
        public Angle ActualVerticalAngle
        {
            get { return _actualVerticalAngle; }
            set { _actualVerticalAngle = value; }
        }
        public double NumOfStrips
        {
            get { return _numOfStrips; }
        }
        #endregion

        #region Constructors
        public SPBey()
        {

        }
        public SPBey(SPSW_Simple_Model model, int floorIndex, int rowIndex)
        {
            _model = model;
            _floorIndex = floorIndex;
            _rowIndex = rowIndex;
            _platesection = model.GetPlateFamily(floorIndex);
            //SetRenderPolygon();
            ClaculateAngleValue();
        }

        #endregion

        #region Methods
        #region Levels
        public Level GetBottomLevel()
        {
            return _model.GetbottomLevelFromFloorIndex(_floorIndex);
        }
        public Level GetTopLevel()
        { return _model.GetTopLevelFromFloorIndex(_floorIndex); }
        public VerticalLine GetLeft()
        { return _model.VerticalLines[_rowIndex]; }
        public VerticalLine GetRight()
        { return _model.VerticalLines[_rowIndex + 1]; }
        public MainNode GetLeftBottom()
        { return GetBottomLevel().LineNodes.Where(x => x is MainNode).Cast<MainNode>().ToArray()[_rowIndex]; }
        public MainNode GetRightBottom()
        { return GetBottomLevel().LineNodes.Where(x => x is MainNode).Cast<MainNode>().ToArray()[_rowIndex + 1]; }
        public MainNode GetRightTop()
        { return GetTopLevel().LineNodes.Where(x => x is MainNode).Cast<MainNode>().ToArray()[_rowIndex + 1]; }
        public MainNode GetLeftTop()
        { return GetTopLevel().LineNodes.Where(x => x is MainNode).Cast<MainNode>().ToArray()[_rowIndex]; }
        #endregion

        public double GetBeyWidth()
        {
            return _model.Layout.GetModelWidth();
        }
        public double GetBeyHeight()
        {
            return _model.Layout.GetFloorHeight(_floorIndex);
        }
        private void SetRenderPolygon()
        {
            _renderPolygon = new Polygon2D( new List<Point2D>()
            {
                GetLeftBottom().Point,
                GetRightBottom().Point,
                GetRightTop().Point,
                GetLeftTop().Point
            });
        }
        internal void CreateTrussesSection()
        {
            _trussesSection = new RectangleSection(++Section.LastID, _platesection.Name+$" {_floorIndex+1}", _platesection.Thickness,
               (GetBeyWidth() * Math.Cos(_actualVerticalAngle.Radians) + GetBeyHeight() * Math.Sin(_actualVerticalAngle.Radians)) / _numOfStrips);
        }
        public double CalcBeamSegmentLength()
        {
            double l = GetBeyWidth();
            double h = GetBeyHeight() * Math.Tan(_actualVerticalAngle.Radians);
            return (h + l) / _numOfStrips;
        }
        
        public void CreateTrussGroup()
        {
            SetRenderPolygon();
            double space = CalcBeamSegmentLength();
            Point2D centerpoint = new Point2D(_renderPolygon.Vertices.Select(x =>x.X).Average()
                , _renderPolygon.Vertices.Select(x => x.Y).Average());

            double HZSpace = space / Math.Tan(_actualVerticalAngle.Radians);
            Point2D LeftBottom = GetLeftBottom().Point;
            Point2D RightBottom = GetRightBottom().Point;
            Point2D RightTop = GetRightTop().Point;
            Point2D LeftTop = GetLeftTop().Point;


            _trussGroup = VirtualTrussesGroup.CreateTrussGroup(space, _platesection, _trussesSection , _actualVerticalAngle,
               centerpoint, new ReferenceLine(GetTopLevel(), new Line2D(LeftTop, RightTop),space)
               , new ReferenceLine(GetBottomLevel(), new Line2D(LeftBottom, RightBottom),space)
               , new ReferenceLine(GetLeft(), new Line2D(LeftTop, LeftBottom),HZSpace)
               , new ReferenceLine(GetRight(), new Line2D(RightTop, RightBottom),HZSpace));
        }
        public virtual void Render()
        {
            GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.TrussesColor);
            _trussGroup?.Trusses?.ForEach(x => x.Render());
        }
        public virtual bool HitTest(Point2D Hitpoint)
        {
            if ((object)RenderPolygon == null)
                return false;
            return RenderPolygon.EnclosesPoint(Hitpoint);
        }
        public virtual ObjectProperties GetProperties()
        {
            return new SPBeyProperties(this);
        }
        public void RenderDeformation(int loadCase , int index )
        {
            _trussGroup?.Trusses?.ForEach(x => x.RenderDeformation(loadCase , index));
        }
        public void RenderModeShape(int index , double Factor)
        {
            GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.TrussesColor);
            _trussGroup?.Trusses?.ForEach(x => x.RenderModeShape(index , Factor));
        }
        private void CalcTheoriticalAngle()
        {
            double H = _model.Layout.GetFloorHeight(_floorIndex);
            double L = _model.Layout.GetModelWidth();
            double tw = _platesection.Thickness;

            FrameElementFamily beamSection1;
            FrameElementFamily beamSection2;
            _model.GetBeamFamiliesByFloorIndex(_floorIndex, out beamSection1, out beamSection2);
            IShapeSection columnsSection = _model.GetColumnFamilyByFloorIndex(_floorIndex)?.Section;
            double d0 = L - columnsSection.D;
            double Ac = columnsSection.A;
            double Ic = columnsSection.Ix;
            double Ab = 0,Ad = 0;
            
            if (beamSection1 != null)
            { 
                Ab += beamSection1.Section.A;
                Ad += beamSection1.Section.D; 
            }
            if (beamSection2 != null)
            { 
                Ab += beamSection2.Section.A;
                Ad += beamSection2.Section.D; 
            }

            Ab *= 0.5;
            Ad *= 0.5;

            double Hw = H - Ad;

            switch (_model.DesignApproach)
            {
                case DesignApproach.AISC_Tension_Field_Angle:
                    double t1 = 1 + (tw * L / (2 * Ac));
                    double t2 = 1 + tw * H * ((1 / Ab) + Math.Pow(H, 3) / (360 * Ic * L));
                    _theoriticalAngle = Angle.FromRadians(Math.Atan(Math.Pow(t1 / t2, 0.25)));
                    break;
                case DesignApproach.cardiff:
                    _theoriticalAngle = Angle.FromRadians(2 / 3.0 * Math.Atan(Hw / d0));
                    break;
                case DesignApproach.Basler:
                    _theoriticalAngle = Angle.FromRadians(0.5 * Math.Atan(Hw / d0));
                    break;
                case DesignApproach.UserDefined:
                    _theoriticalAngle = _model.UserDefinedAngle;
                    break;
                default:
                    break;
            }
        }
        internal void ClaculateAngleValue()
        {
            CalcTheoriticalAngle();
            CalcActualAngle();
        }

        private void CalcActualAngle()
        {
            double H = _model.Layout.GetFloorHeight(_floorIndex);
            double L = _model.Layout.GetModelWidth();

            Angle minAngle = Angle.FromDegrees(Math.Max(5, _theoriticalAngle.Degrees - SPSW_Model.DegreeTolerance));
            Angle maxAngle = Angle.FromDegrees(Math.Min(85, _theoriticalAngle.Degrees + SPSW_Model.DegreeTolerance));
            double minH = H * Math.Tan(minAngle.Radians);
            double maxH = H * Math.Tan(maxAngle.Radians);
            double h = 0.5 * (minH + maxH);
            int n = _model.MinStrips - 1;
            double lengthTolerance = 1e-6;
            while (true)
            {
                double delta = (h + L) / n;
                int n1 = (int)(Math.Round(L / delta, 0));
                delta = L / n1;
                int n2 = (int)(Math.Round(h / delta, 0));
                double actualH = n2 * delta;
                if (((actualH > minH && actualH < maxH) || Math.Abs(actualH - minH) < lengthTolerance || Math.Abs(actualH - maxH) < lengthTolerance)
                    && n1 + n2 >= _model.MinStrips)
                {
                    _actualVerticalAngle = Angle.FromRadians(Math.Atan(actualH / H));
                    _numOfStrips = n1 + n2;
                    return;
                }
                n++;
            }
        }
        #endregion
    }
}
