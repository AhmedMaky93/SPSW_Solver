using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SPSW_Solver.UI.Selection;
using MathNet.Spatial.Units;
using MathNet.Numerics.LinearAlgebra;
using SPSW_Solver.BasicModel;
using SPSW_Solver.Model;
using System.Windows.Forms;
using ZedGraph;

namespace SPSW_Solver
{
    public interface IRenderable
    {
        bool Selected { get; set; }
        void Render();
        void RenderDeformation(int loadCase, int index);
        bool HitTest(Point2D Hitpoint);

        ObjectProperties GetProperties();
    }
    public interface ILineRenderable : IRenderable
    {
        Line2D Line2D { get; }
    }
    public interface IPolygonRenderable : IRenderable
    {
        Polygon2D RenderPolygon { get; }
    }
    
    public static class RenderOptions
    {
        public static Color BackGroundColor = Color.White;
        public static Color GirdLinesColor = Color.Gray;
        public static Color NodesColor = Color.Black;
        public static Color TrussesColor = Color.Green;
        public static Color SelectedColor = Color.Blue;
        public static Color ColumnColor = Color.Purple;
        public static Color BeamColor = Color.Purple;
        public static Color linkColor = Color.DarkBlue;
        public static Color LoadsArrowColor = Color.Red;

        public static Color initStessColor = Color.Black;
        public static Color ElasticLimitColor = Color.Blue;
        public static Color UltimateLimitColor = Color.Red;
        public static Color FailureLimitColor = Color.Purple;

        public static double NodesRadius = 5.0;
        public static double FramesRadius = 0.35;
        public static double linkedsRadius = 0.5;
        public static double SelectionTolerance = 0.01;
        public static double LoadsArrowLength = 1;
        public static double LoadsArrowColumnRatio = 0.25;
        public static double LoadsArrowNodesRatio = 0.5;
        public static double LoadsArrowArrowRatio = 0.333;
        public static double DeformationRatio = 5;
        public static int maxFPS = 60;
        public static double interpolationStep = 0.2;

        public static float GridLinesDepth = -0.5f;
        public static int Curvepoints =5;

        public static void Vertex2(Point2D point)
        {
            GL.Vertex2(point.X, point.Y);
        }

        public static void DrawCurve(Point2D p1, Vector2D v1, Point2D p2, Vector2D v2 , Color color)
        {
            if (v1.Normalize().IsParallelTo(v2,1.0e-7))
            {
              GL.Color4(color);
              GL.Begin(PrimitiveType.LineStrip);
              Vertex2(p1);
              Vertex2(p2);
              GL.End();
                return;
            }
            double l = p1.DistanceTo(p2)* 1.0e-7;
            RenderCurve_interpolation(new List<Point2D>()
            {
                p1,
                p1+v1.Normalize()*l,
                p2+v2.Normalize()*l ,
                p2
            }
            ,color);
        }
        public static void ExportToExcel(ZedGraph.ZedGraphControl control)
        {
            try
            {
                if (control == null)
                    return;
                if (control.GraphPane.CurveList == null)
                    return;
                if (!control.GraphPane.CurveList.Any())
                    return;
                PointPairList list = control.GraphPane.CurveList.First().Points as PointPairList;
                if (list == null)
                    return;

                double[,] saNames = new double[list.Count+1, 2];
                int i = 0;
                foreach (PointPair point in list)
                {
                    saNames[i, 0] = Math.Round(point.X, 4);
                    saNames[i, 1] = Math.Round(point.Y, 4);
                    i++;
                }

                string path;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Select file name and directory";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "xls";
                saveFileDialog1.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    Microsoft.Office.Interop.Excel.Application oXL;
                    Microsoft.Office.Interop.Excel._Workbook oWB;
                    Microsoft.Office.Interop.Excel._Worksheet oSheet;
                    Microsoft.Office.Interop.Excel.Range oRng;
                    object misvalue = System.Reflection.Missing.Value;
                    try
                    {
                        //Start Excel and get Application object.
                        oXL = new Microsoft.Office.Interop.Excel.Application();
                        oXL.Visible = true;

                        //Get a new workbook.
                        oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                        oSheet.Cells[1, 1] = control.GraphPane.XAxis.Title.Text;
                        oSheet.Cells[1, 2] = control.GraphPane.YAxis.Title.Text;
                        //Format A1:D1 as bold, vertical alignment = center.
                        oSheet.get_Range("A2", string.Format("B{0}",i+2)).Value2 = saNames;
                        oRng = oSheet.get_Range(oSheet.Cells[1, 1], oSheet.Cells[1, 2]);
                        oRng.Font.Bold = true;
                        oRng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //AutoFit columns A:D.
                        oRng.EntireColumn.AutoFit();

                        // Add chart.
                        var charts = oSheet.ChartObjects() as
                            Microsoft.Office.Interop.Excel.ChartObjects;
                        var chartObject = charts.Add(200, 10, 900, 900) as
                            Microsoft.Office.Interop.Excel.ChartObject;
                        var chart = chartObject.Chart;

                        // Set chart range.
                        chart.SetSourceData(oRng);

                        // Set chart properties.
                        var srcRng = oSheet.get_Range(oSheet.Cells[2, 1], oSheet.Cells[i+1, 2]);
                        chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlXYScatterSmoothNoMarkers;
                        chart.ChartWizard(Source: srcRng,
                            Title: "PushOver Curve",
                            CategoryTitle: control.GraphPane.XAxis.Title.Text,
                            ValueTitle: control.GraphPane.YAxis.Title.Text);

                        oXL.Visible = false;
                        oXL.UserControl = false;
                        oWB.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                        oWB.Close();
                        oXL.Quit();

                        //...
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception e)
            { }
            

        }
        public static void RenderCurve_interpolation(List<Point2D> points, Color color)
        {
            double minX = points.Select(x => x.X).Min();
            double maxX = points.Select(x => x.X).Max();

            double minY = points.Select(x => x.Y).Min();
            double maxY = points.Select(x => x.Y).Max();

            Point2D p1 = new Point2D(minX, minY);
            Point2D p2 = new Point2D(maxX, maxY);

            Vector2D rotation = (p2 - p1).Normalize();
            double seta = Vector2D.XAxis.SignedAngleTo(rotation, true, true).Radians;
            Point2D cen = new Point2D(0.5 * (p1.X + p2.X), 0.5 * (p1.Y + p2.Y));
            List<Point2D> Rpoints = RenderCurve_interpolationNormalized(points.Select(x => Transform(x, cen, seta)).ToList());
            GL.Color4(color);
            GL.Begin(PrimitiveType.LineStrip);
            Rpoints.ForEach(x => Vertex2(ReTransform(x, cen, seta)));
            GL.End();
        }
        public static Point2D Transform(Point2D point , Point2D cen , double seta)
        {
            double x = point.X - cen.X;
            double y = point.Y - cen.Y;
            Vector<double> vector = new Vector2D(x,y).ToVector();
            var matrix = Matrix2D.Create(Math.Cos(seta), Math.Sin(seta), -1*Math.Sin(seta), Math.Cos(seta));
            Vector<double> result = matrix.Multiply(vector);
            return new Point2D(result[0],result[1]);
        }
        public static Point2D ReTransform(Point2D point, Point2D cen, double seta)
        {
            Vector<double> vector = new Vector2D(point.X, point.Y).ToVector();
            var matrix = Matrix2D.Create(Math.Cos(seta), Math.Sin(seta), -1 * Math.Sin(seta), Math.Cos(seta)).Inverse();
            Vector<double> result = matrix.Multiply(vector);
            return new Point2D(result[0]+cen.X, result[1]+cen.Y);
        }
        private static List<Point2D> RenderCurve_interpolationNormalized(List<Point2D> points)
        {
            List<double> xValues = points.Select(e => e.X).ToList();
            double minX = xValues.Min();
            double maxX = xValues.Max();
            xValues.Clear();
            List<Point2D> results = new List<Point2D>();
            double x = minX;
            
            while (x < maxX)
            {
                results.Add(new Point2D(x, GetYIntepolation(x, points)));
                x += interpolationStep;
            }
            results.Add(new Point2D(maxX, GetYIntepolation(maxX, points)));
            return results;


        }
        public static double GetYIntepolation(double x , List<Point2D> points )
        {
            double y = 0;
            for (int i = 0; i < points.Count; i++)
            {
                double m = 1;
                double c = 1;

                for (int j = 0; j < i; j++)
                {
                    m *= (x - points[j].X);
                    c *= (points[i].X - points[j].X);
                }
                for (int j = i+1; j < points.Count; j++)
                {
                    m *= (x - points[j].X);
                    c *= (points[i].X - points[j].X);
                }
                y += m * points[i].Y / c;
            }
            return y;
        }

    }
}
