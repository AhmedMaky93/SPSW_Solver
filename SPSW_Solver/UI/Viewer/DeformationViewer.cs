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
    public partial class DeformationViewer :BasicViewer
    {
        public SPSW_Simple_Model Model { get; set; }
        public DeformationViewer()
        {
            InitializeComponent();
        }
        public DeformationViewer(SPSW_Simple_Model model) : this()
        {
            this.Model = model;
            VSync = true;
        }
        protected override void Viewer_Load(object sender, EventArgs e)
        {
            base.Viewer_Load(sender, e);
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
            var xvalues=  this.Model.VerticalLines.Select(x => x.Distance);
            double min = xvalues.Min() + Math.Min(0,Model.ValuesRanges[DialogResultControl.CurrentLoadCase].XDisplacement.MinValue) * RenderOptions.DeformationRatio;
            double max = xvalues.Max() + Math.Max(0,Model.ValuesRanges[DialogResultControl.CurrentLoadCase].XDisplacement.MaxValue) * RenderOptions.DeformationRatio;
            return (float)((max - min) * (1+ SPSW_Simple_Model.Margin));
        }
        public override float GetModelHeight()
        {
            var yvalues = this.Model.Levels.Select(x => x.Elevation);
            double min = yvalues.Min() + Math.Min(0, Model.ValuesRanges[DialogResultControl.CurrentLoadCase].YDisplacement.MinValue) * RenderOptions.DeformationRatio;
            double max = yvalues.Max() + Math.Max(0, Model.ValuesRanges[DialogResultControl.CurrentLoadCase].YDisplacement.MaxValue) * RenderOptions.DeformationRatio;
            return (float)((max - min) * (1 + SPSW_Simple_Model.Margin));
        }
        protected override void DrawElements()
        {
            AddTitleText();
            GL.Begin(PrimitiveType.Lines);
            Model.RigdLinks.ForEach(x =>x.RenderDeformation(DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            GL.End();
            this.Model.SPBeys.ForEach(x => x.RenderDeformation(DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.Beams.ForEach(x => x.RenderDeformation(DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.Columns.ForEach(x => x.RenderDeformation(DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.GravityColumns.ForEach(x => x.RenderDeformation(DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.SupportsNodes.ForEach(x => x.RenderDeformation(DialogResultControl.CurrentLoadCase, CurrentTimeStep));
            Model.MainNodes.ForEach(x => x.RenderDeformation(DialogResultControl.CurrentLoadCase, CurrentTimeStep));
        }
        private void AddTitleText()
        {            
           //_renderer.DrawString(string.Format("Deformed Model :{0}", Model.TimeSteps[DialogResultControl.CurrentLoadCase][CurrentTimeStep]), f, new PointF(0, 0), false);
        }

    }
}
