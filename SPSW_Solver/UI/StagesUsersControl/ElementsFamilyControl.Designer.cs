namespace SPSW_Solver
{
    partial class ElementsFamilyControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementsFamilyControl));
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Status_pictureBox
            // 
            this.Status_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Status_pictureBox.Image")));
            // 
            // Main_pictureBox
            // 
            this.Main_pictureBox.Image = global::SPSW_Solver.Properties.Resources.Organize;
            this.Main_pictureBox.Location = new System.Drawing.Point(48, 0);
            this.Main_pictureBox.Size = new System.Drawing.Size(52, 61);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 43);
            this.label1.Size = new System.Drawing.Size(51, 26);
            this.label1.Text = "Sections \r\n Groups";
            // 
            // ElementsFamilyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ElementsFamilyControl";
            this.Size = new System.Drawing.Size(103, 71);
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
