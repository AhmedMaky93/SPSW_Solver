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
    public partial class PlateSectionFrm : Form
    {
        public SPSW_Simple_Model Model { get; set; }
        public PlateFamily Element { get; set; }
        public PlateSectionFrm()
        {
            InitializeComponent();
        }
        private void Name_Tb_TextChanged(object sender, EventArgs e)
        {
            TrySetName();
        }
        private void Thickness_Tb_TextChanged(object sender, EventArgs e)
        {
            TrySetThickness();
        }

        private void PlateSectionFrm_Load(object sender, EventArgs e)
        {
            this.Material_comboBox.DataSource = this.Model.Materials;
            if (Element == null)
            {
                Thickness_Tb.Text  =Name_Tb.Text = "";
                Modifier_TB.Text = "1.0";
                return;              
            }
            Name_Tb.Text = Element.Name;
            Material_comboBox.SelectedIndex = this.Model.Materials.IndexOf(Element.Material);
            Thickness_Tb.Text = Element.Thickness.ToString();
            Modifier_TB.Text = Element.AreaModifier.ToString();
        }
        private bool TrySetName()
        {
            if (string.IsNullOrEmpty(Name_Tb.Text))
            {
                Name_VLB.Text = "Section Name field is empty";
                return false;
            }

            foreach (var item in Model.PlateFamilies)
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
        private bool TrySetThickness()
        {
            if (string.IsNullOrEmpty(Thickness_Tb.Text))
            {
               Thickness_VLB.Text = "Plate thickness field is empty";
                return false;
            }
            double value;
            if (!double.TryParse(Thickness_Tb.Text,out value) || value<0)
            {
                Thickness_VLB.Text = "InValid Input";
                return false;
            }
            Thickness_VLB.Text = "";
            return true;
        }

        private bool TrySetModifer()
        {
            if (string.IsNullOrEmpty(Modifier_TB.Text))
            {
                Modifier_VLB.Text = "Section area modifier field is empty";
                return false;
            }
            double value;
            if (!double.TryParse(Modifier_TB.Text, out value) || value < 0)
            {
                Modifier_VLB.Text = "InValid Input";
                return false;
            }
            Modifier_VLB.Text = "";
            return true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!TrySetName())
                return;
            if (!TrySetThickness())
                return;
            if (!TrySetModifer())
                return;
            string name = Name_Tb.Text;
            Material m = this.Material_comboBox.SelectedItem as Material;
            double thickness = double.Parse(Thickness_Tb.Text);
            double areaModifier = double.Parse(Modifier_TB.Text);
            if (Element == null)
            {
                Model.PlateFamilies.Add(new PlateFamily(name, m, thickness , areaModifier));
            }
            else
            {
                Element.Name = name;
                Element.Thickness = thickness;
                Element.Material = m;
                Element.AreaModifier = areaModifier;
            }
            this.Close();
        }

        private void Material_comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var p = (Material)e.ListItem;
            e.Value = p.BasicData.Name;
        }
        private void Modifier_TB_TextChanged(object sender, EventArgs e)
        {
            TrySetModifer();
        }
    }
}
