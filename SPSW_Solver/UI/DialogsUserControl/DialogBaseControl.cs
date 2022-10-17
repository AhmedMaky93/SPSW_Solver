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
   
	
    public partial class DialogBaseControl : UserControl
    {
        protected SPSW_Simple_Model Model { get; set; }
        public Action NextAction { get; set; }
        public Action BackAction { get; set; }
        public StageControl OppositeControl { get; set; }

        public DialogBaseControl()
        {
            InitializeComponent();
        }

        public void SetMainData(SPSW_Simple_Model model , ModelStage stage, Action nextAction, Action backAction, StageControl oppositeControl)
        {
            this.Model = model;
            this.Model.Stage = stage;
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
        private void Next_button_Click(object sender, EventArgs e)
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

        private void Back_button_Click(object sender, EventArgs e)
        {
            this.OppositeControl.Status = StageStatus.Default;
            BackAction();
        }
    }
}
