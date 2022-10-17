using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.PythonTranslator;
using SPSW_Solver.Model;

namespace SPSW_Solver
{
    public partial class DialogRunControl : DialogBaseControl
    {
        public Action SaveFile;
        public DialogRunControl(SolverAanalysisOptions options)
        {
            InitializeComponent();
            dialogSolvingOptions1.InitValues(options);
        }

        public override bool ValidateInput()
        {
            return Model.Solved;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!dialogSolvingOptions1.ValidateAndSetData())
                return;

            InitializeTexts();
            StartRun();
        }
        private void StartRun()
        {
            InitializeView();
            if (!CreateInputFile())
            {
                InputCreate_LB.ForeColor = Color.Red;
                InputCreate_LB.Text = "Failed to create Tcl file ..";
                RunFailed();
                return;
            }
            if (!RunOpenSees())
            {
                Running_Lb.ForeColor = Color.Red;
                Running_Lb.Text = "Error in running the file ..";
                RunFailed();
                return;
            }
            if (!SaveDeforamtionValues())
            {
                SaveDeformation_LB.ForeColor = Color.Red;
                SaveDeformation_LB.Text = "Failed in saving deformations ..";
                RunFailed();
                return;
            }
            if (!SaveElementsForces())
            {
                SaveForces_LB.ForeColor = Color.Red;
                SaveForces_LB.Text = "Failed in saving elements forces ..";
                RunFailed();
                return;
            }

            SaveForces_LB.ForeColor = Color.Green;
            progressBar1.Value = 100;
            SaveForces_LB.Text = "Elements Forces are saved ..";
            RunSucceeded();
        }
        private bool SaveElementsForces()
        {
            SaveDeformation_LB.ForeColor = Color.Green;
            progressBar1.Value = 75;
            SaveDeformation_LB.Text = "Nodes deformations are saved ..";
            Current_LB.Text = "Reading elements forces Results ..";
            return OpenSeesTranslator.ReadElementsForcesData(Model);
        }
        private bool SaveDeforamtionValues()
        {
            Running_Lb.ForeColor = Color.Green;
            progressBar1.Value = 50;
            Running_Lb.Text = "Model has been executed ..";


            Current_LB.Text = "Reading deformations Results ..";
            return OpenSeesTranslator.ReadDeformationData(Model);
        }
        private bool RunOpenSees()
        {
            InputCreate_LB.ForeColor = Color.Green;
            progressBar1.Value = 25;
            InputCreate_LB.Text = "Tcl input file is created ..";


            Current_LB.Text = "Running OpenSees.exe ..";
            return OpenSeesTranslator.Run();
        }
        private bool CreateInputFile()
        {
            progressBar1.Value = 2;
            Current_LB.Text = "Creating input Tcl File ..";
            return OpenSeesTranslator.CreateInputFile(this.Model);
        }
        private void InitializeView()
        {
            pictureBox1.Visible = false;
            groupBox1.Visible = true;
            progressBar1.Visible = true;
        }
        private void InitializeTexts()
        {
            pictureBox1.Visible = false;
            groupBox1.Visible = false;

            Current_LB.Text = InputCreate_LB.Text =
            Running_Lb.Text = SaveDeformation_LB.Text =
            SaveForces_LB.Text = "";
        }
        private void DialogRunControl_Load(object sender, EventArgs e)
        {
            InitializeTexts();
        }
        private void RunCompleted(Image url)
        {
            pictureBox1.Image = new Bitmap(url);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Visible = true;
            Current_LB.Text = "";
        }
        private void RunSucceeded()
        {
            if (this.Model.NumofLoadCases() > 1)
            {
                OpenSeesTranslator.AddAccumLoadCase(this.Model,true);
                OpenSeesTranslator.AddAccumLoadCase(this.Model,false);
            }
            RunCompleted(Properties.Resources.Completed_check);
            //OpenSeesTranslator.ClearAnalysisFolder();
            this.Model.Solved = true;
            SaveFile();
        }
        private void RunFailed()
        {
            RunCompleted(Properties.Resources.Error);
            this.Model.Solved = false;
        }

       
    }
}
