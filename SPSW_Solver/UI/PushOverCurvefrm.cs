using BasicModel;
using MathNet.Spatial.Euclidean;
using SPSW_Solver.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SPSW_Solver
{
    public partial class PushOverCurvefrm : Form
    {
        public int CurrentLoadCase { get; set; } = 0;
        protected SPSW_Simple_Model Model { get; set; }
        public List<SupportsMainNode> supportNodes { get; set; } = new List<SupportsMainNode>();
        
        public int floor = 1;
        public PushOverCurvefrm(SPSW_Simple_Model Model, List<SupportsMainNode> supportNodes)
        {
            this.Model = Model;
            this.supportNodes = supportNodes;
            InitializeComponent();
            Story_TB.Text = floor.ToString();
        }

        private void UpdateCurve(int floor)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.GraphPane.Title.Text = "Pushover curve";
            string xText = floor > 0 ? string.Format("{0}-Storey drift", floor) : "Roof displacement";
            string ytext = "Base Shear" ;
            zedGraphControl1.GraphPane.XAxis.Title.Text = xText;
            zedGraphControl1.GraphPane.YAxis.Title.Text = ytext;
            int fi = Model.BaseProperties.GetFirstBeamLevelIndex();
            groupBox2.Visible = false;
            List<Point2D> points = new List<Point2D>();
            int count = 0;
            if (floor > 0)
            {
                MainNode mainMode =  Model.Levels[floor + fi].GetFirstLeftNode();
                MainNode subMode =  Model.Levels[floor + fi-1].GetFirstLeftNode();
                double LevelHeight = (mainMode.Point.Y - subMode.Point.Y);
                count = mainMode.Deformations[CurrentLoadCase].Count;
                for (int i = 0; i < count; i++)
                {
                    points.Add(new Point2D((mainMode.Deformations[CurrentLoadCase][i].Dx - subMode.Deformations[CurrentLoadCase][i].Dx) / LevelHeight, Model.GetBaseShear(CurrentLoadCase, i)));
                }
            }
            else
            {
                MainNode mainMode =  Model.Levels.Last().GetFirstLeftNode();
                count = mainMode.Deformations[CurrentLoadCase].Count;
                for (int i = 0; i < count; i++)
                {
                    points.Add(new Point2D(mainMode.Deformations[CurrentLoadCase][i].Dx, Model.GetBaseShear(CurrentLoadCase, i)));
                }
            }

            
            PointPairList list = new PointPairList();
            for (int i = 0; i < count; i++)
            {
                list.Add(new PointPair(points[i].X, points[i].Y));
            }
            zedGraphControl1.GraphPane.AddCurve("", list, Color.Red, SymbolType.None);
            if (Model.AnalysisParameters.AnalysisMethod == AnalysisMethod.Monotonic_Pushover_Analysis)
            {
                groupBox2.Visible = true;
                double Vmax = 0.0;
                double SegmaYield = 0.0;
                double SegmaUltimate = 0.0;
                Point2D MaxV = points.OrderBy(x => x.Y).Last();
                Line2D topLine = new Line2D(new Point2D(0.0, MaxV.Y), new Point2D(points.Last().X, MaxV.Y));
                list = new PointPairList();
                list.Add(new PointPair(topLine.StartPoint.X, topLine.StartPoint.Y));
                list.Add(new PointPair(topLine.EndPoint.X, topLine.EndPoint.Y));
                Vmax = Math.Round(MaxV.Y, 4);
                zedGraphControl1.GraphPane.AddCurve(string.Format("V max =  {0}", Vmax), list, Color.Black, SymbolType.HDash);

                Line2D initLine = new Line2D(points[0], points[(int)(Math.Max(1, 0.01 * points.Count))]);
                Point2D intersect = initLine.IntersectWith(topLine).Value;
                list = new PointPairList();
                list.Add(new PointPair(points[0].X, points[0].Y));
                list.Add(new PointPair(intersect.X, intersect.Y));
                zedGraphControl1.GraphPane.AddCurve(string.Format("", Math.Round(MaxV.Y, 4)), list, Color.Black, SymbolType.HDash);

                list = new PointPairList();
                list.Add(new PointPair(intersect.X, 0));
                list.Add(new PointPair(intersect.X, intersect.Y));
                SegmaYield = Math.Round(intersect.X, 4);
                zedGraphControl1.GraphPane.AddCurve(string.Format(string.Format("δy,eff = {0}", SegmaYield)), list, Color.Black, SymbolType.HDash);

                Line2D Vmax2Line = topLine;
                int index = points.IndexOf(MaxV);
                double y = MaxV.Y;
                intersect = points.Last();
                if (index < count - 1)
                {
                    var PlasticCurve = points.GetRange(index, points.Count - index);
                    y = Math.Max(PlasticCurve.Min(x => x.Y), 0.8 * MaxV.Y);
                    Vmax2Line = new Line2D(new Point2D(0.0, y), new Point2D(intersect.X, y));
                    list = new PointPairList();
                    list.Add(new PointPair(Vmax2Line.StartPoint.X, Vmax2Line.StartPoint.Y));
                    list.Add(new PointPair(Vmax2Line.EndPoint.X, Vmax2Line.EndPoint.Y));
                    zedGraphControl1.GraphPane.AddCurve(string.Format(string.Format("{0} V max = {1}", Math.Round(y / MaxV.Y, 2), Math.Round(y, 4))), list, Color.Black, SymbolType.HDash);
                    for (int i = 0; i < PlasticCurve.Count - 1; i++)
                    {
                        Line2D curveSegement = new Line2D(PlasticCurve[i], PlasticCurve[i + 1]);
                        var point = Vmax2Line.IntersectWith(curveSegement);
                        if (point != null && curveSegement.ClosestPointTo(point.Value, true).DistanceTo(point.Value) < 1e-9)
                        {
                            intersect = point.Value;
                            break;
                        }
                    }
                }
                list = new PointPairList();
                list.Add(new PointPair(intersect.X, 0));
                list.Add(new PointPair(intersect.X, intersect.Y));
                SegmaUltimate = Math.Round(intersect.X, 4);
                zedGraphControl1.GraphPane.AddCurve(string.Format(string.Format("δu = {0}", SegmaUltimate)), list, Color.Black, SymbolType.HDash);

                Cs_LB.Text = Math.Round(Model.AnalysisParameters.SpectralResponse.Cs, 4).ToString();
                R_LB.Text = Math.Round(Model.AnalysisParameters.SpectralResponse.R, 4).ToString();
                W_LB.Text = Math.Round(Model.GetTotalWeight(), 4).ToString();
                Vd_LB.Text = Math.Round(Model.GetDesginBaseShear(), 4).ToString();
                Omega_LB.Text = Math.Round(Vmax / Model.GetDesginBaseShear(), 4).ToString();
                Meu_LB.Text = Math.Round(SegmaUltimate / SegmaYield, 4).ToString();

            }
            else if (Model.AnalysisParameters.AnalysisMethod == AnalysisMethod.Cyclic_Pushover)
            {
                List<PointPair> specials = new List<PointPair>();
                var temp = list.OrderBy(x => x.X).ToList();
                specials.Add(temp.First());
                specials.Add(temp.Last());
                temp.Clear();
                temp = list.OrderBy(x => x.Y).ToList();
                specials.Add(temp.First());
                specials.Add(temp.Last());
                temp.Clear();
                specials.Distinct();
                const double offset = 0.8;
                specials.ForEach(pt =>
                { 
                TextObj text = new TextObj(string.Format("({0},{1})",Math.Round(pt.X, 4), Math.Round(pt.Y,4)), pt.X, pt.Y + offset, CoordType.AxisXYScale, AlignH.Left, AlignV.Center);
                text.ZOrder = ZOrder.A_InFront;
                text.FontSpec.Border.IsVisible = false;
                text.FontSpec.Fill.IsVisible = false;
                text.FontSpec.Fill = new Fill(Color.FromArgb(100, Color.White));
                zedGraphControl1.GraphPane.GraphObjList.Add(text);
                });
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        private void PushOverCurvefrm_Load(object sender, EventArgs e)
        {
            Displacement_Btn.Checked = true;
            this.loadCaseControl1.SetMain(this.Model, () => 
            {
                CurrentLoadCase = this.loadCaseControl1.CurrentLoadCase;
                Displacement_Btn_CheckedChanged(null,null);
                Drift_btn_CheckedChanged(null,null);
            });
        }
        private void Displacement_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Displacement_Btn.Checked)
            {
                Story_TB.Visible = false;
                UpdateCurve(0);
            }
        }
        private void Drift_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Drift_btn.Checked)
            {
                Story_TB.Visible = true;
                UpdateCurve(floor);
            }
        }
        
        
        private void Story_TB_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(Story_TB.Text,out value) && value > 0 && value <= Model.Layout.FloorNo)
            {
                floor = value;
                Displacement_Btn_CheckedChanged(null, null);
                Drift_btn_CheckedChanged(null, null);
            }
        }
        private void Export_btn_Click(object sender, EventArgs e)
        {
            RenderOptions.ExportToExcel(zedGraphControl1);
        }
      
    }

}
