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
    public partial class DialogLateralLoadControl : DialogBaseControl
    {
        public AnalysisParameters parameters { get; set; } = new AnalysisParameters();
        public UserControl ParametersControl { get; set; }
        public DialogLateralLoadControl()
        {
            InitializeComponent();
        }
        private void Pushover_RBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (LateralPushover_RBtn.Checked)
            {
                this.parameters.AnalysisMethod = AnalysisMethod.Monotonic_Pushover_Analysis;
                SetGroupBox();
            }
        }
        private void IDA_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (TimeHistory_Rbtn.Checked)
            {
                this.parameters.AnalysisMethod = AnalysisMethod.Time_History_Dynamic_Analysis;
                SetGroupBox();
            }
        }

        public override bool ValidateInput()
        {
            if (this.parameters.AnalysisMethod == AnalysisMethod.Monotonic_Pushover_Analysis)
            {
                return (ParametersControl as ProfilePushoverControl).ValidateInput();
            }
            if (this.parameters.AnalysisMethod == AnalysisMethod.Cyclic_Pushover)
            {
                return (ParametersControl as AdaptivePushOverControl).ValidateInput();
            }
            else if(this.parameters.AnalysisMethod == AnalysisMethod.Time_History_Dynamic_Analysis)
            {
                return (ParametersControl as Time_History_ParametersControl).ValidateInput();
            }
            return false;
            
        }
        public override bool SetData()
        {
            return true;
        }
        private void SetGroupBox()
        {
            panel1.Controls.Clear();
            if (this.parameters.AnalysisMethod == AnalysisMethod.Monotonic_Pushover_Analysis)
            {
                ParametersControl = new ProfilePushoverControl(parameters.ProfilePushOverParameters , this.Model);
            }
            else if (this.parameters.AnalysisMethod == AnalysisMethod.Cyclic_Pushover)
            {
                ParametersControl = new AdaptivePushOverControl(parameters.CyclicPushoOver);
            }
            else if (this.parameters.AnalysisMethod == AnalysisMethod.Time_History_Dynamic_Analysis)
            {
                ParametersControl = new Time_History_ParametersControl(parameters.TimeHistory_Parameters, Model.FreeLevels);
            }
            panel1.Controls.Add(ParametersControl);
            ParametersControl.Dock = DockStyle.Fill;
        }
        private void SetMethod()
        {
            switch (this.parameters.AnalysisMethod)
            {
                case AnalysisMethod.Monotonic_Pushover_Analysis:
                    LateralPushover_RBtn.Checked = true;
                    SetGroupBox();
                    break;
                case AnalysisMethod.Cyclic_Pushover:
                    AISCE_Rbtn.Checked = true;
                    SetGroupBox();
                    break;
                case AnalysisMethod.Time_History_Dynamic_Analysis:
                    TimeHistory_Rbtn.Checked = true;
                    SetGroupBox();
                    break;
                default:
                    break;
            }
        }
        private void DialogLateralLoadControl_Load(object sender, EventArgs e)
        {
            parameters = Model.AnalysisParameters;
            SetMethod();
        }

        private void AISCE_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (AISCE_Rbtn.Checked)
            {
                this.parameters.AnalysisMethod = AnalysisMethod.Cyclic_Pushover;
                SetGroupBox();
            }
        }
    }
}
