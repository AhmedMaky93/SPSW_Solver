using MathNet.Spatial.Euclidean;
using SPSW_Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SPSW_Solver.UI.Selection;
using System.Drawing;
using System.Runtime.Serialization;
using SPSW_Solver.Model;
using SPSW_Solver.BasicModel;
using MathNet.Spatial.Units;

namespace BasicModel
{
    public interface IFEMELement
    {
        int ID
        {
            get;
        }
    }
    public enum SupportType
    {
          Hinged,
          Fixed
    }

    [DataContract]
    public class Node2DFixingCondition
    {
        #region Members
        [DataMember]
        protected bool _fix_X = false;
        [DataMember]
        protected bool _fix_Y = false;
        [DataMember]
        protected bool _fix_XY_Rotation = false;
        #endregion

        #region Properties
        public bool Fix_X
        {
            get { return _fix_X; }
        } 
        public bool Fix_Y
        {
            get { return _fix_Y; }
        }
        public bool Fix_XY_Rotation
        {
            get { return _fix_XY_Rotation; }
        }
        #endregion

        #region Constructors
        public Node2DFixingCondition()
        {

        }
        public Node2DFixingCondition(bool fixX, bool fixY, bool fixXYRotation)
        {
            _fix_X = fixX;
            _fix_Y = fixY;
            _fix_XY_Rotation = fixXYRotation;
        }
        #endregion

        #region Methods
        public int[] ToVector()
        {
            int[] vector = new int[3];

            vector[0] = _fix_X ? 1 : 0;
            vector[1] = _fix_Y ? 1 : 0;
            vector[2] = _fix_XY_Rotation ? 1 : 0;
            return vector;
        }
        public static Node2DFixingCondition GetSupportbytype(SupportType type)
        {
            Node2DFixingCondition result = null;
            switch (type)
            {
                case SupportType.Hinged:
                    result = new Node2DFixingCondition(true, true, false);
                    break;
                case SupportType.Fixed:
                    result = new Node2DFixingCondition(true, true, true);
                    break;
                default:
                    break;
            }
            return result;
        }
        #endregion

    }
    [DataContract(IsReference = true)]
    [KnownType(typeof(SecondaryNode))]
    [KnownType(typeof(MainNode))]
    [KnownType(typeof(SupportsMainNode))]
    public abstract class Node : IFEMELement
    {
        #region Static Members
        public static int LastID = 1;
        #endregion

        #region Members
        [DataMember]
        protected Point2D _point;
        [DataMember]
        protected int _ID;
        [DataMember]
        protected List<List<NodeDeformation>> _deformations = new List<List<NodeDeformation>>();
        [DataMember]
        protected List<NodeDeformation> _modeShapesDeformations = new List<NodeDeformation>();
        #endregion

        #region Properties
        public Point2D Point
        { get { return _point; } }
        public List<List<NodeDeformation>> Deformations
        {
            get { return _deformations; }
            set { _deformations = value; }
        }
        public List<NodeDeformation> ModeShapesDeformations
        {
            get { return _modeShapesDeformations; }
            set { _modeShapesDeformations = value; }
        }
        public int ID
        { get { return _ID; } }
        #endregion

        #region Constructor
        protected Node()
        {
            _ID = LastID;
            LastID++;
        }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return _ID; 
        }
        public Point2D GetDeformedPoint(int loadCase , int index )
        {
           return new Point2D(_point.X + _deformations[loadCase][index].Dx * RenderOptions.DeformationRatio,
                            _point.Y + _deformations[loadCase][index].Dy * RenderOptions.DeformationRatio);
        }
        public Point2D GetDeformedPoint(int modeShape,double factor)
        {
            return new Point2D(_point.X + _modeShapesDeformations[modeShape].Dx * factor* RenderOptions.DeformationRatio,
                             _point.Y + _modeShapesDeformations[modeShape].Dy * factor* RenderOptions.DeformationRatio);
        }

        internal void AddAccumlativeNodeDeformation(int loadCases, int k, bool srss)
        {
            List<NodeDeformation> deformationList = new List<NodeDeformation>();
            if (srss)
            {
                for (int i = 0; i < k; i++)
                {
                    List<NodeDeformation> temp = new List<NodeDeformation>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_deformations[j][i]);
                    }
                    deformationList.Add(NodeDeformation.SRSS(temp));
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    List<NodeDeformation> temp = new List<NodeDeformation>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_deformations[j][i]);
                    }
                    deformationList.Add(NodeDeformation.Peak(temp));
                }
            }
            _deformations.Add(deformationList);
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class SupportsMainNode : MainNode, IPolygonRenderable
    {
        #region Members
        [DataMember]
        protected SupportType _type = SupportType.Hinged;
        [DataMember]
        protected List<List<NodeReaction>> _reactions = new List<List<NodeReaction>> ();
        protected Polygon2D _renderPolygon;
        #endregion

        #region Properties
        public SupportType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                SetRenderPolygon();
            }
        }
        public List<List<NodeReaction>> Reactions
        {
            get { return _reactions; }
            set { _reactions = value;}
        }
        public Polygon2D RenderPolygon
        {
            get
            {
                if ((object)_renderPolygon == null)
                    SetRenderPolygon();
                return _renderPolygon;
            }
            set { _renderPolygon = value; }
        }
        #endregion

        #region Constructors
        public SupportsMainNode() : base()
        {

        }
        public SupportsMainNode(Point2D point, SupportType type = SupportType.Hinged) : base(point)
        {
            _type = type;
            SetRenderPolygon();
        }
        #endregion

        #region Methods
        public override ObjectProperties GetProperties()
        {
            return new SupportingMainNodeProperties(this);
        }
        public virtual void SetRenderPolygon()
        {
            switch (_type)
            {
                case SupportType.Hinged:
                    { 
                        double NminX = _point.X - 2 * RenderOptions.NodesRadius;
                        double NmaxX = _point.X + 2 * RenderOptions.NodesRadius;
                        double NminY = _point.Y - 2 * RenderOptions.NodesRadius;
                        _renderPolygon = new Polygon2D( new List<Point2D>()
                        {
                            new Point2D(NminX, NminY),
                            new Point2D(NmaxX, NminY),
                            new Point2D(_point.X, _point.Y),
                        });
                    }
                    break;
                case SupportType.Fixed:
                    { 
                        double NminX = _point.X - 2 * RenderOptions.NodesRadius;
                        double NmaxX = _point.X + 2 * RenderOptions.NodesRadius;
                        double NminY = _point.Y - 2 * RenderOptions.NodesRadius;
                        _renderPolygon = new Polygon2D( new List<Point2D>()
                        {
                            new Point2D(NminX, _point.Y),
                            new Point2D(NminX, NminY),
                            new Point2D(NmaxX, NminY),
                            new Point2D(NmaxX, _point.Y),
                        });
                    }
                    break;
            }

        }
        public override bool HitTest(Point2D Hitpoint)
        {
            if ((object)RenderPolygon == null)
                return false;
            return RenderPolygon.EnclosesPoint(Hitpoint);
        }
        public override void Render()
        {
            if ((object)RenderPolygon == null)
                return;
            switch (_type)
            {
                case SupportType.Hinged:
                    {
                        GL.Begin(PrimitiveType.Triangles);
                        GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.NodesColor);
                        foreach (var point in _renderPolygon.Vertices)
                        {
                            RenderOptions.Vertex2(point);
                        }
                        GL.End();
                        base.Render();
                    }
                    break;
                case SupportType.Fixed:
                    {
                        GL.Begin(PrimitiveType.Quads);
                        GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.NodesColor);
                        foreach (var point in _renderPolygon.Vertices)
                        {
                            RenderOptions.Vertex2(point);
                        }
                        GL.End();
                    }
                    break;
            }
           
        }

        internal void AddAccumlativeReactions(int loadCases , int k, bool srss)
        {
            List<NodeReaction> reactionList = new List<NodeReaction>();
            if (srss)
            {
                for (int i = 0; i < k; i++)
                {
                    List<NodeReaction> temp = new List<NodeReaction>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_reactions[j][i]);
                    }
                    reactionList.Add(NodeReaction.SRSS(temp));
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    List<NodeReaction> temp = new List<NodeReaction>();
                    for (int j = 0; j < loadCases; j++)
                    {
                        temp.Add(_reactions[j][i]);
                    }
                    reactionList.Add(NodeReaction.Peak(temp));
                }
            }
            _reactions.Add(reactionList);
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    [KnownType(typeof(SupportsMainNode))]
    public class MainNode : Node, IRenderable
    {
        #region Members
        [DataMember]
        protected bool _selected = false;
        [DataMember]
        protected double _nodeMass = 0.0;
        [DataMember]
        protected LoadArrow _loadArrow;
        [DataMember]
        protected List<FrameTwoNodesElement> _connectedRigidElements = new List<FrameTwoNodesElement>();
        [DataMember]
        protected List<ForcesRange> _valuesRanges = new List<ForcesRange>();
        #endregion

        #region Properties
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public double NodeMass
        {
            get { return _nodeMass; }
            set { _nodeMass = value; ; }
        }
        public LoadArrow LoadArrow
        {
            get { return _loadArrow; }
            set { _loadArrow = value; }
        }
        public List<FrameTwoNodesElement> ConnectedRigidElements
        {
            get { return _connectedRigidElements; }
            set { _connectedRigidElements = value; }
        }
        public List<ForcesRange> ValuesRanges
        {
            get { return _valuesRanges; }
            set { _valuesRanges = value; }
        }
        #endregion

        #region Constructors
        public MainNode()
        {

        }
        public MainNode(Point2D point) : base()
        {
            _point = point;
        }
        #endregion

        public virtual ObjectProperties GetProperties()
        {
            return new MainNodeProperties(this);
        }
        public virtual bool HitTest(Point2D Hitpoint)
        {
            
            return _point.DistanceTo(Hitpoint) < RenderOptions.NodesRadius + RenderOptions.SelectionTolerance;
        }
        public void CreateLoadArrow()
        {
            _nodeMass = Math.Max(_nodeMass, AnalysisParameters.Tolerance);
            _loadArrow = new LoadArrow(this);
        }
        public virtual void ClearNodeMass()
        {
            _nodeMass = 0;
            _loadArrow = null;
        }
        public virtual void Render()
        {
            RenderCircularNode(_point, _selected ? RenderOptions.SelectedColor : RenderOptions.NodesColor);
            _loadArrow?.Render();
        }
        public void RenderConnectedElements()
        {
            _connectedRigidElements.ForEach(x => Element2d.RenderPolygon(Element2d.GetRectangular(
               x.StartNode.Point, x.EndNode.Point, RenderOptions.linkedsRadius * RenderOptions.NodesRadius)));
        }
        public static void RenderCircularNode(Point2D point , Color color , double sizefactor = 1.0)
        {
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color4(color);
            RenderOptions.Vertex2(point);
            for (double angle = 1.0f; angle < 361.0f; angle += 0.2)
            {
                double x = point.X + Math.Sin(angle) * RenderOptions.NodesRadius * sizefactor ;
                double y = point.Y + Math.Cos(angle) * RenderOptions.NodesRadius * sizefactor;
                GL.Vertex2(x, y);
            }
            GL.End();
        }
        public void SetValuesRange(int loadCase)
        {
            _connectedRigidElements.ForEach(x => _valuesRanges[loadCase].Set(loadCase, x));
        }
        public void UpdateIDReference()
        {
            if (_connectedRigidElements != null && _connectedRigidElements.Any())
            {
                Element2d.LastID = Math.Max(_connectedRigidElements.Select(t => t.ID).Max(), Element2d.LastID);
            }
        }
        public void RenderDeformation(int loadCase, int index)
        {
            _connectedRigidElements.ForEach(x => x.RenderDeformed(loadCase,index,null));
        }
        public void RenderModeShape(int modeshape , double factor)
        {
            _connectedRigidElements.ForEach(x => x.RenderModeShape(modeshape,factor , _selected ? RenderOptions.SelectedColor : RenderOptions.NodesColor));
            RenderCircularNode(GetDeformedPoint(modeshape,factor), _selected ? RenderOptions.SelectedColor : RenderOptions.NodesColor);
        }
        public virtual void RenderDiagram(DiagramHandler handler, DiagramType type, int loadCase, int index)
        {
            _connectedRigidElements.ForEach(x => {
                Point2D start = x.StartNode.Point;
                Point2D end = x.EndNode.Point;
                Vector2D direction = (end.ToVector2D() - start.ToVector2D()).Normalize();
                Vector2D prep = direction.Rotate(Angle.FromDegrees(90));
                x.RenderDiagram(prep, handler, type, loadCase, index);
                });
        }
        private double ToBaseHeightRatio(double minZ, double maxZ)
        {
            return (_point.Y - minZ) / (maxZ - minZ);
        }
       
    }
    [DataContract(IsReference = true)]
    public class SecondaryNode : Node
    {
        public SecondaryNode(Point2D point):base()
        {
            _point = point;
        }
    }
    [DataContract]
    public class NodeDeformation
    {
        #region Members
        [DataMember]
        protected double _dx;
        [DataMember]
        protected double _dy;
        [DataMember]
        protected double _dz;
        #endregion

        #region properties
        public double Dx
        { get { return _dx; } }
        public double Dy
        { get { return _dy; } }
        public double Dz
        { get { return _dz; } }
        #endregion

        #region Constructors
        public NodeDeformation()
        {

        }
        public NodeDeformation(double x, double y, double z)
        {
            _dx = x;
            _dy = y;
            _dz = z;
        }
        #endregion

        public static NodeDeformation SRSS(IEnumerable<NodeDeformation> values)
        {
            return new NodeDeformation
                (Element2d.SRSS(values.Select(x => x.Dx))
                , Element2d.SRSS(values.Select(x => x.Dy))
                , Element2d.SRSS(values.Select(x => x.Dz)));
        }
        public static NodeDeformation Peak(IEnumerable<NodeDeformation> values)
        {
            return new NodeDeformation
                (values.Select(x => x.Dx).Max()
                , values.Select(x => x.Dy).Max()
                , values.Select(x => x.Dz).Max());
        }

    }
    [DataContract]
    public class NodeReaction
    {
        #region Members
        [DataMember]
        protected double _rx;
        [DataMember]
        protected double _ry;
        [DataMember]
        protected double _mz;
        #endregion

        #region Properties
        public double Rx
        { get { return _rx; } }
        public double Ry
        { get { return _ry; } }
        public double Mz
        { get { return _mz; } }
        #endregion

        #region Constructors
        public NodeReaction()
        {

        }
        public NodeReaction(double x, double y, double z)
        {
            _rx = x;
            _ry = y;
            _mz = z;
        }
        #endregion

        public static NodeReaction SRSS(IEnumerable<NodeReaction> values)
        {
            return new NodeReaction
                (Element2d.SRSS(values.Select(x=>x.Rx))
                , Element2d.SRSS(values.Select(x => x.Ry))
                , Element2d.SRSS(values.Select(x => x.Mz)));
        }
        public static NodeReaction Peak(IEnumerable<NodeReaction> values)
        {
            return new NodeReaction
                ( values.Select(x => x.Rx).Max()
                , values.Select(x => x.Ry).Max()
                , values.Select(x => x.Mz).Max());
        }

    }
    [DataContract(IsReference = true)]
    public class LoadArrow : IRenderable
    {
        #region Members
        [DataMember]
        protected Point2D _topPoint;
        [DataMember]
        protected Point2D _nodePoint;
        [DataMember]
        protected double _value;
        [DataMember]
        protected bool _selected;
        protected Polygon2D _triangle;
        protected Polygon2D _rectangular;
        #endregion

        #region Properties
        public Point2D TopPoint
        {
            get { return _topPoint; }
        }
        public Point2D NodePoint
        {
            get { return _nodePoint; }
        }
        public Polygon2D Triangle
        {
            get
            {
                if ((object)_triangle == null)
                    CreateArrowTriangle();
                return _triangle;
            }
        }
        public Polygon2D Rectangular
        {
            get
            {
                if ((object)_rectangular == null)
                    CreateArrowRectangle();
                return _rectangular;
            }
        }
        public double Value
        {
            get { return _value; }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; ; }
        }
        #endregion

        #region Constructors
        public LoadArrow()
        {

        }
        public LoadArrow(MainNode mainNode)
        {
            _value = Math.Round(mainNode.NodeMass, 4);
            _nodePoint = mainNode.Point;
            _topPoint = new Point2D(_nodePoint.X, _nodePoint.Y + RenderOptions.LoadsArrowLength);
            CreateArrowTriangle();
            CreateArrowRectangle();
        }
        #endregion

        #region methods
        private void CreateArrowRectangle()
        {
            double thick = RenderOptions.LoadsArrowNodesRatio * RenderOptions.NodesRadius;
            double trithick = RenderOptions.LoadsArrowArrowRatio * RenderOptions.LoadsArrowLength;
            _rectangular = new Polygon2D(new List<Point2D>()
                        {
                            new Point2D(_nodePoint.X+thick, _nodePoint.Y + trithick),
                            new Point2D(_topPoint.X + thick, _topPoint.Y),
                            new Point2D(_topPoint.X-thick, _topPoint.Y),
                            new Point2D(_nodePoint.X-thick, _nodePoint.Y+ trithick),
                        });
        }
        private void CreateArrowTriangle()
        {
            double thick = RenderOptions.LoadsArrowArrowRatio * RenderOptions.LoadsArrowLength;
            _triangle = new Polygon2D(new List<Point2D>()
                        {
                            new Point2D(_nodePoint.X, _nodePoint.Y),
                            new Point2D(_nodePoint.X-thick, _nodePoint.Y + thick),
                            new Point2D(_nodePoint.X+thick, _nodePoint.Y + thick),
                        });
        }
        public ObjectProperties GetProperties()
        {
            return null;
        }
        public bool HitTest(Point2D Hitpoint)
        {
            return false;
        }
        public void Render()
        {
            if ((object)Rectangular != null)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.LoadsArrowColor);
                foreach (var point in _rectangular.Vertices)
                {
                    RenderOptions.Vertex2(point);
                }
                GL.End();
            }
            if ((object)Triangle != null)
            {
                GL.Begin(PrimitiveType.Triangles);
                GL.Color4(_selected ? RenderOptions.SelectedColor : RenderOptions.LoadsArrowColor);
                foreach (var point in _triangle.Vertices)
                {
                    RenderOptions.Vertex2(point);
                }
                GL.End();
            }

        }
        public void RenderDeformation(int loadcase ,int index)
        {
        }
        #endregion
    }
}
