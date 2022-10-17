using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SPSW_Solver.Model;
using MathNet.Spatial.Euclidean;
using System.Drawing.Drawing2D;
using System.Linq;

namespace SPSW_Solver
{
    public partial class ModelViewer2D : BasicViewer
    {
        
        private SPSW_Simple_Model model;
        //private Graphics formGraphics;
        
        public ModelViewer2D()
        {
            InitializeComponent();
        }
        
        public ModelViewer2D(SPSW_Simple_Model model) : this()
        {
            this.model = model;
            VSync = true;
        }
        protected override void Viewer_Load(object sender, EventArgs e)
        {
            base.Viewer_Load(sender,e);
            
        }
        private void Viewer2D_MouseDown(object sender, MouseEventArgs e)
        {
            _activatePan = true;

             MRX = e.X;
             MRY = e.Y;
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (_activatePan)
                return;
            double w = (double)this.Width;
            double h = (double)this.Height;
            double x_Ratio = (e.X - w / 2.0) / w;
            double y_Ration = (e.Y - h / 2.0) /h;
            x_Ratio *= (maxX - minX);
            y_Ration *= (maxY - minY);
            if (e.Delta > 0)
            {
                scale = 1.0f + _scaleDelta;
                DeltaX = -1* _scaleDelta*2 * x_Ratio;
                DeltaY =  _scaleDelta *2* y_Ration ;
            }
            else
            {
                scale = 1.0f - _scaleDelta;
                DeltaX = _scaleDelta*2 *(1- x_Ratio);
                DeltaY = -1* _scaleDelta*2* (1-y_Ration);
            }

            Viewer_Paint(null,null); 

        }
        // functions:
        protected override void Viewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearSelectionReference();

            Point2D point = convertScreenToWorldCoords(e.X,e.Y);
            foreach (var mainNode in this.model.MainNodes)
            {
                if (mainNode.HitTest(point))
                {
                    SelectObject(mainNode);
                    return;
                }
            }
            foreach (var mainNode in this.model.SupportsNodes)
            {
                if (mainNode.HitTest(point))
                {
                    SelectObject(mainNode);
                    return;
                }
            }
            foreach (var Beam in this.model.Beams)
            {
                if (Beam.HitTest(point))
                {
                    SelectObject(Beam);
                    return;
                }
            }
            foreach (var column in this.model.Columns)
            {
                if (column.HitTest(point))
                {
                    SelectObject(column);
                    return;
                }
            }
            foreach (var column in this.model.GravityColumns)
            {
                if (column.HitTest(point))
                {
                    SelectObject(column);
                    return;
                }
            }
            foreach (var link in this.model.RigdLinks)
            {
                if (link.HitTest(point))
                {
                    SelectObject(link);
                    return;
                }
            }
            foreach (var SPBey in this.model.SPBeys)
            {
                if (SPBey.HitTest(point))
                {
                    SelectObject(SPBey);
                    return;
                }
            }

        }
        private void Viewer2D_MouseClick(object sender, MouseEventArgs e)
        {
        }
        protected override void Viewer_Resize(object sender, EventArgs e)
        {
            base.Viewer_Resize(sender,e);
        }
        public override float GetModelWidth()
        {
            return (float)(this.model.MaxX - this.model.MinX);
        }
        public override float GetModelHeight()
        {
            return (float)(this.model.MaxY - this.model.MinY);
        }
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        private void Viewer2D_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    DeltaY = _scaleDelta * maxY;
                    DeltaX = 0.0;
                    scale = 1.0;
                    Viewer_Paint(null,null);
                    break;
                case Keys.Down:
                    DeltaY = _scaleDelta * minY;
                    DeltaX = 0.0;
                    scale = 1.0;
                    Viewer_Paint(null, null);
                    break;
                case Keys.Right:
                    DeltaX = _scaleDelta * maxX;
                    DeltaY = 0.0;
                    scale = 1.0;
                    Viewer_Paint(null, null);
                    break;
                case Keys.Left:
                    DeltaX = _scaleDelta * minX;
                    DeltaY = 0.0;
                    scale = 1.0;
                    Viewer_Paint(null, null);
                    break;

                case Keys.Add:
                    DeltaX = 0.0;
                    DeltaY = 0.0;
                    scale = 1.0 + _scaleDelta;
                    Viewer_Paint(null, null);
                    break;
                case Keys.Subtract:
                    DeltaX = 0.0;
                    DeltaY = 0.0;
                    scale = 1.0 -_scaleDelta;
                    Viewer_Paint(null, null);
                    break;
                case Keys.Escape:
                    ClearSelection();
                    break;
                default:
                    break;
            }
        }
        protected override void DrawElements()
        {
            AddLoadsTexts();
            DrawGridLines();
            DrawSPBeys();
            DrawFrameElments();
            DrawSupportsNodes();
            DrawMainNodes();
        }
        private float Transform(double min , double max , double x , double VMax)
        {
            return (float)((x-min)*VMax/(max-min));
        }
        protected override void OraganizeRatio()
        {
            float width = (float)this.Width;
            float height = (float)this.Height;
            float modelWidth = GetModelWidth();
            float modelHeight = GetModelHeight();

            if (modelWidth > modelHeight)
            {
                minX = -0.5f * modelWidth;
                maxX = 0.5f * modelWidth;
                modelHeight = height * modelWidth / width;
                minY = -0.5f * modelHeight;
                maxY = 0.5f * modelHeight;
            }
            else
            {
                minY = -0.5f * modelHeight;
                maxY = 0.5f * modelHeight;
                modelWidth = width * modelHeight / height;
                minX = -0.5f * modelWidth;
                maxX = 0.5f * modelWidth;
            }
        }
        private void AddLoadsTexts()
        {

            if (!this.model.MainNodes.Any(x => x.LoadArrow != null))
                return;

            //_renderer.DrawString(x.LoadArrow.Value.ToString(), f,

        }
        private void DrawFrameElments()
        {
            GL.Begin(PrimitiveType.Quads);
            model.Beams.ForEach(x => x.Render());
            model.Columns.ForEach(x => x.Render());
            model.GravityColumns.ForEach(x => x.Render());
            model.RigdLinks.ForEach(x => x.Render());
            model.MainNodes.ForEach(x => x.RenderConnectedElements());
            model.SupportsNodes.ForEach(x => x.RenderConnectedElements());
            GL.End();
        }
        private void DrawSPBeys()
        {
            GL.Begin(PrimitiveType.Lines);
            model.SPBeys.ForEach(x => x.Render());
            GL.End();
        }
        private void DrawMainNodes()
        {
           model.MainNodes.ForEach(x => x.Render());
        }
        private void DrawSupportsNodes()
        {
            model.SupportsNodes.ForEach(x=>x.Render());
        }
        private void DrawGridLines()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(RenderOptions.GirdLinesColor);
            model.Levels.ForEach(x => x.Render());
            model.VerticalLines.ForEach(x => x.Render());
            GL.End();
        }
        private void Viewer2D_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_activatePan)
                return;

            Cursor.Current = Cursors.Cross;
            int dx = e.X - MRX;
            int dy = e.Y - MRY;

            MRX = e.X;
            MRY = e.Y;
            scale = 1.00f;
            DeltaX = dx * (maxX - minX) /this.Width;
            DeltaY = -1* dy * (maxY - minY) /this.Height;
            this.Viewer_Paint(sender,null);

        }
        private void Viewer2D_MouseUp(object sender, MouseEventArgs e)
        {
            _activatePan = false;
            Cursor.Current = Cursors.Default;
        }

        
    }
}
