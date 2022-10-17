using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SPSW_Solver.Model;
using MathNet.Spatial.Euclidean;
using System.Drawing.Drawing2D;
using System.Linq;
using BasicModel;
using System.Collections.Generic;
using MathNet.Spatial.Units;

namespace SPSW_Solver
{
    public partial class NumericalModelViewer : BasicViewer
    {
        protected FEM_Axe _mainAxe;
        protected List<FEM_Axe> _subAxes = new List<FEM_Axe>();
        protected double _sectionDepth;
        protected RegularFrameElement _element;
        protected FrameElementNumericalModel _model;

        public NumericalModelViewer()
        {
            InitializeComponent();
        }

        public void CreateMainElements(FrameElementNumericalModel model, double depth, double Length, int segments, Vector2D v)
        {
            this._model = model;
            CreateTheGrids(depth, Length, segments, v);
            model.AddIntermediateNodes(_mainAxe.LineNodes, depth , _mainAxe , depth, depth);
            _mainAxe.SortNodes();
            CreateDummyElement(depth,segments);
            RefreshEx();
        }
        private void CreateDummyElement(double depth, int segments)
        {
            _element = new RegularFrameElement(_mainAxe.LineNodes,_mainAxe
                ,new FrameSectionGroup(0,0,new FrameElementFamily("",0,null,null,IShapeSection.CreateDummySection(depth)),_model));
            foreach (var option in new PlasticHingeApproach[] { PlasticHingeApproach.None , PlasticHingeApproach.NolinearBeamColumn
                 , PlasticHingeApproach.DistrubuitedPlasticity , PlasticHingeApproach.BeamWithHinges })
            {
                _model.CreateSegments(_element, option);
            }
            if (_model is FiberPlasticSections)
            {
                (_model as FiberPlasticSections).CreatePlasticSegments(_element, depth, depth);
            }
        }
        private void CreateTheGrids(double depth, double Length, int segments, Vector2D v)
        {
            double margin = 0.1;
            Node start = null;
            Node end = null;
            double half = ( 1+ margin)*Length / 2.0;
            _mainAxe = new FEM_Axe(new Line2D((Point2D.Origin - v * half), (Point2D.Origin + v * half)));
            start = _mainAxe.AddNode(new MainNode(Point2D.Origin - v * Length / 2.0));
            end = _mainAxe.AddNode(new MainNode(Point2D.Origin + v * Length / 2.0));
            double seglength = Length / segments;
            for (int i = 1; i < segments; i++)
            {
                _mainAxe.AddNode(start.Point + v * seglength * i);
            }
            _mainAxe.SortNodes();
            Vector2D P = v.Rotate(Angle.FromDegrees(90));
            half = (1 + margin) * depth ;
            _subAxes = new List<FEM_Axe>();
            _mainAxe.LineNodes.ForEach(x => _subAxes.Add(new FEM_Axe(new Line2D((x.Point - P * half), (x.Point + P * half)))));
        }
        protected override void DrawElements()
        {
            DrawMainElement();
            DrawGridLines();
            DrawPlasticHinges();
        }
        private void DrawPlasticHinges()
        {
            double depth = _element.Family.Section.D;
            _element.PlasticHinges.ForEach(x =>
            {
                MainNode.RenderCircularNode(new Point2D(0.5 * (x.StartNode.Point.X + x.EndNode.Point.X)
                    , 0.5 * (x.StartNode.Point.Y + x.EndNode.Point.Y))
                    , Color.Green, 0.5 * depth / RenderOptions.NodesRadius);
            });
        }
        private void DrawMainElement()
        {
            GL.Begin(PrimitiveType.Quads);
            BeamWithHingesModel BWHModel = _model as BeamWithHingesModel;
            Point2D start = _element.Nodes.First().Point;
            Point2D end = _element.Nodes.Last().Point;
            double depth = _element.Family.Section.D;
            _element.Childs.ForEach(x =>
            {
                switch (x.Representation)
                {
                    case PlasticHingeApproach.None:
                        GL.Color4(Color.Blue);
                        Element2d.RenderPolygon(Element2d.GetRectangular(x.StartNode.Point, x.EndNode.Point, depth));
                        break;
                    case PlasticHingeApproach.NolinearBeamColumn:
                    case PlasticHingeApproach.DistrubuitedPlasticity:
                        GL.Color4(Color.Red);
                        Element2d.RenderPolygon(Element2d.GetRectangular(x.StartNode.Point, x.EndNode.Point, depth));
                        break;
                    case PlasticHingeApproach.BeamWithHinges:
                        double SLP;
                        double Elp;
                        Point2D start1 = x.StartNode.Point;
                        Point2D end1 = x.EndNode.Point;
                        Vector2D v = (end1 - start1).Normalize();
                        BWHModel.GetHingesDistances(x, start1.DistanceTo(start) < 1e-9, end1.DistanceTo(end) < 1e-9, out SLP, out Elp);
                        Point2D start2 = start1 + v * SLP;
                        Point2D end2 = end1 - v * Elp;
                        GL.Color4(Color.Red);
                        Element2d.RenderPolygon(Element2d.GetRectangular(start1, start2, depth));
                        Element2d.RenderPolygon(Element2d.GetRectangular(end2, end1, depth));
                        GL.Color4(Color.Blue);
                        Element2d.RenderPolygon(Element2d.GetRectangular(start2, end2, depth));
                        break;
                }
            });
              GL.Color4(Color.Green);
            _element.PlasticHinges.ForEach(x =>
            {
                Element2d.RenderPolygon(Element2d.GetRectangular(x.StartNode.Point, x.EndNode.Point, depth));
            });
            GL.End();
        }

        private void DrawGridLines()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(RenderOptions.GirdLinesColor);
            _mainAxe?.Render();
            _subAxes.ForEach(x => x.Render());
            GL.End();
        }

        public override float GetModelWidth()
        {
            if (_mainAxe == null || _element == null)
                return 10000;

            List<double> xvalues = Element2d.GetRectangular(_mainAxe.Line2D.StartPoint,
                _mainAxe.Line2D.EndPoint, 2 * _element.Family.Section.D).Vertices.Select(x =>x.X).ToList();
            return (float)((xvalues.Max()-xvalues.Min())*1.1);
        }
        public override float GetModelHeight()
        {
            if (_subAxes == null || !_subAxes.Any())
                return 10000;
            List<double> yvalues = Element2d.GetRectangular(_mainAxe.Line2D.StartPoint,
                _mainAxe.Line2D.EndPoint, 2 * _element.Family.Section.D).Vertices.Select(x => x.Y).ToList();
            return (float)((yvalues.Max() - yvalues.Min())*1.1);

        }
    }
}
