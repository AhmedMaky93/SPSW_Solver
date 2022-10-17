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

namespace SPSW_Solver
{
    public partial class ElasticPPMaterialCurveControl : MaterialCurveValidationBaseControl
    {
        public ElasticPPMaterialCurveControl()
        {
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            List<bool> checks = new List<bool>();
            if (TrySetDyTension())
            {
                checks.Add(true);
                checks.Add(TrySetDUTension());

            }
            else
            {
                checks.Add(false);
            }
            MaterialType type = ParentControl.Materialfrm.BasicData.Type;
            if (type == MaterialType.Generic )
            {
                if (TrySetDyCompression())
                {
                    checks.Add(true);
                    checks.Add(TrySetDUCompression());
                }
                else
                {
                    checks.Add(false);
                }
            }

            return checks.All(x =>x);
        }
        private bool TrySetDUCompression()
        {
            try
            {
                double value;
                if (!double.TryParse(DuComp_TB.Text, out value))
                {
                    DuComp_VLB.Text = "Invalid Input";
                    return false;
                }
                if (value > double.Parse(DyComp_TB.Text))
                {
                    DuComp_VLB.Text = "Must be < "+ double.Parse(DyComp_TB.Text);
                    return false;
                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        private bool TrySetDUTension()
        {
            try
            {
                double value;
                if (!double.TryParse(DuTension_TB.Text, out value))
                {
                    DuTension_VLB.Text = "Invalid Input";
                    return false;
                }
                if (value < double.Parse(DyTension_TB.Text))
                {
                    DuTension_VLB.Text = "Must be > "+ double.Parse(DyTension_TB.Text);
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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
            ElasticPerfectlyPlasticMaterial m = null;
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    m = ElasticPerfectlyPlasticMaterial.CreateGenericMaterial(frm.BasicData, double.Parse(DyTension_TB.Text), double.Parse(DuTension_TB.Text), double.Parse(DyComp_TB.Text), double.Parse(DuComp_TB.Text));
                    break;
                case MaterialType.NoCompression:
                    m = ElasticPerfectlyPlasticMaterial.CreateNoCompresstionMaterial(frm.BasicData, double.Parse(DyTension_TB.Text), double.Parse(DuTension_TB.Text));
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    m = ElasticPerfectlyPlasticMaterial.CreateSymmetricMaterial(frm.BasicData, double.Parse(DyTension_TB.Text), double.Parse(DuTension_TB.Text));
                    break;
            }
            return m;
        }
        public override void ClearValidationMessages()
        {
            DyTension_VLB.Text = DuTension_VLB.Text = DyComp_VLB.Text = DuTension_VLB.Text = "";
        }
        public override void InitializeGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();

            Materialfrm frm = ParentControl.Materialfrm;
            double xT1 = double.Parse(DyTension_TB.Text);
            double yT = xT1 * frm.BasicData.E;
            double xT2 = double.Parse(DuTension_TB.Text);
            double xC1 = -1e-9;
            double xC2 = -1e-9;
            double yC = -1e-9;

            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    xC1 = double.Parse(DyComp_TB.Text);
                    yC = xC1 * frm.BasicData.E;
                    xC2 = double.Parse(DuComp_TB.Text);
                    break;
                case MaterialType.NoCompression:
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    xC1 = -xT1;
                    xC2 = -xT2;
                    yC = -yT;
                    break;
            }

            PointPairList list = new PointPairList();
            list.Add(xC2, yC);
            list.Add(xC1, yC);
            list.Add(0.0, 0.0);
            list.Add(xT1, yT);
            list.Add(xT2, yT);
            zedGraphControl1.GraphPane.AddCurve("", list, Color.Black, SymbolType.None);

            list = new PointPairList();
            list.Add(xT1, 0.0);
            list.Add(xT1, yT);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);

            list = new PointPairList();
            list.Add(xC1, 0.0);
            list.Add(xC1, yC);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);


            list = new PointPairList();
            list.Add(xT2, 0.0);
            list.Add(xT2, yT);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.UltimateLimitColor, SymbolType.None);

            list = new PointPairList();
            list.Add(xC2, 0.0);
            list.Add(xC2, yC);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.UltimateLimitColor, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        private void ElasticPPMaterialCurveControl_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.Title.Text = "Elastic perfect Plastic Material";
            switch (ParentControl.Materialfrm.CurveType)
            {
                case MaterialCurve.AngleAndMoment:
                    DyTension_Lb.Text = "Elastic +ve Deformation :";
                    DuTension_Lb.Text = "Plastic +ve Deformation :";
                    DyComp_Lb.Text = "Elastic -ve Deformation :";
                    DuComp_Lb.Text = "Plastic -ve Deformation :";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "M";
                    zedGraphControl1.GraphPane.XAxis.Title.Text = "deformation Angle";
                    break;
                case MaterialCurve.StressAndStrain:
                    DyTension_Lb.Text = "Elastic +ve Strain :";
                    DuTension_Lb.Text = "Plastic +ve Strain :";
                    DyComp_Lb.Text = "Elastic -ve Strain :";
                    DuComp_Lb.Text = "Plastic -ve Strain :";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "p";
                    zedGraphControl1.GraphPane.XAxis.Title.Text = "Strain";
                    break;
            }

            MaterialType type = ParentControl.Materialfrm.BasicData.Type;
            if (type == MaterialType.NoCompression || type == MaterialType.TensionCompressionSymmetric)
            {
                Compression_Gbox.Visible = false;
            }


            if (ParentControl.Materialfrm.Material != null)
            {
                ElasticPerfectlyPlasticMaterial m = ParentControl.Materialfrm.Material as ElasticPerfectlyPlasticMaterial;
                if (m != null)
                {
                    DyComp_TB.Text = m.Getdy_Compression().ToString();
                    DuComp_TB.Text = m.GetdU_Compression().ToString();
                    DyTension_TB.Text = m.Getdy_Tension().ToString();
                    DuTension_TB.Text = m.GetdU_Tension().ToString();
                    InitializeGraph();
                }
            }
        }

        private void ShowPdf_Btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.ElasticPP_Doc_Url);
        }
    }
}
