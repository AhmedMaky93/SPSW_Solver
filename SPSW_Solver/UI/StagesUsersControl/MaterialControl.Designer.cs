﻿namespace SPSW_Solver
{
    partial class MaterialControl
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
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_pictureBox
            // 
            this.Main_pictureBox.Image = global::SPSW_Solver.Properties.Resources.curve;
            this.Main_pictureBox.Location = new System.Drawing.Point(48, 0);
            this.Main_pictureBox.Size = new System.Drawing.Size(52, 57);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.Text = "Material";
            // 
            // MaterialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MaterialControl";
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
