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
using MathNet.Spatial.Euclidean;
using ZedGraph;
using System.IO;
using System.Reflection;

namespace SPSW_Solver
{
    public partial class HystericMaterialCurveControl : MaterialCurveValidationBaseControl
    {
        public HystericMaterialCurveControl()
        {
            InitializeComponent();
        }
        public override bool ValidateInput()
        {
            MaterialType type = ParentControl.Materialfrm.BasicData.Type;
            if (type == MaterialType.Generic)
            {
                bool b1 = ValidateTensionPart();
                bool b2 = ValidateCompressionPart();
                return b1 && b2;
            }
            else
            {
                return ValidateTensionPart();
            }
        }
        private bool ValidateCompressionPart()
        {
            Curve3Points curvePart;
            if (!GetPointsPart(CompressionGridView, CompressionPoints_VLB, DfComp_TB.Text, DfComp_VLB, out curvePart))
            {
                CompressionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (curvePart.AsVector().Select(x => x.Y).Any(x => x > 0.0))
            {
                CompressionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (0 < curvePart.P1.X)
            {
                CompressionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (curvePart.P1.X < curvePart.P2.X && Math.Abs(curvePart.P1.X - curvePart.P2.X) > 1e-5)
            {
                CompressionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (curvePart.P2.X < curvePart.P3.X && Math.Abs(curvePart.P2.X - curvePart.P3.X) > 1e-5)
            {
                CompressionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (curvePart.P3.X < curvePart.CurveLimit && Math.Abs(curvePart.P3.X - curvePart.CurveLimit) > 1e-5)
            {
                DfComp_VLB.Text = "Must be <" + curvePart.P3.X;
                return false;
            }
            
            return true;
        }
        public bool ValidateTensionPart()
        {
            Curve3Points curvePart;
            if (!GetPointsPart(TensionGridView, TensionPoints_VLB, DfTension_TB.Text, DfTension_VLB, out curvePart))
            {
                return false;
            }
            if (curvePart.AsVector().Select(x => x.Y).Any(x => x < 0.0))
            {
                TensionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (0 > curvePart.P1.X)
            {
                TensionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (curvePart.P1.X > curvePart.P2.X && Math.Abs(curvePart.P1.X - curvePart.P2.X) > 1e-5)
            {
                TensionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (curvePart.P2.X > curvePart.P3.X && Math.Abs(curvePart.P2.X - curvePart.P3.X) > 1e-5)
            {
                TensionPoints_VLB.Text = "Invalid points";
                return false;
            }
            if (curvePart.P3.X > curvePart.CurveLimit && Math.Abs(curvePart.P3.X - curvePart.CurveLimit) > 1e-5)
            {
                DfTension_VLB.Text = "Must be >" + curvePart.P3.X;
                return false;
            }
            
            return true;
        }
        public override void InitializeGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            PointPairList list = GetMainCurve();
            zedGraphControl1.GraphPane.AddCurve("", list, Color.Black, SymbolType.None);

            AddElasticLimitLines();
            AddEndLimitsLines();
            AddPlasticLimitLines();

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        private void AddPlasticLimitLines()
        {
            Curve3Points tensionPart;
            GetPointsPart(TensionGridView, TensionPoints_VLB, DfTension_TB.Text, DfTension_VLB, out tensionPart);
            Materialfrm frm = ParentControl.Materialfrm;
            Point2D p4 = tensionPart.GetPointByX(tensionPart.GetPlasticLimit(), true);
            PointPairList list = new PointPairList();
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    Curve3Points CompressionPart;
                    GetPointsPart(CompressionGridView, CompressionPoints_VLB, DfComp_TB.Text, DfComp_VLB, out CompressionPart);
                    list = new PointPairList();
                    Point2D p44 = CompressionPart.GetPointByX(CompressionPart.GetPlasticLimit(), false);
                    list.Add(p44.X, 0.0);
                    list.Add(p44.X, p44.Y);
                    zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.UltimateLimitColor, SymbolType.None);
                    break;
                case MaterialType.NoCompression:
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    list = new PointPairList();
                    list.Add(-1 * p4.X, 0.0);
                    list.Add(-1 * p4.X, -1 * p4.Y);
                    zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.UltimateLimitColor, SymbolType.None);
                    break;
            }
            list = new PointPairList();
            list.Add(p4.X, 0.0);
            list.Add(p4.X, p4.Y);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.UltimateLimitColor, SymbolType.None);
        }
        private void AddElasticLimitLines()
        {
            Curve3Points tensionPart;
            GetPointsPart(TensionGridView, TensionPoints_VLB, DfTension_TB.Text, DfTension_VLB, out tensionPart);
            Materialfrm frm = ParentControl.Materialfrm;
            Point2D p4 = tensionPart.GetPointByX(tensionPart.GetElasticLimit(), true);
            PointPairList list = new PointPairList();
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    Curve3Points CompressionPart;
                    GetPointsPart(CompressionGridView, CompressionPoints_VLB, DfComp_TB.Text, DfComp_VLB, out CompressionPart);
                    list = new PointPairList();
                    Point2D p44 = CompressionPart.GetPointByX(CompressionPart.GetElasticLimit(), false);
                    list.Add(p44.X, 0.0);
                    list.Add(p44.X, p44.Y);
                    zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);
                    break;
                case MaterialType.NoCompression:
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    list = new PointPairList();
                    list.Add(-1 * p4.X, 0.0);
                    list.Add(-1 * p4.X, -1 * p4.Y);
                    zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);
                    break;
            }
            list = new PointPairList();
            list.Add(p4.X, 0.0);
            list.Add(p4.X, p4.Y);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.ElasticLimitColor, SymbolType.None);
        }
        private void AddEndLimitsLines()
        {
            Curve3Points tensionPart;
            GetPointsPart(TensionGridView, TensionPoints_VLB, DfTension_TB.Text, DfTension_VLB, out tensionPart);
            Materialfrm frm = ParentControl.Materialfrm;
            Point2D p4 = tensionPart.GetLastPointPositive();
            PointPairList list = new PointPairList();
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    Curve3Points CompressionPart;
                    GetPointsPart(CompressionGridView, CompressionPoints_VLB, DfComp_TB.Text, DfComp_VLB, out CompressionPart);
                    list = new PointPairList();
                    Point2D p44 = CompressionPart.GetLastPointNegative();
                    list.Add(p44.X, 0.0);
                    list.Add(p44.X, p44.Y);
                    zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.FailureLimitColor, SymbolType.None);
                    break;
                case MaterialType.NoCompression:
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    list = new PointPairList();
                    list.Add(-1 * p4.X, 0.0);
                    list.Add(-1 * p4.X, -1 * p4.Y);
                    zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.FailureLimitColor, SymbolType.None);
                    break;
            }
            list = new PointPairList();
            list.Add(p4.X, 0.0);
            list.Add(p4.X, p4.Y);
            zedGraphControl1.GraphPane.AddCurve("", list, RenderOptions.FailureLimitColor, SymbolType.None);
        }
        private PointPairList GetMainCurve()
        {
            Curve3Points tensionPart;
            GetPointsPart(TensionGridView, TensionPoints_VLB, DfTension_TB.Text, DfTension_VLB, out tensionPart);
            Materialfrm frm = ParentControl.Materialfrm;
            PointPairList list = new PointPairList();
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    Curve3Points CompressionPart;
                    GetPointsPart(CompressionGridView, CompressionPoints_VLB, DfComp_TB.Text, DfComp_VLB, out CompressionPart);
                    Point2D tpC4 = CompressionPart.GetLastPointNegative();
                    list.Add(tpC4.X, tpC4.Y);
                    list.Add(CompressionPart.P3.X,CompressionPart.P3.Y);
                    list.Add(CompressionPart.P2.X,CompressionPart.P2.Y);
                    list.Add(CompressionPart.P1.X,CompressionPart.P1.Y);
                    break;
                case MaterialType.NoCompression:
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    Point2D tpp4 = tensionPart.GetLastPointPositive();
                    list.Add(-1*tpp4.X,-1* tpp4.Y);
                    list.Add(-1*tensionPart.P3.X,-1* tensionPart.P3.Y);
                    list.Add(-1*tensionPart.P2.X,-1* tensionPart.P2.Y);
                    list.Add(-1*tensionPart.P1.X,-1* tensionPart.P1.Y);
                    break;
            }
            list.Add(0.0,0.0);
            list.Add(tensionPart.P1.X, tensionPart.P1.Y);
            list.Add(tensionPart.P2.X, tensionPart.P2.Y);
            list.Add(tensionPart.P3.X, tensionPart.P3.Y);
            Point2D tp4 = tensionPart.GetLastPointPositive();
            list.Add(tp4.X, tp4.Y);
            return list;

        }
        public override Material CreateMaterial()
        {
            
            Materialfrm frm = ParentControl.Materialfrm;
            HystereticMaterial m = null;
            Curve3Points tensionPart;
            GetPointsPart(TensionGridView, TensionPoints_VLB, DfTension_TB.Text, DfTension_VLB, out tensionPart);
            switch (frm.BasicData.Type)
            {
                case MaterialType.Generic:
                    Curve3Points CompressionPart;
                    GetPointsPart(CompressionGridView, CompressionPoints_VLB, DfComp_TB.Text, DfComp_VLB, out CompressionPart);
                    m = HystereticMaterial.CreateGenericMaterial(frm.BasicData, tensionPart , CompressionPart);
                    break;
                case MaterialType.NoCompression:
                    m = HystereticMaterial.CreateNoCompresstionMaterial(frm.BasicData, tensionPart);
                    break;
                case MaterialType.TensionCompressionSymmetric:
                    m = HystereticMaterial.CreateSymmetricMaterial(frm.BasicData, tensionPart);
                    break;
            }
            return m;
        }
        public bool GetPointsPart(DataGridView dgv  , System.Windows.Forms.Label pointslabel , string limit , System.Windows.Forms.Label limitLabel, out Curve3Points curvePart)
        {
            curvePart = new Curve3Points();

            bool b1 = true;
            bool b2 = true;

            Point2D point;
            if (!ReadPoint(dgv.Rows[0], out point))
            {
                b1 = false;
            }
            else
            {
                curvePart.P1 = point;
            }

            if (!ReadPoint(dgv.Rows[1], out point))
            {
                b1 = false;
            }
            else
            {
                curvePart.P2 = point;
            }

            if (!ReadPoint(dgv.Rows[2], out point))
            {
                b1 = false;
            }
            else
            {
                curvePart.P3 = point;
            }
            if (!b1)
            {
                pointslabel.Text = "Invalid Points";
            }
            double value;
            if (!double.TryParse(limit, out value))
            {
                limitLabel.Text = "Invalid Input";
                b2 = false;
            }
            else
            {
                b2 = true;
                curvePart.CurveLimit = value;
            }
            return b1 && b2;
        }
        public bool ReadPoint(DataGridViewRow row, out Point2D point)
        {
            point = new Point2D();
            double x ,  y =0.0;
            if (!double.TryParse(row.Cells[1].Value.ToString(),out x))
                return false;
            if (!double.TryParse(row.Cells[2].Value.ToString(), out y))
                return false;
            point = new Point2D(x,y);
            return true;
        }
        public override void ClearValidationMessages()
        {
            TensionPoints_VLB.Text = CompressionPoints_VLB.Text = DfTension_VLB.Text  = DfComp_VLB.Text  = "";
        }
        private void HystericMaterialCurveControl_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.Title.Text = "Hysteric Material";
            switch (ParentControl.Materialfrm.CurveType)
            {
                case MaterialCurve.AngleAndMoment:
                    DfTension_Lb.Text = "Max. +ve Deformation:";
                    DfComp_Lb.Text = "Max. -ve Deformation:";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "M";
                    zedGraphControl1.GraphPane.XAxis.Title.Text = "deformation Angle";
                    break;
                case MaterialCurve.StressAndStrain:
                    DfTension_Lb.Text = "Max. +ve Strain:";
                    DfComp_Lb.Text = "Max. -ve Strain:";
                    zedGraphControl1.GraphPane.YAxis.Title.Text = "Stress";
                    zedGraphControl1.GraphPane.XAxis.Title.Text = "Strain";
                    break;
            }
            MaterialType type = ParentControl.Materialfrm.BasicData.Type;
            if (type == MaterialType.NoCompression || type == MaterialType.TensionCompressionSymmetric)
            {
                Compression_Gbox.Visible = Compression_Gbox2.Visible = false;
            }
            for (int i = 0; i < 3; i++)
            {
                TensionGridView.Rows.Add(i+1, "", "");
                CompressionGridView.Rows.Add(i+1,"","");
            }
            if (ParentControl.Materialfrm.Material != null)
            {
                HystereticMaterial m = ParentControl.Materialfrm.Material as HystereticMaterial;
                if (m != null)
                {
                    DfTension_TB.Text = m.Getdmax_Tension().ToString();
                    DfComp_TB.Text = m.Getdmax_Compression().ToString();

                    int i = 0;
                    foreach (var point in m.TensionPart.AsVector())
                    {
                        TensionGridView[1, i].Value = point.X;
                        TensionGridView[2, i].Value = point.Y;
                        i++;
                    }
                    i = 0;
                    foreach (var point in m.CompressionPart.AsVector())
                    {
                        CompressionGridView[1, i].Value = point.X;
                        CompressionGridView[2, i].Value = point.Y;
                        i++;
                    }
                    InitializeGraph();
                }
            }
        }
        private void ShowPdf_Btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MaterialDialogsBaseControl.Hysteric_Doc_Url);
        }
        
    }
}
