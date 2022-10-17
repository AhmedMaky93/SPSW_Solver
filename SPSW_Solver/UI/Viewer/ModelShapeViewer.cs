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

namespace SPSW_Solver
{
    public partial class ModelShapeViewer : BasicViewer
    {
        public static int TimeCount { get; set; } = 11;

        TextRenderer _renderer;
        Color _fontTextureBackground = Color.FromArgb(0, 0, 0, 0); // Black is (255, 0, 0, 0)
        FontFamily fontFamily;
        Dictionary<int, double> _timeStepsFactors = new Dictionary<int, double>();
        public int CurrentModeShape { get; set; }
        public SPSW_Simple_Model Model { get; set; }
        public ModelShapeViewer()
        {
            InitializeComponent();
        }
        public ModelShapeViewer(SPSW_Simple_Model model , int currentModeShape) : this()
        {
            this.Model = model;
            CurrentModeShape = currentModeShape;
            _timeStepsFactors.Add(0,0.0);
            _timeStepsFactors.Add(1,1.0/3.0);
            _timeStepsFactors.Add(2,2.0/3.0);
            _timeStepsFactors.Add(3,1.0);
            _timeStepsFactors.Add(4,2.0/3.0);
            _timeStepsFactors.Add(5,1.0/3.0);
            _timeStepsFactors.Add(6,0.0);
            _timeStepsFactors.Add(7,-1.0 / 3.0);
            _timeStepsFactors.Add(8,-2.0/3.0);
            _timeStepsFactors.Add(9,-1.0);
            _timeStepsFactors.Add(10,-2.0/3.0);
            _timeStepsFactors.Add(11,-1.0/3.0);
            VSync = true;
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
                    f = new Font(fontFamily, 10);
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
            CurrentTimeStep++;
            if (CurrentTimeStep >= _timeStepsFactors.Count)
                CurrentTimeStep = 0;
            UpdateEx();
            return true;
        }
        public override float GetModelWidth()
        {
            double maxValue = Model.GetAllNodes(false).Select(x => Math.Abs(x.ModeShapesDeformations[CurrentModeShape - 1].Dx)).Max();
            var xvalues = this.Model.VerticalLines.Select(x => x.Distance);
            double min = xvalues.Min() - maxValue * RenderOptions.DeformationRatio;
            double max = xvalues.Max() + maxValue * RenderOptions.DeformationRatio;
            return (float)((max - min) * (1 + SPSW_Simple_Model.Margin));
        }
        public override float GetModelHeight()
       {
            double maxValue = Model.GetAllNodes(false).Select(x => Math.Abs(x.ModeShapesDeformations[CurrentModeShape - 1].Dy)).Max();
            var yvalues = this.Model.Levels.Select(x => x.Elevation);
            double min = yvalues.Min() - maxValue * RenderOptions.DeformationRatio;
            double max = yvalues.Max() + maxValue * RenderOptions.DeformationRatio;
            return (float)((max - min) * (1 + SPSW_Simple_Model.Margin));
        }
        protected override void DrawElements()
        {
            int n = CurrentModeShape - 1;
            double factor = _timeStepsFactors[CurrentTimeStep];
            AddTitleText();
            Model.SupportsNodes.ForEach(x => x.RenderModeShape(n, factor));
            Model.MainNodes.ForEach(x => x.RenderModeShape(n,factor));
            GL.Begin(PrimitiveType.Lines);
            Model.SPBeys.ForEach(x => x.RenderModeShape(n, factor));
            Model.RigdLinks.ForEach(x => x.RenderModeShape(n, factor));
            GL.End();
            Model.Beams.ForEach(x => x.RenderModeShape(n, factor));
            Model.Columns.ForEach(x => x.RenderModeShape(n, factor));
            Model.GravityColumns.ForEach(x => x.RenderModeShape(n, factor));
        }
        private void AddTitleText()
        {
            
           //_renderer.DrawString(string.Format("Mode Shape :{0}", CurrentModeShape), f, new PointF(0, 0), false);
 
        }
    }
}
