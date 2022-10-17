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

namespace SPSW_Solver
{
    public partial class DialogMaterialBehaviorControl : MaterialDialogsBaseControl
    {
        public Action<MaterialBehaviorType> SetBehavior { get; set; }
        public DialogMaterialBehaviorControl()
        {
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            return true;
        }
        public override bool SetData()
        {
            return true;
        }

        private void DialogMaterialBehaviorControl_Load(object sender, EventArgs e)
        {
            SetGraphProperty(ElasticGraphControl, "Elastic Uniaxial Material", Properties.Resources.Elastic, "an elastic uniaxial material ",Elastic_Doc_Url, MaterialBehaviorType.ElasticMaterial);
            SetGraphProperty(Steel01GraphControl, "Steel01 Material", Properties.Resources.Steel01, "a uniaxial bilinear steel material object with kinematic hardening and optional isotropic hardening",Steel01_Doc_Url, MaterialBehaviorType.Steel01);
            SetGraphProperty(PlastticGraphControl, "Elastic-Perfectly Plastic Material", Properties.Resources.ElasticPP, "an elastic perfectly-plastic uniaxial material", ElasticPP_Doc_Url, MaterialBehaviorType.ElasticPerfectlyPlasticMaterial);
            SetGraphProperty(HysetricGraphControl, "Hysteretic Material", Properties.Resources.Hysteretic, "a uniaxial bilinear hysteretic material with pinching of force and deformation, damage due to ductility and energy, and degraded unloading stiffness based on ductility", Hysteric_Doc_Url, MaterialBehaviorType.HystereticMaterial);
        }
        private void SetGraphProperty(MaterialBehaviorGraphControl graph, string title, Image url, string description, string doc_url, MaterialBehaviorType result)
        {
            graph.SetData(title, url, description, doc_url);
            graph.Click += () =>
            {
                SetBehavior(result);
                Next();
            };
        }
    }
}
