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
    public partial class ModalAnalysisReportFrm : Form
    {
        public ModalAnalysisData Data { get; set; }
        public ModalAnalysisReportFrm(ModalAnalysisData modalAnalysisData)
        {
            this.Data = modalAnalysisData;
            InitializeComponent();
        }

        private void ModalAnalysisReportFrm_Load(object sender, EventArgs e)
        {
            TMX_LB.Text = Data.SumMx.ToString();
            TMY_LB.Text = Data.SumMy.ToString();
            TMRZ_LB.Text = Data.SumMrz.ToString();

            foreach (var modeShape in Data.ModeShapeData)
            {
                 dataGridView1.Rows.Add(modeShape.Index,modeShape.LAMBDA , modeShape.OMEGA , modeShape.FREQUENCY , modeShape.PERIOD , 
                     modeShape.MX , modeShape.MY , modeShape.MRZ , modeShape.SumMx , modeShape.SumMy , modeShape.SumMrz );
            }
        }
    }
}
