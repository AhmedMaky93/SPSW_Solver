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

namespace SPSW_Solver.UI.Selection
{
    public partial class NodesGraphsFrm : Form
    {
        public int CurrentLoadCase { get; protected set; } = 0;
        public MainNode Node { get; protected set; }
        public NodesGraphsFrm(MainNode node)
        {
            InitializeComponent();
            this.Node = node;
        }
        private void DrawGraphResult(string title, List<double> yValues)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.Title.Text = title;
            zedGraphControl1.GraphPane.YAxis.Title.Text = title ;
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Time(seconds)";

            PointPairList list = new PointPairList();
            List<double> xvalues = ObjectProperties.CurrentModel.TimeSteps[CurrentLoadCase];
            for (int i = 0; i < xvalues.Count; i++)
            {
                list.Add(new PointPair(xvalues[i],yValues[i]));
            }
            //zedGraphControl1.ZoomPane();
            zedGraphControl1.GraphPane.AddCurve(title,list,Color.Red, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        private void NodesGraphsFrm_Load(object sender, EventArgs e)
        {
            Reaction_label.Visible = Rx_rbt.Visible =
            Ry_rbt.Visible = M_rbt.Visible = (this.Node is SupportsMainNode);
            Dx_rbt.Checked = true;
            this.loadCaseControl1.SetMain(ObjectProperties.CurrentModel, () => 
            {
                this.CurrentLoadCase = loadCaseControl1.CurrentLoadCase;
                Dx_rbt_CheckedChanged(null,null);
                Dy_rbt_CheckedChanged(null,null);
                R_rbt_CheckedChanged(null,null);
                Rx_rbt_CheckedChanged(null,null);
                Ry_rbt_CheckedChanged(null,null);
                M_rbt_CheckedChanged(null,null);
            });
        }

        private void Dx_rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Dx_rbt.Checked)
            {
                DrawGraphResult(Dx_rbt.Text , Node.Deformations[CurrentLoadCase].Select(x =>x.Dx).ToList());
            }
        }
        private void Dy_rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Dy_rbt.Checked)
            {
                DrawGraphResult(Dy_rbt.Text, Node.Deformations[CurrentLoadCase].Select(x => x.Dy).ToList());
            }
        }
        private void R_rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (R_rbt.Checked)
            {
                DrawGraphResult(R_rbt.Text, Node.Deformations[CurrentLoadCase].Select(x => x.Dz).ToList());
            }
        }
        private void Rx_rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Rx_rbt.Checked)
            {
                DrawGraphResult(Rx_rbt.Text, (Node as SupportsMainNode).Reactions[CurrentLoadCase].Select(x => x.Rx).ToList());
            }
        }
        private void Ry_rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Ry_rbt.Checked)
            {
                DrawGraphResult(Ry_rbt.Text, (Node as SupportsMainNode).Reactions[CurrentLoadCase].Select(x => x.Ry).ToList());
            }
        }
        private void M_rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (M_rbt.Checked)
            {
                DrawGraphResult(M_rbt.Text, (Node as SupportsMainNode).Reactions[CurrentLoadCase].Select(x => x.Mz).ToList());
            }
        }
    }

    
}
