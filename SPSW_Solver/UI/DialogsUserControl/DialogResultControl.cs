using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SPSW_Solver.Model;

namespace SPSW_Solver
{
    public partial class DialogResultControl : DialogBaseControl
    {
        public MainFrm ParentFrm { get; set; }
        public Action ScaleChanged { get; set; }

        public static int CurrentLoadCase { get; set; } = 0;
        public DialogResultControl(MainFrm parentFrm)
        {
            this.ParentFrm = parentFrm;
            InitializeComponent();
        }

        private void Default_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Default_Rbt.Checked)
            {
                scaleTB.Enabled = FPS_TB.Enabled = false;
                ParentFrm.InitializeTheViewer();
                ParentFrm.StopTimer();
                panel1.Refresh();
            }
        }
        private void Deformation_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Deformation_Rbt.Checked)
            {
                scaleTB.Enabled = FPS_TB.Enabled = true;
                ParentFrm.InitializeDeformationViewer();
                ParentFrm.StartInimation(Model.TimeSteps[CurrentLoadCase].Count - 1);
                panel1.Refresh();
            }
        }
        private void FPS_TB_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(FPS_TB.Text, out value) && value > 0)
            {
                value = Math.Min(value, RenderOptions.maxFPS);
                ParentFrm.timer1.Interval = 100 / value;
            }
            else
            {
                FPS_TB.Text = (100 / ParentFrm.timer1.Interval).ToString();
            }
        }
        private void DialogResultControl_Load(object sender, EventArgs e)
        {
            FPS_TB.Text = (100 / ParentFrm.timer1.Interval).ToString();
            scaleTB.Text = RenderOptions.DeformationRatio.ToString();
            Default_Rbt.Checked = true;
            CurrentLoadCase = 0;
            loadCaseControl1.SetMain(this.Model, () =>
            {
                CurrentLoadCase = loadCaseControl1.CurrentLoadCase;
                ParentFrm.StopTimer();
                Default_Rbt_CheckedChanged(null,null);
                Deformation_Rbt_CheckedChanged(null, null);
                N_Rbt_CheckedChanged(null, null);
                SF_Rbt_CheckedChanged(null, null);
                FM_Rbt_CheckedChanged(null, null);
            });
        }
        private void ScaleTB_TextChanged(object sender, EventArgs e)
        {
            double value;
            if (double.TryParse(scaleTB.Text, out value) && value>= AnalysisParameters.Tolerance)
            {
                RenderOptions.DeformationRatio = value;
                ScaleChanged();
            }
        }
        private void N_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (N_Rbt.Checked)
            {
                scaleTB.Enabled = FPS_TB.Enabled = true;
                ParentFrm.InitializeNFDViewer();
                ParentFrm.StartInimation(Model.TimeSteps[CurrentLoadCase].Count - 1);
                panel1.Refresh();
            }
        }
        private void SF_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if(SF_Rbt.Checked)
            {
                scaleTB.Enabled = FPS_TB.Enabled = true;
                ParentFrm.InitializeSFDViewer();
                ParentFrm.StartInimation(Model.TimeSteps[CurrentLoadCase].Count - 1);
                panel1.Refresh();
            }
        }
        private void FM_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if(FM_Rbt.Checked)
            {
                scaleTB.Enabled = FPS_TB.Enabled = true;
                ParentFrm.InitializeBMDViewer();
                ParentFrm.StartInimation(Model.TimeSteps[CurrentLoadCase].Count - 1);
                panel1.Refresh();
            }
        }
        public override bool ValidateInput()
        {
            return true;
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            var g= e.Graphics;
            DiagramHandler h = ParentFrm.GetScaleHandler();
            if (h == null)
            {
                MinV_Lb.Visible = MaxV_Lb.Visible = false;
            }
            else
            {

                MinV_Lb.Text = Math.Round(h.Range.MinValue, 4).ToString();
                MaxV_Lb.Text = Math.Round(h.Range.MaxValue, 4).ToString();
                MinV_Lb.Visible = MaxV_Lb.Visible = true;

                LinearGradientBrush pthGrBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, panel1.Height), Color.Red, Color.Blue);
                g.FillRectangle(pthGrBrush, 30, 0, 40, panel1.Height);
            }
        }
        private void PushOver_btn_Click(object sender, EventArgs e)
        {
            PushOver_btn.Enabled = false;
            PushOverCurvefrm frm = new PushOverCurvefrm(Model, Model.SupportsNodes);
            frm.ShowDialog();
            PushOver_btn.Enabled = true;
        }
    }
}
