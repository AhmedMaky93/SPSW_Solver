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
using ZedGraph;

namespace SPSW_Solver
{
    public partial class AdaptivePushOverControl : UserControl
    {
        public static string ErrorMessage = "Invalid Input";
        public CyclicPushoOver PushOverParameters { get; set; }
        public int Records { get; protected set; }
        public AdaptivePushOverControl(CyclicPushoOver pushOverParameters)
        {
            this.PushOverParameters = pushOverParameters;
            InitializeComponent();
        }
        public bool ValidateInput()
        {
            return ReadDataGridView();

        }
        public bool SetData()
        {
            return true;
        }
        private void SetRecordes(int num)
        {
            Records = Math.Max(num, 1);
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            int cCouunt = this.dataGridView1.Rows.Count;
            if (cCouunt > Records)
            {
                for (int i = Records; i < cCouunt; i++)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count-1);
                }
            }
            else if (cCouunt < Records)
            {
                for (int i = cCouunt; i < Records; i++)
                {
                    dataGridView1.Rows.Add("", "" , "");
                }
            }
        }
        private void FillDataGridView()
        {
            for (int i = 0; i < this.PushOverParameters.Records.Count; i++)
            {
                CyclicLoadRecord record = this.PushOverParameters.Records[i];
                dataGridView1.Rows.Add(record.Drift, record.Cycles, record.Steps);
            }

        }
        private bool ReadDataGridView()
        {
            if (dataGridView1.Rows.Count < 0)
                return false;
            this.PushOverParameters.Records.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double drift;
                int steps;
                int cycles;
                if (!double.TryParse(row.Cells["Drift"].Value.ToString(), out drift) || drift < 1e-9)
                    return false;
                if (!int.TryParse(row.Cells["Cycles"].Value.ToString(), out cycles) || cycles < 1)
                    return false;
                if (!int.TryParse(row.Cells["Steps"].Value.ToString(), out steps) || steps < 1)
                    return false;
                PushOverParameters.Records.Add(new CyclicLoadRecord(drift, cycles, steps));
            }
            return true;
        }
        private void SetOptions(bool apply)
        {
            
            if (apply && ReadDataGridView())
            {
                UpdateGraph();
                groupBox1.Enabled = Submit_btn.Enabled = false;
                Edit_btn.Enabled = true;
            }
            else
            {
                ClearGraph();
                groupBox1.Enabled = Submit_btn.Enabled = true;
                Edit_btn.Enabled = false;
            }
        }

        private void ClearGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void UpdateGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            PointPairList mainlist = new PointPairList();
            double t = 0.0;
            mainlist.Add(new PointPair(0,0));
            for (int i = 0; i < this.PushOverParameters.Records.Count; i++)
            {
                CyclicLoadRecord record = this.PushOverParameters.Records[i];
                double drift = record.Drift;
                for (int j = 0; j < record.Cycles; j++)
                {
                    mainlist.Add(new PointPair(t + 0.25 , drift));
                    mainlist.Add(new PointPair(t + 0.5,0));
                    mainlist.Add(new PointPair(t + 0.75 , -drift));
                    mainlist.Add(new PointPair(t+1,0));
                    t ++;
                }
                
            }
            zedGraphControl1.GraphPane.AddCurve("", mainlist, Color.Red, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void PushOverControl_Load(object sender, EventArgs e)
        {
            if (this.PushOverParameters.Records == null)
                this.PushOverParameters.Records = new List<CyclicLoadRecord>();
            FillDataGridView();
            SetRecordes(this.PushOverParameters.Records.Count);
            Recordes_TB.Text = Records.ToString();
            SetOptions(this.PushOverParameters.Records.Count > 0);
            zedGraphControl1.GraphPane.Title.Text = "Cyclic Load";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Drift %";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "T (seconds)";
        }
        private void Recordes_TB_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(Recordes_TB.Text , out value))
            {
                SetRecordes(value);
            }
        }
        private void Edit_btn_Click(object sender, EventArgs e)
        {
            SetOptions(false);
        }
        private void Submit_btn_Click(object sender, EventArgs e)
        {
            SetOptions(true);
        }

    }
}
