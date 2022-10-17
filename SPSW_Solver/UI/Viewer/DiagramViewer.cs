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
using OpenTK.Graphics.OpenGL;
using BasicModel;

namespace SPSW_Solver
{
    public partial class DiagramViewer : BasicViewer
    {
        TextRenderer _renderer;

        public static double ElementScaleMax = 0.5;
        public SPSW_Simple_Model Model { get; set; }
        public DiagramType Type { get; protected set; }
        public DiagramHandler ScaleHandler { get; set; }
        public DiagramViewer()
        {
            InitializeComponent();
        }
        public DiagramViewer(SPSW_Simple_Model model, DiagramType Type) : this()
        {
            this.Model = model;
            this.Type = Type;
            InitializeScaleHandler();
            VSync = true;
        }

        private double GetMaxLength()
        {
            return ElementScaleMax * Math.Min(Model.Layout.BeamWidth, Model.Layout.GetMaxFloorHeight());
        }
        private void InitializeScaleHandler()
        {
            double maxDistance = GetMaxLength();
            switch (Type)
            {
                case DiagramType.NormalForce:
                    ScaleHandler = new DiagramHandler(ValueRange.ByRange( Model.ValuesRanges[DialogResultControl.CurrentLoadCase].NF,0.05),maxDistance);
                    break;
                case DiagramType.ShearForce:
                    ScaleHandler = new DiagramHandler(ValueRange.ByRange(Model.ValuesRanges[DialogResultControl.CurrentLoadCase].SF,0.05),maxDistance);
                    break;
                case DiagramType.BendingMoment:
                    ScaleHandler = new DiagramHandler(ValueRange.ByRange(Model.ValuesRanges[DialogResultControl.CurrentLoadCase].FM,0.05),maxDistance);
                    break;
                default:
                    break;
            }
        }

        protected override void Viewer_Load(object sender, EventArgs e)
        {
            base.Viewer_Load(sender, e);
            FontFamily[] fontFamilies = FontFamily.Families;

            foreach (FontFamily ff in fontFamilies)
            {
                if (ff.Name == "Arial")
                {
                    fontFamily = ff;
                    break;
                }
            }
        }
        protected override void Viewer_Resize(object sender, EventArgs e)
        {
            base.Viewer_Resize(sender, e);
        }
        internal override bool Increment()
        {
            int n = Model.TimeSteps[DialogResultControl.CurrentLoadCase].Count;
            if (CurrentTimeStep >= n - 1)
                return false;
            CurrentTimeStep++;
            UpdateEx();
            return true;
        }

        public override float GetModelWidth()
        {                                                                            
            double maxDistance = GetMaxLength();
            var xvalues = this.Model.VerticalLines.Select(x => x.Distance);
            double min = xvalues.Min() - maxDistance;
            double max = xvalues.Max() + maxDistance;
            return (float)(max - min) ;
        }
        public override float GetModelHeight()
        {
            double maxDistance = GetMaxLength();
            var xvalues = this.Model.Levels.Select(x => x.Elevation);
            double min = xvalues.Min() - maxDistance;
            double max = xvalues.Max() + maxDistance;
            return (float)(max - min);
        }
        protected override void DrawElements()
        {
            AddTitleText();
            GL.Begin(PrimitiveType.Lines);
            Model.Levels.ForEach(x => x.Render());
            Model.VerticalLines.ForEach(x => x.Render());
            GL.End();
            GL.Begin(PrimitiveType.Quads);
            Model.MainNodes.ForEach(x => x.RenderDiagram(ScaleHandler, Type, DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.SupportsNodes.ForEach(x => x.RenderDiagram(ScaleHandler, Type, DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.Beams.ForEach(x => x.RenderDiagram(ScaleHandler, Type, DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.Columns.ForEach(x => x.RenderDiagram(ScaleHandler, Type, DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.GravityColumns.ForEach(x => x.RenderDiagram(ScaleHandler, Type, DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            GL.End();
        }
        private string GetTitleString()
        {
            string result= "";
            switch (Type)
            {
                case DiagramType.NormalForce:
                    result = "N.F.D";
                    break;
                case DiagramType.ShearForce:
                    result = "S.F.D";
                    break;
                case DiagramType.BendingMoment:
                    result = "B.M.D";
                    break;
                default:
                    break;
            }
            return result;

        }
        private void AddTitleText()
        {
           // _renderer.DrawString(string.Format("{0}:{1}", GetTitleString(), Model.TimeSteps[DialogResultControl.CurrentLoadCase][CurrentTimeStep]), f, new PointF(0, 0), false);
        }

    }
    public class DiagramHandler
    {
        public ValueRange Range { get; protected set; }
        public double  Scale { get; protected set; }

        public DiagramHandler(ValueRange Range, double MaxDistance)
        {
            this.Range = Range;
            this.Scale = MaxDistance / Math.Max(Math.Abs(Range.MaxValue), Math.Abs(Range.MinValue));
        }

        public double GetScaledDistance(double value)
        {
            return value * Scale;
        }
        public Color GetColor(double value)
        {
            double ratio = Range.GetRatio(value);
            return Color.FromArgb((int)(255.0*ratio),0,(int)(255.0*(1-ratio)));
        }
    }
    
    public enum DiagramType
    {
        NormalForce,
        ShearForce,
        BendingMoment
    }
}
