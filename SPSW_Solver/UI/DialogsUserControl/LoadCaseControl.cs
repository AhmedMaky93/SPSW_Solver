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
    public enum ResultsShowingOptions
    {
        ShowAll,
        OnlySRSS,
        OnlyPeak
    }
    public partial class LoadCaseControl : UserControl
    {
        private ResultsShowingOptions _options = ResultsShowingOptions.ShowAll;
        protected int _CurrentLoadCases = 0;
        public int CurrentLoadCase
        {
            get { return _CurrentLoadCases; }
            protected set
            {
                _CurrentLoadCases = value;
                if (UpdateAction != null)
                {
                    UpdateAction();
                }
            }
        }
        public ResultsShowingOptions Options
        {
            set
            {
                _options = value;
                SetOptions();
            }
        }
        public int LoadCasesCount { get; set; } = 1;
        public Action UpdateAction;
        public LoadCaseControl()
        {
            InitializeComponent();
        }

        public void SetMain(SPSW_Simple_Model model  , Action action)
        {
            UpdateAction += action;
            LoadCasesCount = model.NumofLoadCases();
            Options = model.AnalysisParameters.GetRunResultOptions();
        }
        private void SetOptions()
        {
            if (LoadCasesCount == 1)
            {
                _options = ResultsShowingOptions.ShowAll;
                this.Visible = false;
                return;
            }
            switch (_options)
            {
                case ResultsShowingOptions.ShowAll:
                    SingleRun_btn.Checked = true;
                    break;
                case ResultsShowingOptions.OnlySRSS:
                    SRss_Rbtn.Checked = true;
                    this.Visible = false;
                    break;
                case ResultsShowingOptions.OnlyPeak:
                    Peak_Rbtn.Checked = true;
                    this.Visible = false;
                    break;
            }
        }
        private void LoadCaseControl_Load(object sender, EventArgs e)
        {
           //SetOptions();
        }

        private void Nxt_btn_Click(object sender, EventArgs e)
        {
            if (CurrentLoadCase < LoadCasesCount-1)
            {
                CurrentLoadCase++;
                SingleRun_btn_CheckedChanged(null,null);
            }
        }
        private void Back_btn_Click(object sender, EventArgs e)
        {
            if (CurrentLoadCase > 0)
            {
                CurrentLoadCase--;
                SingleRun_btn_CheckedChanged(null,null);
            }
        }

        private void SingleRun_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (SingleRun_btn.Checked)
            {
                back_btn.Visible = nxt_btn.Visible = true;
                if (CurrentLoadCase >= LoadCasesCount)
                {
                    CurrentLoadCase = 0;
                }
                ModeShape_LB.Text = (CurrentLoadCase + 1).ToString(); 
            }
        }
        private void SRss_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (SRss_Rbtn.Checked)
            {
                back_btn.Visible = nxt_btn.Visible = false;
                CurrentLoadCase = LoadCasesCount;
            }
        }
        private void Peak_Rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Peak_Rbtn.Checked)
            {
                back_btn.Visible = nxt_btn.Visible = false;
                CurrentLoadCase = LoadCasesCount +1;
            }
        }
    }
}
