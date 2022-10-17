using BasicModel;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver.Model
{
    [DataContract]
    public class ReferenceLine
    {
        #region Members
        [DataMember]
        protected FEM_Axe _Axe;
        [DataMember]
        protected Line2D _lineSegemnt;
        [DataMember]
        protected List<Point2D> _midPoints = new List<Point2D>();
        #endregion

        #region Properties
        public FEM_Axe Axe
        {
            get { return _Axe; }
            set { _Axe = value; }
        }
        public Line2D LineSegemnt
        {
            get { return _lineSegemnt; }
            set { _lineSegemnt = value; }
        }
        public List<Point2D> MidPoints
        {
            get { return _midPoints; }
            set { _midPoints = value; }
        } 
        #endregion

        #region Constructors
        public ReferenceLine()
        {

        }
        public ReferenceLine(FEM_Axe axe, Line2D lineSegemnt, double space)
        {
            _Axe = axe;
            _lineSegemnt = lineSegemnt;
            CreateMidPoints(space);
        }
        #endregion

        #region Methods
        private void CreateMidPoints(double space)
        {
            Vector2D vec = _lineSegemnt.Direction;
            double step = space;
            double length = _lineSegemnt.Length - 0.1 * space;
            while (step < length)
            {
                _midPoints.Add(_lineSegemnt.StartPoint + step * vec);
                step += space;
            }
        }
        #endregion

    }
    [DataContract]
    public class Corrner
    {
        #region Members
        [DataMember]
        protected ReferenceLine _line1;
        [DataMember]
        protected ReferenceLine _line2;
        [DataMember]
        protected List<Node> _midNodes = new List<Node>();
        #endregion

        #region Properties
        public ReferenceLine Line1
        {
            get { return _line1; }
            set { _line1 = value; }
        }
        public ReferenceLine Line2
        {
            get { return _line2; }
            set { _line2 = value; }
        }
        public List<Node> MidNodes
        {
            get { return _midNodes; }
            set { _midNodes = value; }
        }
        #endregion

        #region Constructors
        public Corrner()
        {

        }
        public Corrner(ReferenceLine line1, ReferenceLine line2)
        {
            _line1 = line1;
            _line2 = line2;
            CreateMidPoints();
        }
        #endregion

        #region Methods
        private void CreateMidPoints()
        {
            _line1.MidPoints.ForEach(x =>MidNodes.Add(_line1.Axe.AddNode(x)));
            _line2.MidPoints.ForEach(x => MidNodes.Add(_line2.Axe.AddNode(x)));
            Point2D cornerNode = GetCornerPoint();
            _midNodes.Add(_line1.Axe.AddNode(cornerNode));
        }
        public Node GetNode(Point2D point, Vector2D lengthVector)
        {
            Point2D? point1 = GetIntersectedPoint(_line1.LineSegemnt,point,lengthVector);
            if (point1 != null)
            {
               return Line1.Axe.AddNode(point1.Value);
            }
            point1 = GetIntersectedPoint(_line2.LineSegemnt, point, lengthVector);
            if (point1 != null)
            {
               return Line2.Axe.AddNode(point1.Value);
            }
            return null;
        }
        public static Point2D GetIntersectPoint(Point2D point, Vector2D lengthVector, Corrner corrner)
        {
            Point2D? point1 = GetIntersectedPoint(corrner._line1.LineSegemnt, point, lengthVector);
            if (point1 != null)
            {
                return point1.Value;
            }
            point1 = GetIntersectedPoint(corrner._line2.LineSegemnt, point, lengthVector);
            if (point1 != null)
            {
                return point1.Value;
            }
            return point;
        }
        public Point2D GetCornerPoint()
        {
             return _line1.LineSegemnt.IntersectWith(_line2.LineSegemnt).Value;
        }
        public static Point2D? GetIntersectedPoint(Line2D lineSegment, Point2D point, Vector2D lengthVector)
        {
            Point2D? result = lineSegment.IntersectWith(new Line2D(point,point+lengthVector));
            if (result != null)
            {
                if (lineSegment.ClosestPointTo(result.Value,true).Equals(result.Value, 0.00001))
                {
                    return result;
                }
            }
            return null;
        }
        #endregion
    }
    [DataContract]
    [KnownType(typeof(CrossTrussesGroup))]
    public abstract class VirtualTrussesGroup
    {
        #region Members
        [DataMember]
        protected double _trussesSpace;
        [DataMember]
        protected Angle _verticalAngle;
        [DataMember]
        protected Point2D _centerPoint;
        [DataMember]
        protected ReferenceLine _top;
        [DataMember]
        protected ReferenceLine _bottom;
        [DataMember]
        protected ReferenceLine _left;
        [DataMember]
        protected ReferenceLine _right;
        [DataMember]
        protected List<RegularTrussElement> _trusses = new List<RegularTrussElement>();
        #endregion

        #region Properties
        public double TrussesSpace
        {
            get { return _trussesSpace; }
            set { _trussesSpace = value; }
        }
        public Angle VerticalAngle
        {
            get { return _verticalAngle; }
            set { _verticalAngle = value; }
        }
        public Point2D CenterPoint
        {
            get { return _centerPoint; }
            set { _centerPoint = value; }
        }
        public ReferenceLine Top
        {
            get { return _top; }
            set { _top = value; }
        }
        public ReferenceLine Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }
        public ReferenceLine Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public ReferenceLine Right
        {
            get { return _right; }
            set { _right = value; }
        }
        public List<RegularTrussElement> Trusses
        {
            get { return _trusses; }
            set { _trusses = value; }
        }
        #endregion

        #region Constructors
        protected VirtualTrussesGroup()
        {

        }
        #endregion

        #region methods
        public virtual void AppendTrussess(PlateFamily trussSec, RectangleSection section , ReferenceLine top, ReferenceLine bottom, ReferenceLine left, ReferenceLine right )
        {

        }
        protected void AddTrusses(PlateFamily SecFamily, RectangleSection section, Vector2D lengthVector, Corrner Top, Corrner Bottom)
        {

            List<Node> copy = new List<Node>(Top.MidNodes);
            foreach (Node node1 in Bottom.MidNodes)
            {
                Node node2 = copy.FirstOrDefault(x => lengthVector.IsParallelTo(x.Point - node1.Point));
                if (node2 == null)
                    continue;
                RegularTrussElement truss = new RegularTrussElement(node1, node2, SecFamily, section);
                copy.Remove(node2);
                _trusses.Add(truss);
            }
        }
        
        public static VirtualTrussesGroup CreateTrussGroup(double space, PlateFamily trussSec, RectangleSection section, Angle verticalAngle
          , Point2D centerPoint, ReferenceLine top, ReferenceLine bottom, ReferenceLine left, ReferenceLine right)
        {
            VirtualTrussesGroup instance = null;
            
            instance = new CrossTrussesGroup();
            instance._trussesSpace = space;
            instance._verticalAngle = verticalAngle;
            instance._centerPoint = centerPoint;
            instance._top = top;
            instance._right = right;
            instance._left = left;
            instance._bottom = bottom;
            instance.AppendTrussess(trussSec, section, top, bottom, left, right);
            return instance;
        }
        #endregion


    }
    [DataContract]
    public class CrossTrussesGroup : VirtualTrussesGroup
    {
        public CrossTrussesGroup()
        {

        }
        public override void AppendTrussess(PlateFamily trussSec, RectangleSection section, ReferenceLine top, ReferenceLine bottom, ReferenceLine left, ReferenceLine right)
        {
            Vector2D positive = Vector2D.FromPolar(1.00,Angle.FromDegrees(90-VerticalAngle.Degrees));
            Vector2D Negative = Vector2D.FromPolar(1.00, Angle.FromDegrees(90 + VerticalAngle.Degrees));
            Corrner topRight = new Corrner(top, right);
            Corrner bottomLeft = new Corrner(bottom, left);
            Corrner topLeft = new Corrner(top, left);
            Corrner BottomRight = new Corrner(bottom, right);
            AddTrusses(trussSec, section, positive, topRight, bottomLeft);
            AddTrusses(trussSec, section, Negative, topLeft, BottomRight);
        }
    }
}
