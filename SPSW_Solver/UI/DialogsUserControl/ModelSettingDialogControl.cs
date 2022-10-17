using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Spatial.Units;
using SPSW_Solver.Model;

namespace SPSW_Solver
{
    public partial class ModelSettingDialogControl : DialogBaseControl
    {
        public static string ErrorMessage = "Invalid input";
        public static int MinTrusses = 10;
        

        public string ModelName { get; protected set; } 
        public ModelLayout ModelLayout { get; protected set; }
        public BaseProperties ModelBaseProperties { get; protected set; }
        public int MinStrips { get; protected set; }
        public Angle userAngle  { get; set; }
        public DesignApproach DesignApproach { get; protected set; } 
        public SeismicityLevel SeismicityLevel { get; protected set; } 
        public ModelSettingDialogControl()
        {
            InitializeComponent();
        }
        private void ModelSettingDialogControl_Load(object sender, EventArgs e)
        {
            SetProperties();

            ModelName_VLB.Visible = Width_VLB.Visible = BaseOffset_VLB.Visible = false;
            ModelName_VLB.Text = Min_Str_VLB.Text = Width_VLB.Text= BaseOffset_VLB.Text  = ErrorMessage;

            ModelName_TB.Text = ModelName;
            BaseOffset_TB.Text = ModelBaseProperties.BaseOffset.ToString();

            if (ModelBaseProperties.IsFixed)
                Fixed_Btn.Checked = true;
            else
                Ground_Beam_btn.Checked = true;

            Angle_TB.Text = userAngle.Degrees.ToString();
            PanelZones_Chbox.Checked = Model.IncludePanelZones;
            MinStr_Tb.Text = MinStrips.ToString();
            SetDesignApproachBtns();
        }

        private void SetProperties()
        {
            this.ModelName = Model.Name;
            this.ModelLayout = Model.Layout != null ? Model.Layout : new ModelLayout(); 
            this.ModelBaseProperties = Model.BaseProperties != null ? Model.BaseProperties : new BaseProperties();
            this.DesignApproach = Model.DesignApproach;
            this.MinStrips = Model.MinStrips;
            this.userAngle = Angle.FromDegrees(Model.UserDefinedAngle.Degrees);
        }

        private void SetDesignApproachBtns()
        {
            switch (this.DesignApproach)
            {
                case DesignApproach.AISC_Tension_Field_Angle:
                    this.AISC_Btn.Checked = true;
                    break;
                case DesignApproach.cardiff:
                    this.Carddif_Btn.Checked = true;
                    break;
                case DesignApproach.Basler:
                    this.Basler.Checked = true;
                    break;
                case DesignApproach.UserDefined:
                    this.UserAngle_btn.Checked = true;
                    break;
            }
        }

        #region Try Set Methods
        public bool TrySetModelName()
        {
            if (string.IsNullOrEmpty(ModelName_TB.Text))
                return false;

            ModelName = ModelName_TB.Text;
            return true;
        }
        
        public bool TrySetBaseOffset()
        {
            double baseOFF;
            if (!double.TryParse(BaseOffset_TB.Text, out baseOFF))
                return false;
            if (baseOFF < -1* BaseProperties.Tolerance)
                return false;
            this.ModelBaseProperties.BaseOffset = baseOFF;
            return true;
        }
       
        #endregion
        public override bool ValidateInput()
        {
            return TrySetModelName() && TrySetBaseOffset() && TrySetUserAngle() && TrySetMinStrips();
        }

        public override bool SetData()
        {
            Model.Name = ModelName;
            Model.SetModelDimensions(this.ModelLayout, this.Model.BaseProperties);
            Model.DesignApproach = this.DesignApproach;
            Model.UserDefinedAngle = this.userAngle;
            Model.MinStrips = this.MinStrips;
            Model.CreateMainLines();
            return true;
        }

        #region Text Changed Event
        
        private void ModelName_TB_TextChanged(object sender, EventArgs e)
        {
            ModelName_VLB.Visible = !TrySetModelName();
        }
        
        private void BaseOffset_TB_TextChanged(object sender, EventArgs e)
        {
            BaseOffset_VLB.Visible = !TrySetBaseOffset();
        }
        private void PanelZones_Chbox_CheckedChanged(object sender, EventArgs e)
        {
            Model.IncludePanelZones = PanelZones_Chbox.Checked;
        }

        private void MinStr_Tb_TextChanged(object sender, EventArgs e)
        {
            Min_Str_VLB.Visible = !TrySetMinStrips();
        }
        public bool TrySetMinStrips()
        {
            int i;
            if (!int.TryParse(MinStr_Tb.Text, out i))
                return false;

            if (i < MinTrusses)
                return false;

            MinStrips = i;
            return true;
        }
        #endregion

        #region Enum
        private void AISC_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (AISC_Btn.Checked)
            {
                this.DesignApproach = DesignApproach.AISC_Tension_Field_Angle;
                degrres_Tb.Visible = Angle_TB.Visible = Angle_VLB.Visible = false;
            }
        }
        private void Carddif_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Carddif_Btn.Checked)
            {
                this.DesignApproach = DesignApproach.cardiff;
                degrres_Tb.Visible = Angle_TB.Visible = Angle_VLB.Visible = false;
            }
        }
        private void Brussil_CheckedChanged(object sender, EventArgs e)
        {
            if (Basler.Checked)
            {
                this.DesignApproach = DesignApproach.Basler;
                degrres_Tb.Visible = Angle_TB.Visible = Angle_VLB.Visible = false;
            }
        }
        private void UserAngle_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (UserAngle_btn.Checked)
            {
                this.DesignApproach = DesignApproach.UserDefined;
                degrres_Tb.Visible = Angle_TB.Visible = Angle_VLB.Visible = true;
                Angle_TB.Text = userAngle.Degrees.ToString();
            }
        }
        private void Angle_TB_TextChanged(object sender, EventArgs e)
        {
            TrySetUserAngle();
        }
        private bool TrySetUserAngle()
        {
            if (!Angle_TB.Visible)
                return true;
            double value;
            if (!double.TryParse(Angle_TB.Text, out value))
            {
                Angle_VLB.Text = ErrorMessage;
                return false;
            }
            double min = 10;
            double max = 80;
            if (value < min)
            {
                Angle_VLB.Text = string.Format("min. value = {0}",min);
                return false;
            }
            if (value > max)
            {
                Angle_VLB.Text = string.Format("max. value = {0}", max);
                return false;
            }
            Angle_VLB.Text = "";
            this.userAngle = Angle.FromDegrees(value);
            return true;

        }

        #endregion

        private void AISC_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.aisc.org/products/publication/design-guide/design-guide-20-steel-plate-shear-walls/");
        }
        private void Cardiff_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.researchgate.net/publication/241086951_Postbuckling_and_ultimate_state_of_stresses_in_steel_plate_girders");
        }
        private void Basler_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.researchgate.net/publication/241086951_Postbuckling_and_ultimate_state_of_stresses_in_steel_plate_girders");
        }
        private void Model_Layout_Btn_Click(object sender, EventArgs e)
        {
            Model_Layout_Btn.Enabled = false;
            ModelMainDimensionsfrm frm = new ModelMainDimensionsfrm(this.ModelLayout.Clone() as ModelLayout);
            frm.ShowDialog();
            if (frm.IsValidModel())
            { 
                this.ModelLayout = frm.modelLayout.Clone() as ModelLayout;
            }
            frm.Dispose();
            Model_Layout_Btn.Enabled = true;
        }

        private void Fixed_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Fixed_Btn.Checked)
            {
                BaseOffset_TB.Text = "0.0";
                BaseOffset_TB.Enabled = false;
                ModelBaseProperties.IsFixed = true;
            }
        }
        private void Ground_Beam_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Ground_Beam_btn.Checked)
            {
                BaseOffset_TB.Enabled = true;
                ModelBaseProperties.IsFixed = false;
            }
        }
    }
}
