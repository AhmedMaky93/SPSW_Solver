namespace SPSW_Solver
{
    partial class DPModelUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.IP_TB = new System.Windows.Forms.TextBox();
            this.VLB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AllSegments_btn = new System.Windows.Forms.RadioButton();
            this.EndSegments_btn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of integration points :";
            // 
            // IP_TB
            // 
            this.IP_TB.Location = new System.Drawing.Point(182, 16);
            this.IP_TB.Name = "IP_TB";
            this.IP_TB.Size = new System.Drawing.Size(68, 20);
            this.IP_TB.TabIndex = 1;
            this.IP_TB.TextChanged += new System.EventHandler(this.IP_TB_TextChanged);
            // 
            // VLB
            // 
            this.VLB.AutoSize = true;
            this.VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.VLB.Location = new System.Drawing.Point(53, 42);
            this.VLB.Name = "VLB";
            this.VLB.Size = new System.Drawing.Size(35, 13);
            this.VLB.TabIndex = 2;
            this.VLB.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.VLB);
            this.groupBox1.Controls.Add(this.IP_TB);
            this.groupBox1.Location = new System.Drawing.Point(6, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EndSegments_btn);
            this.groupBox2.Controls.Add(this.AllSegments_btn);
            this.groupBox2.Location = new System.Drawing.Point(6, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 103);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nonlinear Segments";
            // 
            // AllSegments_btn
            // 
            this.AllSegments_btn.AutoSize = true;
            this.AllSegments_btn.Location = new System.Drawing.Point(20, 33);
            this.AllSegments_btn.Name = "AllSegments_btn";
            this.AllSegments_btn.Size = new System.Drawing.Size(86, 17);
            this.AllSegments_btn.TabIndex = 0;
            this.AllSegments_btn.TabStop = true;
            this.AllSegments_btn.Text = "All Segments";
            this.AllSegments_btn.UseVisualStyleBackColor = true;
            this.AllSegments_btn.CheckedChanged += new System.EventHandler(this.AllSegments_btn_CheckedChanged);
            // 
            // EndSegments_btn
            // 
            this.EndSegments_btn.AutoSize = true;
            this.EndSegments_btn.Location = new System.Drawing.Point(20, 65);
            this.EndSegments_btn.Name = "EndSegments_btn";
            this.EndSegments_btn.Size = new System.Drawing.Size(118, 17);
            this.EndSegments_btn.TabIndex = 1;
            this.EndSegments_btn.TabStop = true;
            this.EndSegments_btn.Text = "End Segments Only";
            this.EndSegments_btn.UseVisualStyleBackColor = true;
            this.EndSegments_btn.CheckedChanged += new System.EventHandler(this.EndSegments_btn_CheckedChanged);
            // 
            // DPModelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DPModelUC";
            this.Load += new System.EventHandler(this.DPModelUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IP_TB;
        private System.Windows.Forms.Label VLB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton EndSegments_btn;
        private System.Windows.Forms.RadioButton AllSegments_btn;
    }
}
