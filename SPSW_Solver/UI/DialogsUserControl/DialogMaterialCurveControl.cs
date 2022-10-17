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
    public partial class DialogMaterialCurveControl : MaterialDialogsBaseControl
    {
        public MaterialCurveValidationBaseControl Child { get; set; }
        public Materialfrm Materialfrm { get; set; }
        public DialogMaterialCurveControl(Materialfrm parent)
        {
            Materialfrm = parent;
            InitializeComponent();
        }

        public override bool ValidateInput()
        {
            return true;
        }
        private void Back_btn_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void Next_btn_Click(object sender, EventArgs e)
        {
            Next();
        }
        private void Edit_button_Click(object sender, EventArgs e)
        {
            Child?.ClearValidationMessages();
            Child?.zedGraphControl1.GraphPane.CurveList.Clear();
            SetEditMode(true);
        }
        private void Check_button_Click(object sender, EventArgs e)
        {
            if (Child == null)
                return;
            Child.ClearValidationMessages();
            if (Child.ValidateInput())
            {
                Child.InitializeGraph();
                Materialfrm.Material = Child.CreateMaterial();
                SetEditMode(false);
            }
        }
        private void SetEditMode(bool value)
        {
            Next_btn.Enabled = Edit_button.Enabled = !value;
            Check_button.Enabled  = value;
            if(Child != null)
            {
                Child.Enabled = value;
            }
        }

        private void DialogMaterialCurveControl_Load(object sender, EventArgs e)
        {
            switch (Materialfrm.Behavior)
            {
                case BasicModel.MaterialBehaviorType.ElasticMaterial:
                    Child = new ElasticMaterialCurveControl();
                    break;
                case BasicModel.MaterialBehaviorType.Steel01:
                    Child = new Steel01MaterialCurveControl();
                    break;
                case BasicModel.MaterialBehaviorType.ElasticPerfectlyPlasticMaterial:
                    Child = new ElasticPPMaterialCurveControl();
                    break;
                case BasicModel.MaterialBehaviorType.HystereticMaterial:
                    Child = new HystericMaterialCurveControl();
                    break;
            }
            Child.ParentControl = this;
            panel1.Controls.Add(Child);
            SetEditMode(true);
        }
    }
}
