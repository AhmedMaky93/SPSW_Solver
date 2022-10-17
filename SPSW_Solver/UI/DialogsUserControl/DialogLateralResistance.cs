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
using ZedGraph;

namespace SPSW_Solver
{
    public partial class DialogLateralResistance : DialogBaseControl
    {
        public static string ErrorMessage = "Invalid Input";
        private ResposeSpectrumData _resposeSpectrumData;
        public DialogLateralResistance()
        {
            InitializeComponent();
        }
        public override bool SetData()
        {
            return true;
        }
        private void UpdateResponseGragh()
        {
            if (!Model.ModalSolved)
                return;

            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            if (IsValidResponse())
            {
                R_Label.Visible = zedGraphControl2.Visible = true;
                _resposeSpectrumData.SetTandCs(Model.GetBuildingHeight() / 12.00, Model.ModalData.ModeShapeData[0].PERIOD);

                PointPairList mainlist = new PointPairList();
                double t = 0.0;
                while (t < _resposeSpectrumData.TL)
                {
                    mainlist.Add(new PointPair(t, _resposeSpectrumData.GetAgResponse(t)));
                    t += 0.1;
                }
                t = _resposeSpectrumData.TL;
                mainlist.Add(new PointPair(t, _resposeSpectrumData.GetAgResponse(t)));
                zedGraphControl2.GraphPane.XAxis.Scale.Max = t;
                zedGraphControl2.GraphPane.YAxis.Scale.Max = 1.1 * mainlist.Max(x => x.Y);
                
                zedGraphControl2.GraphPane.AddCurve("", mainlist, Color.Red, SymbolType.None);

                t = _resposeSpectrumData.T;
                double response = _resposeSpectrumData.Cs;
                PointPairList VLine = new PointPairList();
                VLine.Add(new PointPair(t, 0));
                VLine.Add(new PointPair(t, response));
                zedGraphControl2.GraphPane.AddCurve("", VLine, Color.Black, SymbolType.None);

                PointPairList HLine = new PointPairList();
                HLine.Add(new PointPair(0, response));
                HLine.Add(new PointPair(t, response));
                zedGraphControl2.GraphPane.AddCurve("", HLine, Color.Black, SymbolType.None);
                R_Label.Text = string.Format("T={0},Cs={1}", Math.Round(t, 3), Math.Round(response, 3));
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();
                R_Label.Visible = zedGraphControl2.Visible = true;
            }
            else
            {
                R_Label.Visible = zedGraphControl2.Visible = false;
            }
            
        }
       
        private bool IsValidResponse()
        {
            return TryToSetSD1() && TryToSetSDS() && TryToSetTl() && TrySetI() && TrySetR();
        }
        public override bool ValidateInput()
        {
            if (IsValidResponse())
            {
                return _resposeSpectrumData.Profile == PushOverProfile.Generic ? TrySetK() : true;
            }
            return false;
        }
        private void I_TB_TextChanged(object sender, EventArgs e)
        {
            I_VLB.Text = TrySetI() ? "" : ErrorMessage;
            UpdateResponseGragh();
        }

        private void R_TB_TextChanged(object sender, EventArgs e)
        {
            R_VLB.Text = TrySetR() ? "" : ErrorMessage;
            UpdateResponseGragh();
        }
        private void Ta_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _resposeSpectrumData.UseTa = Ta_CheckBox.Checked;
            UpdateResponseGragh();
        }

        private void SDS_TB_TextChanged(object sender, EventArgs e)
        {
            SDS_VLB.Text = TryToSetSDS() ? "" : ErrorMessage;
            SD1_VLB.Text = TryToSetSD1() ? "" : ErrorMessage;
            UpdateResponseGragh();
        }
        
        private void TL_TB_TextChanged(object sender, EventArgs e)
        {
            TL_VLB.Text = TryToSetTl() ? "" : ErrorMessage;
            UpdateResponseGragh();
        }
        private void SD1_TB_TextChanged(object sender, EventArgs e)
        {
            SDS_VLB.Text = TryToSetSDS() ? "" : ErrorMessage;
            SD1_VLB.Text = TryToSetSD1() ? "" : ErrorMessage;
            UpdateResponseGragh();
        }
        private void DialogLateralResistance_Load(object sender, EventArgs e)
        {
            _resposeSpectrumData = this.Model.AnalysisParameters.SpectralResponse;
            TL_TB.Text = _resposeSpectrumData.TL.ToString();
            SD1_TB.Text = _resposeSpectrumData.SD1.ToString();
            SDS_TB.Text = _resposeSpectrumData.SDs.ToString();
            R_TB.Text = _resposeSpectrumData.R.ToString();
            I_TB.Text = _resposeSpectrumData.I.ToString();
            Ta_CheckBox.Checked = _resposeSpectrumData.UseTa;
            K_TB.Text = _resposeSpectrumData.K.ToString();

            switch (_resposeSpectrumData.Profile)
            {
                case PushOverProfile.SingleTop:
                    Top_Force_btn.Checked = true;
                    break;
                case PushOverProfile.Uniform:
                    Uniform_Profile_btn.Checked = true;
                    break;
                case PushOverProfile.StaticEquivalent:
                    AISCE_btn.Checked = true;
                    break;
                case PushOverProfile.Generic:
                    Generic_btn.Checked = true;
                    break;
            }
            zedGraphControl2.GraphPane.Title.Text = "";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "";
            UpdateResponseGragh();

            zedGraphControl1.GraphPane.Title.Text = "";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "";

            UpdateTheGraph();
        }
        
        private bool TryToSetTl()
        {
            double value;
            if (!double.TryParse(TL_TB.Text, out value))
                return false;
            if (value < 1e-9)
                return false;
            if (value <= _resposeSpectrumData.Ts)
                return false;
            _resposeSpectrumData.TL = value;
            return true;
        }
        private bool TryToSetSD1()
        {
            double value;
            if (!double.TryParse(SD1_TB.Text, out value))
                return false;
            if (value < 1e-9)
                return false;
            if (value >= _resposeSpectrumData.SDs)
                return false;
            _resposeSpectrumData.SD1 = value;
            return true;
        }
        private bool TryToSetSDS()
        {
            double value;
            if (!double.TryParse(SDS_TB.Text, out value))
                return false;
            if (value < 1e-9)
                return false;
            if (value <= _resposeSpectrumData.SD1)
                return false;
            _resposeSpectrumData.SDs = value;
            return true;
        }
        private bool TrySetR()
        {
            double value;
            if (!double.TryParse(R_TB.Text, out value))
                return false;
            if (value < 1e-9)
                return false;
            _resposeSpectrumData.R = value;
            return true;
        }
        private bool TrySetI()
        {
            double value;
            if (!double.TryParse(I_TB.Text, out value))
                return false;
            if (value < 1e-9)
                return false;
            _resposeSpectrumData.I = value;
            return true;
        }

        private void Top_Force_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Top_Force_btn.Checked)
            {
                _resposeSpectrumData.Profile = PushOverProfile.SingleTop;
                zedGraphControl1.GraphPane.CurveList.Clear();
                K_TB.Enabled = zedGraphControl1.Visible = false;
            }
        }
        private void Uniform_Profile_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Uniform_Profile_btn.Checked)
            {
                _resposeSpectrumData.Profile = PushOverProfile.Uniform;
                zedGraphControl1.GraphPane.CurveList.Clear();
                K_TB.Enabled = zedGraphControl1.Visible = false;
            }
        }
        private void Generic_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Generic_btn.Checked)
            {
                _resposeSpectrumData.Profile = PushOverProfile.Generic;
                K_TB.Enabled = zedGraphControl1.Visible = true;
                UpdateTheGraph();
            }
        }
        private bool TrySetK()
        {
            double value;
            if (!double.TryParse(K_TB.Text, out value))
                return false;
            if (value < 1e-9)
                return false;
            _resposeSpectrumData.K = value;
            return true;
        }
        private void K_TB_TextChanged(object sender, EventArgs e)
        {
            K_VLB.Text = TrySetK() ? "" : ErrorMessage;
            UpdateTheGraph();
        }
        private void UpdateTheGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();

            double maxH = Model.Levels.Last().Elevation;
            double minH = Model.Levels.First().Elevation;
            double HT = maxH - minH;
            PointPairList mainlist = new PointPairList();
            for (int i = 0; i < Model.Levels.Count; i++)
            {
                double H = Model.Levels[i].Elevation;
                double v = Math.Pow((H - minH) / (HT), _resposeSpectrumData.K);
                PointPairList list = new PointPairList();
                list.Add(new PointPair(0, i));
                PointPair p = new PointPair(v, i);
                list.Add(p);
                mainlist.Add(p);
                zedGraphControl1.GraphPane.AddCurve("", list, Color.Blue, SymbolType.Circle);
            }
            zedGraphControl1.GraphPane.AddCurve("", mainlist, Color.Red, SymbolType.None);
            //zedGraphControl1.ZoomPane();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        private void AISCE_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (AISCE_btn.Checked)
            {
                _resposeSpectrumData.Profile = PushOverProfile.StaticEquivalent;
                zedGraphControl1.GraphPane.CurveList.Clear();
                K_TB.Enabled = zedGraphControl1.Visible = false;
            }
        }
    }
}
