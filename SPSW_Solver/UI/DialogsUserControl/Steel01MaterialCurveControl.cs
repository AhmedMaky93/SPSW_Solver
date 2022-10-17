using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using SPSW_Solver.BasicModel;

namespace SPSW_Solver
{
    public partial class Steel01MaterialCurveControl : MaterialCurveValidationBaseControl
    {
        public Steel01MaterialCurveControl()
        {
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            List<bool> checks = new List<bool>();
            checks.Add(TrySetB());
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
            if (type == MaterialType.Generic)
            {
                //if (TrySetDyCompression())
                //{
                //    checks.Add(true);
                    checks.Add(TrySetDUCompression());
                //}
                //else
                //{
                //    checks.Add(false);
                //}
            }

            return checks.All(x => x);
        }
        private bool TrySetB()
        {
            double value;
            if (!double.TryParse(B_TB.Text, out value))
            {
                B_VLB.Text = "Invalid Input";
                return false;
            }
            return true;
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
                if (value > -1 *double.Parse(DyTension_TB.Text))
                {
                    DuComp_VLB.Text = "Must be < " + -1* double.Parse(DyTension_TB.Text);
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
                    DuTension_VLB.Text = "Must be > " + double.Parse(DyTension_TB.Text);
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //private bool TrySetDyCompression()
        //{
        //    double value;
        //    if (!double.TryParse(DyComp_TB.Text, out value))
        //    {
        //        DyComp_VLB.Text = "Invalid Input";
        //        return false;
        //    }
        //    if (value > -1e-9)
        //    {
        //        DyComp_VLB.Text = "Must be < 0.0";
        //        return false;
        //    }
        //    return true;
        //}
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
            Steel01Material m = null;
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    m = Steel01Material.CreateGenericMaterial(frm.BasicData, double.Parse(B_TB.Text), double.Parse(DyTension_TB.Text), double.Parse(DuTension_TB.Text),-1 * double.Parse(DyTension_TB.Text), double.Parse(DuComp_TB.Text));
                    break;
                case MaterialType.NoCompression:
                    m = Steel01Material.CreateNoCompresstionMaterial(frm.BasicData, double.Parse(B_TB.Text), double.Parse(DyTension_TB.Text), double.Parse(DuTension_TB.Text));
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    m = Steel01Material.CreateSymmetricMaterial(frm.BasicData, double.Parse(B_TB.Text), double.Parse(DyTension_TB.Text), double.Parse(DuTension_TB.Text));
                    break;
            }
            return m;
        }
        public override void ClearValidationMessages()
        {
            B_VLB.Text = DyTension_VLB.Text = DuTension_VLB.Text = /*DyComp_VLB.Text =*/ DuTension_VLB.Text = "";
        }
        public override void InitializeGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();

            Materialfrm frm = ParentControl.Materialfrm;
            double b = double.Parse(B_TB.Text);
            double xT1 = double.Parse(DyTension_TB.Text);
            double yT1 = xT1 * frm.BasicData.E;
            double xT2 = double.Parse(DuTension_TB.Text);
            double yT2 = yT1 + frm.BasicData.E * b *(xT2- xT1);
            double xC1 = -1e-9;
            double xC2 = -1e-9;
            double yC1 = -1e-9;
            double yC2 = -1e-9;

            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    xC1 = -1* double.Parse(DyTension_TB.Text);
                    yC1 = xC1 * frm.BasicData.E;
                    xC2 = double.Parse(DuComp_TB.Text);
                    yC2 = yC1 + frm.BasicData.E*b* (xC2 - xC1);
                    break;
                case MaterialType.NoCompression:
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    xC1 = -xT1;
                    xC2 = -xT2;
                    yC1 = -yT1;
                    yC2 = -yT2;
                    break;
            }

            PointPairList list = new PointPairList();
            list.Add(xC2, yC2);
            list.Add(xC1, yC1);
            list.Add(0.0, 0.0);
            list.Add(xT1, yT1);
            list.Add(xT2, yT2);
            zedGraphControl1.GraphPane.AddCurve("", list, Color.Black, SymbolType.None);

            list = new PointPairList();
            list.Add(xT1, 0.0);
            list.Add(xT1, yT1);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);

            list = new PointPairList();
            list.Add(xC1, 0.0);
            list.Add(xC1, yC1);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);


            list = new PointPairList();
            list.Add(xT2, 0.0);
            list.Add(xT2, yT2);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.UltimateLimitColor, SymbolType.None);

            list = new PointPairList();
            list.Add(xC2, 0.0);
            list.Add(xC2, yC2);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.UltimateLimitColor, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        private void Steel01MaterialCurveControl_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.Title.Text = "Steel01 Material";
            switch (ParentControl.Materialfrm.CurveType)
            {
                case MaterialCurve.AngleAndMoment:
                    DyTension_Lb.Text = "Elastic +ve Deformation :";
                    DuTension_Lb.Text = "Plastic -ve Deformation :";
                    //DyComp_Lb.Text = "Elastic Deformation:";
                    DuComp_Lb.Text = "Plastic -ve Deformation :";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "M";
                    zedGraphControl1.GraphPane.XAxis.Title.Text = "deformation Angle";
                    break;
                case MaterialCurve.StressAndStrain:
                    DyTension_Lb.Text = "Elastic +ve Strain :";
                    DuTension_Lb.Text = "Plastic +ve Strain :";
                    //DyComp_Lb.Text = "Elastic Strain:";
                    DuComp_Lb.Text = "Plastic -ve Strain :";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "Stress";
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
                Steel01Material m = ParentControl.Materialfrm.Material as Steel01Material;
                if (m != null)
                {
                    //DyComp_TB.Text = m.Getdy_Compression().ToString();
                    DuComp_TB.Text = m.GetdU_Compression().ToString();
                    DyTension_TB.Text = m.Getdy_Tension().ToString();
                    DuTension_TB.Text = m.GetdU_Tension().ToString();
                    B_TB.Text = m.B.ToString();
                    InitializeGraph();
                }
            }
        }

        private void ShowPdf_Btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.Steel01_Doc_Url);
        }
    }
}
