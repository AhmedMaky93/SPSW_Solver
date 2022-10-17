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
    public partial class MaterialDialogsBaseControl : UserControl
    {
        public Action NextAction { get; set; }
        public Action BackAction { get; set; }
        public StageControl OppositeControl { get; set; }

        public static string Elastic_Doc_Url = "https://opensees.berkeley.edu/wiki/index.php/Elastic_Uniaxial_Material";
        public static string ElasticPP_Doc_Url = "https://opensees.berkeley.edu/wiki/index.php/Elastic-Perfectly_Plastic_Material";
        public static string Steel01_Doc_Url = "https://opensees.berkeley.edu/wiki/index.php/Steel01_Material";
        public static string Hysteric_Doc_Url = "https://opensees.berkeley.edu/wiki/index.php/Hysteretic_Material";

        public static string ElasticBeamColumn_Link = "https://opensees.berkeley.edu/wiki/index.php/Elastic_Beam_Column_Element";
        public static string ZeroLengthSection_Link = "https://opensees.berkeley.edu/wiki/index.php/ZeroLength_Element";
        public static string NonlinearBeamColumn_Link = "https://opensees.berkeley.edu/wiki/index.php/Force-Based_Beam-Column_Element";
        public static string DispBeamColumn_Link = "https://opensees.berkeley.edu/wiki/index.php/Displacement-Based_Beam-Column_Element";
        public static string BeamWithHinges_Link = "https://opensees.berkeley.edu/wiki/index.php/Beam_With_Hinges_Element";

        public MaterialDialogsBaseControl()
        {
            InitializeComponent();
        }
        public void SetMainData( Action nextAction, Action backAction, StageControl oppositeControl)
        {
            this.NextAction = nextAction;
            this.OppositeControl = oppositeControl;
            this.BackAction = backAction;
            this.OppositeControl.Status = StageStatus.Current;
        }

        public virtual bool ValidateInput()
        {
            return false;
        }
        public virtual bool SetData()
        {
            return false;
        }
        public void Next()
        {
            if (ValidateInput())
            {
                this.OppositeControl.Status = StageStatus.Accepted;
                SetData();
                NextAction();
            }
            else
            {
                this.OppositeControl.Status = StageStatus.Rejected;
            }
        }

        public void Back()
        {
            this.OppositeControl.Status = StageStatus.Default;
            BackAction();
        }
    }
}
