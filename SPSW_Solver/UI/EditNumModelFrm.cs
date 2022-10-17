using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
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
    public partial class EditNumModelFrm : Form
    {
        public FrameElementNumericalModel Model { get; set; }
        public SPSW_Simple_Model _sPSW_Model { get; set; }
        protected int floorIndex { get; set; }
        protected Angle Angle { get; set; } = Angle.FromDegrees(45);
        protected int NumofStrips { get; set; } = 10;

        public BaseNumModelUC Control { get; set; }

        public double BeamLength { get { return _sPSW_Model.Layout.GetModelWidth(); } }
        public int BeamSegments { get { return _sPSW_Model.GetNumBeamsSegmentsByFloorIndex(floorIndex, Angle, NumofStrips); } }

        public double ColumnLength { get { return _sPSW_Model.Layout.GetFloorHeight(floorIndex); } }
        public int ColumnSegments { get { return _sPSW_Model.GetNumColumnsSegmentsByFloorIndex(floorIndex, Angle, NumofStrips); } }


        protected NumericalModelViewer _viewer;
        public EditNumModelFrm(FrameElementNumericalModel Model,SPSW_Simple_Model SPSW_Model)
        {
            this.Model = Model;
            _sPSW_Model = SPSW_Model;
            InitializeComponent();
        }
        internal void InitializeTheViewer()
        {
            Viewer_panel.Controls.Clear();
            _viewer?.Dispose();
            _viewer = new NumericalModelViewer();
            _viewer.SelectionChanged += (obj) =>{ };
            if (UpdateViewerRefernces())
            {
                Viewer_panel.Controls.Add(_viewer);
                _viewer.Dock = DockStyle.Fill;
                _viewer.RefreshEx();
            }
            else
            {
                ClearViewer();
            }
        }

        private void ClearViewer()
        {
            _viewer?.Dispose();
            _viewer = null;
            Viewer_panel.Controls.Clear();
        }

        private void EditNumModelFrm_Load(object sender, EventArgs e)
        {
            this.Text = Model.Name;
            this.Floor_TB.Text = "1";
            this.Angle_TB.Text = Angle.Degrees.ToString();
            this.Stirups_TB.Text = NumofStrips.ToString();
            Beam_btn.Checked = true;

            if (_sPSW_Model.BaseProperties.HasOffset)
            {
                BaseColumn_btn.Text = string.Format("Base Column: {0} unit length ", Math.Round(_sPSW_Model.BaseProperties.BaseOffset, 2));
            }
            else
            {
                BaseColumn_btn.Visible = false;
            }
            UpdateLabels();
            InitializeParametersControl();
            D_TB.Text = (Math.Round(0.5 * BeamLength / BeamSegments, 2)).ToString();
            SetMode(true);
        }
        private void InitializeParametersControl()
        {
            
            if (Model is ElasticElement)
            {
                Control = null;
            }
            else if (Model is DistrubutredPlasticity)
            {
                Control = new DPModelUC(Model as DistrubutredPlasticity);
            }
            else if (Model is NonLinearBeams)
            {
                Control = new NonLinearEndNumModelUC(Model as NonLinearBeams);
            }
            else if (Model is FiberPlasticSections)
            {
                Control = new FibersZeroLengthNumModelUC(Model as FiberPlasticSections);
            }
            else if (Model is BeamWithHingesModel)
            {
                Control = new BWHNumModelUC(Model as BeamWithHingesModel);
            }

            if (Control != null)
            {
                Control_panel.Controls.Add(Control);
                Control.Dock = DockStyle.Fill;
            }
        }

        private void UpdateLabels()
        {
            Beam_btn.Text = string.Format("Beam: {0} unit length - {1} segments ({2} for each)", Math.Round(BeamLength, 2), BeamSegments, Math.Round(BeamLength / BeamSegments, 2));
            Column_btn.Text = string.Format("Column: {0} unit length - {1} segments ({2} for each)", Math.Round(ColumnLength, 2), ColumnSegments, Math.Round(ColumnLength / ColumnSegments, 2));

        }

        private void UpdateTheViewer()
        {
            if (Check_btn.Enabled)
                return;
            UpdateLabels();
            InitializeTheViewer();
        }
        private bool UpdateViewerRefernces()
        {
            double d;
            if (!GetViewerSectionDepth(out d))
            {
                return false;
            }
            Vector2D v = new Vector2D(0,1);
            double length = 0.0;
            int segments = 1;

            if (Beam_btn.Checked)
            {
                v = new Vector2D(1,0);
                length = BeamLength;
                segments = BeamSegments;
            }
            else if (Column_btn.Checked)
            {
                length = ColumnLength;
                segments = ColumnSegments;
            }
            else if (BaseColumn_btn.Checked)
            {
                length = _sPSW_Model.BaseProperties.BaseOffset;
            }
            _viewer.CreateMainElements(Model, d, length,segments, v);
            return true;
        }
        private void SetMode(bool edit)
        {
            if (Control == null)
            {
                Check_btn.Enabled = Edit_btn.Enabled = false;
                InitializeTheViewer();
                return;
            }

            Edit_btn.Enabled = Ok_button.Enabled = !edit;
            Check_btn.Enabled = Control.Enabled = edit;
            if (edit)
                ClearViewer();
            else
                InitializeTheViewer();
        }
        private void Check_btn_Click(object sender, EventArgs e)
        {
            if (Control.IsValidParameters())
            {
                SetMode(false);
            }
        }
        private void Edit_btn_Click(object sender, EventArgs e)
        {
            SetMode(true);
        }
        private void Ok_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BaseColumn_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (BaseColumn_btn.Checked)
            {
                UpdateTheViewer();
            }
        }
        private void Column_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Column_btn.Checked)
            {
                UpdateTheViewer();
            }
        }
        private void Beam_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Beam_btn.Checked)
            {
                UpdateTheViewer();
            }
        }
        private void D_TB_TextChanged(object sender, EventArgs e)
        {
            double d;
            if (GetViewerSectionDepth(out d))
            {
                UpdateTheViewer();
            }
        }
        private bool GetViewerSectionDepth(out double d)
        {
            d = 0.0;
            if (string.IsNullOrEmpty(D_TB.Text))
                return false;
            if (!double.TryParse(D_TB.Text,out d) || d < 1e-9)
                return false;
            return true;
        }

        private void Floor_TB_TextChanged(object sender, EventArgs e)
        {
            int floor_index;
            if (!int.TryParse(Floor_TB.Text,out floor_index))
                return;
            if (floor_index > 0 && floor_index < _sPSW_Model.Layout.FloorNo)
            {
                this.floorIndex = floorIndex;
                UpdateTheViewer();
            }
        }

        private void Angle_TB_TextChanged(object sender, EventArgs e)
        {
            double angleDegrees;
            if (!double.TryParse(Angle_TB.Text, out angleDegrees))
                return;
            if (angleDegrees > 0 && angleDegrees < 90)
            {
                this.Angle = Angle.FromDegrees(angleDegrees);
                UpdateTheViewer();
            }
        }

        private void Stirups_TB_TextChanged(object sender, EventArgs e)
        {
            int Stirups;
            if (!int.TryParse(Stirups_TB.Text, out Stirups))
                return;
            if (Stirups >= _sPSW_Model.MinStrips)
            {
                this.NumofStrips = Stirups;
                UpdateTheViewer();
            }
        }

    }
}
