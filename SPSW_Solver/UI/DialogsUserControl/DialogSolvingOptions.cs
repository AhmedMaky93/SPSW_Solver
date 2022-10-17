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

namespace SPSW_Solver.UI.DialogsUserControl
{
    public partial class DialogSolvingOptions : UserControl
    {
        public SolverAanalysisOptions _solvingOptions;
        public DialogSolvingOptions()
        {
            InitializeComponent();
        }
        public void InitValues(SolverAanalysisOptions options)
        {
            _solvingOptions = options;
            InitDropdownListByEnum(typeof(Constraints),Constraints_CBox,_solvingOptions.Constraint.ToString());
            InitDropdownListByEnum(typeof(Numberer),Numberer_CBox,_solvingOptions.Numberer.ToString());
            InitDropdownListByEnum(typeof(SPSW_Solver.Model.System),System_CBox,_solvingOptions.System.ToString());
            InitDropdownListByEnum(typeof(TestType),Test_CBox,_solvingOptions.TestType.ToString());
            MaxIter_TB.Text = _solvingOptions.MaxIter.ToString();
            Tolerance_TB.Text = _solvingOptions.Tolerance.ToString();
        }
        private void InitDropdownListByEnum(Type enumType, ComboBox box , string value)
        {
            string[] itemNames = System.Enum.GetNames(enumType);
            for (int i = 0; i < itemNames.Length; i++)
            {
                box.Items.Add(itemNames[i]);
            }
            box.SelectedItem = value;

        }
        
        public bool ValidateAndSetData()
        {
            Constraints selectedConstraints;
            Numberer selectedNumberer;
            SPSW_Solver.Model.System selectedSystem;
            TestType selectedTestType;

            if (!Enum.TryParse(Constraints_CBox.SelectedItem.ToString(), out selectedConstraints))
                return false;
            if (!Enum.TryParse(Numberer_CBox.SelectedItem.ToString(), out selectedNumberer))
                return false;
            if (!Enum.TryParse(System_CBox.SelectedItem.ToString(), out selectedSystem))
                return false;
            if (!Enum.TryParse(Test_CBox.SelectedItem.ToString(), out selectedTestType))
                return false;

            _solvingOptions.Constraint = selectedConstraints;
            _solvingOptions.Numberer = selectedNumberer;
            _solvingOptions.System = selectedSystem;
            _solvingOptions.TestType = selectedTestType;

            bool result = true;
            switch (_solvingOptions.Constraint)
            {
                case Constraints.Lagrange:
                case Constraints.Penalty:
                    result = TrySetAlphaS() && TrySetAlphaM();
                    break;
            }

            if (!result)
                return false;

            switch (_solvingOptions.TestType)
            {
                case TestType.FixedNumIter:
                    result = TrySetMaxIter();
                    break;
                default:
                    result = TrySetMaxIter() && TrySetTolerance();
                    break;    

            }
            return result;
        }

        private void Constraints_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedConstrains = Constraints_CBox.SelectedItem.ToString();
            if (selectedConstrains == Constraints.Plain.ToString()
                || selectedConstrains == Constraints.Transformation.ToString())
            {
                 AlphaS_VLB.Visible = AlphaM_VLB.Visible =
                 alphaS_TB.Enabled  = alphaM_TB.Enabled = false;
            }
            else if (selectedConstrains == Constraints.Lagrange.ToString()
                || selectedConstrains == Constraints.Penalty.ToString())
            {
                alphaS_TB.Enabled = alphaM_TB.Enabled = true;
                alphaS_TB.Text = _solvingOptions.AlphaS.ToString();
                alphaM_TB.Text = _solvingOptions.AlphaM.ToString();
                AlphaS_VLB.Visible = !TrySetAlphaS();
                AlphaM_VLB.Visible = !TrySetAlphaM();
            }
            else 
            { }

        }

        private void Test_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTestType = Test_CBox.SelectedItem.ToString();

            if (selectedTestType == TestType.FixedNumIter.ToString())
            {
                Tolerance_TB.Enabled = Tolerance_VLB.Visible = false;
            }
            else
            {
                Tolerance_TB.Enabled = true;
                Tolerance_TB.Text = _solvingOptions.Tolerance.ToString();
                Tolerance_VLB.Visible = !TrySetTolerance();
            }
        }

        private bool TrySetAlphaS()
        {
            double AlphaS = 0.0;
            if (!double.TryParse(alphaS_TB.Text, out AlphaS))
                return false;

            _solvingOptions.AlphaS = AlphaS;
            return true;
        }

        private void alphaS_TB_TextChanged(object sender, EventArgs e)
        {
            AlphaS_VLB.Visible = !TrySetAlphaS();
        }
        private void alphaM_TB_TextChanged(object sender, EventArgs e)
        {
            AlphaM_VLB.Visible = !TrySetAlphaM();
        }

        private bool TrySetAlphaM()
        {
            double AlphaM = 0.0;
            if (!double.TryParse(alphaM_TB.Text, out AlphaM))
                return false;

            _solvingOptions.AlphaM = AlphaM;
            return true;
        }
        private void Tolerance_TB_TextChanged(object sender, EventArgs e)
        {
            Tolerance_VLB.Visible = !TrySetTolerance();
        }

        private bool TrySetTolerance()
        {
            double Tolerance = 0.0;
            if (!double.TryParse(Tolerance_TB.Text, out Tolerance))
                return false;

            _solvingOptions.Tolerance = Tolerance;
            return true;
        }

        private void MaxIter_TB_TextChanged(object sender, EventArgs e)
        {
            MaxIter_VLB.Visible = !TrySetMaxIter();
        }

        private bool TrySetMaxIter()
        {
            int MaxIter =1;
            if (!int.TryParse(MaxIter_TB.Text, out MaxIter))
                return false;

            if (MaxIter < 1)
                return false;

            _solvingOptions.MaxIter = MaxIter;
            return true;
        }
    }
    

}
