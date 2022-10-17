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
    public partial class MaterialBehaviorGraphControl : UserControl
    {
        public Action Click;
        private string Documentation_Url;
        public MaterialBehaviorGraphControl()
        {
            InitializeComponent();
        }
        public void SetData(string title, Image url , string description , string doc_url)
        {
            label1.Text = title;
            button1.BackgroundImage = url;
            richTextBox1.Text = description;
            Documentation_Url = doc_url;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Click();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Documentation_Url);
        }
    }
}
