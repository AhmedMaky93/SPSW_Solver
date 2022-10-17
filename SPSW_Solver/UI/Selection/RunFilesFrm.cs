using SPSW_Solver.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPSW_Solver
{
    public partial class RunFilesFrm : Form
    {
        public List<string> FilePathes { get; protected set; } = new List<string>();
        Action SubmitAction;
        TimeHistory_Parameters TimeHistoryParameters;
        public RunFilesFrm(TimeHistory_Parameters timeHistoryParameters)
        {
            this.TimeHistoryParameters = timeHistoryParameters;
            this.FilePathes = timeHistoryParameters.GroundMotionFilePaths;
            InitializeComponent();
        }
        private void Add_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Ground Motion Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "acc",
                Filter = "Ground Motion File (*.acc)|*.acc|txt files (*.txt)|*.txt",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName) || this.FilePathes.Any(x => x == openFileDialog1.FileName))
                {
                    return;
                }
                FilePathes.Add(openFileDialog1.FileName);
                AppendMaterials();
            }
        }
        private void Check_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
        }
        private void Uncheck_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, false);
            }
        }
        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count < 1)
                return;
            this.FilePathes.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                this.FilePathes.Add(item as string);
            }
            TimeHistoryParameters.GroundMotionFilePaths = this.FilePathes;
            this.Close();
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string path = checkedListBox1.SelectedValue as String;
            if (path == null)
                return;
            this.FilePathes.Remove(path);
            AppendMaterials();
        }
        private void AppendMaterials()
        {
            List<string> oldList = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                oldList.Add(item as string);
            }
            
            (this.checkedListBox1).DataSource = new List<string>(this.FilePathes);
            for (int i = 0; i < FilePathes.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, oldList.Contains(FilePathes[i]));
            }
            CheckedListBox1_SelectedIndexChanged(null, null);
        }
        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = checkedListBox1.SelectedValue as string;
            Delete_btn.Enabled = path != null;
            SetLabelText();
        }
        private void SetLabelText()
        {
            string path = checkedListBox1.SelectedValue as string;
            if (path == null)
            {
                linkLabel1.Text = "...";
            }
            else
            {
                linkLabel1.Text = path;
            }
        }
        private void RunFilesFrm_Load(object sender, EventArgs e)
        {
            AppendMaterials();
        }

        private void CheckedListBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = Path.GetFileName((string)e.ListItem);
        }
    }
}
