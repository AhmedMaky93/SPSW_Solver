using MathNet.Spatial.Euclidean;
using OpenTK.Graphics.ES10;
using SPSW_Solver;
using SPSW_Solver.BasicModel;
using SPSW_Solver.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicModel
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Level))]
    [KnownType(typeof(VerticalLine))]
    public class FEM_Axe  : ILineRenderable
    {
        #region StaticMembers
        public static double Tolerance = 1e-9;
        #endregion

        #region Members
        [DataMember]
        protected List<Node> _lineNodes = new List<Node>();
        [DataMember]
        protected Point2D _startPoint = new Point2D();
        [DataMember]
        protected Point2D _endPoint = new Point2D();
        [DataMember]
        protected bool _selected = false;
        #endregion

        #region Properties
        public List<Node> LineNodes
        {
            get { return _lineNodes; }
        }
        public Line2D Line2D
        {
            get { return new Line2D(_startPoint ,_endPoint); }
            set
            {
                if (value != null)
                {
                    _startPoint = value.StartPoint;
                    _endPoint = value.EndPoint;
                }
            }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        #endregion

        #region Constructors
        protected FEM_Axe()
        {

        }
        public FEM_Axe(Line2D line2D)
        {
            Line2D = line2D;
        }
        #endregion

        #region Methods
        public virtual Node GetNode(Point2D point)
        {
            return _lineNodes.FirstOrDefault(x =>x.Point.Equals(point,Tolerance));
        }
        public List<MainNode> GetMainNodes()
        { return _lineNodes.Where(x => x is MainNode).Cast<MainNode>().ToList(); }
      
        public virtual List<List<Node>> DivideByMainNodes()
        {
            List<List<Node>> result = new List<List<Node>>();
            List<MainNode> mainNodes = GetMainNodes();
            int n = mainNodes.Count - 1;
            for (int i = 0; i < n; i++)
            {
                int firstIndex = _lineNodes.IndexOf(mainNodes[i]);
                int lastIndex = _lineNodes.IndexOf(mainNodes[i+1]);
                result.Add(_lineNodes.Skip(firstIndex).Take(lastIndex-firstIndex+1).ToList());
            }
            return result;
        }
        public virtual Node AddNode(Node node)
        {
            if (_lineNodes == null)
                _lineNodes = new List<Node>();

            if (!Line2D.ClosestPointTo(node.Point,false).Equals(node.Point,Tolerance))
                return null;

            Node existNode = _lineNodes.FirstOrDefault(x => x.Point.Equals(node.Point, Tolerance));
            if (existNode != null)
            { return existNode;}

            _lineNodes.Add(node);
            return node;
        }
        public static bool IsEqualSegment(Point2D p1, Point2D p2, Node n1, Node n2)
        {
            if (p1.Equals(n1.Point, Tolerance) && p2.Equals(n2.Point, Tolerance))
                return true;
            else if (p2.Equals(n1.Point, Tolerance) && p1.Equals(n2.Point, Tolerance))
                return true;
            else
                return false;
        }
        public virtual Node AddNode(Point2D point, bool supportingNode = false)
        {
            if (_lineNodes == null)
                _lineNodes = new List<Node>();

            if (!Line2D.ClosestPointTo(point, false).Equals(point, Tolerance))
                return null;

            Node existNode = _lineNodes.FirstOrDefault(x => x.Point.Equals(point, Tolerance));
            if (existNode != null)
            { return existNode; }

            Node node = null;
            if (supportingNode)
            {
                node = new SupportsMainNode(point);
            }
            else
            {
                node = new SecondaryNode(point);
            }
                
            _lineNodes.Add(node);
            return node;
        }
        public virtual void SortNodes()
        {
            _lineNodes = _lineNodes.OrderBy(x => x.Point.DistanceTo(_startPoint)).ToList();
        }
        public void Render()
        {
            RenderOptions.Vertex2(Line2D.StartPoint);
            RenderOptions.Vertex2(Line2D.EndPoint);
        }
        public bool HitTest( Point2D Hitpoint)
        {
            return false;
        }
        public ObjectProperties GetProperties()
        {
            return null;
        }
        public virtual void RenderDeformation(int loadCase ,int index)
        {
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class Level : FEM_Axe
    {
        #region Memebers
        [DataMember]
        protected double _elevation;
        #endregion

        #region Properties
        public double Elevation
        {
            get { return _elevation; }
        }
        #endregion

        #region Constructors
        public Level()
        {

        }
        public Level(double elevation, double minX, double maxX)
        {
            _elevation = elevation;
            Line2D = new Line2D(new Point2D(minX, _elevation), new Point2D(maxX, _elevation));
        }
        #endregion

        #region Methods
        public override Node AddNode(Node node)
        {
            if (_lineNodes == null)
                _lineNodes = new List<Node>();

            if (Math.Abs(node.Point.Y - _elevation) > Tolerance)
                return null;

            Node existNode = _lineNodes.FirstOrDefault(x => Math.Abs(x.Point.X - node.Point.X) <Tolerance);
            if (existNode != null)
            { return existNode; }

            _lineNodes.Add(node);
            return node;
        }
        public override Node AddNode(Point2D point, bool supportingNode = false)
        {
            if (_lineNodes == null)
                _lineNodes = new List<Node>();

            if (Math.Abs(point.Y - _elevation) > Tolerance)
                return null;

            Node existNode = _lineNodes.FirstOrDefault(x => Math.Abs(x.Point.X - point.X) < Tolerance);
            if (existNode != null)
            { return existNode; }

            Node node = null;
            if (supportingNode)
            {
                node = new SupportsMainNode(point);
            }
            else
            {
                node = new SecondaryNode(point);
            }
            _lineNodes.Add(node);
            return node;
        }
        
        public override void SortNodes()
        {
            _lineNodes = _lineNodes.OrderBy(x => x.Point.X).ToList();
        }
        public MainNode GetFirstLeftNode()
        {
            var node = _lineNodes.FirstOrDefault(x => x is MainNode);
            return (node == null) ? null : node as MainNode;
        }

        public List<MainNode> GetMainNodes(List<VerticalLine> verticalLines)
        {
            List<MainNode> result = new List<MainNode>();
            List<MainNode> mainNodes = GetMainNodes();

            foreach (var verticalline in verticalLines)
            {
                MainNode node = mainNodes.FirstOrDefault(x=> verticalline.LineNodes.Contains(x));
                if (node == null)
                    continue;
                result.Add(node);
            }
            return result;
        }
        public  List<List<Node>> DivideByMainNodes(List<VerticalLine> verticalLines)
        {
            List<List<Node>> result = new List<List<Node>>();
            List<MainNode> mainNodes = GetMainNodes(verticalLines);
            int n = mainNodes.Count - 1;
            for (int i = 0; i < n; i++)
            {
                int firstIndex = _lineNodes.IndexOf(mainNodes[i]);
                int lastIndex = _lineNodes.IndexOf(mainNodes[i + 1]);
                result.Add(_lineNodes.Skip(firstIndex).Take(lastIndex - firstIndex + 1).ToList());
            }
            return result;
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class VerticalLine : FEM_Axe
    {
        #region Members
        [DataMember]
        protected double _distance;
        #endregion

        #region Properties
        public double Distance
        {
            get { return _distance; }
        }
        #endregion

        #region Constructors
        public VerticalLine()
        {

        }
        public VerticalLine(double distance, double minY, double maxY)
        {
            _distance = distance;
            Line2D = new Line2D(new Point2D(_distance, minY), new Point2D(_distance, maxY));
        }
        #endregion

        #region Methods
        public override Node AddNode(Node node)
        {
            if (_lineNodes == null)
                _lineNodes = new List<Node>();

            if (Math.Abs(node.Point.X - _distance) > Tolerance)
                return null; ;

            Node existNode = _lineNodes.FirstOrDefault(x => Math.Abs(x.Point.Y - node.Point.Y) < Tolerance);
            if (existNode != null)
            { return existNode; }

            _lineNodes.Add(node);
            return node;
        }
        public virtual void AddspringsHingeNodes(double lengthFactor)
        {
            DivideByMainNodes().ForEach(x => 
            {
                Node StartNode = x.First();
                Node EndNode = x.Last();
                double length = EndNode.Point.DistanceTo(StartNode.Point) * lengthFactor;
                Vector2D v = (EndNode.Point - StartNode.Point).Normalize();
                AddNode(StartNode.Point + v * length);
                AddNode(EndNode.Point - v * length);
            });
            SortNodes();
        }
        public override Node AddNode(Point2D point, bool supportingNode = false)
        {
            if (_lineNodes == null)
                _lineNodes = new List<Node>();

            if (Math.Abs(point.X - _distance) > Tolerance)
                return null; ;

            Node existNode = _lineNodes.FirstOrDefault(x => Math.Abs(x.Point.Y - point.Y) < Tolerance);
            if (existNode != null)
            { return existNode; }

            Node node = null;
            if (supportingNode)
            {
                node = new SupportsMainNode(point);
            }
            else
            {
                node = new SecondaryNode(point);
            }
            _lineNodes.Add(node);
            return node;
        }
        public override void SortNodes()
        {
            _lineNodes = _lineNodes.OrderBy(x => x.Point.Y).ToList();
        }
        #endregion

    }
}
