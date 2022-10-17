using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.BasicModel;

namespace SPSW_Solver
{
    public partial class DialogMaterialBasicDataControl : MaterialDialogsBaseControl
    {
        public static string ErrorMessage = "Invalid Input";
        public List<string> Names { get; set; }
        public MaterialBasicData BasicData { get; set; }
        public DialogMaterialBasicDataControl(MaterialBasicData basicData)
        {
            this.BasicData = basicData;
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            return TrySetName()&& TrySetNu() && TrySetE()&& TrySetDensity();
        }
        private void Name_TB_TextChanged(object sender, EventArgs e)
        {
            Name_VLB.Text = TrySetName() ?"":"Can't be empty Or Repeated name";
        }
        private bool TrySetName()
        {
            if (string.IsNullOrEmpty(Name_TB.Text))
                return false;
            if (Names != null && Names.Any() && Names.Contains(Name_TB.Text))
                return false;
            BasicData.Name = Name_TB.Text;
            return true;
        }
        private void Nu_TB_TextChanged(object sender, EventArgs e)
        {
            Nu_VLB.Text = TrySetNu() ? "" : ErrorMessage;
        }
        private bool TrySetNu()
        {
            double value;
            if (!double.TryParse(Nu_TB.Text, out value))
                return false;
            if (value <= 0 || value >0.5)
                return false;
            BasicData.Nu = value;
            return true;
        }
        private void E_TB_TextChanged(object sender, EventArgs e)
        {
            E_VLB.Text = TrySetE() ? "" : ErrorMessage;
        }
        private bool TrySetE()
        {
            double value;
            if (!double.TryParse(E_TB.Text, out value))
                return false;
            if (value <= 0)
                return false;
            BasicData.E = value;
            return true;
        }
        private void Density_TB_TextChanged(object sender, EventArgs e)
        {
            Density_VLB.Text = TrySetDensity() ? "" : ErrorMessage;
        }
        private bool TrySetDensity()
        {
            double value;
            if (!double.TryParse(Density_TB.Text, out value))
                return false;
            if (value <= 0)
                return false;
            BasicData.Density = value;
            return true;
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            Back();
        }
        private void Next_btn_Click(object sender, EventArgs e)
        {
            Next();
        }
        private void DialogMaterialBasicDataControl_Load(object sender, EventArgs e)
        {
            Name_TB.Text = BasicData.Name;
            Nu_TB.Text = BasicData.Nu.ToString();
            E_TB.Text = BasicData.E.ToString();
            Density_TB.Text = BasicData.Density.ToString();
            switch (BasicData.Type)
            {
                case MaterialType.NoCompression:
                    NoCompression_Rbtn.Checked = true;
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    Symmetric_Rtbn.Checked = true;
                    break;
                case MaterialType.Generic:
                    generic_Rtbn.Checked = true;
                    break;
            }
        }
        private void NoCompression_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (NoCompression_Rbtn.Checked)
            {
                BasicData.Type = MaterialType.NoCompression;
            }
        }
        private void Symmetric_Rtbn_CheckedChanged(object sender, EventArgs e)
        {
            if (Symmetric_Rtbn.Checked)
            {
                BasicData.Type = MaterialType.TensionCompressionSymmetric;
            }
        }
        private void Generic_Rtbn_CheckedChanged(object sender, EventArgs e)
        {
            if (generic_Rtbn.Checked)
            {
                BasicData.Type = MaterialType.Generic;
            }
        }
    }
}
