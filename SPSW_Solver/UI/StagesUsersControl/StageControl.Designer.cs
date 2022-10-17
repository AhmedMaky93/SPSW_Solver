namespace SPSW_Solver
{
    partial class StageControl
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
            this.Main_pictureBox = new System.Windows.Forms.PictureBox();
            this.Status_pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_pictureBox
            // 
            this.Main_pictureBox.Location = new System.Drawing.Point(44, 0);
            this.Main_pictureBox.Name = "Main_pictureBox";
            this.Main_pictureBox.Size = new System.Drawing.Size(56, 57);
            this.Main_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Main_pictureBox.TabIndex = 2;
            this.Main_pictureBox.TabStop = false;
            // 
            // Status_pictureBox
            // 
            this.Status_pictureBox.Location = new System.Drawing.Point(3, 3);
            this.Status_pictureBox.Name = "Status_pictureBox";
            this.Status_pictureBox.Size = new System.Drawing.Size(39, 37);
            this.Status_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Status_pictureBox.TabIndex = 1;
            this.Status_pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // StageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Main_pictureBox);
            this.Controls.Add(this.Status_pictureBox);
            this.Name = "StageControl";
            this.Size = new System.Drawing.Size(103, 60);
            this.Load += new System.EventHandler(this.StageControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Main_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.PictureBox Status_pictureBox;
        protected System.Windows.Forms.PictureBox Main_pictureBox;
        protected System.Windows.Forms.Label label1;
    }
}
