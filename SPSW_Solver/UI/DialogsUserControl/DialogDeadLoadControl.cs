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
    public partial class DialogDeadLoadControl :DialogBaseControl
    {
        public static string FloorsColumnHeadText = "Floor";
        public static string ColumnsLoadColumnHeadText = "Dead Load (Gravity Columns)";
        public static string PlatesLoadColumnHeadText = "Dead Load (SPSW)";

        public static string FloorsColumnName = "FloorsColumn";
        public static string ColumnsLoadColumnName = "ColumnssDeadLoad";
        public static string PlatesLoadColumnName = "PlatesDeadLoad";
        public FloorDeadLoad[] FloorsDeadLoads;
        public double[] Modifiers;
        public DialogDeadLoadControl()
        {
            InitializeComponent();
        }
        public override bool SetData()
        {
            Model.MainNodes.ForEach(x => x.ClearNodeMass());
            Model.SupportsNodes.ForEach(x => x.ClearNodeMass());
            Model.FloorsDeadLoads = FloorsDeadLoads;
            Model.RigidLinkModifier = Modifiers[0];
            Model.GravityCoulmnModifier = Modifiers[1];
            Model.G = GetGravityAccelration();
            Model.CalculateNodesMass();
            return true;
        }
        private bool ValidateDeadLoad()
        {
            int k = this.Model.BaseProperties.HasOffset ? 1 : 0;
            FloorsDeadLoads = new FloorDeadLoad[this.Model.Layout.FloorNo + k];
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int floorindex = (int)row.Cells[FloorsColumnName].Value;
                double platesDeadLoad;
                double columnsDeadLoad;
                if (!double.TryParse(row.Cells[PlatesLoadColumnName].Value.ToString(), out platesDeadLoad))
                    return false;
                if (!double.TryParse(row.Cells[ColumnsLoadColumnName].Value.ToString(), out columnsDeadLoad))
                    return false;
                FloorsDeadLoads[floorindex - 1] = new FloorDeadLoad() { ColumnsLoad = columnsDeadLoad, PlatesLoad = platesDeadLoad };
            }
            
            return true;
        }
        private bool ValidateModifiers()
        {
            int k = 0;
            Modifiers = new double[2];
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                double v;
                if ( (!double.TryParse(row.Cells["Modifier"].Value.ToString(), out v)) || v < 0.0)
                    return false;
                Modifiers[k] = v;
                k++;
            }
            return true;
        }
        public override bool ValidateInput()
        {
            return ValidateDeadLoad() && ValidateModifiers() && ValidateGravity();
        }
        private bool ValidateGravity()
        {
            double g;
            if (double.TryParse(Gravity_TB.Text, out g) && g > 0)
            {
                gravity_LB.Visible = false;
                return true;
            }
            else
            { 
                gravity_LB.Visible = true;
                return false;
            }
        }
        private double GetGravityAccelration()
        {
            double g;
            if (double.TryParse(Gravity_TB.Text, out g) && g > 0)
            {
                return g;
            }
            return 0.0;
        }
        private void InitializeDataGridView1()
        {
            dataGridView1.Columns.Add(FloorsColumnName, FloorsColumnHeadText);
            dataGridView1.Columns.Add(ColumnsLoadColumnName, ColumnsLoadColumnHeadText);
            dataGridView1.Columns.Add(PlatesLoadColumnName, PlatesLoadColumnHeadText);

            int n = this.Model.Layout.FloorNo;
            if (this.Model.BaseProperties.HasOffset)
                n++;

            if (this.FloorsDeadLoads == null || this.FloorsDeadLoads.Length != n)
            {
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Rows.Add(n - i, "", "");
                }
            }
            else
            {
                for (int i = this.FloorsDeadLoads.Length - 1; i > -1; i--)
                {
                    dataGridView1.Rows.Add(i + 1, this.FloorsDeadLoads[i].ColumnsLoad, this.FloorsDeadLoads[i].PlatesLoad);
                }
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.RowHeadersVisible = false;
            //set autosize mode
            dataGridView1.Columns[0].ReadOnly = true;
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            //datagrid has calculated it's widths so we can store them
            for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dataGridView1.Columns[i].Width;
                //remove autosizing
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dataGridView1.Columns[i].Width = colw;
            }
        }
        private void InitializeDataGridView2()
        {
            if (this.Modifiers == null)
                this.Modifiers = new double[] {100,100};
            
            dataGridView2.Rows.Add("Rigid Links", "A", Modifiers[0]);
            dataGridView2.Rows.Add("Gravity Columns", "A", Modifiers[1]);

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView2.RowHeadersVisible = false;
            //set autosize mode
            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[1].ReadOnly = true;

            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //datagrid has calculated it's widths so we can store them
            for (int i = 0; i <= dataGridView2.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dataGridView2.Columns[i].Width;
                //remove autosizing
                dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dataGridView2.Columns[i].Width = colw;
            }
        }
        public void InitializeDataGridView()
        {
            InitializeDataGridView1();
            InitializeDataGridView2();
            Gravity_TB.Text = Model.G.ToString();
        }
        private void DialogDeadLoadControl_Load(object sender, EventArgs e)
        {
            this.AutomaticDeadLoads_Chb.Checked = this.Model.AddDeadLoadsAutomatically;
        }
        private void AutomaticDeadLoads_Chb_CheckedChanged(object sender, EventArgs e)
        {
            this.Model.AddDeadLoadsAutomatically = this.AutomaticDeadLoads_Chb.Checked;
        }
        private void Gravity_TB_TextChanged(object sender, EventArgs e)
        {
            ValidateGravity();
        }
    }
}
