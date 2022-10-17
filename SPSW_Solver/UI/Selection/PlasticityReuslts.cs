using BasicModel;
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
    public partial class PlasticityReuslts : Form
    {
        public int CurrentLoadCase { get; set; } = 0;
        public RegularFrameElement FrameElement { get; set; }
        protected SPSW_Simple_Model Model { get; set; }
        public List<IPlasticElement> Elements { get; set; }
        public PlasticityReuslts(SPSW_Simple_Model model, RegularFrameElement frameElement)
        {
            Model = model;
            FrameElement = frameElement;
            InitializeComponent();
        }
        private void PlasticityReuslts_Load(object sender, EventArgs e)
        {
            this.loadCaseControl1.SetMain(this.Model, () =>
            {
                CurrentLoadCase = this.loadCaseControl1.CurrentLoadCase;
                ComboBox1_SelectedIndexChanged(null, null);
            });

            Elements = FrameElement.GetPlasticityElements();
            comboBox1.DataSource = Elements.Select(x =>x.GetRelativeLocation(FrameElement)).ToList();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurve(Elements[comboBox1.SelectedIndex]);
        }
        private void UpdateCurve(IPlasticElement element)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.GraphPane.Title.Text = "Moment - Rotation";
            zedGraphControl1.GraphPane.XAxis.Title.Text ="Rotation - radians";
            string ytext = "Moment";
            
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Moment";
            List<double> xvalues = element.GetRotaions(CurrentLoadCase);
            List<double> yvalues = element.GetMoment(CurrentLoadCase);
            int count = Math.Min(xvalues.Count , yvalues.Count);
            PointPairList list = new PointPairList();
            for (int i = 0; i < count; i++)
            {
                list.Add(new PointPair(xvalues[i], yvalues[i]));
            }
            zedGraphControl1.GraphPane.AddCurve("", list, Color.Red, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void Export_btn_Click(object sender, EventArgs e)
        {
            RenderOptions.ExportToExcel(zedGraphControl1);
            
        }

        
    }
}
