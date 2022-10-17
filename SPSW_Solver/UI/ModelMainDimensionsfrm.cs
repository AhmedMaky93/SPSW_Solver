using SPSW_Solver.Model;
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
    public partial class ModelMainDimensionsfrm : Form
    {
        public static string ErrorMessage = "Invalid input";
        
        public static string Activate_Grp1Btn = "Reset";
        public static string Activate_Grp2Btn = "Submit";
        
        public static double MinPanelApsectRatio = 0.7;
        public static double MaxPanelApsectRatio = 2.5;

        protected bool IsHeightsDGVActive = false;
        protected int HeightGroups = 1;
        public ModelLayout modelLayout { get; protected set; }
        public ModelMainDimensionsfrm(ModelLayout Layout)
        {
            this.modelLayout = Layout;
            InitializeComponent();
        }

        private void ModelMainDimensionsfrm_Load(object sender, EventArgs e)
        {
            FloorsNo_VLB.Visible = Width_VLB.Visible = Heights_VLB.Visible = HeightGrps_VLB.Visible = false;
            FloorsNo_VLB.Text = Width_VLB.Text = Heights_VLB.Text = HeightGrps_VLB.Text = ErrorMessage;

            Aspect_Ratio_LB.Text = $"Required : {MinPanelApsectRatio} <= Panel Aspect Ratio (L/H) <= {MaxPanelApsectRatio}";
            FloorsNo_TB.Text = modelLayout.FloorNo.ToString();
            Width_TB.Text = modelLayout.BeamWidth.ToString();
            if (modelLayout.FloorsGroupsHeights != null && modelLayout.FloorsGroupsHeights.Count > 0)
            {
                HeightGroups = modelLayout.FloorsGroupsHeights.Count;
                ShowHeightsDGV();
                FillDGV();

            }
            else 
            {
                HideHeightsDGV();
            }
            Heights_TB.Text = HeightGroups.ToString();

        }

        public bool TrySetFloorsNumber()
        {
            int i;
            if (!int.TryParse(FloorsNo_TB.Text, out i))
                return false;

            if (i < 1)
                return false;

            modelLayout.FloorNo = i;
            return true;
        }
        public bool TrySetWidth()
        {
            double width;
            if (!double.TryParse(Width_TB.Text, out width))
                return false;
            if (width < 1e-9)
                return false;

            modelLayout.BeamWidth = width;
            return true;
        }
        public bool TrySetHeightsGroups()
        {
            if (!TrySetFloorsNumber())
                return false;

            int groups;
            if (!int.TryParse(Heights_TB.Text, out groups))
                return false;
            if (groups < 1 || groups > modelLayout.FloorNo)
                return false;

            HeightGroups = groups;
            return true;
        }
        private void FloorsNo_TB_TextChanged(object sender, EventArgs e)
        {
            FloorsNo_VLB.Visible = !TrySetFloorsNumber();
        }
        private void Width_TB_TextChanged(object sender, EventArgs e)
        {
            Width_VLB.Visible = !TrySetWidth();
        }
        private void Height_TB_TextChanged(object sender, EventArgs e)
        {
            Heights_VLB.Visible = !TrySetHeightsGroups();
        }
        public bool IsValidModel()
        {
            if (this.modelLayout == null)
                return false;

            if (modelLayout.FloorNo < 1)
                return false;

            if (modelLayout.BeamWidth < 1e-9)
                return false;

            if (!IsValidFloorsGroups(modelLayout.FloorsGroupsHeights))
                return false;

            return true;
        }

        private bool IsValidFloorsGroups(List<FloorHeightGroup> Groups)
        {
            if (Groups == null)
                return false;

            int groupsCount = Groups.Count;
            if (groupsCount < 1 || groupsCount > modelLayout.FloorNo)
                return false;

            if (Groups[0].StartIndex != 0)
                return false;

            if (Groups[groupsCount-1].EndIndex != modelLayout.FloorNo-1)
                return false;

            for (int i = 1; i < groupsCount; i++)
            {
                if ( (Groups[i].StartIndex - Groups[i - 1].EndIndex) != 1)
                    return false;
            }
            for (int i = 0; i < groupsCount; i++)
            {
                double Height = Groups[i].Height;
                if (Math.Abs(Height) < 1e-9)
                    return false;
                double AspectRatio = modelLayout.BeamWidth / Height;
                if (AspectRatio < MinPanelApsectRatio || AspectRatio > MaxPanelApsectRatio)
                    return false;
            }

            return true;
        }


        private void Group1_btn_Click(object sender, EventArgs e)
        {
            if (IsHeightsDGVActive)
            {
                HideHeightsDGV();
            }
            else 
            {
                if (TrySetFloorsNumber() && TrySetWidth() && TrySetHeightsGroups())
                { 
                    ShowHeightsDGV();
                    InitDGV();
                }
            }
        }
        
        private void ShowHeightsDGV()
        {
            IsHeightsDGVActive = true;
            Group1_btn.Text = Activate_Grp1Btn;
            WidthGroupBox.Enabled = false;
            HeightGroupBox.Visible = true;
        }
        private void HideHeightsDGV()
        {
            IsHeightsDGVActive = false;
            Group1_btn.Text = Activate_Grp2Btn;
            WidthGroupBox.Enabled = true;
            HeightGroupBox.Visible = false;
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (DataGridViewRefresh())
            {
                this.Close();
            }
        }
        private bool DataGridViewRefresh()
        {
            List<FloorHeightGroup> groups = null;
            bool valid = GetGroupsData(out groups) && IsValidFloorsGroups(groups);
            HeightGrps_VLB.Visible = !valid;
            if (valid)
                modelLayout.FloorsGroupsHeights = groups;
            else
                groups?.Clear();
            return valid;
        }

        private bool GetGroupsData(out List<FloorHeightGroup> groups)
        {
            groups = new List<FloorHeightGroup>();
            try
            {
                foreach (DataGridViewRow row in Heights_DGV.Rows)
                {
                    if (row.Cells[0].Value == null)
                        return false;

                    int startIndex;
                    if (!int.TryParse(row.Cells[0].Value.ToString(), out startIndex))
                        return false;

                    if (row.Cells[1].Value == null)
                        return false;

                    int endIndex;
                    if (!int.TryParse(row.Cells[1].Value.ToString(), out endIndex))
                        return false;

                    if (row.Cells[2].Value == null)
                        return false;

                    double Height;
                    if (!double.TryParse(row.Cells[2].Value.ToString(), out Height))
                        return false;

                    groups.Add(new FloorHeightGroup()
                    {
                        StartIndex = startIndex-1,
                        EndIndex = endIndex-1,
                        Height = Height,
                    });
                }
                return true;
            }
            catch (Exception e)
            {
                groups.Clear();
                return false;
            }
           
        }

        private void InitDGV()
        {
            Heights_DGV.Rows.Clear();
            for (int i = 0; i < HeightGroups; i++)
            {
                Heights_DGV.Rows.Add();
            }
            Heights_DGV.Rows[0].Cells[0].Value = 1;
            Heights_DGV.Rows[HeightGroups-1].Cells[1].Value = modelLayout.FloorNo;
        }

        private void FillDGV()
        {
            Heights_DGV.Rows.Clear();
            for (int i = 0; i < modelLayout.FloorsGroupsHeights.Count; i++)
            {
                var group = modelLayout.FloorsGroupsHeights[i];
                Heights_DGV.Rows.Add(group.StartIndex+1,group.EndIndex+1,group.Height);
                TrySetHeight(i, 2,out double Height);
            }
            DataGridViewRefresh();
        }

        private void Heights_DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 2)
            { 
                TrySetHeight(e.RowIndex, e.ColumnIndex,out double Height);
            }
            DataGridViewRefresh();
        }
        
        private bool TrySetHeight(int RowIndex, int ColumnIndex , out double Height)
        {
            try
            {
                DataGridViewCell cell = Heights_DGV.Rows[RowIndex].Cells[ColumnIndex];
                Height = 0;
                if (!double.TryParse(cell.Value.ToString(), out Height))
                {
                    SetAspectRatioCell(RowIndex, false, "");
                    return false;
                }

                if (Math.Abs(Height) < 1e-9)
                {
                    SetAspectRatioCell(RowIndex, false, "Not Valid");
                    return false;
                }

                double AspectRatio = modelLayout.BeamWidth /Height;
                 Heights_DGV.Rows[RowIndex].Cells[ColumnIndex+1].Value = AspectRatio;
                if (AspectRatio < MinPanelApsectRatio || AspectRatio > MaxPanelApsectRatio)
                {
                    SetAspectRatioCell(RowIndex, false, "Not Valid");
                    return false;
                }
                SetAspectRatioCell(RowIndex, true, "Valid");
                return true;
            }
            catch (Exception exc)
            {
                Height = 0;
                return false;
            }

        }
        private void SetAspectRatioCell(int rowIndex, bool valid , string Message)
        {
            Heights_DGV.Rows[rowIndex].Cells[3].Value = Message;
            Heights_DGV.Rows[rowIndex].Cells[3].Style.BackColor = valid ? Color.Green : Color.Red;
        }
    }
}
