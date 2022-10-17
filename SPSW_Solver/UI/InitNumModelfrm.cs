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
    public partial class InitNumModelfrm : Form
    {
        public List<string> ReservedNames { get; set; }
        public Action<string, PlasticHingeApproach> OkAction { get; set; }
        public InitNumModelfrm(List<string> ReservedNames, Action<string, PlasticHingeApproach> OkAction)
        {
            this.ReservedNames = ReservedNames;
            this.OkAction = OkAction;
            InitializeComponent();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            IsValidName();
        }
        private bool IsValidName()
        {
            VLB.Text = "";
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                VLB.Text = "Empty input";
                return false;
            }
            if (ReservedNames.Any(x => x == textBox1.Text))
            {
                VLB.Text = "Repeated numerical model name";
                return false;
            }
            return true;
        }
        private void InitNumModelfrm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "New Model";
        }
        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (!IsValidName())
                return;
            if (OkAction == null)
                return;
            PlasticHingeApproach approach = PlasticHingeApproach.None;
            if (Elastic_btn.Checked)
                approach = PlasticHingeApproach.None;
            if (NonLinear_btn.Checked)
                approach = PlasticHingeApproach.NolinearBeamColumn;
            if (BWH_btn.Checked)
                approach = PlasticHingeApproach.BeamWithHinges;
            if (DP_btn.Checked)
                approach = PlasticHingeApproach.DistrubuitedPlasticity;
            if (Fiber_btn.Checked)
                approach = PlasticHingeApproach.ZeroLengthFiberSection;
            
            OkAction(textBox1.Text, approach);
            Close();
        }
        private void elasticBeamColumn_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.ElasticBeamColumn_Link);
        }
        private void ZeroLengthSection_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.ZeroLengthSection_Link);
        }
        private void nonlinearBeamColumn_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.NonlinearBeamColumn_Link);
        }
        private void dispBeamColumn_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.DispBeamColumn_Link);
        }
        private void beamWithHinges_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.BeamWithHinges_Link);
        }
    }
}
