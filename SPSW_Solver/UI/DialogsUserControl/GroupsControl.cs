using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.Model;

namespace SPSW_Solver
{
    public partial class GroupsControl : UserControl
    {
        public List<SectionFamily> ChooseList { get; set; }
        public List<FrameElementNumericalModel> NumModelList { get; set; }
        public int MaxNoGroups { get; set; }
        public int NoGroups { get; set; }
        public int MinIndex { get; set; }
        public int MaxIndex { get; set; }

        public Predicate<List<LevelsSectionGroup>> ValidateInput;
        public Predicate<DataGridView> ReadData;
        public Action<List<LevelsSectionGroup>, DataGridView> FillDatatGrid;
        public GroupsControl()
        {
            InitializeComponent();
        }
        private void Ok_button_Click(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(Groups_TB.Text, out value))
                return;
            if (value < 1 || value > MaxNoGroups)
                return;

            NoGroups = value;
            InitializeDataGridViewRows();
            Ok_button.Visible = false;
            dataGridView1.Visible = Submit_button.Visible = Edit_button.Visible = true; 
        }
        public void SetMainData(List<LevelsSectionGroup> data, List<SectionFamily> chooseList, List<FrameElementNumericalModel> NumModelList)
        {
            this.ChooseList = chooseList;
            this.NumModelList = NumModelList;
            if (ValidateInput(data))
            {
                SetEditMode(false);
                FillDatatGrid(data,dataGridView1);
                Groups_TB.Text = data.Count.ToString();
                ReadData(this.dataGridView1);
            }
            else
            {
                SetEditMode(true);
            }
        }
        private void InitializeDataGridViewRows()
        {
            dataGridView1.Rows.Clear();
            if (this.NumModelList == null)
            {
                for (int i = 0; i < NoGroups; i++)
                {
                    DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell();
                    cbCell.DataSource = this.ChooseList;
                    cbCell.DisplayMember = "Name";

                    dataGridView1.Rows.Add(string.Format("g{0}", (i + 1)), "", "", "");
                    dataGridView1.Rows[i].Cells[3] = cbCell;
                }
            }
            else
            {
                for (int i = 0; i < NoGroups; i++)
                {
                    DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell();
                    cbCell.DataSource = this.ChooseList;
                    cbCell.DisplayMember = "Name";

                    DataGridViewComboBoxCell cMCell = new DataGridViewComboBoxCell();
                    cMCell.DataSource = this.NumModelList;
                    cMCell.DisplayMember = "Name";

                    dataGridView1.Rows.Add(string.Format("g{0}", (i + 1)), "", "", "" , "");
                    dataGridView1.Rows[i].Cells[3] = cbCell;
                    dataGridView1.Rows[i].Cells[4] = cMCell;
                }
            }
            

            dataGridView1.Rows[0].Cells[1].Value = MinIndex.ToString();
            dataGridView1.Rows[NoGroups-1].Cells[2].Value = MaxIndex.ToString();
        }
        public void SetNoAndIndex(int MaxNoofGroup , int minIndex , int maxIndex)
        {
            MaxNoGroups = MaxNoofGroup;
            MinIndex = minIndex;
            MaxIndex = maxIndex;
        }
        public void SetColumnsHeaders(string h1 , string h2 , string h3 , string h4, string h5 = null)
        {
            dataGridView1.Columns[0].HeaderText = h1;
            dataGridView1.Columns[1].HeaderText = h2;
            dataGridView1.Columns[2].HeaderText = h3;
            dataGridView1.Columns[3].HeaderText = h4;
            if (h5 == null)
            {
                dataGridView1.Columns.RemoveAt(4);
            }
            else
            {
                dataGridView1.Columns[4].HeaderText = h5;
            }
        }

        private void SetEditMode(bool edit)
        {
            VlB.Text ="";
            this.dataGridView1.Enabled = Submit_button.Enabled =Groups_TB.Enabled = Ok_button.Visible = edit;
            dataGridView1.Visible = Submit_button.Visible = Edit_button.Visible = !edit;
        }
        private void Edit_button_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
        }

        private void Submit_button_Click(object sender, EventArgs e)
        {
            if (ReadData(this.dataGridView1))
            {
                SetEditMode(false);
            }
            else
            {
                VlB.Text = "Invalid Data";
            }  
        }

    }
}
