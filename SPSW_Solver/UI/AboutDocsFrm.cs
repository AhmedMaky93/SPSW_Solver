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
    public partial class AboutDocsFrm : Form
    {
        private static int _txtMargin = 3;
        public AboutDocsFrm()
        {
            InitializeComponent();
        }

        private void AboutDocsFrm_Load(object sender, EventArgs e)
        {
            ReShapeComponents();
            About_btn.Checked = true;
        }
        private void ReShapeComponents()
        {
            int W=  Size.Width;
            int H = Size.Height;
            int gw = groupBox1.Size.Width;
            webBrowser1.Size = new Size(W-4*_txtMargin-gw,H-2*_txtMargin);
        }

        private void AboutDocsFrm_Resize(object sender, EventArgs e)
        {
            ReShapeComponents();
        }

        private void About_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (About_btn.Checked)
            {
                //webBrowser1.DocumentText = Properties.Resources.INSPECT_SPSW_ABOUT;
                webBrowser1.DocumentText = Properties.Resources.INSPECT_SPSW_LICENSE;
            }
        }
        private void License_CheckedChanged(object sender, EventArgs e)
        {
            if (License.Checked)
            {
                webBrowser1.DocumentText = Properties.Resources.INSPECT_SPSW_READ_ME;
            }
        }
        private void Acknowledgement_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Acknowledgement_Btn.Checked)
            {
                webBrowser1.DocumentText = Properties.Resources.INSPECT_SPSW_ACKNOWLEDEMNETS;
            }
        }
        private void OpenSees_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenSees_Btn.Checked)
            {
                webBrowser1.DocumentText = Properties.Resources.INSPECT_SPSW_OPENSEES;
            }
        }
    }
}
