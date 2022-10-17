using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.BasicModel;
using ZedGraph;
using MathNet.Spatial.Euclidean;

namespace SPSW_Solver
{
    public partial class ElasticMaterialCurveControl : MaterialCurveValidationBaseControl
    {
        public ElasticMaterialCurveControl()
        {
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            MaterialType type = ParentControl.Materialfrm.BasicData.Type;
            List<bool> checks = new List<bool>();
            checks.Add(TrySetDyTension());
            checks.Add(TrySetEta());
            if (type == MaterialType.Generic)
            {
                checks.Add(TrySetDyCompression());
                checks.Add(TrySetEneg());
            }
            return checks.All(x => x);
        }

        private bool TrySetEta()
        {
            double value;
            if (!double.TryParse(Eta_TB.Text, out value))
            {
                Eta_VLB.Text = "Invalid Input";
                return false;
            }
            if (value < -1e-9)
            {
                Eta_VLB.Text = "Must be > 0.0";
                return false;
            }
            return true;
        }

        private bool TrySetEneg()
        {
            double value;
            if (!double.TryParse(Eneg_TB.Text, out value))
            {
                Eneg_VLB.Text = "Invalid Input";
                return false;
            }
            if (value < 1e-9)
            {
                Eneg_VLB.Text = "Must be > 0.0";
                return false;
            }
            return true;
        }
        private bool TrySetDyCompression()
        {
            double value;
            if (!double.TryParse(DyComp_TB.Text, out value))
            {
                DyComp_VLB.Text = "Invalid Input";
                return false;
            }
            if (value > -1e-9)
            {
                DyComp_VLB.Text = "Must be < 0.0";
                return false;
            }
            return true;
        }
        private bool TrySetDyTension()
        {
            double value;
            if (!double.TryParse(DyTension_TB.Text, out value))
            {
                DyTension_VLB.Text = "Invalid Input";
                return false;
            }
            if (value < 1e-9)
            {
                DyTension_VLB.Text = "Must be > 0.0";
                return false;
            }
            return true;
        }

        public override Material CreateMaterial()
        {
            Materialfrm frm = ParentControl.Materialfrm;
            ElasticMaterial m = null;
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    m = ElasticMaterial.CreateGenericMaterial(frm.BasicData, double.Parse(DyTension_TB.Text), double.Parse(DyComp_TB.Text), double.Parse(Eneg_TB.Text), double.Parse(Eta_TB.Text));
                    break;
                case MaterialType.NoCompression:
                    m = ElasticMaterial.CreateNoCompresstionMaterial(frm.BasicData, double.Parse(DyTension_TB.Text) , double.Parse(Eta_TB.Text));
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    m = ElasticMaterial.CreateSymmetricMaterial(frm.BasicData, double.Parse(DyTension_TB.Text), double.Parse(Eta_TB.Text));
                    break;
            }
            return m;
        }
        public override void ClearValidationMessages()
        {
            Eneg_VLB.Text = DyTension_VLB.Text = DyComp_VLB.Text  = Eta_VLB.Text = "";
        }
        public override void InitializeGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();

            Materialfrm frm = ParentControl.Materialfrm;
            double x1 = double.Parse(DyTension_TB.Text);
            double y1 = x1 * frm.BasicData.E;
            double x2 = -1e-9;
            double y2 = -1e-9;

            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    x2 = double.Parse(DyComp_TB.Text);
                    y2 = x2 * double.Parse(Eneg_TB.Text);
                    break;
                case MaterialType.NoCompression:
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    x2 = -x1;
                    y2 = -y1;
                    break;
            }

            PointPairList list = new PointPairList();
            list.Add(x2, y2);
            list.Add(0.0, 0.0);
            list.Add(x1, y1);
            zedGraphControl1.GraphPane.AddCurve("", list, Color.Black, SymbolType.None);

            list = new PointPairList();
            list.Add(x1, 0.0);
            list.Add(x1, y1);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);

            list = new PointPairList();
            list.Add(x2, 0.0);
            list.Add(x2, y2);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

        }

        private void ElasticMaterialCurveControl_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.Title.Text = "Elastic Material";
            switch (ParentControl.Materialfrm.CurveType)
            {
                case MaterialCurve.AngleAndMoment:
                    DyTension_Lb.Text = "Max. +ve Deformation :";
                    DyComp_Lb.Text = "Max. -ve Deformation :";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "M";
                    zedGraphControl1.GraphPane.XAxis.Title.Text = "deformation Angle";
                    break;
                case MaterialCurve.StressAndStrain:
                    DyTension_Lb.Text = "Max. +ve Strain :";
                    DyComp_Lb.Text = "Max. -ve Strain :";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "Stress";
                    zedGraphControl1.GraphPane.XAxis.Title.Text = "Strain";
                    break;
            }

            MaterialType type = ParentControl.Materialfrm.BasicData.Type;
            if (type == MaterialType.NoCompression ||  type == MaterialType.TensionCompressionSymmetric)
            {
                    Compression_Gbox.Visible = false;
            }
            

            if (ParentControl.Materialfrm.Material != null)
            {
                ElasticMaterial m = ParentControl.Materialfrm.Material as ElasticMaterial;
                if (m != null)
                {
                    DyComp_TB.Text = m.Getdy_Compression().ToString();
                    DyTension_TB.Text = m.Getdy_Tension().ToString();
                    Eneg_TB.Text = m.Enegative.ToString();
                    Eta_TB.Text = m.Eta.ToString();
                    InitializeGraph();
                }
            }
        }

        private void ShowPdf_Btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.Elastic_Doc_Url);
        }
    }
}
