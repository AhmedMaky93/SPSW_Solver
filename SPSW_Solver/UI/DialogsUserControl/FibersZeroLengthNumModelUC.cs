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
    public partial class FibersZeroLengthNumModelUC : BaseNumModelUC
    {
        private static double tol = 1e-9;
        public FiberPlasticSections Model { get; set; }
        public FibersZeroLengthNumModelUC(FiberPlasticSections Model)
        {
            this.Model = Model;
            InitializeComponent();
        }
        public override bool IsValidParameters()
        {
            return ReadEndsDGV() && ReadRealtivesDGV();
        }
        private bool ReadEndsDGV()
        {
            if (Additional_DGV.Rows == null)
                return true;

            List<double> locations = new List<double>();
            List<double> Lps = new List<double>();

            foreach (DataGridViewRow row in Additional_DGV.Rows)
            {
                double location = 0.0;
                double Lp = 0.0;
                if (!IsValidLocation(row.Cells[0], out location))
                    continue;
                if (!IsValidLp(row.Cells[1], out Lp))
                    continue;
                locations.Add(location);
                Lps.Add(Lp);
            }
            Model.AdditionalRelativePositions = locations.ToArray();
            Model.AdditionalLengths = Lps.ToArray();
            return true;
        }
        private bool IsValidLp(DataGridViewCell cell, out double value)
        {
            value = 0.0;
            if (cell.Value == null)
                return false;
            return double.TryParse(cell.Value.ToString(), out value) && value > tol && value < 1+tol;
        }
        private bool IsValidLocation(DataGridViewCell cell, out double value)
        {
            value = 0.0;
            if (cell.Value == null)
                return false;
            return double.TryParse(cell.Value.ToString(), out value) && value > -tol && value < 1 + tol;
        }
        private bool ReadRealtivesDGV()
        {
            double startLP = 0.0;
            double endLP = 0.0;

            if (!IsValidLp(End_DGV.Rows[0].Cells[2],out startLP))
                return false;
            if (!IsValidLp(End_DGV.Rows[1].Cells[2],out endLP))
                return false;

            Model.StartLp = startLP;
            Model.EndLp = endLP;

            Model.AddStart = RetriveCheckValue(End_DGV.Rows[0].Cells[1]);
            Model.AddEnd = RetriveCheckValue(End_DGV.Rows[1].Cells[1]);
            return true;
        }
        private bool RetriveCheckValue(DataGridViewCell cell)
        {
            DataGridViewCheckBoxCell chk = cell as DataGridViewCheckBoxCell;
            return chk.Value == null? false: (bool)chk.Value ;
        }
        private void FibersZeroLengthNumModelUC_Load(object sender, EventArgs e)
        {
            switch (Model.EndsDistance)
            {
                case EndFiberDistance.Zero:
                    Zero_btn.Checked = true;
                    break;
                case EndFiberDistance.Depth:
                    Depth_btn.Checked = true;
                    break;
                case EndFiberDistance.DepthAndConnection:
                    Panel_btn.Checked = true;
                    break;
            }
            InitializeEndsDGV();
            InitializeRelativeDGV();
        }
        private void InitializeEndsDGV()
        {
            End_DGV.Rows.Add("Start", "", Model.StartLp.ToString());
            DataGridViewCheckBoxCell chk1 = new DataGridViewCheckBoxCell();
            chk1.Value = Model.AddStart ? true : false;
            End_DGV.Rows[0].Cells[1] = chk1;
            End_DGV.Rows.Add("End", "", Model.EndLp.ToString());
            DataGridViewCheckBoxCell chk2 = new DataGridViewCheckBoxCell();
            chk2.Value = Model.AddEnd ? true : false;
            End_DGV.Rows[1].Cells[1] = chk2;
        }
        private void InitializeRelativeDGV()
        {
            if (Model.AdditionalRelativePositions == null || Model.AdditionalLengths == null)
                return;
            if (Model.AdditionalRelativePositions.Length != Model.AdditionalLengths.Length)
                return;
            for (int i = 0; i < Model.AdditionalRelativePositions.Length; i++)
            {
                Additional_DGV.Rows.Add(Model.AdditionalRelativePositions[i].ToString(), Model.AdditionalLengths[i].ToString());
            }
        }
        private void Zero_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Zero_btn.Checked)
            {
                Model.EndsDistance = EndFiberDistance.Zero;
            }
        }
        private void Depth_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Depth_btn.Checked)
            {
                Model.EndsDistance = EndFiberDistance.Depth;
            }
        }
        private void Panel_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Panel_btn.Checked)
            {
                Model.EndsDistance = EndFiberDistance.DepthAndConnection;
            }
        }

  
    }
}
