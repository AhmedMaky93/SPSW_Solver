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
using ZedGraph;

namespace SPSW_Solver
{
    public partial class ProfilePushoverControl : UserControl
    {
        public string ErrorMessage { get; set; } = "Invalid Input";
        public LateralProfilePushOverParameters Parameters { get; set; }
        public SPSW_Simple_Model Model { get; set; }
        public ProfilePushoverControl(LateralProfilePushOverParameters parameters , SPSW_Simple_Model model)
        {
            this.Parameters = parameters;
            Model = model;
            InitializeComponent();
        }
        internal bool ValidateInput()
        {
            if (TrySetNSteps())
            {
                bool res = false;
                switch (Parameters.ControlType)
                {
                    case PushOverControl.DisplacementControl:
                        res = TrySetMaxDrift();
                        break;
                    case PushOverControl.LoadControl:
                        res = TrySetOmega();
                        break;
                }
                return res;
            }
            return false;
        }
        private void Drift_TB_TextChanged(object sender, EventArgs e)
        {
            MaxDrift_VLB.Text = TrySetMaxDrift() ?"": ErrorMessage;
        }
        private bool TrySetMaxDrift()
        {
            double value;
            if (!double.TryParse(Drift_TB.Text, out value))
                return false;
            if (value < 1e-9 || value > 20)
                return false;
            Parameters.MaxDriftPercentage = value;
            return true;
        }
        private bool TrySetOmega()
        {
            double value;
            if (!double.TryParse(textBox_Omega.Text, out value))
                return false;
            if (value < 1 )
                return false;
            Parameters.Omega = value;
            return true;
        }

        private void DisControl_Rtb_CheckedChanged(object sender, EventArgs e)
        {
            if (DisControl_Rtb.Checked)
            {
                Parameters.ControlType = PushOverControl.DisplacementControl;
                MaxDrift_VLB.Visible = Drift_TB.Enabled = true;
                Omega_VLB.Visible = textBox_Omega.Enabled = false;
            }
        }
        private void LoadControl_Rtb_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadControl_Rtb.Checked)
            {
                Parameters.ControlType = PushOverControl.LoadControl;
                MaxDrift_VLB.Visible = Drift_TB.Enabled = false;
                Omega_VLB.Visible = textBox_Omega.Enabled = true;
            }
        }
        private void ProfilePushoverControl_Load(object sender, EventArgs e)
        {
            Drift_TB.Text = Parameters.MaxDriftPercentage.ToString();
            textBox_Omega.Text = Parameters.Omega.ToString();
            Vd_Label.Text = string.Format("Vd = {0}",Math.Round(Model.GetDesginBaseShear(),3));
            NSteps_TB.Text = Parameters.NumOfSteps.ToString();
            switch (Parameters.ControlType)
            {
                case PushOverControl.DisplacementControl:
                    DisControl_Rtb.Checked = true;
                    break;
                case PushOverControl.LoadControl:
                    LoadControl_Rtb.Checked = true;
                    break;
            }
           
        }

        private void NSteps_TB_TextChanged(object sender, EventArgs e)
        {
            NSteps_VLB.Text = TrySetNSteps() ? "" : ErrorMessage;
        }
        private bool TrySetNSteps()
        {
            int value;
            if (!int.TryParse(NSteps_TB.Text, out value))
                return false;
            if (value < 1)
                return false;
            Parameters.NumOfSteps = value;
            return true;
        }

        private void TextBox_Omega_TextChanged(object sender, EventArgs e)
        {
            Omega_VLB.Text = TrySetOmega() ? "" : ErrorMessage;
        }
    }
}
