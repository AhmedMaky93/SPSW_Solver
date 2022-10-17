namespace SPSW_Solver
{
    partial class MaterialPropertiesStageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialPropertiesStageControl));
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Status_pictureBox
            // 
            this.Status_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Status_pictureBox.Image")));
            this.Status_pictureBox.Location = new System.Drawing.Point(10, 3);
            // 
            // Main_pictureBox
            // 
            this.Main_pictureBox.Image = global::SPSW_Solver.Properties.Resources.seo_report;
            this.Main_pictureBox.Location = new System.Drawing.Point(59, 3);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.Text = "Properties";
            // 
            // MaterialPropertiesStageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MaterialPropertiesStageControl";
            this.Size = new System.Drawing.Size(115, 64);
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
