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
    public partial class DialogSectionFamiliesControl : DialogBaseControl
    {
        public List<FrameElementFamily> FramesFamilies { get; set; } = new List<FrameElementFamily>();
        public List<PlateFamily> PlateFamilies { get; set; } = new List<PlateFamily>();
        public DialogSectionFamiliesControl()
        {
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            return (!this.groupBox1.Enabled) && this.FramesFamilies.Any()
                && (!this.groupBox2.Enabled) && this.PlateFamilies.Any();
        }
        public override bool SetData()
        {
            this.Model.FramesFamilies = FramesFamilies;
            this.Model.PlateFamilies = PlateFamilies;
            return true;
        }

        private void DialogSectionFamiliesControl_Load(object sender, EventArgs e)
        {
            this.FramesFamilies = Model.FramesFamilies;
            this.PlateFamilies = Model.PlateFamilies;
            AppendFrameSections();
            AppendPlateSections();
        }
        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrameElementFamily mat = checkedListBox1.SelectedValue as FrameElementFamily;
            Frame_Edit_btn.Enabled = Frame_Delete_btn.Enabled = mat != null;
        }
        private void CheckedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlateFamily mat = checkedListBox2.SelectedValue as PlateFamily;
            Plate_Edit_btn.Enabled = Plate_Delete_btn.Enabled = mat != null;
        }
        private void CheckedListBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (FrameElementFamily)e.ListItem;
            e.Value = p.Name;
        }
        private void CheckedListBox2_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (PlateFamily)e.ListItem;
            e.Value = p.Name;
        }

        private void Frame_check_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
        }
        private void Plate_Check_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                this.checkedListBox2.SetItemChecked(i, true);
            }
        }
        private void Frame_uncheck_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, false);
            }
        }
        private void Plate_UnCheck_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                this.checkedListBox2.SetItemChecked(i, false);
            }
        }
        private void AppendFrameSections()
        {
            List<FrameElementFamily> oldList = new List<FrameElementFamily>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                FrameElementFamily fam = item as FrameElementFamily;
                if (fam == null)
                    continue;
                oldList.Add(fam);
            }
            (this.checkedListBox1).DataSource = new List<FrameElementFamily>(this.FramesFamilies);
            ((ListBox)this.checkedListBox1).DisplayMember = "Name";
            foreach (var mat in oldList)
            {
                if (mat == null)
                    continue;
                if (!this.FramesFamilies.Contains(mat))
                    continue;
                this.checkedListBox1.SetItemChecked(this.FramesFamilies.IndexOf(mat), true);
            }
            CheckedListBox1_SelectedIndexChanged(null, null);
        }
        private void AppendPlateSections()
        {
            List<PlateFamily> oldList = new List<PlateFamily>();
            foreach (var item in checkedListBox2.CheckedItems)
            {
                PlateFamily fam = item as PlateFamily;
                if (fam == null)
                    continue;
                oldList.Add(fam);
            }
            
            (this.checkedListBox2).DataSource = new List<PlateFamily>(this.PlateFamilies);
            ((ListBox)this.checkedListBox2).DisplayMember = "Name";
            foreach (var mat in oldList)
            {
                if (mat == null)
                    continue;
                if (!this.PlateFamilies.Contains(mat))
                    continue;
                this.checkedListBox2.SetItemChecked(this.PlateFamilies.IndexOf(mat), true);
            }
            CheckedListBox2_SelectedIndexChanged(null, null);
        }
        private void Frame_Delete_btn_Click(object sender, EventArgs e)
        {
           FrameElementFamily mat = checkedListBox1.SelectedValue as FrameElementFamily;
            if (mat == null)
                return;
            this.FramesFamilies.Remove(mat);
            AppendFrameSections();
        }
        private void Plate_Delete_btn_Click(object sender, EventArgs e)
        {
            PlateFamily mat = checkedListBox2.SelectedValue as PlateFamily;
            if (mat == null)
                return;
            this.PlateFamilies.Remove(mat);
            AppendPlateSections();
        }

        private void Frame_Submit_Btn_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count < 1)
                return;
            this.FramesFamilies.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                this.FramesFamilies.Add(item as FrameElementFamily);
            }

            groupBox1.Enabled = false;
        }
        private void Plate_Submit_btn_Click(object sender, EventArgs e)
        {
            if (checkedListBox2.CheckedItems.Count < 1)
                return;
            this.PlateFamilies.Clear();
            foreach (var item in checkedListBox2.CheckedItems)
            {
                this.PlateFamilies.Add(item as PlateFamily);
            }

            groupBox2.Enabled = false;
        }
        private void Frame_Add_Btn_Click(object sender, EventArgs e)
        {
            Frame_Add_Btn.Enabled = false;
            FrameFamilyFrm frm = new FrameFamilyFrm();
            frm.Model = this.Model;
            frm.ShowDialog();
            AppendFrameSections();
            Frame_Add_Btn.Enabled = true;
        }
        private void Frame_Edit_btn_Click(object sender, EventArgs e)
        {
            FrameElementFamily mat = checkedListBox1.SelectedValue as FrameElementFamily;
            if (mat == null)
                return;

            Frame_Edit_btn.Enabled = false;
            FrameFamilyFrm frm = new FrameFamilyFrm();
            frm.Model = this.Model;
            frm.Element = mat;
            frm.ShowDialog();
            AppendFrameSections();
            Frame_Edit_btn.Enabled = true;
        }

        private void Plate_Add_btn_Click(object sender, EventArgs e)
        {
            Plate_Add_btn.Enabled = false;
            PlateSectionFrm frm = new PlateSectionFrm();
            frm.Model = this.Model;
            frm.ShowDialog();
            AppendPlateSections();
            Plate_Add_btn.Enabled = true;
        }
        private void Plate_Edit_btn_Click(object sender, EventArgs e)
        {
            PlateFamily mat = checkedListBox2.SelectedValue as PlateFamily;
            if (mat == null)
                return;
            Plate_Edit_btn.Enabled = false;
            PlateSectionFrm frm = new PlateSectionFrm();
            frm.Model = this.Model;
            frm.Element = mat;
            frm.ShowDialog();
            AppendPlateSections();
            Plate_Edit_btn.Enabled = true;
        }
    }
}
