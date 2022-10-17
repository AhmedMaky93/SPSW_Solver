namespace SPSW_Solver
{
    partial class DialogLateralResistance
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Ta_CheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.I_VLB = new System.Windows.Forms.Label();
            this.I_TB = new System.Windows.Forms.TextBox();
            this.R_VLB = new System.Windows.Forms.Label();
            this.R_TB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SD1_VLB = new System.Windows.Forms.Label();
            this.SD1_TB = new System.Windows.Forms.TextBox();
            this.SDS_VLB = new System.Windows.Forms.Label();
            this.SDS_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TL_VLB = new System.Windows.Forms.Label();
            this.TL_TB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AISCE_btn = new System.Windows.Forms.RadioButton();
            this.K_VLB = new System.Windows.Forms.Label();
            this.Generic_btn = new System.Windows.Forms.RadioButton();
            this.Uniform_Profile_btn = new System.Windows.Forms.RadioButton();
            this.Top_Force_btn = new System.Windows.Forms.RadioButton();
            this.K_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.R_Label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Ta_CheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.I_VLB);
            this.groupBox1.Controls.Add(this.I_TB);
            this.groupBox1.Controls.Add(this.R_VLB);
            this.groupBox1.Controls.Add(this.R_TB);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.SD1_VLB);
            this.groupBox1.Controls.Add(this.SD1_TB);
            this.groupBox1.Controls.Add(this.SDS_VLB);
            this.groupBox1.Controls.Add(this.SDS_TB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TL_VLB);
            this.groupBox1.Controls.Add(this.TL_TB);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 226);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pushover procedure ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "g";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "g";
            // 
            // Ta_CheckBox
            // 
            this.Ta_CheckBox.AutoSize = true;
            this.Ta_CheckBox.Location = new System.Drawing.Point(9, 115);
            this.Ta_CheckBox.Name = "Ta_CheckBox";
            this.Ta_CheckBox.Size = new System.Drawing.Size(224, 17);
            this.Ta_CheckBox.TabIndex = 48;
            this.Ta_CheckBox.Text = "only use approximate fundamental period. ";
            this.Ta_CheckBox.UseVisualStyleBackColor = true;
            this.Ta_CheckBox.CheckedChanged += new System.EventHandler(this.Ta_CheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Importance Factor (I)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 26);
            this.label2.TabIndex = 46;
            this.label2.Text = "Response modification \r\ncoefficient (R)";
            // 
            // I_VLB
            // 
            this.I_VLB.AutoSize = true;
            this.I_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.I_VLB.Location = new System.Drawing.Point(172, 210);
            this.I_VLB.Name = "I_VLB";
            this.I_VLB.Size = new System.Drawing.Size(0, 13);
            this.I_VLB.TabIndex = 44;
            // 
            // I_TB
            // 
            this.I_TB.Location = new System.Drawing.Point(175, 180);
            this.I_TB.Name = "I_TB";
            this.I_TB.Size = new System.Drawing.Size(51, 20);
            this.I_TB.TabIndex = 45;
            this.I_TB.TextChanged += new System.EventHandler(this.I_TB_TextChanged);
            // 
            // R_VLB
            // 
            this.R_VLB.AutoSize = true;
            this.R_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.R_VLB.Location = new System.Drawing.Point(172, 164);
            this.R_VLB.Name = "R_VLB";
            this.R_VLB.Size = new System.Drawing.Size(0, 13);
            this.R_VLB.TabIndex = 42;
            // 
            // R_TB
            // 
            this.R_TB.Location = new System.Drawing.Point(175, 134);
            this.R_TB.Name = "R_TB";
            this.R_TB.Size = new System.Drawing.Size(51, 20);
            this.R_TB.TabIndex = 43;
            this.R_TB.TextChanged += new System.EventHandler(this.R_TB_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "SD1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "SDS";
            // 
            // SD1_VLB
            // 
            this.SD1_VLB.AutoSize = true;
            this.SD1_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.SD1_VLB.Location = new System.Drawing.Point(142, 94);
            this.SD1_VLB.Name = "SD1_VLB";
            this.SD1_VLB.Size = new System.Drawing.Size(0, 13);
            this.SD1_VLB.TabIndex = 38;
            // 
            // SD1_TB
            // 
            this.SD1_TB.Location = new System.Drawing.Point(155, 63);
            this.SD1_TB.Name = "SD1_TB";
            this.SD1_TB.Size = new System.Drawing.Size(46, 20);
            this.SD1_TB.TabIndex = 39;
            this.SD1_TB.TextChanged += new System.EventHandler(this.SD1_TB_TextChanged);
            // 
            // SDS_VLB
            // 
            this.SDS_VLB.AutoSize = true;
            this.SDS_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.SDS_VLB.Location = new System.Drawing.Point(43, 94);
            this.SDS_VLB.Name = "SDS_VLB";
            this.SDS_VLB.Size = new System.Drawing.Size(0, 13);
            this.SDS_VLB.TabIndex = 36;
            // 
            // SDS_TB
            // 
            this.SDS_TB.Location = new System.Drawing.Point(48, 63);
            this.SDS_TB.Name = "SDS_TB";
            this.SDS_TB.Size = new System.Drawing.Size(37, 20);
            this.SDS_TB.TabIndex = 37;
            this.SDS_TB.TextChanged += new System.EventHandler(this.SDS_TB_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "TL";
            // 
            // TL_VLB
            // 
            this.TL_VLB.AutoSize = true;
            this.TL_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.TL_VLB.Location = new System.Drawing.Point(36, 46);
            this.TL_VLB.Name = "TL_VLB";
            this.TL_VLB.Size = new System.Drawing.Size(0, 13);
            this.TL_VLB.TabIndex = 32;
            // 
            // TL_TB
            // 
            this.TL_TB.Location = new System.Drawing.Point(41, 19);
            this.TL_TB.Name = "TL_TB";
            this.TL_TB.Size = new System.Drawing.Size(58, 20);
            this.TL_TB.TabIndex = 33;
            this.TL_TB.TextChanged += new System.EventHandler(this.TL_TB_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AISCE_btn);
            this.groupBox2.Controls.Add(this.K_VLB);
            this.groupBox2.Controls.Add(this.Generic_btn);
            this.groupBox2.Controls.Add(this.Uniform_Profile_btn);
            this.groupBox2.Controls.Add(this.Top_Force_btn);
            this.groupBox2.Controls.Add(this.K_TB);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.zedGraphControl1);
            this.groupBox2.Location = new System.Drawing.Point(6, 395);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 179);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Push Over Profile";
            // 
            // AISCE_btn
            // 
            this.AISCE_btn.AutoSize = true;
            this.AISCE_btn.Location = new System.Drawing.Point(3, 66);
            this.AISCE_btn.Name = "AISCE_btn";
            this.AISCE_btn.Size = new System.Drawing.Size(107, 30);
            this.AISCE_btn.TabIndex = 38;
            this.AISCE_btn.TabStop = true;
            this.AISCE_btn.Text = "Static equivalent\r\nloads distrubution";
            this.AISCE_btn.UseVisualStyleBackColor = true;
            this.AISCE_btn.CheckedChanged += new System.EventHandler(this.AISCE_btn_CheckedChanged);
            // 
            // K_VLB
            // 
            this.K_VLB.AutoSize = true;
            this.K_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.K_VLB.Location = new System.Drawing.Point(32, 158);
            this.K_VLB.Name = "K_VLB";
            this.K_VLB.Size = new System.Drawing.Size(0, 13);
            this.K_VLB.TabIndex = 37;
            // 
            // Generic_btn
            // 
            this.Generic_btn.AutoSize = true;
            this.Generic_btn.Location = new System.Drawing.Point(2, 97);
            this.Generic_btn.Name = "Generic_btn";
            this.Generic_btn.Size = new System.Drawing.Size(94, 17);
            this.Generic_btn.TabIndex = 18;
            this.Generic_btn.TabStop = true;
            this.Generic_btn.Text = "Generic Profile";
            this.Generic_btn.UseVisualStyleBackColor = true;
            this.Generic_btn.CheckedChanged += new System.EventHandler(this.Generic_btn_CheckedChanged);
            // 
            // Uniform_Profile_btn
            // 
            this.Uniform_Profile_btn.AutoSize = true;
            this.Uniform_Profile_btn.Location = new System.Drawing.Point(3, 42);
            this.Uniform_Profile_btn.Name = "Uniform_Profile_btn";
            this.Uniform_Profile_btn.Size = new System.Drawing.Size(93, 17);
            this.Uniform_Profile_btn.TabIndex = 17;
            this.Uniform_Profile_btn.TabStop = true;
            this.Uniform_Profile_btn.Text = "Uniform Profile";
            this.Uniform_Profile_btn.UseVisualStyleBackColor = true;
            this.Uniform_Profile_btn.CheckedChanged += new System.EventHandler(this.Uniform_Profile_btn_CheckedChanged);
            // 
            // Top_Force_btn
            // 
            this.Top_Force_btn.AutoSize = true;
            this.Top_Force_btn.Location = new System.Drawing.Point(3, 19);
            this.Top_Force_btn.Name = "Top_Force_btn";
            this.Top_Force_btn.Size = new System.Drawing.Size(106, 17);
            this.Top_Force_btn.TabIndex = 16;
            this.Top_Force_btn.TabStop = true;
            this.Top_Force_btn.Text = "Single Top Force";
            this.Top_Force_btn.UseVisualStyleBackColor = true;
            this.Top_Force_btn.CheckedChanged += new System.EventHandler(this.Top_Force_btn_CheckedChanged);
            // 
            // K_TB
            // 
            this.K_TB.Location = new System.Drawing.Point(57, 133);
            this.K_TB.Name = "K_TB";
            this.K_TB.Size = new System.Drawing.Size(49, 20);
            this.K_TB.TabIndex = 15;
            this.K_TB.TextChanged += new System.EventHandler(this.K_TB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Profile power :";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(112, 19);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(127, 152);
            this.zedGraphControl1.TabIndex = 13;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.IsEnableHPan = false;
            this.zedGraphControl2.IsEnableHZoom = false;
            this.zedGraphControl2.IsEnableVPan = false;
            this.zedGraphControl2.IsEnableVZoom = false;
            this.zedGraphControl2.Location = new System.Drawing.Point(6, 253);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(245, 136);
            this.zedGraphControl2.TabIndex = 24;
            this.zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // R_Label
            // 
            this.R_Label.AutoSize = true;
            this.R_Label.Location = new System.Drawing.Point(8, 234);
            this.R_Label.Name = "R_Label";
            this.R_Label.Size = new System.Drawing.Size(35, 13);
            this.R_Label.TabIndex = 25;
            this.R_Label.Text = "label4";
            // 
            // DialogLateralResistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.R_Label);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DialogLateralResistance";
            this.Load += new System.EventHandler(this.DialogLateralResistance_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.zedGraphControl2, 0);
            this.Controls.SetChildIndex(this.R_Label, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox Ta_CheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label I_VLB;
        private System.Windows.Forms.TextBox I_TB;
        private System.Windows.Forms.Label R_VLB;
        private System.Windows.Forms.TextBox R_TB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label SD1_VLB;
        private System.Windows.Forms.TextBox SD1_TB;
        private System.Windows.Forms.Label SDS_VLB;
        private System.Windows.Forms.TextBox SDS_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TL_VLB;
        private System.Windows.Forms.TextBox TL_TB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Generic_btn;
        private System.Windows.Forms.RadioButton Uniform_Profile_btn;
        private System.Windows.Forms.RadioButton Top_Force_btn;
        private System.Windows.Forms.TextBox K_TB;
        private System.Windows.Forms.Label label3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label K_VLB;
        private System.Windows.Forms.RadioButton AISCE_btn;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.Label R_Label;
    }
}
