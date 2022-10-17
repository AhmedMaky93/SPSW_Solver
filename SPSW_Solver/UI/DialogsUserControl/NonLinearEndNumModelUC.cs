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
    public partial class NonLinearEndNumModelUC : BaseNumModelUC
    {
        public NonLinearBeams Model { get; set; }
        public NonLinearEndNumModelUC(NonLinearBeams Model)
        {
            this.Model = Model;
            InitializeComponent();
        }
        private void NonLinearEndNumModelUC_Load(object sender, EventArgs e)
        {
            switch (Model.RepLength)
            {
                case LengthRep.RelativeToDepth:
                    Depth_btn.Checked = true;
                    break;
                case LengthRep.RelativeToSegmentLength:
                    Segment_btn.Checked = true;
                    break;
            }
            IP_TB.Text = Model.IP.ToString();
            First_TB.Text = Model.NonLinearLengthFirst.ToString();
            Last_TB.Text = Model.NonLinearLengthLast.ToString();

        }
        public override bool IsValidParameters()
        {
            return IsValidIPs() && IsValidFirstSegmentLength()&& IsValidLastSegmentLength();
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
            if ((!int.TryParse(IP_TB.Text, out value)) || value < 2)
            {
                VLB.Text = "Invlid Input";
                return false;
            }
            Model.IP = value;
            return true;
        }
        private void IP_TB_TextChanged(object sender, EventArgs e)
        {
            IsValidIPs();
        }
        private void Depth_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Depth_btn.Checked)
            {
                Model.RepLength = LengthRep.RelativeToDepth;
            }
            IsValidFirstSegmentLength(); IsValidLastSegmentLength();
        }
        private void Segment_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Segment_btn.Checked)
            {
                Model.RepLength = LengthRep.RelativeToSegmentLength;
            }
            IsValidFirstSegmentLength(); IsValidLastSegmentLength();
        }
        private void First_TB_TextChanged(object sender, EventArgs e)
        {
            IsValidFirstSegmentLength();
        }

        private bool IsValidFirstSegmentLength()
        {
            First_VLB.Text = "";
            if (string.IsNullOrEmpty(First_TB.Text))
            {
                First_VLB.Text = "Emapty Field";
                return false;
            }
            double value;
            if ((!double.TryParse(First_TB.Text, out value)) || value < -1e-9)
            {
                First_VLB.Text = "Invalid input";
                return false;
            }
            if (Model.RepLength == LengthRep.RelativeToSegmentLength && value>1)
            {
                First_VLB.Text = "Invalid input";
                return false;
            }
            Model.NonLinearLengthFirst = value;
            return true;

        }
        private bool IsValidLastSegmentLength()
        {
            Last_VLB.Text = "";
            if (string.IsNullOrEmpty(Last_TB.Text))
            {
                Last_VLB.Text = "Emapty Field";
                return false;
            }
            double value;
            if ((!double.TryParse(Last_TB.Text, out value)) || value < -1e-9)
            {
                Last_VLB.Text = "Invalid input";
                return false;
            }
            if (Model.RepLength == LengthRep.RelativeToSegmentLength && value > 1)
            {
                Last_VLB.Text = "Invalid input";
                return false;
            }
            Model.NonLinearLengthLast = value;
            return true;

        }
        private void Last_TB_TextChanged(object sender, EventArgs e)
        {
            IsValidLastSegmentLength();
        }
    }
}
