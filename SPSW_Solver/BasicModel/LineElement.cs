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
using SPSW_Solver;
using SPSW_Solver.BasicModel;
using SPSW_Solver.Model;
using SPSW_Solver.UI.Selection;

namespace BasicModel
{
    public interface IPlasticElement
    {
        double GetRelativeLocation(RegularFrameElement element);
        List<double> GetRotaions(int CurrentLoadCase);
        List<double> GetMoment(int CurrentLoadCase);
    }
    public interface ITrussElement
    {
        Node StartNode
        {
            get;
        }
        Node EndNode
        {
            get;
        }
    }
    public interface IFrameElement
    {
        List<Node> Nodes
        {
            get;
        }
    }
    public interface IRotspring : ITrussElement
    {
        FrameElementFamily Family
        {
            get;
        }
        int ID
        {
            get;
        }
        void UpdateIDReference();
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(TwoNodesElement))]
    [KnownType(typeof(FrameTwoNodesElement))]
    [KnownType(typeof(RigidLink))]
    [KnownType(typeof(TrussElement))]
    [KnownType(typeof(RegularTrussElement))]
    [KnownType(typeof(RegularFrameElement))]
    [KnownType(typeof(Column))]
    [KnownType(typeof(Beam))]
    [KnownType(typeof(RotSpring))]
    [KnownType(typeof(PlasticHinge))]
    public abstract class Element2d : IFEMELement
    {
        #region Static Members
        public static int LastID = 0;
        #endregion

        #region Members
        [DataMember]
        protected int _ID;
        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        #endregion

        #region Constructors
        public Element2d(int ID)
        {
            _ID = ID;
        }
        public Element2d()
        {
        }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return _ID;
        }
        public static Polygon2D GetRectangular(Point2D start, Point2D end, double thick)
        {

            Vector2D direction = (end.ToVector2D() - start.ToVector2D()).Normalize();
            Vector2D prep = direction.Rotate(Angle.FromDegrees(90));
            prep *= thick;
            return new Polygon2D(new List<Point2D>()
            {
                start + prep,
                end + prep,
                end- prep,
                start - prep,
            });
        }
        public static void RenderPolygon(Polygon2D renderPolygon)
        {
            foreach (var point in renderPolygon.Vertices)
            {
                RenderOptions.Vertex2(point);
            }
        }
        public static double GetDeformedviewerThickness()
        {
            return 0.5 * RenderOptions.FramesRadius * RenderOptions.NodesRadius;
        }
        public static double SRSS(IEnumerable<double> values)
        {
            double sum = 0.0;
            foreach (var v in values)
            {
                sum += Math.Pow(v, 2);
            }
            return Math.Sqrt(sum);
        }
        public virtual void UpdateIDReference()
        {
            LastID = Math.Max(LastID, _ID);
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class SectionLocalForces
    {
        #region Members
        [DataMember]
        protected double _Nf;
        [DataMember]
        protected double _Sf;
        [DataMember]
        protected double _FM;
        #endregion

        #region Properties
        public double Nf
        {
            get { return _Nf; }
            set { _Nf = value; }
        }
        public double Sf
        {
            get { return _Sf; }
            set { _Sf = value; }
        }
        public double FM
        {
            get { return _FM; }
            set { _FM = value; }
        }
        #endregion

        #region Constructors
        public SectionLocalForces()
        {

        }
        public SectionLocalForces(double x, double y, double M)
        {
            _Nf = x;
            _Sf = y;
            _FM = M;
        }
        #endregion

        public static SectionLocalForces SRSS(IEnumerable<SectionLocalForces> values)
        {
            return new SectionLocalForces
                (Element2d.SRSS(values.Select(x => x.Nf))
                , Element2d.SRSS(values.Select(x => x.Sf))
                , Element2d.SRSS(values.Select(x => x.FM)));
        }
        public static SectionLocalForces Peak(IEnumerable<SectionLocalForces> values)
        {
            return new SectionLocalForces
                (values.Select(x => x.Nf).Max()
                , values.Select(x => x.Sf).Max()
                , values.Select(x => x.FM).Max());
        }
    }

    [DataContract(IsReference = true)]
    public class RigidLink : TwoNodesElement, ITrussElement, IPolygonRenderable
    {
        #region Members
        protected Polygon2D _renderPolygon;
        [DataMember]
        protected bool _selected;
        [DataMember]
        protected FrameElementFamily _family;
        #endregion

        #region Properties
        public Polygon2D RenderPolygon
        {
            get
            {
                if ((object)_renderPolygon == null)
                    SetRenderPolygon();
                return _renderPolygon;
            }
        }
        public FrameElementFamily FrameSectionFamily
        {
            get { return _family; }

        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; ; }
        }
        #endregion

        #region Constructors
        public RigidLink()
        {

        }
        public RigidLink(Node startNode, Node endNode, FrameElementFamily family) : base(startNode, endNode)
        {
            _family = family;
            SetRenderPolygon();
        }
        #endregion

        #region Methods
        public virtual void SetRenderPolygon()
        {
            _renderPolygon = GetRectangular(_startNode.Point, _endNode.Point, RenderOptions.linkedsRadius * RenderOptions.NodesRadius);
        }
        public virtual void Render()
        {
            if ((object)RenderPolygon == null)
                return;
            GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.linkColor);
            RenderPolygon(_renderPolygon);
        }
        public virtual bool HitTest(Point2D Hitpoint)
        {
            if ((object)RenderPolygon == null)
                return false;
            return RenderPolygon.EnclosesPoint(Hitpoint);
        }
        public virtual ObjectProperties GetProperties()
        {
            return new RigidLinkProperties(this);
        }
        public void RenderDeformation(int loadcase, int index)
        {
            GL.Color4(RenderOptions.initStessColor);
            RenderOptions.Vertex2(_startNode.GetDeformedPoint(loadcase, index));
            RenderOptions.Vertex2(_endNode.GetDeformedPoint(loadcase, index));
        }
        public void RenderModeShape(int index, double Factor)
        {
            GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.linkColor);
            RenderOptions.Vertex2(_startNode.GetDeformedPoint(index, Factor));
            RenderOptions.Vertex2(_endNode.GetDeformedPoint(index, Factor));
        }
        #endregion
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(RegularTrussElement))]
    [KnownType(typeof(PlasticHinge))]
    public abstract class TrussElement : TwoNodesElement
    {
        #region Members
        [DataMember]
        protected List<List<double>> _forces = new List<List<double>>();
        [DataMember]
        protected List<List<double>> _deformations = new List<List<double>>();
        #endregion

        #region Properties
        public List<List<double>> Forces
        {
            get { return _forces; }
            set { _forces = value; }
        }
        public List<List<double>> Deformations
        {
            get { return _deformations; }
            set { _deformations = value; }
        }
        #endregion

        #region Constructors
        public TrussElement()
        {

        }
        public TrussElement(Node startNode, Node endNode, SectionFamily section) : base(startNode, endNode)
        {
            _startNode = startNode;
            _endNode = endNode;
        }
        #endregion

        #region Methods
        internal void ClearRunResullts()
        {
            _forces.Clear();
            _deformations.Clear();
        }
        internal virtual void AddAccumlativeResults(int loadCases, int k, bool srss)
        {
            AddAccumlativeStrain(loadCases, k, srss);
            AddAccumlativeForce(loadCases, k, srss);
        }
        internal virtual void AddAccumlativeStrain(int loadCases, int k, bool srss)
        {
            List<double> strainList = new List<double>();
            if (srss)
            {
                for (int i = 0; i < k; i++)
                {
                    List<double> temp = new List<double>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_deformations[j][i]);
                    }
                    strainList.Add(Element2d.SRSS(temp));
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    List<double> temp = new List<double>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_deformations[j][i]);
                    }
                    strainList.Add(temp.Max());
                }
            }
            _deformations.Add(strainList);
        }
        internal virtual void AddAccumlativeForce(int loadCases, int k, bool srss)
        {
            List<double> forcesList = new List<double>();
            if (srss)
            {
                for (int i = 0; i < k; i++)
                {
                    List<double> temp = new List<double>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_forces[j][i]);
                    }
                    forcesList.Add(Element2d.SRSS(temp));
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    List<double> temp = new List<double>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_forces[j][i]);
                    }
                    forcesList.Add(temp.Max());
                }
            }
            _forces.Add(forcesList);
        }
        #endregion
    }

    [DataContract(IsReference = true)]
    public class RegularTrussElement : TrussElement
    {
        #region Members
        [DataMember]
        protected RectangleSection _section;
        [DataMember]
        protected PlateFamily _plateFamily;
        #endregion

        #region Properties
        public RectangleSection Section
        {
            get { return _section; }
        }
        public PlateFamily PlateFamily
        {
            get { return _plateFamily; }
        }
        #endregion

        #region Constructors
        public RegularTrussElement()
        {

        }
        public RegularTrussElement(Node startNode, Node endNode, PlateFamily PlateFamily, RectangleSection section) : base(startNode, endNode, PlateFamily)
        {
            _section = section;
            _plateFamily = PlateFamily;
        }
        #endregion

        #region Methods
        internal override void RenderDeformation(int loadcase, int index)
        {
            GL.Begin(PrimitiveType.Quads);

            Color c = RenderOptions.initStessColor;
            if (_deformations.Any() && _deformations[loadcase].Any())
            {
                c = _plateFamily.Material.GetColorByStrain(_deformations[loadcase][index]/GetLength());
            }
            GL.Color4(c);
            RenderPolygon(GetRectangular(_startNode.GetDeformedPoint(loadcase, index), _endNode.GetDeformedPoint(loadcase, index), GetDeformedviewerThickness()));
            GL.End();
        }
        #endregion

    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(Column))]
    [KnownType(typeof(Beam))]
    public class RegularFrameElement : Element2d, IFrameElement, IPolygonRenderable
    {
        #region Members
        [DataMember]
        protected List<Node> _nodes = new List<Node>();
        [DataMember]
        protected List<FrameTwoNodesElement> _childs = new List<FrameTwoNodesElement>();
        [DataMember]
        protected List<PlasticHinge> _plasticHinges = new List<PlasticHinge>();
        [DataMember]
        protected FrameSectionGroup _group;
        protected Polygon2D _renderPolygon;
        [DataMember]
        protected bool _selected;
        [DataMember]
        protected List<ForcesRange> _valuesRanges = new List<ForcesRange>();
        [DataMember]
        protected RotSpring _startHinge;
        [DataMember]
        protected RotSpring _endHinge;
        [DataMember]
        protected FEM_Axe _line;
        #endregion

        #region Properties
        public List<Node> Nodes
        {
            get { return _nodes; }
        }
        public List<FrameTwoNodesElement> Childs
        {
            get { return _childs; }
            set { _childs = value; }
        }
        public List<PlasticHinge> PlasticHinges
        {
            get { return _plasticHinges; }
            set { _plasticHinges = value; }
        }
        public FrameElementFamily Family
        {
            get { return _group.FrameSection; }
        }
        public FrameSectionGroup Group
        {
            get { return _group; }
            set { _group = value; }
        }
        public Polygon2D RenderPolygon
        {
            get
            {
                if ((object)_renderPolygon == null)
                    SetRenderPolygon();
                return _renderPolygon;
            }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public List<ForcesRange> ValuesRanges
        {
            get { return _valuesRanges; }
            set { _valuesRanges = value; }
        }
        public RotSpring StartHinge
        {
            get { return _startHinge; }
            set { _startHinge = value; }
        }
        public RotSpring EndHinge
        {
            get { return _endHinge; }
            set { _endHinge = value; }
        }
        #endregion

        #region Constructors
        public RegularFrameElement()
        {

        }
        public RegularFrameElement(List<Node> Nodes, FEM_Axe line, FrameSectionGroup Group) : base(++LastID)
        {
            _nodes = Nodes;
            _group = Group;
            _line = line;
            SetRenderPolygon();
        }

        #endregion

        #region Methods
        public void CreateRotsprings()
        {
            int n = _nodes.Count;
            if (n < 4)
                return;
            _startHinge = new RotSpring(_nodes[0], _nodes[1], Family);
            _endHinge = new RotSpring(_nodes[n - 1], _nodes[n - 2], Family);  //order  to priorty
            _nodes = _nodes.GetRange(1, n - 2);
        }
        public void AddPlasticHingesToList(List<PlasticHinge> list)
        {
            if (_plasticHinges == null)
                return;
            if (!_plasticHinges.Any())
                return;
            list.AddRange(_plasticHinges);
        }
        public void SetValuesRange(int loadCase)
        {
            _childs.ForEach(x => _valuesRanges[loadCase].Set(loadCase, x));
        }
        public bool IsValidToCutRigidZones(double StartAdjDepth, double endAdjDepth)
        {
            MainNode Start = _nodes.First() as MainNode;
            if (Start == null)
                return false;

            MainNode end = _nodes.Last() as MainNode;
            if (end == null)
                return false;

            double depth = Family.Section.D;

            FrameTwoNodesElement startChild = _childs.FirstOrDefault(x => x.StartNode.Point.DistanceTo(Start.Point) < 1e-9);
            if (startChild == null || startChild.Representation != PlasticHingeApproach.None)
                return false;
            if (startChild.GetLength() < 0.5 * (depth + StartAdjDepth))
                return false;

            FrameTwoNodesElement endChild = _childs.FirstOrDefault(x => x.EndNode.Point.DistanceTo(end.Point) < 1e-9);
            if (endChild == null || endChild.Representation != PlasticHingeApproach.None)
                return false;
            if (endChild.GetLength() < 0.5 * (depth + endAdjDepth))
                return false;

            return true;
        }
        public void CreateRigidZones(double StartAdjDepth, double endAdjDepth)
        {
            MainNode start = _nodes.First() as MainNode;
            MainNode end = _nodes.Last() as MainNode;
            Vector2D vec = (end.Point - start.Point).Normalize();
            Node node = null;
            if (StartAdjDepth > 1e-9)
            {
                node = _line.AddNode(start.Point + 0.5 * StartAdjDepth * vec);
                FrameTwoNodesElement startChild = _childs.FirstOrDefault(x => x.StartNode.Point.DistanceTo(start.Point) < 1e-9);
                startChild.StartNode = node;
                start.ConnectedRigidElements.Add(new FrameTwoNodesElement(start, node, Family, PlasticHingeApproach.None));
            }
            if (endAdjDepth > 1e-9)
            {
                node = _line.AddNode(end.Point - 0.5 * endAdjDepth * vec);
                FrameTwoNodesElement endChild = _childs.FirstOrDefault(x => x.EndNode.Point.DistanceTo(end.Point) < 1e-9);
                endChild.EndNode = node;
                end.ConnectedRigidElements.Add(new FrameTwoNodesElement(node, end, Family, PlasticHingeApproach.None));
            }
        }
        public void ClearRunResullts()
        {
            ValuesRanges = new List<ForcesRange>();
            _childs.ForEach(x => x.ClearRunResullts());
            _plasticHinges.ForEach(x => x.ClearRunResullts());
        }
        public void CreateDefaultChild(PlasticHingeApproach option)
        {
            _childs.Add(new FrameTwoNodesElement(_nodes.First(), _nodes.Last(), Family, option));
        }
        public virtual void SetRenderPolygon()
        {
            _renderPolygon = GetRectangular(_nodes.First().Point, _nodes.Last().Point, RenderOptions.FramesRadius * RenderOptions.NodesRadius);
        }
        public virtual void Render()
        {
            if ((object)RenderPolygon == null)
                return;
            RenderPolygon(_renderPolygon);
        }
        public virtual bool HitTest(Point2D Hitpoint)
        {
            if ((object)RenderPolygon == null)
                return false;
            return RenderPolygon.EnclosesPoint(Hitpoint);
        }
        public virtual ObjectProperties GetProperties()
        {
            return new RegularFrameElementProperties(this, "Frame");
        }
        public virtual void RenderDiagram(DiagramHandler handler, DiagramType type, int loadCase, int index)
        {
            Point2D start = _nodes.First().Point;
            Point2D end = _nodes.Last().Point;
            Vector2D direction = (end.ToVector2D() - start.ToVector2D()).Normalize();
            Vector2D prep = direction.Rotate(Angle.FromDegrees(90));
            _childs.ForEach(x => x.RenderDiagram(prep, handler, type, loadCase, index));
        }
        public override void UpdateIDReference()
        {
            base.UpdateIDReference();
            _startHinge?.UpdateIDReference();
            _endHinge?.UpdateIDReference();
            _childs.ForEach(x => x.UpdateIDReference());
            _plasticHinges.ForEach(x => x.UpdateIDReference());
        }
        public virtual void RenderDeformation(int loadcase, int index)
        {
            _childs.ForEach(x => x.RenderDeformed(loadcase, index, this));
            _plasticHinges.ForEach(x => x.RenderDeformation(loadcase, index));
            
        }
        public virtual void RenderModeShape(int index, double Factor)
        {

        }
        protected void RenderModeShape(int index, double Factor, Color c)
        {
            _childs.ForEach(x => x.RenderModeShape(index, Factor, _selected ? RenderOptions.SelectedColor : c));
        }
        public List<IPlasticElement> GetPlasticityElements()
        {
            return _group.NumericalModel.GetPlasticElements(this);
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class Column : RegularFrameElement
    {
        #region Constructors
        public Column()
        {

        }
        
        public Column(List<Node> Nodes, FEM_Axe line, FrameSectionGroup Group) :base(Nodes, line,Group)
        {

        }
        #endregion

        #region Methods
        public override void Render()
        {
            GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.ColumnColor);
            base.Render();
        }
        public override ObjectProperties GetProperties()
        {
            return new ColumnProperties(this);
        }
        public override void RenderDeformation(int loadcase, int index)
        {
            base.RenderDeformation(loadcase, index);
        }
        public override void RenderModeShape(int index, double Factor)
        {
            base.RenderModeShape(index,Factor , RenderOptions.ColumnColor);
        }
        #endregion

    }
    [DataContract(IsReference = true)]
    public class Beam : RegularFrameElement
    {
        #region Constructors
        public Beam()
        {

        }
        public Beam(List<Node> Nodes, FEM_Axe line, FrameSectionGroup Group) : base( Nodes , line, Group)
        {

        }
        #endregion

        #region Methods
        public override void Render()
        {
            GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.BeamColor);
            base.Render();
        }
        public override ObjectProperties GetProperties()
        {
            return new BeamProperties(this);
        }

        public override void RenderDeformation(int loadcase, int index )
        {
            base.RenderDeformation(loadcase, index);
        }
        public override void RenderModeShape(int index, double Factor)
        {
            base.RenderModeShape(index, Factor , RenderOptions.BeamColor);
        }
        #endregion
    }
    [DataContract]
    public class ValueRange
    {
        #region members
        [DataMember]
        protected double _minValue = double.MaxValue;
        [DataMember]
        protected double _maxValue = double.MinValue;
        #endregion

        #region Properties
        public double MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        } 
        public double MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }
        #endregion

        #region Constructors
        public ValueRange()
        {

        }
        #endregion

        #region Methods
        public void Set(ValueRange other)
        {
            _minValue = Math.Min(_minValue,other._minValue);
            _maxValue = Math.Max(_maxValue,other._maxValue);
        }
        public void Set(IEnumerable<double> values)
        {
            _minValue = Math.Min(_minValue, values.Min());
            _maxValue = Math.Max(_maxValue, values.Max());
        }
        public void Scale(double t)
        {
            double scale = (_maxValue - _minValue) * t;
            _minValue -= scale;
            _maxValue += scale;
        }
        public static ValueRange GetInstance(IEnumerable<double> values)
        {
            ValueRange range = new ValueRange();
            range.Set(values);
            return range;
        }

        public double GetRatio(double value)
        {
            return (value - _minValue) / (_maxValue - _minValue);
        }
        public static ValueRange ByRange(ValueRange range ,double t )
        {
            ValueRange result = new ValueRange();
            result.Set(range);
            result.Scale(t);
            return result;
        }
        #endregion

    }
    [DataContract]
    public class ForcesRange
    {
        #region Members
        [DataMember]
        protected ValueRange _xDisplacement = new ValueRange();
        [DataMember]
        protected ValueRange _yDisplacement = new ValueRange();
        [DataMember]
        protected ValueRange _NF = new ValueRange();
        [DataMember]
        protected ValueRange _SF = new ValueRange();
        [DataMember]
        protected ValueRange _FM = new ValueRange();
        #endregion

        #region Properties
        public ValueRange XDisplacement
        {
            get { return _xDisplacement; }
            set { _xDisplacement = value; }
        } 
        public ValueRange YDisplacement
        {
            get { return _yDisplacement; }
            set { _yDisplacement = value; }
        }
        public ValueRange NF
        {
            get { return _NF; }
            set { _NF = value; }
        }
        public ValueRange SF
        {
            get { return _SF; }
            set { _SF = value; }
        }
        public ValueRange FM
        {
            get { return _FM; }
            set { _FM = value; }
        }
        #endregion

        #region Constructors
        public ForcesRange()
        {

        }
        #endregion

        #region Methods
        public void Set(ForcesRange other)
        {
            _xDisplacement.Set(other._xDisplacement);
            _yDisplacement.Set(other._yDisplacement);
            _NF.Set(other._NF);
            _SF.Set(other._SF);
            _FM.Set(other._FM);
        }
        public void Set(int loadCase , FrameTwoNodesElement element)
        {
            List<NodeDeformation> deformations = element.StartNode.Deformations[loadCase].Concat(element.EndNode.Deformations[loadCase]).ToList();
            List<double> values = deformations.Select(x => x.Dx).ToList();
            _xDisplacement.Set(values);
            values = deformations.Select(x => x.Dy).ToList();
            _yDisplacement.Set(values);

            List<SectionLocalForces> sectionForces = element.StartSectionForces[loadCase].Concat(element.EndSectionForces[loadCase]).ToList();
            values = sectionForces.Select(x => x.Nf).ToList();
            _NF.Set(values);
            values = sectionForces.Select(x => x.Sf).ToList();
            _SF.Set(values);
            values = sectionForces.Select(x => x.FM).ToList();
            _FM.Set(values);
        }
        #endregion

    }

}
