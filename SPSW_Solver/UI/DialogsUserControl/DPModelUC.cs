using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPSW_Solver
{
    public partial class DPModelUC : BaseNumModelUC
    {
        public DistrubutredPlasticity Model { get; set; }
        public DPModelUC(DistrubutredPlasticity Model)
        {
            this.Model = Model;
            InitializeComponent();
        }
        private void DPModelUC_Load(object sender, EventArgs e)
        {
            IP_TB.Text = Model.IP.ToString();
            switch (Model.ModelOption)
            {
                case DistributedPlasticityOptions.AllSegments:
                    AllSegments_btn.Checked = true;
                    break;
                case DistributedPlasticityOptions.EndSegments:
                    EndSegments_btn.Checked = true;
                    break;
            }
        }
        public override bool IsValidParameters()
        {
            return IsValidIPs();
        }
        private void AllSegments_btn_CheckedChanged(object sender, EventArgs e)
        {
            if(AllSegments_btn.Checked)
            {
                Model.ModelOption = DistributedPlasticityOptions.AllSegments;
            }
        }
        private void EndSegments_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (EndSegments_btn.Checked)
            {
                Model.ModelOption = DistributedPlasticityOptions.EndSegments;
            }
        }
        private void IP_TB_TextChanged(object sender, EventArgs e)
        {
            IsValidIPs();
        }
        private bool IsValidIPs()
        {
            VLB.Text = "";
            if (string.IsNullOrEmpty(IP_TB.Text))
            {
                VLB.Text = "Empty field";
                return false;
            }
            int value;
            if ( (!int.TryParse(IP_TB.Text,out value)) || value < 2)
            {
                VLB.Text = "Invlid Input";
                return false;
            }
            Model.IP = value;
            return true;
        }
    }
}
