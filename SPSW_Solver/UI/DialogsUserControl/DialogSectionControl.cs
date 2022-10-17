using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicModel;

namespace SPSW_Solver
{
    public partial class DialogSectionControl : DialogBaseControl
    {
        public List<IShapeSection> SectionList { get; set; } = new List<IShapeSection>();
        public List<IShapeSection> SelectedSectionList { get; set; } = new List<IShapeSection>();

        public DialogSectionControl()
        {
            InitializeComponent();
        }
        public DialogSectionControl(List<IShapeSection> SectionList):this()
        {
            this.SectionList = SectionList;
        }
        public override bool ValidateInput()
        {
            return  (!this.groupBox1.Enabled) && this.SelectedSectionList.Any();
        }
        public override bool SetData()
        {
            Model.SectionsList = SelectedSectionList;
            Model.SectionListChanged();
            return true;
        }

        private void DialogSectionControl_Load(object sender, EventArgs e)
        {
            (this.checkedListBox1).DataSource = this.SectionList;
            ((ListBox)this.checkedListBox1).DisplayMember = "Name";
            foreach (var selectedSection in SelectedSectionList)
            {
                this.checkedListBox1.SetItemChecked(this.SectionList.IndexOf(selectedSection), true);
            }

        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IShapeSection section = checkedListBox1.SelectedValue as IShapeSection;
            if (section != null)
            {
                NameLabel.Text = section.Name;
                IDLabel.Text = section.ID.ToString();
                A_Label.Text = section.A.ToString();
                Ix_Label.Text = section.Ix.ToString();
                Iy_label.Text = section.Iy.ToString();
                d_label.Text = section.D.ToString();
                b_label.Text = section.Bf.ToString();
                tf_label.Text = section.Tf.ToString();
                tw_label.Text = section.Tw.ToString();
            }
            else
            {
                NameLabel.Text =
                IDLabel.Text =
                A_Label.Text =
                Ix_Label.Text =
                Iy_label.Text =
                d_label.Text =
                b_label.Text =
                tf_label.Text =
                tw_label.Text = "";
            }

        }

        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count < 1)
                return;
            SelectedSectionList.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                SelectedSectionList.Add(item as IShapeSection);
            }
            

            groupBox1.Enabled = false;
            
        }

    }
}
