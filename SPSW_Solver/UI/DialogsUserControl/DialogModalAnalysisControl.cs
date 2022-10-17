using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.PythonTranslator;
using System.Threading;
using SPSW_Solver.Model;

namespace SPSW_Solver
{
    public partial class DialogModalAnalysisControl : DialogBaseControl
    {
        public MainFrm ParentFrm { get; set; }
        public Action ScaleChanged { get; set; }
        public static int CurrentModeShape { get; set; } = 1;
        public Action SaveFile { get; set; }
        public DialogModalAnalysisControl(MainFrm parentFrm, SolverAanalysisOptions options)
        {
            this.ParentFrm = parentFrm;
            InitializeComponent();
            CurrentModeShape = 1;
            dialogSolvingOptions1.InitValues(options);
        }

        public override bool SetData()
        {
            return true;
        }
        public override bool ValidateInput()
        {
            return this.Model.ModalSolved;
        }

        private void ClearAnalysis()
        {
            ParentFrm.StopTimer();
            Run_Button.BackgroundImage = Properties.Resources.play_button__1_;
            Model.ClearModalAnalysisRun();
            modeShapes_TB.Enabled = true;
            groupBox2.Visible = false;
            SaveFile();
        }
        private void Run_Button_Click(object sender, EventArgs e)
        {

            if ( (!Model.ModalSolved) && dialogSolvingOptions1.ValidateAndSetData() && TrySetModeShapesValue() && RunModalAnalysis())
            {
                AnalysisCompleted();
            }
            else
            {

                ClearAnalysis();
            }
        }

        private void AnalysisCompleted()
        {
            modeShapes_TB.Enabled = false;
            groupBox2.Visible = true;
            Run_Button.BackgroundImage = Properties.Resources._lock;
            Default_Rbt.Checked = true;
        }
        private bool RunModalAnalysis()
        {
            modeShapes_TB.Enabled = false;
            if (!OpenSeesTranslator.CreateInputFileModalAnalysis(Model))
            {
                RunFailed();
                return false;
            }
            if (!OpenSeesTranslator.Run())
            {
                RunFailed();
                return false;
            }
            if (!OpenSeesTranslator.ReadModalAnalysisOutPut(Model))
            {
                RunFailed();
                return false;
            }
            Fail_Lb.Visible = false; 
            OpenSeesTranslator.ClearAnalysisFolder();
            this.Model.ModalSolved = true;
            SaveFile();
            return true;
        }

        private void RunFailed()
        {
            groupBox2.Visible = false;
            Fail_Lb.Visible = true; 
            this.Model.Solved = false;
        }

        private void ModeShapes_TB_TextChanged(object sender, EventArgs e)
        {
            TrySetModeShapesValue();
        }

        private bool TrySetModeShapesValue()
        {
            ModeShapes_VLB.Text = "";
            int max = Model.FreeLevels;
            string ErrorMessage = string.Format("Must be a value from 1 to {0}", max);
            int value;
            if ((!int.TryParse(modeShapes_TB.Text, out value)) || value < 1 || value > max)
            {
                ModeShapes_VLB.Text = ErrorMessage;
                return false;
            }
            Model.ModeShapes = value;
            return true;
        }

        private void DialogModalAnalysisControl_Load(object sender, EventArgs e)
        {
            modeShapes_TB.Text = Model.ModeShapes.ToString();
            ModeShape_LB.Text = CurrentModeShape.ToString();
            scaleTB.Text = RenderOptions.DeformationRatio.ToString();
            FPS_TB.Text = (100 / ParentFrm.timer1.Interval).ToString();

            if (Model.ModalSolved && TrySetModeShapesValue())
            {
                AnalysisCompleted();
            }
            else
            {
                ClearAnalysis();
            }
        }

        private void Default_Rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (Default_Rbt.Checked)
            {
                nxt_btn.Enabled = back_btn.Enabled = scaleTB.Enabled = FPS_TB.Enabled = false;
                ParentFrm.InitializeTheViewer();
                ParentFrm.StopTimer();
            }
        }
        private void Model_Shapes_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Model_Shapes_Rbtn.Checked)
            {
                ModeShape_LB.Text = CurrentModeShape.ToString();
                nxt_btn.Enabled = back_btn.Enabled = scaleTB.Enabled = FPS_TB.Enabled = true;
                ParentFrm.InitializeModeShapeViewer();
                ParentFrm.StartInimation(ModelShapeViewer.TimeCount);
            }
        }
        private void Nxt_btn_Click(object sender, EventArgs e)
        {
            if (CurrentModeShape < Model.ModeShapes)
            {
                CurrentModeShape++;
                Model_Shapes_Rbtn_CheckedChanged(null, null);
            }
        }
        private void Back_btn_Click(object sender, EventArgs e)
        {
            if (CurrentModeShape > 1)
            {
                CurrentModeShape--;
                Model_Shapes_Rbtn_CheckedChanged(null, null);
            }
        }
        private void ScaleTB_TextChanged(object sender, EventArgs e)
        {
            double value;
            if (double.TryParse(scaleTB.Text, out value) && value >= 1e-9)
            {
                RenderOptions.DeformationRatio = value;
                ScaleChanged();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            ModalAnalysisReportFrm frm = new ModalAnalysisReportFrm(Model.ModalData);
            button1.Enabled = false;
            frm.ShowDialog();
            button1.Enabled = true;
        }
    }
}
