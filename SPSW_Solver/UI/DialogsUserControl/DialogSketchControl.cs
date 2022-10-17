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
    public partial class DialogSketchControl : DialogBaseControl
    {
        public List<FrameSectionGroup> BeamsGroup { get; set; } = new List<FrameSectionGroup>();
        public List<FrameSectionGroup> ColumnsGroup { get; set; } = new List<FrameSectionGroup>();
        public List<PlateSectionGroup> PlatesGroup { get; set; } = new List<PlateSectionGroup>();
        public DialogSketchControl()
        {
            InitializeComponent();
        }
        public override bool SetData()
        {
            Model.BeamsSectionGroups = BeamsGroup;
            Model.ColumnsSectionGroups = ColumnsGroup;
            Model.PlatesSectionGroups = PlatesGroup;
            Model.CreateElements();
            StringBuilder b = new StringBuilder();
            b.AppendLine(string.Format("Include Rigid Zones for joints : {0}", Model.IncludePanelZones.ToString()));
            b.AppendLine(string.Format("Method : {0}", Model.GetAngleMethodName()));
            b.AppendLine("");
            b.AppendLine("Calcualtions of vertical angle at each floor : ");
            b.AppendLine("");
            b.AppendLine(string.Format("Calculated Angles are modified to assure min {0} strips", this.Model.MinStrips));
            b.AppendLine("");
            b.AppendLine("Floor Index : Therorical Angle , Actual Angle , difference , Num of Strips");
            b.AppendLine("");
            for (int i = Model.SPBeys.Count-1; i > -1; i--)
            {
                var x = Model.SPBeys[i];
                b.AppendLine(string.Format("Floor {0} : {1} ° , {2} ° , {3} ° , {4}",
                    x.FloorIndex + 1, 
                    Math.Round(x.TheoriticalVerticalAngle.Degrees, 2),
                    Math.Round(x.ActualVerticalAngle.Degrees, 2),
                    Math.Round(x.TheoriticalVerticalAngle.Degrees - x.ActualVerticalAngle.Degrees, 2), 
                    x.NumOfStrips));
            }
            b.AppendLine("");
            MessageBox.Show(b.ToString(), "Strips Vertical Angle calculation report", MessageBoxButtons.OK,MessageBoxIcon.Information);
            return true;
        }
        public override bool ValidateInput()
        {
            return Model.IsValidBeamsSectionGroup(BeamsGroup) &&
                   Model.IsValidColumnsSectionGroup(ColumnsGroup) &&
                   Model.IsValidPlatesSectionGroup(PlatesGroup);
        }
        private void DialogSketchControl_Load(object sender, EventArgs e)
        {
            bool hasOffset = Model.BaseProperties.HasOffset;
            BeamsGroupsControl.SetColumnsHeaders("Group", "Start Level Index", "End Level index", "Frame-Section", "Numerical Model");
            BeamsGroupsControl.SetNoAndIndex(Model.CalcMaxBeamFamiliesGroup(), Model.BaseProperties.GetFirstBeamLevelIndex(), Model.Levels.Count - 1);
            Beam_start_Lb.Text = BeamsGroupsControl.MinIndex.ToString();
            Beam_end_Lb.Text = BeamsGroupsControl.MaxIndex.ToString();
            Beam_to_Lb.Text = BeamsGroupsControl.MaxNoGroups.ToString();
            BeamsGroupsControl.ValidateInput = BeamValidatInput;
            BeamsGroupsControl.FillDatatGrid = WriteFrameSectionData;
            BeamsGroupsControl.ReadData = ReadBeamsGroupsData;
            BeamsGroupsControl.SetMainData(Model.BeamsSectionGroups.Any()? Model.BeamsSectionGroups.Cast<LevelsSectionGroup>().ToList() : null , Model.FramesFamilies.Cast<SectionFamily>().ToList() , Model.NumericalModels);

            ColumnsGroupsControl.SetColumnsHeaders("Group", "Start Level Index", "End Level index", "Frame-Section", "Numerical Model");
            ColumnsGroupsControl.SetNoAndIndex(Model.Levels.Count - 1, 0, (Model.Levels.Count - 1));
            Column_to_Lb.Text = Column_end_Lb.Text = (Model.Levels.Count - 1).ToString();
            ColumnsGroupsControl.ValidateInput = ColumnsValidatInput;
            ColumnsGroupsControl.FillDatatGrid = WriteFrameSectionData;
            ColumnsGroupsControl.ReadData = ReadColumnsGroupsData;
            ColumnsGroupsControl.SetMainData(Model.ColumnsSectionGroups.Any()? Model.ColumnsSectionGroups.Cast<LevelsSectionGroup>().ToList() : null, Model.FramesFamilies.Cast<SectionFamily>().ToList(), Model.NumericalModels);

            PlateGroupsControl.SetColumnsHeaders("Group", "Start Floor Index", "End Floor index", "Plate-Section");
            int n = Model.Layout.FloorNo;
            PlateGroupsControl.SetNoAndIndex(n, 1, n);
            Plate_to_Lb.Text = Plate_end_Lb.Text = n.ToString();
            PlateGroupsControl.ValidateInput = PlatesValidatInput;
            PlateGroupsControl.FillDatatGrid = WritePlateSectionData;
            PlateGroupsControl.ReadData = ReadPlatesGroupsData;
            PlateGroupsControl.SetMainData(Model.PlatesSectionGroups.Any()? Model.PlatesSectionGroups.Cast<LevelsSectionGroup>().ToList() : null, Model.PlateFamilies.Cast<SectionFamily>().ToList(), null);
        }
        public bool BeamValidatInput(List<LevelsSectionGroup> data)
        {
            if (data == null || !data.Any())
                return false;
            return this.Model.IsValidBeamsSectionGroup(data.Cast<FrameSectionGroup>().ToList());
        }
        public bool ColumnsValidatInput(List<LevelsSectionGroup> data)
        {
            if (data == null || !data.Any())
                return false;
            return this.Model.IsValidColumnsSectionGroup(data.Cast<FrameSectionGroup>().ToList());
        }
        public bool PlatesValidatInput(List<LevelsSectionGroup> data)
        {
            if (data == null || !data.Any())
                return false;
            return this.Model.IsValidPlatesSectionGroup(data.Cast<PlateSectionGroup>().ToList());
        }
        public void WriteFrameSectionData(List<LevelsSectionGroup> data , DataGridView dgv)
        {
            dgv.Rows.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                FrameSectionGroup sec = data[i] as FrameSectionGroup;
                if (sec == null)
                    continue;

                DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell();
                cbCell.DataSource = this.Model.FramesFamilies;
                cbCell.DisplayMember = "Name";
                cbCell.Value = sec.FrameSection.Name;

                DataGridViewComboBoxCell cMCell = new DataGridViewComboBoxCell();
                cMCell.DataSource = this.Model.NumericalModels;
                cMCell.DisplayMember = "Name";
                cMCell.Value = sec.NumericalModel.Name;

                dgv.Rows.Add(string.Format("g{0}", (i + 1)), sec.MinIndex.ToString(), sec.MaxIndex.ToString(), "" ,"");
                dgv.Rows[i].Cells[3] = cbCell;
                dgv.Rows[i].Cells[4] = cMCell;
            }
        }
        public void WritePlateSectionData(List<LevelsSectionGroup> data, DataGridView dgv)
        {
            dgv.Rows.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                PlateSectionGroup sec = data[i] as PlateSectionGroup;
                if (sec == null)
                    continue;

                DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell();
                cbCell.DataSource = this.Model.PlateFamilies;
                cbCell.DisplayMember = "Name";
                cbCell.Value = sec.PlateSection.Name;
                dgv.Rows.Add(string.Format("g{0}", (i + 1)), sec.MinIndex.ToString(), sec.MaxIndex.ToString(), "");
                dgv.Rows[i].Cells[3] = cbCell;
            }
        }
        public bool ReadFrameSectionRow(DataGridViewRow row, out FrameSectionGroup group)
        {
            group = new FrameSectionGroup();

            int min;
            if (!int.TryParse(row.Cells[1].Value.ToString(), out min))
                return false;

            int max;
            if (!int.TryParse(row.Cells[2].Value.ToString(), out max))
                return false;

            if (row.Cells[3].Value == null)
                return false;

            if (row.Cells[4].Value == null)
                return false;

            FrameElementFamily sec = Model.FramesFamilies.FirstOrDefault(x =>x.Name == row.Cells[3].Value.ToString());
            if (sec == null)
                return false;

            FrameElementNumericalModel numericalModel = Model.NumericalModels.FirstOrDefault(x => x.Name == row.Cells[4].Value.ToString());
            if (numericalModel == null)
                return false;
            group = new FrameSectionGroup(min, max,sec, numericalModel);
            return true;
        }
        public bool ReadFrameSectionsGroupsData(DataGridView dgv, out List<FrameSectionGroup> groups)
        {
            groups = new List<FrameSectionGroup>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                FrameSectionGroup group;
                if (!ReadFrameSectionRow(dgv.Rows[i],out group))
                    return false;
                groups.Add(group);
            }
            return true;
        }
        public bool ReadColumnsGroupsData(DataGridView dgv)
        {
            List<FrameSectionGroup> groups;
            if (!ReadFrameSectionsGroupsData(dgv,out groups))
                return false;
            if (!Model.IsValidColumnsSectionGroup(groups))
                return false;
            ColumnsGroup = groups;
            return true;
        }
        public bool ReadBeamsGroupsData(DataGridView dgv)
        {
            List<FrameSectionGroup> groups;
            if (!ReadFrameSectionsGroupsData(dgv, out groups))
                return false;
            if (!Model.IsValidBeamsSectionGroup(groups))
                return false;
            BeamsGroup = groups;
            return true;
        }
        public bool ReadPlateSectionRow(DataGridViewRow row, out PlateSectionGroup group)
        {
            group = new PlateSectionGroup();

            int min;
            if (!int.TryParse(row.Cells[1].Value.ToString(), out min))
                return false;

            int max;
            if (!int.TryParse(row.Cells[2].Value.ToString(), out max))
                return false;

            if (row.Cells[3].Value == null)
                return false;

            PlateFamily sec = Model.PlateFamilies.FirstOrDefault(x => x.Name == row.Cells[3].Value.ToString());
            if (sec == null)
                return false;

            group = new PlateSectionGroup(min, max, sec);
            return true;
        }
        public bool ReadPlateSectionsGroupsData(DataGridView dgv, out List<PlateSectionGroup> groups)
        {
            groups = new List<PlateSectionGroup>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                PlateSectionGroup group;
                if (!ReadPlateSectionRow(dgv.Rows[i], out group))
                    return false;
                groups.Add(group);
            }
            return true;
        }
        public bool ReadPlatesGroupsData(DataGridView dgv)
        {
            List<PlateSectionGroup> groups;
            if (!ReadPlateSectionsGroupsData(dgv, out groups))
                return false;
            if (!Model.IsValidPlatesSectionGroup(groups))
                return false;
            PlatesGroup = groups;
            return true;
        }
    }
}
