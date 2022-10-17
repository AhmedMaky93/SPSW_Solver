namespace SPSW_Solver
{
    partial class PushOverCurvefrm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.Drift_btn = new System.Windows.Forms.RadioButton();
            this.Displacement_Btn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Export_btn = new System.Windows.Forms.Button();
            this.Story_TB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.R_LB = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Meu_LB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.W_LB = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Omega_LB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Vd_LB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Cs_LB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loadCaseControl1 = new SPSW_Solver.LoadCaseControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(356, 4);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(709, 433);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // Drift_btn
            // 
            this.Drift_btn.AutoSize = true;
            this.Drift_btn.Location = new System.Drawing.Point(8, 52);
            this.Drift_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Drift_btn.Name = "Drift_btn";
            this.Drift_btn.Size = new System.Drawing.Size(118, 21);
            this.Drift_btn.TabIndex = 1;
            this.Drift_btn.TabStop = true;
            this.Drift_btn.Text = "Interstory Drift";
            this.Drift_btn.UseVisualStyleBackColor = true;
            this.Drift_btn.CheckedChanged += new System.EventHandler(this.Drift_btn_CheckedChanged);
            // 
            // Displacement_Btn
            // 
            this.Displacement_Btn.AutoSize = true;
            this.Displacement_Btn.Location = new System.Drawing.Point(8, 23);
            this.Displacement_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Displacement_Btn.Name = "Displacement_Btn";
            this.Displacement_Btn.Size = new System.Drawing.Size(163, 21);
            this.Displacement_Btn.TabIndex = 2;
            this.Displacement_Btn.TabStop = true;
            this.Displacement_Btn.Text = "Roof Drift (All Height)";
            this.Displacement_Btn.UseVisualStyleBackColor = true;
            this.Displacement_Btn.CheckedChanged += new System.EventHandler(this.Displacement_Btn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Export_btn);
            this.groupBox1.Controls.Add(this.Story_TB);
            this.groupBox1.Controls.Add(this.Displacement_Btn);
            this.groupBox1.Controls.Add(this.Drift_btn);
            this.groupBox1.Location = new System.Drawing.Point(3, 161);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(344, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "charts";
            // 
            // Export_btn
            // 
            this.Export_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export_btn.Location = new System.Drawing.Point(221, 23);
            this.Export_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Export_btn.Name = "Export_btn";
            this.Export_btn.Size = new System.Drawing.Size(115, 53);
            this.Export_btn.TabIndex = 4;
            this.Export_btn.Text = "Export To Excel sheets";
            this.Export_btn.UseVisualStyleBackColor = true;
            this.Export_btn.Click += new System.EventHandler(this.Export_btn_Click);
            // 
            // Story_TB
            // 
            this.Story_TB.Location = new System.Drawing.Point(134, 52);
            this.Story_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Story_TB.Name = "Story_TB";
            this.Story_TB.Size = new System.Drawing.Size(49, 22);
            this.Story_TB.TabIndex = 3;
            this.Story_TB.TextChanged += new System.EventHandler(this.Story_TB_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.R_LB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Meu_LB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.W_LB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Omega_LB);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Vd_LB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Cs_LB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 249);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(344, 188);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // R_LB
            // 
            this.R_LB.AutoSize = true;
            this.R_LB.Location = new System.Drawing.Point(53, 46);
            this.R_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.R_LB.Name = "R_LB";
            this.R_LB.Size = new System.Drawing.Size(0, 17);
            this.R_LB.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "R :";
            // 
            // Meu_LB
            // 
            this.Meu_LB.AutoSize = true;
            this.Meu_LB.Location = new System.Drawing.Point(136, 162);
            this.Meu_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Meu_LB.Name = "Meu_LB";
            this.Meu_LB.Size = new System.Drawing.Size(0, 17);
            this.Meu_LB.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 162);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "μT = (δu/ δy,eff) :";
            // 
            // W_LB
            // 
            this.W_LB.AutoSize = true;
            this.W_LB.Location = new System.Drawing.Point(51, 73);
            this.W_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.W_LB.Name = "W_LB";
            this.W_LB.Size = new System.Drawing.Size(0, 17);
            this.W_LB.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "W :";
            // 
            // Omega_LB
            // 
            this.Omega_LB.AutoSize = true;
            this.Omega_LB.Location = new System.Drawing.Point(145, 134);
            this.Omega_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Omega_LB.Name = "Omega_LB";
            this.Omega_LB.Size = new System.Drawing.Size(0, 17);
            this.Omega_LB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ω0 = (Vmax / Vd) :";
            // 
            // Vd_LB
            // 
            this.Vd_LB.AutoSize = true;
            this.Vd_LB.Location = new System.Drawing.Point(51, 100);
            this.Vd_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Vd_LB.Name = "Vd_LB";
            this.Vd_LB.Size = new System.Drawing.Size(0, 17);
            this.Vd_LB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vd :";
            // 
            // Cs_LB
            // 
            this.Cs_LB.AutoSize = true;
            this.Cs_LB.Location = new System.Drawing.Point(57, 20);
            this.Cs_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cs_LB.Name = "Cs_LB";
            this.Cs_LB.Size = new System.Drawing.Size(0, 17);
            this.Cs_LB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cs :";
            // 
            // loadCaseControl1
            // 
            this.loadCaseControl1.LoadCasesCount = 1;
            this.loadCaseControl1.Location = new System.Drawing.Point(3, 4);
            this.loadCaseControl1.Margin = new System.Windows.Forms.Padding(5);
            this.loadCaseControl1.Name = "loadCaseControl1";
            this.loadCaseControl1.Size = new System.Drawing.Size(352, 160);
            this.loadCaseControl1.TabIndex = 5;
            // 
            // PushOverCurvefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 442);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loadCaseControl1);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PushOverCurvefrm";
            this.Text = "Pushover Curve";
            this.Load += new System.EventHandler(this.PushOverCurvefrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.RadioButton Drift_btn;
        private System.Windows.Forms.RadioButton Displacement_Btn;
        private LoadCaseControl loadCaseControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Vd_LB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Cs_LB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label W_LB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Omega_LB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Meu_LB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label R_LB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Story_TB;
        private System.Windows.Forms.Button Export_btn;
    }
}