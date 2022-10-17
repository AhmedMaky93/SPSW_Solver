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
    public partial class BWHNumModelUC : BaseNumModelUC
    {
        public BeamWithHingesModel Model { get; set; }
        public BWHNumModelUC(BeamWithHingesModel Model)
        {
            this.Model = Model;
            InitializeComponent();
        }
        private void BWHNumModelUC_Load(object sender, EventArgs e)
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
            End_TB.Text = Model.EndsLength.ToString();
            Inter_TB.Text = Model.IntermediateLength.ToString();
        }
        public override bool IsValidParameters()
        {
            return IsvalidBothLength();
        }
        private void Depth_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Depth_btn.Checked)
            {
                Model.RepLength = LengthRep.RelativeToDepth;
            }
            IsvalidBothLength();
        }
        private void Segment_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Segment_btn.Checked)
            {
                Model.RepLength = LengthRep.RelativeToSegmentLength;
            }
            IsvalidBothLength();
        }
        private void End_TB_TextChanged(object sender, EventArgs e)
        {
            IsvalidBothLength();
        }
        private bool IsvalidBothLength()
        {
            All_VLB.Text = "";
            if (!IsValidEndLength())
                return false;
            if (!IsValidInterLength())
                return false;   

            double endvalue;
            double intervalue;
            if (!double.TryParse(End_TB.Text, out endvalue))
            {
                return false;
            }
            if (!double.TryParse(Inter_TB.Text, out intervalue))
            {
                return false;
            }
            if (intervalue > endvalue)
            {
                All_VLB.Text = "intermediate length should less than ends";
                return false;
            }
            if (Model.RepLength == LengthRep.RelativeToSegmentLength && (intervalue + endvalue) > 1)
            {
                All_VLB.Text = "Both hinges shouldn't exceed segment length";
                return false;
            }
            Model.EndsLength = endvalue;
            Model.IntermediateLength = intervalue;
            return true;
        }

        private bool IsValidInterLength()
        {
            Inter_VLB.Text = "";
            if (string.IsNullOrEmpty(Inter_TB.Text))
            {
                Inter_VLB.Text = "Emapty Field";
                return false;
            }
            double value;
            if ((!double.TryParse(Inter_TB.Text, out value)) || value < 1e-9)
            {
                Inter_VLB.Text = "Invalid input";
                return false;
            }
            if (Model.RepLength == LengthRep.RelativeToSegmentLength && value > 1)
            {
                Inter_VLB.Text = "Invalid input";
                return false;
            }
            return true;
        }

        private bool IsValidEndLength()
        {
            End_VLB.Text = "";
            if (string.IsNullOrEmpty(End_TB.Text))
            {
                End_VLB.Text = "Emapty Field";
                return false;
            }
            double value;
            if ((!double.TryParse(End_TB.Text, out value)) || value < 1e-9)
            {
                End_VLB.Text = "Invalid input";
                return false;
            }
            if (Model.RepLength == LengthRep.RelativeToSegmentLength && value > 1)
            {
                End_VLB.Text = "Invalid input";
                return false;
            }
            return true;
        }

        private void Inter_TB_TextChanged(object sender, EventArgs e)
        {
            IsvalidBothLength();
        }
    }
}
