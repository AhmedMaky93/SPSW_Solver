using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.BasicModel;
using SPSW_Solver.Model;

namespace SPSW_Solver
{
    public partial class DialogMaterialControl : DialogBaseControl
    {
        public List<Material> Materials { get; set; }
        public List <FrameElementNumericalModel> NumericalModels { get; set; }

        public DialogMaterialControl()
        {
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            return (!this.groupBox1.Enabled) && this.Materials.Any() && (!this.groupBox2.Enabled) && this.NumericalModels.Any();
        }
        public override bool SetData()
        {
            Model.Materials = Materials;
            Model.MaterialListChanged();
            Model.NumericalModels = NumericalModels;
            Model.NumModelListChanged();
            return true;
        }
        private void AppendMaterials()
        {
            List<Material> oldList = new List<Material>();
            foreach (var item in this.checkedListBox1.CheckedItems)
            {
                oldList.Add(item  as Material);
            }
            
            (this.checkedListBox1).DataSource = new List<Material>(Materials);
            ((ListBox)this.checkedListBox1).DisplayMember = "BasicData";
            foreach (var mat in oldList)
            {
                if (mat == null)
                    continue;
                if (!Materials.Contains(mat))
                    continue;
                this.checkedListBox1.SetItemChecked(this.Materials.IndexOf(mat), true);
            }
            CheckedListBox1_SelectedIndexChanged(null, null);
        }
        private void AppendNumericalModels()
        {
            List<FrameElementNumericalModel> oldList = new List<FrameElementNumericalModel>();
            foreach (var item in checkedListBox2.CheckedItems)
            {
                oldList.Add(item as FrameElementNumericalModel);
            }

           (this.checkedListBox2).DataSource = new List<FrameElementNumericalModel>(NumericalModels);
            ((ListBox)this.checkedListBox2).DisplayMember = "Name";
            foreach (var mat in oldList)
            {
                if (mat == null)
                    continue;
                if (!NumericalModels.Contains(mat))
                    continue;
                this.checkedListBox2.SetItemChecked(NumericalModels.IndexOf(mat), true);
            }
            CheckedListBox2_SelectedIndexChanged(null, null);
        }
        private void DialogMaterialControl_Load(object sender, EventArgs e)
        {
            Materials = Model.Materials;
            NumericalModels = Model.NumericalModels;
            AppendMaterials();
            AppendNumericalModels();
        }
        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material mat = checkedListBox1.SelectedValue as Material;
            Edit_btn.Enabled = Delete_btn.Enabled = mat != null; 
        }
        private void Add_Btn_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Materialfrm frm = new Materialfrm(null, Materials.Select(x => x.BasicData.Name).ToList());
            frm.SetReference += (Material m) =>
            {
                if (m != null)
                {
                    Materials.Add(m);
                }
                frm.Close();
            };
            frm.ShowDialog();
            groupBox1.Enabled = true;
            AppendMaterials();
        }
        private void Edit_btn_Click(object sender, EventArgs e)
        {
            Material mat = checkedListBox1.SelectedValue as Material;
            if (mat == null)
                return;
            groupBox1.Enabled = false;
            Materialfrm frm = new Materialfrm(mat,Materials.Select(x => x.BasicData.Name).ToList());
            frm.SetReference += (Material m) =>
            {
                if (m != null)
                {
                    int i = Materials.IndexOf(mat);
                    Materials.Remove(mat);
                    Materials.Insert(i,m);
                    Model.MatrialChanged(mat, m);
                }
                frm.Close();
            };
            frm.ShowDialog();
            groupBox1.Enabled = true;
            AppendMaterials();
        }
        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count < 1)
                return;
            this.Materials.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                this.Materials.Add(item as Material);
            }
            groupBox1.Enabled = false;
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            Material mat = checkedListBox1.SelectedValue as Material;
            if (mat == null)
                return;
            this.Materials.Remove(mat);
            AppendMaterials();
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
        private void CheckedListBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (Material)e.ListItem;
            e.Value = p.BasicData.Name;
        }
        private void CheckedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrameElementNumericalModel numModel  = checkedListBox2.SelectedValue as FrameElementNumericalModel;
            Num_Edit_btn.Enabled = Num_Delete_btn.Enabled = numModel != null;
        }
        private void EditNumModel(FrameElementNumericalModel numModel)
        {
            EditNumModelFrm frm = new EditNumModelFrm(numModel, Model);
            frm.ShowDialog();
            UI.Selection.ObjectProperties.ReturnAction();
            Model.ResetStaticVariables();
        }
        private void Num_Add_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            FrameElementNumericalModel numModel = null;

            InitNumModelfrm frm = new InitNumModelfrm(NumericalModels.Select(x => x.Name).ToList(),
               (name,PlasticHingeApproach) => 
               {
                   numModel = FrameElementNumericalModel.GetInstance(name, PlasticHingeApproach);
               });
            frm.ShowDialog();
            if (numModel != null)
            {
                NumericalModels.Add(numModel);
                EditNumModel(numModel);
            }
            groupBox2.Enabled = true;
            AppendNumericalModels();
        }
        private void Num_check_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                this.checkedListBox2.SetItemChecked(i, true);
            }
        }
        private void Num_uncheck_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                this.checkedListBox2.SetItemChecked(i, false);
            }
        }
        private void Num_Delete_btn_Click(object sender, EventArgs e)
        {
            FrameElementNumericalModel mat = checkedListBox2.SelectedValue as FrameElementNumericalModel;
            if (mat == null)
                return;
            this.NumericalModels.Remove(mat);
            AppendNumericalModels();
        }
        private void Num_Edit_btn_Click(object sender, EventArgs e)
        {
            FrameElementNumericalModel  mat = checkedListBox2.SelectedValue as FrameElementNumericalModel;
            if (mat == null)
                return;
            groupBox2.Enabled = false;
            EditNumModel(mat);
            groupBox2.Enabled = true;
            AppendNumericalModels();
        }
        private void Num_submit_btn_Click(object sender, EventArgs e)
        {
            if (checkedListBox2.CheckedItems.Count < 1)
                return;
            this.NumericalModels.Clear();
            foreach (var item in checkedListBox2.CheckedItems)
            {
                this.NumericalModels.Add(item as FrameElementNumericalModel);
            }
            groupBox2.Enabled = false;
        }
        private void CheckedListBox2_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (FrameElementNumericalModel)e.ListItem;
            e.Value = p.Name;
        }
    }
}
