using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using MathNet.Spatial.Euclidean;
using SPSW_Solver.Model;

namespace SPSW_Solver
{
    public abstract partial class BasicViewer : GLControl
    {
        public int CurrentTimeStep { get; set; } = 0;
        protected double _deltaX = 0.0;
        protected double _deltaY = 0.0;
        protected double _scale = 1.0;
        protected Font f;
        protected Color _fontTextureBackground = Color.FromArgb(0, 0, 0, 0); // Black is (255, 0, 0, 0)
        protected FontFamily fontFamily;

        public double DeltaX
        {
            get { return _deltaX; }
            set
            {
                _deltaX = value;
            }
        }
        public double DeltaY
        {
            get { return _deltaY; }
            set
            {
                _deltaY = value;
            }
        }
        public double scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
            }
        }

        public double _scaleDelta = 0.01f;

        public float minX = 0.0f;
        public float maxX = 100.0f;
        public float minY = 0.0f;
        public float maxY = 100.0f;
        protected bool _activatePan = false;

        public int MRX = 0;
        public int MRY = 0;

        private IRenderable _selectedObject = null;
        public IRenderable SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                _selectedObject = value;
                SelectionChanged(_selectedObject);
            }
        }
        public Action<IRenderable> SelectionChanged;
        public BasicViewer()
        {
            InitializeComponent();
        }

        internal virtual bool Increment()
        {
            return false;
        }
        public static Point2D convertScreenToWorldCoords(int x, int y)
        {
            try
            {
                int[] viewport = new int[4];
                Matrix4 modelViewMatrix, projectionMatrix;
                GL.GetFloat(GetPName.ModelviewMatrix, out modelViewMatrix);
                GL.GetFloat(GetPName.ProjectionMatrix, out projectionMatrix);
                GL.GetInteger(GetPName.Viewport, viewport);
                Vector2 mouse;
                mouse.X = x;
                mouse.Y = viewport[3] - y;
                Vector4 vector = UnProject(ref projectionMatrix, modelViewMatrix, new Size(viewport[2], viewport[3]), mouse);
                return new Point2D(vector.X, vector.Y);
            }
            catch (Exception e)
            {
                return new Point2D(double.MinValue, double.MinValue);
            }

        }
        public static Vector4 UnProject(ref Matrix4 projection, Matrix4 view, Size viewport, Vector2 mouse)
        {
            Vector4 vec;

            vec.X = 2.0f * mouse.X / (float)viewport.Width - 1;
            vec.Y = 2.0f * mouse.Y / (float)viewport.Height - 1;
            vec.Z = 0;
            vec.W = 1.0f;

            Matrix4 viewInv = Matrix4.Invert(view);
            Matrix4 projInv = Matrix4.Invert(projection);

            Vector4.Transform(ref vec, ref projInv, out vec);
            Vector4.Transform(ref vec, ref viewInv, out vec);

            if (vec.W > float.Epsilon || vec.W < float.Epsilon)
            {
                vec.X /= vec.W;
                vec.Y /= vec.W;
                vec.Z /= vec.W;
            }

            return vec;
        }
        protected virtual void Viewer_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Translate(DeltaX, DeltaY, 0.0);
            GL.Scale(scale, scale, 1.0);

            try
            {
                DrawElements();
            }
            catch (Exception ex)
            {

            }
            
            
            this.SwapBuffers();
        }
        public virtual void ClearAllElements()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Translate(DeltaX, DeltaY, 0.0);
            GL.Scale(scale, scale, 1.0);
            this.SwapBuffers();
        }
        public void UpdateEx()
        {
            DeltaX = DeltaY = 0.0;
            scale = 1.00;
            Viewer_Paint(null, null);
            SelectionChanged(SelectedObject);
        }
        protected void SelectObject(IRenderable obj)
        {
            obj.Selected = true;
            DeltaX = DeltaY = 0.0;
            scale = 1.00;
            Viewer_Paint(null, null);
            SelectedObject = obj;
        }
        protected void ClearSelection()
        {
            if (SelectedObject == null)
                return;

            SelectedObject.Selected = false;
            DeltaX = DeltaY = 0.0;
            scale = 1.00;
            Viewer_Paint(null, null);
            SelectedObject = null;
        }
        public void ClearSelectionReference()
        {
            if (SelectedObject != null)
            {
                SelectedObject.Selected = false;
                SelectedObject = null;
            }
        }
        public void RefreshEx()
        {
            OraganizeRatio();
            GL.Viewport(0, 0, this.Width, this.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(minX, maxX, minY, maxY, -1.0f, 1.00f);
            GL.MatrixMode(MatrixMode.Modelview);
            UpdateEx();
        }
        protected virtual void Viewer_Resize(object sender, EventArgs e)
        {
            scale = 1.00f;
            DeltaX = 0.0f;
            DeltaY = 0.0f;
            RefreshEx();
        }
        protected virtual void Viewer_Load(object sender, EventArgs e)
        {
            GL.ClearColor(RenderOptions.BackGroundColor);

            FontFamily[] fontFamilies = FontFamily.Families;

            foreach (FontFamily ff in fontFamilies)
            {
                if (ff.Name == "Arial")
                {
                    fontFamily = ff;
                    break;
                }
            }
            f = new Font(fontFamily, 10);
        }
        public virtual float GetModelWidth()
        {
            return 0;
        }
        public virtual float GetModelHeight()
        {
            return 0;
        }
        protected virtual void OraganizeRatio()
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
        protected virtual void DrawElements()
        {
            
        }
        protected virtual void Viewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
