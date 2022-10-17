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
using ZedGraph;

namespace SPSW_Solver.UI.Selection
{
    public partial class ShearPlateResultFrm : Form
    {
        public int CurrentLoadCase { get; protected set; } = 0;
        protected ShearPlateViewer _viewer;
        public SPBey ShearPlate { get; set; }
        public ShearPlateResultFrm(SPBey shearPlate)
        {
            this.ShearPlate = shearPlate;
            InitializeComponent();
            zedGraphControl1.GraphPane.Title.Text = "";
            
            Forces_Rtbn.Checked = true;
            InitializeGraphTitles();
        }

        private void InitializeGraphTitles()
        {
            ViewerPanel.Controls.Clear();
            _viewer = new ShearPlateViewer(this.ShearPlate);
            _viewer.SelectionChanged += UpdateSelection;
            ViewerPanel.Controls.Add(_viewer);
            _viewer.Dock = DockStyle.Fill;
        }

        private void UpdateSelection(IRenderable selectedObject)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            UITruss selectedTruss = selectedObject as UITruss;
            if (selectedTruss == null)
            {
                this.Text = "Shear Plate Results";
            }
            else
            {
                this.Text = string.Format("Shear Plate Results ( Truss Id : {0} )", selectedTruss.Element.ID);

                PointPairList list = new PointPairList();
                List<double> xvalues = new List<double>();
                List<double> yvalues = new List<double>();
                if (Forces_Rtbn.Checked)
                {
                    xvalues = ObjectProperties.CurrentModel.TimeSteps[CurrentLoadCase];
                    yvalues = selectedTruss.Element.Forces[CurrentLoadCase];
                }
                else if (Strain_Rbtn.Checked)
                {
                    xvalues = ObjectProperties.CurrentModel.TimeSteps[CurrentLoadCase];
                    yvalues = selectedTruss.Element.Deformations[CurrentLoadCase];
                }
                else if(StrainForce_Rtbn.Checked)
                {
                    xvalues = selectedTruss.Element.Deformations[CurrentLoadCase];
                    yvalues = selectedTruss.Element.Forces[CurrentLoadCase];
                }
                int count = Math.Min(xvalues.Count, yvalues.Count);
                for (int i = 0; i < count; i++)
                {
                    list.Add(new PointPair(xvalues[i], yvalues[i]));
                }

                //zedGraphControl1.ZoomPane();
                zedGraphControl1.GraphPane.AddCurve("", list, Color.Red, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();
            }

        }
        private void Forces_Rtbn_CheckedChanged(object sender, EventArgs e)
        {
            if (Forces_Rtbn.Checked)
            {
                zedGraphControl1.GraphPane.YAxis.Title.Text = "Axial Force";
                zedGraphControl1.GraphPane.XAxis.Title.Text = "Time";
                _viewer?.SelectionChanged(_viewer.SelectedObject);
            }
        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Strain_Rbtn.Checked)
            {
                zedGraphControl1.GraphPane.YAxis.Title.Text = "Axial Deformation";
                zedGraphControl1.GraphPane.XAxis.Title.Text = "Time";
                _viewer?.SelectionChanged(_viewer.SelectedObject);
            }
        }
        private void StrainForce_Rtbn_CheckedChanged(object sender, EventArgs e)
        {
            if (StrainForce_Rtbn.Checked)
            {
                zedGraphControl1.GraphPane.YAxis.Title.Text = "Axial Force";
                zedGraphControl1.GraphPane.XAxis.Title.Text = "Axial Deformation";
                _viewer?.SelectionChanged(_viewer.SelectedObject);
            }
        }
        private void ShearPlateResultFrm_Load(object sender, EventArgs e)
        {
            this.loadCaseControl1.SetMain(ObjectProperties.CurrentModel, () =>
            {
                this.CurrentLoadCase = this.loadCaseControl1.CurrentLoadCase;
                Forces_Rtbn_CheckedChanged(null,null);
                RadioButton1_CheckedChanged(null,null);
                StrainForce_Rtbn_CheckedChanged(null,null);
            });

        }

        private void Export_btn_Click(object sender, EventArgs e)
        {
            RenderOptions.ExportToExcel(zedGraphControl1);
        }
    }
}
