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
using System.IO;

namespace SPSW_Solver
{
    public partial class Time_History_ParametersControl : UserControl
    {
        public static string ErrorMessage = "Invalid Input";
        public TimeHistory_Parameters TimeHistoryParameters { get; set; }

        protected Dictionary<Integrator, string> _integratorHelper = new Dictionary<Integrator, string>();
        public int FreeLevels { get; set; }
        public Time_History_ParametersControl(TimeHistory_Parameters iDA_Parameters , int freeLevels)
        {
            TimeHistoryParameters = iDA_Parameters;
            FreeLevels = freeLevels;
            init_integratorHelper();
            InitializeComponent();
        }

        private void init_integratorHelper()
        {
            _integratorHelper.Add(Integrator.Central_Difference, "Central Difference");
            _integratorHelper.Add(Integrator.Explicit_Difference, "Explicit Difference");
            _integratorHelper.Add(Integrator.HilberHughesTaylor_Method, "Hilber Hughes Taylor");
            _integratorHelper.Add(Integrator.Newmark_Method, "NewMark");
            _integratorHelper.Add(Integrator.TRBDF2, "TRBDF2");
        }

        public bool ValidateInput()
        {

            if (TrySetTimeStepValue() && TrySetNofStepsValue()  && TrySetLoadFactor()
                && TrySetIntegratorParams() &&(TimeHistoryParameters.UseConstantDamingRatio && TrySetDampingRatio()
                || TrySetTalphaMValue() && TrySetBetaKValue() && TrySetDampingValue()))
            {
                if (!TimeHistoryParameters.GroundMotionFilePaths.Any() ||
                    TimeHistoryParameters.GroundMotionFilePaths.Any(x => string.IsNullOrEmpty(x)) )
                {
                    MessageBox.Show("No selected path for ground motion", "Ground motion file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (TimeHistoryParameters.GroundMotionFilePaths.Any(x => !File.Exists(x)) )
                {
                    MessageBox.Show("File not Found", "Ground motion file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool SetData()
        {
            return true;
        }

        private void IDA_ParametersControl_Load(object sender, EventArgs e)
        {
            NSteps_TB.Text = TimeHistoryParameters.NumberOfSteps.ToString();
            TimeStep_TB.Text = TimeHistoryParameters.TimpStep.ToString();
            loadFactor_Tb.Text = TimeHistoryParameters.LoadFactor.ToString();
            CDamping_TB.Text = TimeHistoryParameters.DampingRatio.ToString();
            alphaM_TB.Text = TimeHistoryParameters.AlphaM.ToString();
            BetaK_TB.Text = TimeHistoryParameters.BetaK.ToString();

            if (TimeHistoryParameters.UseConstantDamingRatio)
                CDamping_Rbtn.Checked = true;
            else
                RDamping_Rbtn.Checked = true;

            Alpha_TB.Text = TimeHistoryParameters.IntegratorAlpha.ToString();
            Beta_TB.Text = TimeHistoryParameters.Integrator_Beta.ToString();
            Gamma_TB.Text = TimeHistoryParameters.Integrator_Gamma.ToString();

            foreach (var command in _integratorHelper.Values)
            {
                Integrator_CBox.Items.Add(command);
            }
            Integrator_CBox.SelectedItem = GetIntegratorCommand(TimeHistoryParameters.Integrator);
        }              

        private void TimeStep_TB_TextChanged(object sender, EventArgs e)
        {
            TimeStep_VLB.Text = TrySetTimeStepValue() ? "" : ErrorMessage;
        }
        private void NSteps_TB_TextChanged(object sender, EventArgs e)
        {
            NSteps_VLB.Text = TrySetNofStepsValue() ? "" : ErrorMessage;
        }
        //private void HighSeismic_Btn_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (HighSeismic_Btn.Checked)
        //    {
        //        IDA_Parameters.SeismicityLevel = SeismicityLevel.High;
        //    }
        //}
        //private void MediumSeismic_Btn_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (MediumSeismic_Btn.Checked)
        //    {
        //        IDA_Parameters.SeismicityLevel = SeismicityLevel.Medium;
        //    }
        //}
        //private void LowSeismic_Btn_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (LowSeismic_Btn.Checked)
        //    {
        //        IDA_Parameters.SeismicityLevel = SeismicityLevel.Low;
        //    }
        //}
        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            (new RunFilesFrm(TimeHistoryParameters)).ShowDialog();
            button1.Enabled = true;
        }
        private bool TrySetNofStepsValue()
        {
            int value;
            if (!int.TryParse(NSteps_TB.Text, out value))
                return false;
            if (value < 1)
                return false;
            TimeHistoryParameters.NumberOfSteps = value;
            return true;
        }
        private bool TrySetTimeStepValue()
        {
            double value;
            if (!double.TryParse(TimeStep_TB.Text, out value))
                return false;
            if (value < 0.00000001)
                return false;
            TimeHistoryParameters.TimpStep = value;
            return true;
        }
        private void AlphaM_TB_TextChanged(object sender, EventArgs e)
        {
            alphaM_VLB.Text = TrySetTalphaMValue() ? "" : ErrorMessage;
            TrySetDampingValue();
        }
        private bool TrySetTalphaMValue()
        {
            double value;
            if (!double.TryParse(alphaM_TB.Text, out value))
                return false;
            if (value < -AnalysisParameters.Tolerance)
                return false;
            TimeHistoryParameters.AlphaM = value;
            return true;
        }
        private void BetaK_TB_TextChanged(object sender, EventArgs e)
        {
            BetaK_VLB.Text = TrySetBetaKValue() ? "" : ErrorMessage;
            TrySetDampingValue();
        }
        private bool TrySetBetaKValue()
        {
            double value;
            if (!double.TryParse(BetaK_TB.Text, out value))
                return false;
            if (value < -AnalysisParameters.Tolerance)
                return false;
            TimeHistoryParameters.BetaK = value;
            return true;
        }
        private bool TrySetDampingValue()
        {
            Damping_VLB.Text = "";
            if (TimeHistoryParameters.AlphaM < AnalysisParameters.Tolerance && TimeHistoryParameters.BetaK < AnalysisParameters.Tolerance)
            {
                Damping_VLB.Text = "All Damping coefficients equal zero";
                return false;
            }
            return true;
        }

        private void RDamping_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (RDamping_Rbtn.Checked)
            {
                TimeHistoryParameters.UseConstantDamingRatio = false;
                CDamping_VLB.Visible = false;
                CDamping_TB.Enabled = false;


                alphaM_TB.Enabled = BetaK_TB.Enabled = true;
                alphaM_TB.Text = TimeHistoryParameters.AlphaM.ToString();
                BetaK_TB.Text = TimeHistoryParameters.BetaK.ToString();
                alphaM_VLB.Visible = BetaK_VLB.Visible = Damping_VLB.Visible = true;
            }
        }

        private void CDamping_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (CDamping_Rbtn.Checked)
            {
                TimeHistoryParameters.UseConstantDamingRatio = true;
                CDamping_TB.Enabled = true;
                CDamping_TB.Text = TimeHistoryParameters.DampingRatio.ToString();
                CDamping_VLB.Visible = true;

                alphaM_TB.Enabled = BetaK_TB.Enabled = false;
                alphaM_VLB.Visible = BetaK_VLB.Visible = Damping_VLB.Visible = false;
            }
        }

        private void CDamping_TB_TextChanged(object sender, EventArgs e)
        {
            CDamping_VLB.Text = TrySetDampingRatio() ? "" : ErrorMessage;
        }
        private bool TrySetDampingRatio()
        {
            double value;
            if (!double.TryParse(CDamping_TB.Text, out value))
                return false;
            if (value < -AnalysisParameters.Tolerance)
                return false;
            if (value > 1)
                return false;
            TimeHistoryParameters.DampingRatio = value;
            return true;
        }

        private void LoadFactor_Tb_TextChanged(object sender, EventArgs e)
        {
            LoadFactor_VLB.Text = TrySetLoadFactor() ? "" : ErrorMessage;
        }

        private bool TrySetLoadFactor()
        {
            double value;
            if (!double.TryParse(loadFactor_Tb.Text, out value))
                return false;
            TimeHistoryParameters.LoadFactor = value;
            return true;
        }
        private Integrator GetIntegratorCommand(string integratorCommand)
        {
           return _integratorHelper.FirstOrDefault(x => x.Value == integratorCommand).Key;
        }
        private string GetIntegratorCommand(Integrator integratorCommand)
        {
            return _integratorHelper[integratorCommand];
        }
        private void Integrator_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeHistoryParameters.Integrator = GetIntegratorCommand(Integrator_CBox.SelectedItem.ToString());
            TrySetIntegratorParams();
        }
        private bool TrySetIntegratorParams()
        {
            bool result = false;
            switch (TimeHistoryParameters.Integrator)
            {
                case Integrator.Central_Difference:
                    Alpha_TB.Enabled = Beta_TB.Enabled = Gamma_TB.Enabled = false;
                    result = true;
                    break;
                case Integrator.Explicit_Difference:
                    Alpha_TB.Enabled = Beta_TB.Enabled = Gamma_TB.Enabled = false;
                    result = true;
                    break;
                case Integrator.HilberHughesTaylor_Method:
                    Alpha_TB.Enabled = Beta_TB.Enabled = Gamma_TB.Enabled = true;
                    result = TrySetAlpha() && TrySetBeta() && TrySetGamma();
                    break;
                case Integrator.Newmark_Method:
                    Alpha_TB.Enabled = Beta_TB.Enabled = true;
                    Gamma_TB.Enabled = false;
                    result = TrySetAlpha() && TrySetBeta();
                    break;
                case Integrator.TRBDF2:
                    Alpha_TB.Enabled = Beta_TB.Enabled = Gamma_TB.Enabled = false;
                    result = true;
                    break;
            }
            Integrator_VLB.Visible = !result;
            return result;
        }
        private void Alpha_TB_TextChanged(object sender, EventArgs e)
        {
            TrySetAlpha();
            TrySetIntegratorParams();
        }
        private bool TrySetAlpha()
        {
            double value;
            if (!double.TryParse(Alpha_TB.Text, out value))
                return false;
            if (value < 0 || value > 1.00)
                return false;
            TimeHistoryParameters.IntegratorAlpha = value;
            return true;
        }
        private void Beta_TB_TextChanged(object sender, EventArgs e)
        {
            TrySetBeta();
            TrySetIntegratorParams();
        }
        private bool TrySetBeta()
        {
            double value;
            if (!double.TryParse(Beta_TB.Text, out value))
                return false;
            if (value < 0 || value > 1.00)
                return false;
            TimeHistoryParameters.Integrator_Beta = value;
            return true;
        }
        private void Gamma_TB_TextChanged(object sender, EventArgs e)
        {
            TrySetGamma();
            TrySetIntegratorParams();
        }
        private bool TrySetGamma()
        {
            double value;
            if (!double.TryParse(Gamma_TB.Text, out value))
                return false;
            if (value < 0 || value > 1.00)
                return false;
            TimeHistoryParameters.Integrator_Gamma = value;
            return true;
        }
    }
}
