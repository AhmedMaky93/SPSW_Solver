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
    public partial class StageControl : UserControl
    {
        protected StageStatus _status = StageStatus.Default;

        public StageStatus Status
        {
            get { return _status; }
            set { _status = value; StatusChanged(); }
        }

        private void StatusChanged()
        {
            switch (_status)
            {
                case StageStatus.Default:
                    this.Status_pictureBox.Image = Properties.Resources.question;
                    break;
                case StageStatus.Current:
                    this.Status_pictureBox.Image = Properties.Resources.refresh;
                    break;
                case StageStatus.Accepted:
                    this.Status_pictureBox.Image = Properties.Resources.Completed_check;
                    break;
                case StageStatus.Rejected:
                    this.Status_pictureBox.Image = Properties.Resources.Error;
                    break;
                default:
                    break;
            }
        }

        public StageControl()
        {
            InitializeComponent();
        }

        private void StageControl_Load(object sender, EventArgs e)
        {
            Status = StageStatus.Default;
        }
    }

    public enum StageStatus
    {
        Default,
        Current,
        Accepted,
        Rejected,
    }
}
