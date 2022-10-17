using SPSW_Solver.BasicModel;
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
    public partial class Materialfrm : Form
    {
        public MaterialCurve CurveType { get; set; } = MaterialCurve.StressAndStrain;
        public MaterialBehaviorType Behavior { get; set; }
        public MaterialBasicData BasicData { get; set; }
        public List<string> MaterialNames { get; set; }
        public Material Material { get; set; }
        public Action<Material> SetReference;
        public Materialfrm(Material Material , List<string> MaterialNames)
        {
            this.Material = Material;
            this.MaterialNames = MaterialNames;
            if (Material != null)
            {
                MaterialNames.Remove(Material.BasicData.Name);
            }
            InitializeComponent();
        }
        private void Materialfrm_Load(object sender, EventArgs e)
        {
            if (Material == null)
            {
                BasicData = new MaterialBasicData();
                InitializeBehaviorControl();
            }
            else
            {
                SetBehavior(Material);
                BasicData = Material.BasicData;
                this.materialPropertiesStageControl1.Status = this.materialBehaviorStageControl1.Status = StageStatus.Accepted;
                InitializeMaterialCurveControl();
            }
        }
        private void SetBehavior(Material material)
        {
            Type t = material.GetType();
            if (t == typeof(ElasticMaterial))
            { Behavior = MaterialBehaviorType.ElasticMaterial; }
            else if (t == typeof(ElasticPerfectlyPlasticMaterial))
            { Behavior = MaterialBehaviorType.ElasticPerfectlyPlasticMaterial; }
            else if (t == typeof(Steel01Material))
            { Behavior = MaterialBehaviorType.Steel01; }
            else if (t == typeof(HystereticMaterial))
            { Behavior = MaterialBehaviorType.HystereticMaterial; }
        }
        private void InitializeBehaviorControl()
        {
            Material = null;
            Dialogs_panel.Controls.Clear();
            DialogMaterialBehaviorControl control = new DialogMaterialBehaviorControl();
            control.SetBehavior += (MaterialBehaviorType b) => { this.Behavior = b; };
            control.SetMainData(InitializeBasicDataControl, () => { },this.materialBehaviorStageControl1);
            Dialogs_panel.Controls.Add(control);
        }
        private void InitializeBasicDataControl()
        {
            Dialogs_panel.Controls.Clear();
            DialogMaterialBasicDataControl control = new DialogMaterialBasicDataControl(this.BasicData);
            control.Names = MaterialNames;
            control.SetMainData(InitializeMaterialCurveControl, InitializeBehaviorControl, this.materialPropertiesStageControl1);
            Dialogs_panel.Controls.Add(control);
        }
        private void InitializeMaterialCurveControl()
        {
            Dialogs_panel.Controls.Clear();
            DialogMaterialCurveControl control = new DialogMaterialCurveControl(this);
            control.SetMainData(() => {
                SetReference(this.Material);
            }, InitializeBasicDataControl, this.materialCurveStageContro11);
            Dialogs_panel.Controls.Add(control);
        }
    }
}
