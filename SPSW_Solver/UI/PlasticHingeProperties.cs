using SPSW_Solver.BasicModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPSW_Solver
{
    public partial class PlasticHingePropertiesfrm : Form
    {
        public PlasticHingeProperties PHP { get; set; }
        public PlasticHingePropertiesfrm(PlasticHingeProperties pHP , string Name)
        {
            this.PHP = pHP;
            this.Text = Name;
            InitializeComponent();
        }

        private void PlasticHingeProperties_Load(object sender, EventArgs e)
        {
             A_Tb.Text = PHP.A.ToString();
             B_Tb.Text = PHP.B.ToString();
            if (PHP.AbsoluteValue)
            {
                Absolute_Rbtn.Checked = true;
            }
            else
            {
                Relative_Rbtn.Checked = true;
            }

            dataGridView1.Rows.Add("basic strength deterioration", PHP.Properties["LS"]);
            dataGridView1.Rows.Add("unloading stiffness deterioration", PHP.Properties["LK"]);
            dataGridView1.Rows.Add("accelerated reloading stiffness deterioration", PHP.Properties["LA"]);
            dataGridView1.Rows.Add("post-capping strength deterioration", PHP.Properties["LD"]);
            dataGridView1.Rows.Add("exponent for basic strength deterioration", PHP.Properties["cS"]);
            dataGridView1.Rows.Add("exponent for unloading stiffness deterioration", PHP.Properties["cK"]);
            dataGridView1.Rows.Add("exponent for accelerated reloading stiffness deterioration", PHP.Properties["cA"]);
            dataGridView1.Rows.Add("exponent for post-capping strength deterioration", PHP.Properties["cD"]);
            dataGridView1.Rows.Add("plastic rot capacity for pos loading", PHP.Properties["th_pP"]);
            dataGridView1.Rows.Add("plastic rot capacity for neg loading", PHP.Properties["th_pN"]);
            dataGridView1.Rows.Add("post-capping rot capacity for pos loading", PHP.Properties["th_pcP"]);
            dataGridView1.Rows.Add("post-capping rot capacity for neg loading", PHP.Properties["th_pcN"]);
            dataGridView1.Rows.Add("residual strength ratio for pos loading", PHP.Properties["ResP"]);
            dataGridView1.Rows.Add("residual strength ratio for neg loading", PHP.Properties["ResN"]);
            dataGridView1.Rows.Add("ultimate rot capacity for pos loading", PHP.Properties["th_uP"]);
            dataGridView1.Rows.Add("ultimate rot capacity for neg loading", PHP.Properties["th_uN"]);
            dataGridView1.Rows.Add("rate of cyclic deterioration for pos loading", PHP.Properties["DP"]);
            dataGridView1.Rows.Add("rate of cyclic deterioration for neg loading", PHP.Properties["DN"]);
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            if (!ValidateA_BValues())
                return;

            Validation_label.Text = "";
            List<string> keys = new List<string>()
            {   "LS", "LK" ,"LA" ,"LD" , "cS" ,"cK" , "cA" ,"cD" , "th_pP" , "th_pN" , "th_pcP" ,"th_pcN" ,
                "ResP" ,"ResN" , "th_uP" , "th_uN" , "DP" ,"DN" };
            List<bool> values = new List<bool>();
            for (int i = 0; i < keys.Count; i++)
            {
                double x;
                if (!double.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out x) || x < 0.0)
                {
                    values.Add(false);
                }
                else
                {
                    values.Add(true);
                    PHP.Properties[keys[i]] = x;
                }

            }

            if (values.All(x => x))
                this.Close();
            else
                Validation_label.Text = "Invalid inputs";
        }

        private bool ValidateA_BValues()
        {
            if (!(ValidateA() && ValidateB()))
                return false;
            if (PHP.A >= PHP.B)
            {
                A_VLB.Text = "a value must be less than b";
                return false;
            }
            return true;
        }
        private bool ValidateB()
        {   
            B_VLb.Text ="";
            double x;
            if (!double.TryParse(B_Tb.Text, out x) || x < 0.0)
            {
                B_VLb.Text = "Invalid Text";
                return false;
            }
            PHP.B = x;
            return true;
        }
        private bool ValidateA()
        {
            A_VLB.Text = "";
            double x;
            if (!double.TryParse(A_Tb.Text, out x) || x < 0.0)
            {
                A_VLB.Text = "Invalid Text";
                return false;
            }
            PHP.A = x;
            return true;
        }
        private void A_Tb_TextChanged(object sender, EventArgs e)
        {
            ValidateA_BValues();
        }
        private void B_Tb_TextChanged(object sender, EventArgs e)
        {
            ValidateA_BValues();
        }
        private void Relative_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Relative_Rbtn.Checked)
            {
                PHP.AbsoluteValue = false;
            }
        }
        private void Absolute_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Absolute_Rbtn.Checked)
            {
                PHP.AbsoluteValue = true;
            }
        }
    }
}
