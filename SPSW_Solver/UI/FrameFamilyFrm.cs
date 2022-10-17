using BasicModel;
using SPSW_Solver.BasicModel;
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
    public partial class FrameFamilyFrm : Form
    {
        public SPSW_Simple_Model Model { get; set; }
        public FrameElementFamily Element { get; set; }
        public FrameFamilyFrm()
        {
            InitializeComponent();
        }
        private void FrameFamilyFrm_Load(object sender, EventArgs e)
        {
            Material_comboBox.DataSource = new List<Material>(this.Model.Materials);
            Flange_comboBox.DataSource = new List<Material>(this.Model.Materials);
            Section_comboBox.DataSource = this.Model.SectionsList;
            IntializeModifiers_DGV();
            IntializeFibers_DGV();
            if (Element == null)
            {
                Name_Tb.Text = "";
                E_TB.Text = "29000";
                return;
            }
            Name_Tb.Text = Element.Name;
            E_TB.Text = Element.initE.ToString();
            Material_comboBox.SelectedIndex = this.Model.Materials.IndexOf(Element.WebMaterial);
            Flange_comboBox.SelectedIndex = this.Model.Materials.IndexOf(Element.FlangeMaterial);
            Section_comboBox.SelectedIndex = this.Model.SectionsList.IndexOf(Element.Section);
            
        }
        private void IntializeFibers_DGV()
        {
            int[] arr = Element == null ?  new int[] {25,2,1,15} : Element.FibersCoor;

            Fibers_DGV.Rows.Add("Flanges", arr[0], arr[1]);
            Fibers_DGV.Rows.Add("Web", arr[2], arr[3]);

            Fibers_DGV.AllowUserToAddRows = false;
            Fibers_DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Fibers_DGV.RowHeadersVisible = false;
            //set autosize mode
            Fibers_DGV.Columns[0].ReadOnly = true;


        }
        private void IntializeModifiers_DGV()
        {
            Modifiers_DGV.Rows.Add( "A", Element == null? 1.0 : Element.AreaModifier);
            Modifiers_DGV.Rows.Add("Ix", Element == null ? 1.0 : Element.IntertiaModifier);

            Modifiers_DGV.AllowUserToAddRows = false;
            Modifiers_DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Modifiers_DGV.RowHeadersVisible = false;
            //set autosize mode
            Modifiers_DGV.Columns[0].ReadOnly = true;
        }
        private void Name_Tb_TextChanged(object sender, EventArgs e)
        {
            TrySetName();
        }
        private bool TrySetName()
        {
            if (string.IsNullOrEmpty(Name_Tb.Text))
            {
                Name_VLB.Text = "Section Name field is empty";
                return false;
            }

            foreach (var item in Model.FramesFamilies)
            {
                if (item == null || item == Element)
                    continue;
                if (item.Name == Name_Tb.Text)
                {
                    Name_VLB.Text = "Repeated Section Name";
                    return false;
                }
            }
            Name_VLB.Text = "";
            return true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!TrySetName() || !TrySetInitE())
                return;
            int[] arr;
            double areaModifier;
            double interiaModifier; 
            if (!ReadModifers(out areaModifier, out interiaModifier))
                return;
            if (!ReadFibers(out arr))
                return;
            string name = Name_Tb.Text;
            double E = double.Parse(E_TB.Text);
            Material WebMaterial = this.Material_comboBox.SelectedItem as Material;
            Material FlangeMaterial = this.Flange_comboBox.SelectedItem as Material;
            IShapeSection section = this.Section_comboBox.SelectedItem as IShapeSection;
            if (Element == null)
            {
                Element = new FrameElementFamily(name, E, WebMaterial, FlangeMaterial, section);
                Model.FramesFamilies.Add(Element);
            }
            else
            {
                Element.Name = name;
                Element.initE = E;
                Element.Section = section;
                Element.WebMaterial = WebMaterial;
                Element.FlangeMaterial = FlangeMaterial;
            }
            Element.AreaModifier = areaModifier;
            Element.IntertiaModifier = interiaModifier;
            Element.FibersCoor = arr;
            this.Close();
        }

        private bool ReadFibers(out int[] arr)
        {
            arr = null;
            List<int> list = new List<int>();
            foreach (DataGridViewRow row in Fibers_DGV.Rows)
            {
                int v;
                if (!int.TryParse(row.Cells["X"].Value.ToString(), out v))
                    return false;

                list.Add(v);

                if (!int.TryParse(row.Cells["Y"].Value.ToString(), out v))
                    return false;

                list.Add(v);
            }
            arr = list.ToArray();
            return true;
        }

        private bool ReadModifers(out double areaModifier, out double interiaModifier)
        {
            areaModifier = interiaModifier = 1;
            if (!double.TryParse(Modifiers_DGV.Rows[0].Cells["Modifier"].Value.ToString(), out areaModifier))
                return false;
            if (!double.TryParse(Modifiers_DGV.Rows[1].Cells["Modifier"].Value.ToString(), out interiaModifier))
                return false;

            return true;
        }

        private void Material_comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (Material)e.ListItem;
            e.Value = p.BasicData.Name;
        }
        private void Section_comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (IShapeSection)e.ListItem;
            e.Value = p.Name;
        }

        private void E_TB_TextChanged(object sender, EventArgs e)
        {
            TrySetInitE();
        }
        private bool TrySetInitE()
        {
            if (string.IsNullOrEmpty(E_TB.Text))
            {
                E_VLB.Text = "E- Elastic field is empty";
                return false;
            }

            double value;
            if (double.TryParse(E_TB.Text, out value) && value > 0.0)
            {
                E_VLB.Text = "";
                return true;
            }

            E_VLB.Text = "Invalid Input";
            return false;
        }

        private void Flange_comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (Material)e.ListItem;
            e.Value = p.BasicData.Name;
        }

    }
}
