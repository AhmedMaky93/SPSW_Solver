using BasicModel;
using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SPSW_Solver.UI.Selection
{
    public partial class FrameElementResultfrm : Form
    {
        public ElementGraphHandler GraphHandler { get; set; }
        public FrameElementResultfrm(RegularFrameElement Element)
        {
            InitializeComponent();
            GraphHandler = ElementGraphHandlerFactory.GetInstance(Element, this.zedGraphControl1);
        }
       
        private void StopAnimation()
        {
            GraphHandler.Running = false;
            this.button1.BackgroundImage =Properties.Resources.start;
            trackBar1.Value = GraphHandler.CurrentIndex;
        }
        private void StartAnimation()
        {
            int n = ObjectProperties.CurrentModel.TimeSteps[GraphHandler.CurrentLoadCase].Count;
            if (GraphHandler.CurrentIndex == n - 1)
                GraphHandler.CurrentIndex = 0;

            this.button1.BackgroundImage =Properties.Resources.pause;
            GraphHandler.Running = true;

        }
        private void Check(object sender, EventArgs e)
        {
            if (GraphHandler.Running)
            {
                GraphHandler.Next();
                trackBar1.Value = GraphHandler.CurrentIndex;
                if (!GraphHandler.Running)
                {
                    StopAnimation();
                }
            }
        }
        private void FrameElementResultfrm_Load(object sender, EventArgs e)
        {
            FPS_TB.Text = (100 / timer1.Interval).ToString();
            zedGraphControl1.GraphPane.XAxis.Title.Text = "";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "";
            zedGraphControl1.GraphPane.Title.Text = "0.0";
            zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = false;
            zedGraphControl1.GraphPane.XAxis.Scale.MinAuto = false;
            zedGraphControl1.GraphPane.YAxis.Scale.MaxAuto = false;
            zedGraphControl1.GraphPane.YAxis.Scale.MinAuto = false;
            Deformation_Rbt.Checked = true;
            trackBar1.Maximum = ObjectProperties.CurrentModel.TimeSteps[GraphHandler.CurrentLoadCase].Count - 1;
            timer1.Start();

            this.loadCaseControl1.SetMain(ObjectProperties.CurrentModel, () => 
            {
                GraphHandler.CurrentLoadCase = loadCaseControl1.CurrentLoadCase;
                StopAnimation();
                trackBar1.Maximum = ObjectProperties.CurrentModel.TimeSteps[GraphHandler.CurrentLoadCase].Count - 1;
                Deformation_Rbt_CheckedChanged(null,null);
                NormalForces_Rbt_CheckedChanged(null,null);
                Moment_Rbt_CheckedChanged(null,null);
                ShearForces_Rb_CheckedChanged(null,null);
            });
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(FPS_TB.Text, out value) && value > 0)
            {
                value = Math.Min(value, RenderOptions.maxFPS);
                timer1.Interval = 100/ value;
            }
            else
            {
                FPS_TB.Text = (100/ timer1.Interval).ToString();
            }

        }
        private void Deformation_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Deformation_Rbt.Checked)
            {
                StopAnimation();
                GraphHandler.CurrentGraph = ElementGraphs.deformations;
                GraphHandler?.Refresh();
            }
        }
        private void NormalForces_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (NormalForces_Rbt.Checked)
            {
                StopAnimation();
                GraphHandler.CurrentGraph = ElementGraphs.NormalForces;
                GraphHandler?.Refresh();
            }

        }
        private void Moment_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Moment_Rbt.Checked)
            {
                StopAnimation();
                GraphHandler.CurrentGraph = ElementGraphs.Moment;
                GraphHandler?.Refresh();
            }

        }
        private void ShearForces_Rb_CheckedChanged(object sender, EventArgs e)
        {
            if (ShearForces_Rb.Checked)
            {
                StopAnimation();
                GraphHandler.CurrentGraph = ElementGraphs.ShearForces;
                GraphHandler?.Refresh();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (GraphHandler.Running)
            {
                StopAnimation();
            }
            else
            {
                StartAnimation();
            }
        }
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (GraphHandler.Running)
                timer1.Stop();
            GraphHandler.CurrentIndex = trackBar1.Value;
            GraphHandler.RefreshGraph(false);

            if (GraphHandler.Running)
                timer1.Start();
        }
    }

    public static class ElementGraphHandlerFactory
    {
        public static ElementGraphHandler GetInstance(RegularFrameElement Element, ZedGraphControl control)
        {
            if (Element is Beam)
            {
                return new BeamGraphHandler(Element as Beam, control);
            }
            else if (Element is Column)
            {
                return new ColumnGraphHandler(Element as Column, control);
            }
            else
            {
                return null;
            }
        }

    }
    public enum ElementGraphs
    {
        deformations,
        NormalForces,
        ShearForces,
        Moment
    }
    public abstract class ElementGraphHandler
    {
        public ZedGraphControl Control { get; protected set; }
        public RegularFrameElement Element { get; protected set; }
        public Point2D Center { get; protected set; }
        public int CurrentLoadCase { get; set; } = 0;
        public int CurrentIndex { get; set; } = 0;
        public CurveList CurrentList { get; set; } = new CurveList();
        public ElementGraphs CurrentGraph { get; set; }
        public bool Running { get; set; } = false;
        public List<double> values { get; set; } = new List<double>();
        public ElementGraphHandler(RegularFrameElement Element , ZedGraphControl control)
        {
            this.Element = Element;
            this.Control = control;
            SetMainPoints();
        }
        public virtual void Next()
        {
            int n = ObjectProperties.CurrentModel.TimeSteps[CurrentLoadCase].Count;
            if (CurrentIndex == n - 1)
                Running = false;
            if(Running)
            {
                RefreshGraph(true);
            }
        }

        public virtual void RefreshGraph(bool increment)
        {
            CurrentList.ForEach(x => Control.GraphPane.CurveList.Remove(x));
            CurrentList.Clear();
            if (increment)
            {
                CurrentIndex++;
            }
            Control.GraphPane.Title.Text = ObjectProperties.CurrentModel.TimeSteps[CurrentLoadCase][CurrentIndex].ToString();
            DrawCurrentRecord();
            Control.AxisChange();
            Control.Refresh();
        }
        protected virtual void DrawCurrentRecord()
        {
            PointPairList mainCurve = new PointPairList();
            Point2D start = Element.Nodes.First().Point;
            var orderedChilds = Element.Childs.OrderBy(x =>x.StartNode.Point.DistanceTo(start)).ToList();
            for (int i = 0; i < orderedChilds.Count; i++)
            {
                double v1;
                double v2;
                GetValue(orderedChilds[i], out v1, out v2);
                DrawValue(Transform(orderedChilds[i].StartNode.Point),v1 , mainCurve);
                DrawValue(Transform(orderedChilds[i].EndNode.Point),v2,mainCurve);
            }
            CurrentList.Add( Control.GraphPane.AddCurve("", mainCurve, Color.Red, SymbolType.None));
        }

        protected virtual void DrawValue(Point2D point, double v2 , PointPairList mainCurve)
        {
        }

        protected virtual void GetValue(FrameTwoNodesElement frameTwoNodesElement, out double v1, out double v2)
        {
            v1 = v2 = 0;
        }

        protected Point2D Transform(Point2D p)
        {
            return new Point2D(p.X - Center.X, p.Y - Center.Y);
        }
        protected virtual void SetMainPoints()
        {
            Point2D start = Element.Nodes.First().Point;
            Point2D end = Element.Nodes.Last().Point;
            this.Center = new Point2D(0.5*(start.X+end.X),0.5*(start.Y + end.Y));
        }
        protected virtual void DrawMainElement()
        {
            PointPairList list = new PointPairList();
            Point2D start = Element.Nodes.First().Point;
            Point2D end = Element.Nodes.Last().Point;
            start = Transform(start);
            end = Transform(end);
            list.Add(new PointPair(start.X, start.Y));
            list.Add(new PointPair(end.X, end.Y));
            Control.GraphPane.AddCurve("", list, Color.Black, SymbolType.None);
            Control.AxisChange();
            Control.Refresh();
        }
        protected virtual void Clear()
        {
            Running = false;
            Control.GraphPane?.CurveList?.Clear();
            this.CurrentList.Clear();
            this.CurrentIndex = 0;
            Control.GraphPane.Title.Text = "0.0";
        }
        public void Refresh()
        {
            Clear();
            SetGraphBoundary();
            DrawMainElement();
        }

        protected void SetGraphBoundary()
        {
            ValueRange xR = GetXRange();
            ValueRange yR = GetYRange();
            xR.Scale(0.1);
            yR.Scale(0.1);
            Control.GraphPane.XAxis.Scale.Max = xR.MaxValue;
            Control.GraphPane.XAxis.Scale.Min = xR.MinValue;
            Control.GraphPane.YAxis.Scale.Max = yR.MaxValue;
            Control.GraphPane.YAxis.Scale.Min = yR.MinValue;
            Control.AxisChange();
            Control.Refresh();
        }

        protected virtual ValueRange GetYRange()
        {
            return null;
        }
        protected virtual ValueRange GetXRange()
        {
            return null;
        }
    }
    public class BeamGraphHandler : ElementGraphHandler
    {
        public Beam Beam { get { return Element as Beam; } }
        public BeamGraphHandler(Beam Beam , ZedGraphControl control) :base(Beam, control)
        {

        }
        protected override ValueRange GetYRange()
        {
            ValueRange range = null;
            switch (this.CurrentGraph)
            {
                case ElementGraphs.deformations:
                    range = Element.ValuesRanges[CurrentLoadCase].YDisplacement;
                    break;
                case ElementGraphs.NormalForces:
                    range = Element.ValuesRanges[CurrentLoadCase].NF;
                    break;
                case ElementGraphs.ShearForces:
                    range = Element.ValuesRanges[CurrentLoadCase].SF;
                    break;
                case ElementGraphs.Moment:
                    range = Element.ValuesRanges[CurrentLoadCase].FM;
                    break;
                default:
                    break;
            }
            return range;
        }
        protected override ValueRange GetXRange()
        {
            Point2D start = Element.Nodes.First().Point;
            Point2D end = Element.Nodes.Last().Point;
            double x1 = Transform(start).X;
            double x2 = Transform(end).X;
            return ValueRange.GetInstance(new double[] {x1,x2 });
        }

        protected override void DrawValue(Point2D point, double v2 , PointPairList mainCurve)
        {
            PointPairList list = new PointPairList();
            list.Add(new PointPair(point.X,point.Y));
            PointPair p = new PointPair(point.X, point.Y + v2);
            list.Add(p);
            mainCurve.Add(p);
            CurrentList.Add(Control.GraphPane.AddCurve("", list, Color.Red, SymbolType.None));
        }

        protected override void GetValue(FrameTwoNodesElement frameTwoNodesElement, out double v1, out double v2)
        {
            v1 = v2 = 0;
            try
            {
                switch (this.CurrentGraph)
                {
                    case ElementGraphs.deformations:
                        v1 = frameTwoNodesElement.StartNode.Deformations[CurrentLoadCase][CurrentIndex].Dy;
                        v2 = frameTwoNodesElement.EndNode.Deformations[CurrentLoadCase][CurrentIndex].Dy;
                        break;
                    case ElementGraphs.NormalForces:
                        v1 = frameTwoNodesElement.StartSectionForces[CurrentLoadCase][CurrentIndex].Nf;
                        v2 = frameTwoNodesElement.EndSectionForces[CurrentLoadCase][CurrentIndex].Nf;
                        break;
                    case ElementGraphs.ShearForces:
                        v1 = frameTwoNodesElement.StartSectionForces[CurrentLoadCase][CurrentIndex].Sf;
                        v2 = frameTwoNodesElement.EndSectionForces[CurrentLoadCase][CurrentIndex].Sf;
                        break;
                    case ElementGraphs.Moment:
                        v1 = frameTwoNodesElement.StartSectionForces[CurrentLoadCase][CurrentIndex].FM;
                        v2 = frameTwoNodesElement.EndSectionForces[CurrentLoadCase][CurrentIndex].FM;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
            }
        }
    }
    public class ColumnGraphHandler : ElementGraphHandler
    {
        public Column Column { get { return Element as Column; } }
        public ColumnGraphHandler(Column column, ZedGraphControl control) :base(column, control)
        {
             
        }
        protected override ValueRange GetXRange()
        {
            ValueRange range = null;
            switch (this.CurrentGraph)
            {
                case ElementGraphs.deformations:
                    range = Element.ValuesRanges[CurrentLoadCase].XDisplacement;
                    break;
                case ElementGraphs.NormalForces:
                    range = Element.ValuesRanges[CurrentLoadCase].NF;
                    break;
                case ElementGraphs.ShearForces:
                    range = Element.ValuesRanges[CurrentLoadCase].SF;
                    break;
                case ElementGraphs.Moment:
                    range = Element.ValuesRanges[CurrentLoadCase].FM;
                    break;
                default:
                    break;
            }
            return range;
        }
        protected override ValueRange GetYRange()
        {
            Point2D start = Element.Nodes.First().Point;
            Point2D end = Element.Nodes.Last().Point;
            double y1 = Transform(start).Y;
            double y2 = Transform(end).Y;
            return ValueRange.GetInstance(new double[] { y1, y2 });
        }
        protected override void DrawValue(Point2D point, double v2 , PointPairList mainCurve)
        {
            PointPairList list = new PointPairList();
            list.Add(new PointPair(point.X, point.Y));
            PointPair p = new PointPair(point.X+v2, point.Y);
            list.Add(p);
            mainCurve.Add(p);
            CurrentList.Add(Control.GraphPane.AddCurve("", list, Color.Red, SymbolType.None));

        }
        protected override void GetValue(FrameTwoNodesElement frameTwoNodesElement, out double v1, out double v2)
        {
            v1 = v2 = 0;
            switch (this.CurrentGraph)
            {
                case ElementGraphs.deformations:
                    v1 = frameTwoNodesElement.StartNode.Deformations[CurrentLoadCase][CurrentIndex].Dx;
                    v2 = frameTwoNodesElement.EndNode.Deformations[CurrentLoadCase][CurrentIndex].Dx;
                    break;
                case ElementGraphs.NormalForces:
                    v1 = frameTwoNodesElement.StartSectionForces[CurrentLoadCase][CurrentIndex].Nf;
                    v2 = frameTwoNodesElement.EndSectionForces[CurrentLoadCase][CurrentIndex].Nf;
                    break;
                case ElementGraphs.ShearForces:
                    v1 = frameTwoNodesElement.StartSectionForces[CurrentLoadCase][CurrentIndex].Sf;
                    v2 = frameTwoNodesElement.EndSectionForces[CurrentLoadCase][CurrentIndex].Sf;
                    break;
                case ElementGraphs.Moment:
                    v1 = frameTwoNodesElement.StartSectionForces[CurrentLoadCase][CurrentIndex].FM;
                    v2 = frameTwoNodesElement.EndSectionForces[CurrentLoadCase][CurrentIndex].FM;
                    break;
                default:
                    break;
            }
        }
    }
}
