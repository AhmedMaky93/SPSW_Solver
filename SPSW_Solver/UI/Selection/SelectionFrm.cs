using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPSW_Solver.UI.Selection
{
    public partial class SelectionFrm : Form
    {
        public Action LoadAction { get; set; }
        public Action OkAction { get; set; }
        public SelectionFrm()
        {
            InitializeComponent();
        }

        private void SelectionFrm_Load(object sender, EventArgs e)
        {
             LoadAction();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OkAction();
            Close();
        }
    }
}
