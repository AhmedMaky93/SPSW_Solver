namespace SPSW_Solver
{
    partial class ModelViewer2D
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Viewer2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Viewer2D";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Viewer2D_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Viewer2D_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Viewer2D_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Viewer2D_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Viewer2D_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
