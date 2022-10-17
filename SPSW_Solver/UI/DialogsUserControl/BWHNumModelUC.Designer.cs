namespace SPSW_Solver
{
    partial class BWHNumModelUC
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.All_VLB = new System.Windows.Forms.Label();
            this.Inter_VLB = new System.Windows.Forms.Label();
            this.Inter_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Segment_btn = new System.Windows.Forms.RadioButton();
            this.Depth_btn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.End_VLB = new System.Windows.Forms.Label();
            this.End_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.All_VLB);
            this.groupBox2.Controls.Add(this.Inter_VLB);
            this.groupBox2.Controls.Add(this.Inter_TB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Segment_btn);
            this.groupBox2.Controls.Add(this.Depth_btn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.End_VLB);
            this.groupBox2.Controls.Add(this.End_TB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 190);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Length of segments hinges :";
            // 
            // All_VLB
            // 
            this.All_VLB.AutoSize = true;
            this.All_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.All_VLB.Location = new System.Drawing.Point(32, 89);
            this.All_VLB.Name = "All_VLB";
            this.All_VLB.Size = new System.Drawing.Size(35, 13);
            this.All_VLB.TabIndex = 10;
            this.All_VLB.Text = "label2";
            // 
            // Inter_VLB
            // 
            this.Inter_VLB.AutoSize = true;
            this.Inter_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Inter_VLB.Location = new System.Drawing.Point(197, 58);
            this.Inter_VLB.Name = "Inter_VLB";
            this.Inter_VLB.Size = new System.Drawing.Size(35, 13);
            this.Inter_VLB.TabIndex = 7;
            this.Inter_VLB.Text = "label2";
            // 
            // Inter_TB
            // 
            this.Inter_TB.Location = new System.Drawing.Point(116, 55);
            this.Inter_TB.Name = "Inter_TB";
            this.Inter_TB.Size = new System.Drawing.Size(68, 20);
            this.Inter_TB.TabIndex = 8;
            this.Inter_TB.TextChanged += new System.EventHandler(this.Inter_TB_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "at intermediate joints :";
            // 
            // Segment_btn
            // 
            this.Segment_btn.AutoSize = true;
            this.Segment_btn.Location = new System.Drawing.Point(9, 162);
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
            this.Depth_btn.Location = new System.Drawing.Point(9, 139);
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
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "The length is relative to :";
            // 
            // End_VLB
            // 
            this.End_VLB.AutoSize = true;
            this.End_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.End_VLB.Location = new System.Drawing.Point(199, 32);
            this.End_VLB.Name = "End_VLB";
            this.End_VLB.Size = new System.Drawing.Size(35, 13);
            this.End_VLB.TabIndex = 3;
            this.End_VLB.Text = "label2";
            // 
            // End_TB
            // 
            this.End_TB.Location = new System.Drawing.Point(116, 29);
            this.End_TB.Name = "End_TB";
            this.End_TB.Size = new System.Drawing.Size(68, 20);
            this.End_TB.TabIndex = 3;
            this.End_TB.TextChanged += new System.EventHandler(this.End_TB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "at End joints :";
            // 
            // BWHNumModelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "BWHNumModelUC";
            this.Load += new System.EventHandler(this.BWHNumModelUC_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Inter_VLB;
        private System.Windows.Forms.TextBox Inter_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Segment_btn;
        private System.Windows.Forms.RadioButton Depth_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label End_VLB;
        private System.Windows.Forms.TextBox End_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label All_VLB;
    }
}
