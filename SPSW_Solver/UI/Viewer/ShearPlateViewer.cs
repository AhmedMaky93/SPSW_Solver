using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.Model;
using MathNet.Spatial.Euclidean;
using OpenTK.Graphics.OpenGL;
using SPSW_Solver.UI.Selection;
using BasicModel;
using MathNet.Spatial.Units;
using SPSW_Solver.BasicModel;

namespace SPSW_Solver
{
    public partial class ShearPlateViewer : BasicViewer
    {
        public SPBey ShearPlate { get; set; }
        protected Point2D Transform { get; set; }
        public List<UITruss> Trusses { get; set; } = new List<UITruss>();

        public ShearPlateViewer(SPBey ShearPlate)
        {
            this.ShearPlate = ShearPlate;
            InitializeComponent();
            SetTransform();
            CreateUITrusses(Transform);
        }

        private void SetTransform()
        {
            Transform = new Point2D(
                0.5*( ShearPlate.GetLeft().Distance + ShearPlate.GetRight().Distance ),
                0.5*( ShearPlate.GetTopLevel().Elevation + ShearPlate.GetBottomLevel().Elevation) );
        }

        private void CreateUITrusses(Point2D transform)
        {
            Trusses.Clear();
            ShearPlate.TrussGroup.Trusses.ForEach(x => Trusses.Add(new UITruss(x,Transform)));
        }

        protected override void Viewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearSelectionReference();

            Point2D point = convertScreenToWorldCoords(e.X, e.Y);
            foreach (var truss in Trusses)
            {
                if (truss.HitTest(point))
                {
                    SelectObject(truss);
                    return;
                }
            }
            

        }

        public override float GetModelWidth()
        {
            return (float)( ShearPlate.GetBeyWidth() *(1+ SPSW_Simple_Model.Margin));
        }
        public override float GetModelHeight()
        {
            return (float)(ShearPlate.GetBeyHeight() *(1+ SPSW_Simple_Model.Margin));
        }

        protected override void DrawElements()
        {
            DrawGridLines();
            DrawTrusses();
            DrawPlateBoundary();
        }

        private void DrawTrusses()
        {
            GL.Begin(PrimitiveType.Quads);
            Trusses.ForEach(x =>x.Render());
            GL.End();
        }

        private Point2D TransformPoint(Point2D p)
        {
            return new Point2D(
                p.X-Transform.X,
                p.Y-Transform.Y
                );
        }
        private void DrawPlateBoundary()
        {
            int n = ShearPlate.RenderPolygon.VertexCount;
            var vertices = ShearPlate.RenderPolygon.Vertices.ToList();
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(RenderOptions.NodesColor);
            double thick  = RenderOptions.linkedsRadius * RenderOptions.NodesRadius;
            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;

                Point2D start = TransformPoint(vertices[i]);
                Point2D end = TransformPoint(vertices[j]);
                Vector2D direction = (end.ToVector2D() - start.ToVector2D()).Normalize();
                Vector2D prep = direction.Rotate(Angle.FromDegrees(90));
                prep *= thick;
                var frameVertices = new List<Point2D>()
                {
                    start + prep,
                    end + prep,
                    end- prep,
                    start - prep,
                };
                frameVertices.ForEach(x => RenderOptions.Vertex2(x));
            }
            GL.End();

            for (int i = 0; i < n; i++)
            {
                MainNode.RenderCircularNode(TransformPoint(vertices[i]), RenderOptions.NodesColor);
            }
        }

        private void DrawGridLines()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(RenderOptions.GirdLinesColor);

            Level[] levels = new Level[] { ShearPlate.GetTopLevel() , ShearPlate.GetBottomLevel() };
            foreach (var level in levels)
            {
                RenderOptions.Vertex2(new Point2D(minX,level.Elevation - Transform.Y));
                RenderOptions.Vertex2(new Point2D(maxX,level.Elevation - Transform.Y));
            }

            VerticalLine[] lines = new VerticalLine[] {ShearPlate.GetLeft() , ShearPlate.GetRight() };
            foreach (var line in lines)
            {
                RenderOptions.Vertex2(new Point2D(line.Distance-Transform.X, minY));
                RenderOptions.Vertex2(new Point2D(line.Distance-Transform.X, maxY));
            }
            GL.End();
        }
    }
    public class UITruss : IPolygonRenderable
    {
        public RegularTrussElement Element { get; protected set; }
        public Polygon2D RenderPolygon { get; protected set; }
        public bool Selected { get; set; }
        public static double NodeRatio = 0.25;
        public UITruss(RegularTrussElement truss , Point2D transform)
        {
            Element = truss;
            SetRenderPolygon(transform);
        }

        public virtual void SetRenderPolygon( Point2D transform)
        {
            Point2D start = Element.StartNode.Point;
            start = new Point2D(start.X-transform.X,start.Y-transform.Y);
            Point2D end = Element.EndNode.Point;
            end = new Point2D(end.X - transform.X, end.Y - transform.Y);
            double thick = NodeRatio * RenderOptions.NodesRadius;
            RenderPolygon = Element2d.GetRectangular(start,end,thick);
        }
        public virtual void Render()
        {
            GL.Color4(Selected ? RenderOptions.SelectedColor : RenderOptions.TrussesColor);
            Element2d.RenderPolygon(RenderPolygon);
        }

        public virtual bool HitTest(Point2D Hitpoint)
        {

            if (RenderPolygon.EnclosesPoint(Hitpoint))
                return true;
            foreach (LineSegment2D line in RenderPolygon.Edges)
            {
                if (line.ClosestPointTo(Hitpoint).DistanceTo(Hitpoint) < NodeRatio * RenderOptions.NodesRadius)
                    return true;
            }
            return false;
        }

        public virtual ObjectProperties GetProperties()
        {
            return null;
        }

        public void RenderDeformation(int loadCase ,int index)
        {
        }
    }
}
