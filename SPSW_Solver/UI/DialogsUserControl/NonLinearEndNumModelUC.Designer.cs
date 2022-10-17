namespace SPSW_Solver
{
    partial class NonLinearEndNumModelUC
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VLB = new System.Windows.Forms.Label();
            this.IP_TB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Segment_btn = new System.Windows.Forms.RadioButton();
            this.Depth_btn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.First_VLB = new System.Windows.Forms.Label();
            this.First_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Last_VLB = new System.Windows.Forms.Label();
            this.Last_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.VLB);
            this.groupBox1.Controls.Add(this.IP_TB);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
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
            // IP_TB
            // 
            this.IP_TB.Location = new System.Drawing.Point(182, 16);
            this.IP_TB.Name = "IP_TB";
            this.IP_TB.Size = new System.Drawing.Size(68, 20);
            this.IP_TB.TabIndex = 1;
            this.IP_TB.TextChanged += new System.EventHandler(this.IP_TB_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Last_VLB);
            this.groupBox2.Controls.Add(this.Last_TB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Segment_btn);
            this.groupBox2.Controls.Add(this.Depth_btn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.First_VLB);
            this.groupBox2.Controls.Add(this.First_TB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(3, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 139);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Length nonlinear elements :";
            // 
            // Segment_btn
            // 
            this.Segment_btn.AutoSize = true;
            this.Segment_btn.Location = new System.Drawing.Point(125, 105);
            this.Segment_btn.Name = "Segment_btn";
            this.Segment_btn.Size = new System.Drawing.Size(125, 17);
            this.Segment_btn.TabIndex = 6;
            this.Segment_btn.TabStop = true;
            this.Segment_btn.Text = "End Segment Length";
            this.Segment_btn.UseVisualStyleBackColor = true;
            this.Segment_btn.CheckedChanged += new System.EventHandler(this.Segment_btn_CheckedChanged);
            // 
            // Depth_btn
            // 
            this.Depth_btn.AutoSize = true;
            this.Depth_btn.Location = new System.Drawing.Point(9, 105);
            this.Depth_btn.Name = "Depth_btn";
            this.Depth_btn.Size = new System.Drawing.Size(93, 17);
            this.Depth_btn.TabIndex = 5;
            this.Depth_btn.TabStop = true;
            this.Depth_btn.Text = "Section Depth";
            this.Depth_btn.UseVisualStyleBackColor = true;
            this.Depth_btn.CheckedChanged += new System.EventHandler(this.Depth_btn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "The length is relative to :";
            // 
            // First_VLB
            // 
            this.First_VLB.AutoSize = true;
            this.First_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.First_VLB.Location = new System.Drawing.Point(190, 27);
            this.First_VLB.Name = "First_VLB";
            this.First_VLB.Size = new System.Drawing.Size(35, 13);
            this.First_VLB.TabIndex = 3;
            this.First_VLB.Text = "label2";
            // 
            // First_TB
            // 
            this.First_TB.Location = new System.Drawing.Point(96, 24);
            this.First_TB.Name = "First_TB";
            this.First_TB.Size = new System.Drawing.Size(68, 20);
            this.First_TB.TabIndex = 3;
            this.First_TB.TextChanged += new System.EventHandler(this.First_TB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "at first segment :";
            // 
            // Last_VLB
            // 
            this.Last_VLB.AutoSize = true;
            this.Last_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Last_VLB.Location = new System.Drawing.Point(188, 53);
            this.Last_VLB.Name = "Last_VLB";
            this.Last_VLB.Size = new System.Drawing.Size(35, 13);
            this.Last_VLB.TabIndex = 7;
            this.Last_VLB.Text = "label2";
            // 
            // Last_TB
            // 
            this.Last_TB.Location = new System.Drawing.Point(96, 50);
            this.Last_TB.Name = "Last_TB";
            this.Last_TB.Size = new System.Drawing.Size(68, 20);
            this.Last_TB.TabIndex = 8;
            this.Last_TB.TextChanged += new System.EventHandler(this.Last_TB_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "at last segment :";
            // 
            // NonLinearEndNumModelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NonLinearEndNumModelUC";
            this.Load += new System.EventHandler(this.NonLinearEndNumModelUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label VLB;
        private System.Windows.Forms.TextBox IP_TB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label First_VLB;
        private System.Windows.Forms.TextBox First_TB;
        private System.Windows.Forms.RadioButton Segment_btn;
        private System.Windows.Forms.RadioButton Depth_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Last_VLB;
        private System.Windows.Forms.TextBox Last_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}
