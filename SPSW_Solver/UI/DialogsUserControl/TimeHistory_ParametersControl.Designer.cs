namespace SPSW_Solver
{
    partial class Time_History_ParametersControl
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
            this.GroundMotion_GB = new System.Windows.Forms.GroupBox();
            this.LoadFactor_VLB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadFactor_Tb = new System.Windows.Forms.TextBox();
            this.NSteps_VLB = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NSteps_TB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TimeStep_VLB = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TimeStep_TB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CDamping_VLB = new System.Windows.Forms.Label();
            this.CDamping_TB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CDamping_Rbtn = new System.Windows.Forms.RadioButton();
            this.BetaK_TB = new System.Windows.Forms.TextBox();
            this.RDamping_Rbtn = new System.Windows.Forms.RadioButton();
            this.alphaM_TB = new System.Windows.Forms.TextBox();
            this.Damping_VLB = new System.Windows.Forms.Label();
            this.BetaK_VLB = new System.Windows.Forms.Label();
            this.alphaM_VLB = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Gamma_TB = new System.Windows.Forms.TextBox();
            this.Beta_TB = new System.Windows.Forms.TextBox();
            this.Alpha_TB = new System.Windows.Forms.TextBox();
            this.Integrator_VLB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Integrator_CBox = new System.Windows.Forms.ComboBox();
            this.GroundMotion_GB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroundMotion_GB
            // 
            this.GroundMotion_GB.Controls.Add(this.LoadFactor_VLB);
            this.GroundMotion_GB.Controls.Add(this.label2);
            this.GroundMotion_GB.Controls.Add(this.loadFactor_Tb);
            this.GroundMotion_GB.Controls.Add(this.NSteps_VLB);
            this.GroundMotion_GB.Controls.Add(this.label9);
            this.GroundMotion_GB.Controls.Add(this.NSteps_TB);
            this.GroundMotion_GB.Controls.Add(this.label7);
            this.GroundMotion_GB.Controls.Add(this.TimeStep_VLB);
            this.GroundMotion_GB.Controls.Add(this.label6);
            this.GroundMotion_GB.Controls.Add(this.TimeStep_TB);
            this.GroundMotion_GB.Controls.Add(this.button1);
            this.GroundMotion_GB.Location = new System.Drawing.Point(4, 4);
            this.GroundMotion_GB.Margin = new System.Windows.Forms.Padding(4);
            this.GroundMotion_GB.Name = "GroundMotion_GB";
            this.GroundMotion_GB.Padding = new System.Windows.Forms.Padding(4);
            this.GroundMotion_GB.Size = new System.Drawing.Size(299, 162);
            this.GroundMotion_GB.TabIndex = 12;
            this.GroundMotion_GB.TabStop = false;
            this.GroundMotion_GB.Text = "ground-motion file";
            // 
            // LoadFactor_VLB
            // 
            this.LoadFactor_VLB.AutoSize = true;
            this.LoadFactor_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.LoadFactor_VLB.Location = new System.Drawing.Point(115, 65);
            this.LoadFactor_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LoadFactor_VLB.Name = "LoadFactor_VLB";
            this.LoadFactor_VLB.Size = new System.Drawing.Size(0, 17);
            this.LoadFactor_VLB.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Load Factor\r\n";
            // 
            // loadFactor_Tb
            // 
            this.loadFactor_Tb.Location = new System.Drawing.Point(11, 44);
            this.loadFactor_Tb.Margin = new System.Windows.Forms.Padding(4);
            this.loadFactor_Tb.Name = "loadFactor_Tb";
            this.loadFactor_Tb.Size = new System.Drawing.Size(69, 22);
            this.loadFactor_Tb.TabIndex = 15;
            this.loadFactor_Tb.TextChanged += new System.EventHandler(this.LoadFactor_Tb_TextChanged);
            // 
            // NSteps_VLB
            // 
            this.NSteps_VLB.AutoSize = true;
            this.NSteps_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.NSteps_VLB.Location = new System.Drawing.Point(187, 142);
            this.NSteps_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NSteps_VLB.Name = "NSteps_VLB";
            this.NSteps_VLB.Size = new System.Drawing.Size(0, 17);
            this.NSteps_VLB.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(173, 79);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Number of steps";
            // 
            // NSteps_TB
            // 
            this.NSteps_TB.Location = new System.Drawing.Point(177, 102);
            this.NSteps_TB.Margin = new System.Windows.Forms.Padding(4);
            this.NSteps_TB.Name = "NSteps_TB";
            this.NSteps_TB.Size = new System.Drawing.Size(83, 22);
            this.NSteps_TB.TabIndex = 12;
            this.NSteps_TB.TextChanged += new System.EventHandler(this.NSteps_TB_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "seconds";
            // 
            // TimeStep_VLB
            // 
            this.TimeStep_VLB.AutoSize = true;
            this.TimeStep_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.TimeStep_VLB.Location = new System.Drawing.Point(12, 142);
            this.TimeStep_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeStep_VLB.Name = "TimeStep_VLB";
            this.TimeStep_VLB.Size = new System.Drawing.Size(0, 17);
            this.TimeStep_VLB.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Time step";
            // 
            // TimeStep_TB
            // 
            this.TimeStep_TB.Location = new System.Drawing.Point(11, 102);
            this.TimeStep_TB.Margin = new System.Windows.Forms.Padding(4);
            this.TimeStep_TB.Name = "TimeStep_TB";
            this.TimeStep_TB.Size = new System.Drawing.Size(69, 22);
            this.TimeStep_TB.TabIndex = 8;
            this.TimeStep_TB.TextChanged += new System.EventHandler(this.TimeStep_TB_TextChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(123, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add / Edit analysis files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CDamping_VLB);
            this.groupBox2.Controls.Add(this.CDamping_TB);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.CDamping_Rbtn);
            this.groupBox2.Controls.Add(this.BetaK_TB);
            this.groupBox2.Controls.Add(this.RDamping_Rbtn);
            this.groupBox2.Controls.Add(this.alphaM_TB);
            this.groupBox2.Controls.Add(this.Damping_VLB);
            this.groupBox2.Controls.Add(this.BetaK_VLB);
            this.groupBox2.Controls.Add(this.alphaM_VLB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(2, 167);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(301, 246);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rayleigh Damping";
            // 
            // CDamping_VLB
            // 
            this.CDamping_VLB.AutoSize = true;
            this.CDamping_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.CDamping_VLB.Location = new System.Drawing.Point(31, 81);
            this.CDamping_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CDamping_VLB.Name = "CDamping_VLB";
            this.CDamping_VLB.Size = new System.Drawing.Size(0, 17);
            this.CDamping_VLB.TabIndex = 16;
            // 
            // CDamping_TB
            // 
            this.CDamping_TB.Location = new System.Drawing.Point(123, 52);
            this.CDamping_TB.Margin = new System.Windows.Forms.Padding(4);
            this.CDamping_TB.Name = "CDamping_TB";
            this.CDamping_TB.Size = new System.Drawing.Size(80, 22);
            this.CDamping_TB.TabIndex = 15;
            this.CDamping_TB.TextChanged += new System.EventHandler(this.CDamping_TB_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Damping Ratio";
            // 
            // CDamping_Rbtn
            // 
            this.CDamping_Rbtn.AutoSize = true;
            this.CDamping_Rbtn.Location = new System.Drawing.Point(16, 25);
            this.CDamping_Rbtn.Margin = new System.Windows.Forms.Padding(4);
            this.CDamping_Rbtn.Name = "CDamping_Rbtn";
            this.CDamping_Rbtn.Size = new System.Drawing.Size(175, 21);
            this.CDamping_Rbtn.TabIndex = 13;
            this.CDamping_Rbtn.TabStop = true;
            this.CDamping_Rbtn.Text = "Constant damping ratio";
            this.CDamping_Rbtn.UseVisualStyleBackColor = true;
            this.CDamping_Rbtn.CheckedChanged += new System.EventHandler(this.CDamping_Rbtn_CheckedChanged);
            // 
            // BetaK_TB
            // 
            this.BetaK_TB.Location = new System.Drawing.Point(75, 182);
            this.BetaK_TB.Margin = new System.Windows.Forms.Padding(4);
            this.BetaK_TB.Name = "BetaK_TB";
            this.BetaK_TB.Size = new System.Drawing.Size(80, 22);
            this.BetaK_TB.TabIndex = 5;
            this.BetaK_TB.TextChanged += new System.EventHandler(this.BetaK_TB_TextChanged);
            // 
            // RDamping_Rbtn
            // 
            this.RDamping_Rbtn.AutoSize = true;
            this.RDamping_Rbtn.Location = new System.Drawing.Point(13, 123);
            this.RDamping_Rbtn.Margin = new System.Windows.Forms.Padding(4);
            this.RDamping_Rbtn.Name = "RDamping_Rbtn";
            this.RDamping_Rbtn.Size = new System.Drawing.Size(221, 21);
            this.RDamping_Rbtn.TabIndex = 12;
            this.RDamping_Rbtn.TabStop = true;
            this.RDamping_Rbtn.Text = "Rayleigh Damping Coefficients";
            this.RDamping_Rbtn.UseVisualStyleBackColor = true;
            this.RDamping_Rbtn.CheckedChanged += new System.EventHandler(this.RDamping_Rbtn_CheckedChanged);
            // 
            // alphaM_TB
            // 
            this.alphaM_TB.Location = new System.Drawing.Point(75, 151);
            this.alphaM_TB.Margin = new System.Windows.Forms.Padding(4);
            this.alphaM_TB.Name = "alphaM_TB";
            this.alphaM_TB.Size = new System.Drawing.Size(80, 22);
            this.alphaM_TB.TabIndex = 4;
            this.alphaM_TB.TextChanged += new System.EventHandler(this.AlphaM_TB_TextChanged);
            // 
            // Damping_VLB
            // 
            this.Damping_VLB.AutoSize = true;
            this.Damping_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Damping_VLB.Location = new System.Drawing.Point(31, 228);
            this.Damping_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Damping_VLB.Name = "Damping_VLB";
            this.Damping_VLB.Size = new System.Drawing.Size(0, 17);
            this.Damping_VLB.TabIndex = 11;
            // 
            // BetaK_VLB
            // 
            this.BetaK_VLB.AutoSize = true;
            this.BetaK_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.BetaK_VLB.Location = new System.Drawing.Point(184, 186);
            this.BetaK_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BetaK_VLB.Name = "BetaK_VLB";
            this.BetaK_VLB.Size = new System.Drawing.Size(0, 17);
            this.BetaK_VLB.TabIndex = 9;
            // 
            // alphaM_VLB
            // 
            this.alphaM_VLB.AutoSize = true;
            this.alphaM_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.alphaM_VLB.Location = new System.Drawing.Point(185, 155);
            this.alphaM_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.alphaM_VLB.Name = "alphaM_VLB";
            this.alphaM_VLB.Size = new System.Drawing.Size(0, 17);
            this.alphaM_VLB.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 186);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Beta K";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 155);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Alpha M";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Gamma_TB);
            this.groupBox1.Controls.Add(this.Beta_TB);
            this.groupBox1.Controls.Add(this.Alpha_TB);
            this.groupBox1.Controls.Add(this.Integrator_VLB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Integrator_CBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 415);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 124);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Integrator";
            // 
            // Gamma_TB
            // 
            this.Gamma_TB.Location = new System.Drawing.Point(209, 86);
            this.Gamma_TB.Name = "Gamma_TB";
            this.Gamma_TB.Size = new System.Drawing.Size(59, 22);
            this.Gamma_TB.TabIndex = 7;
            this.Gamma_TB.TextChanged += new System.EventHandler(this.Gamma_TB_TextChanged);
            // 
            // Beta_TB
            // 
            this.Beta_TB.Location = new System.Drawing.Point(103, 86);
            this.Beta_TB.Name = "Beta_TB";
            this.Beta_TB.Size = new System.Drawing.Size(59, 22);
            this.Beta_TB.TabIndex = 6;
            this.Beta_TB.TextChanged += new System.EventHandler(this.Beta_TB_TextChanged);
            // 
            // Alpha_TB
            // 
            this.Alpha_TB.Location = new System.Drawing.Point(7, 86);
            this.Alpha_TB.Name = "Alpha_TB";
            this.Alpha_TB.Size = new System.Drawing.Size(59, 22);
            this.Alpha_TB.TabIndex = 5;
            this.Alpha_TB.TextChanged += new System.EventHandler(this.Alpha_TB_TextChanged);
            // 
            // Integrator_VLB
            // 
            this.Integrator_VLB.AutoSize = true;
            this.Integrator_VLB.ForeColor = System.Drawing.Color.Red;
            this.Integrator_VLB.Location = new System.Drawing.Point(6, 24);
            this.Integrator_VLB.Name = "Integrator_VLB";
            this.Integrator_VLB.Size = new System.Drawing.Size(100, 17);
            this.Integrator_VLB.TabIndex = 4;
            this.Integrator_VLB.Text = "Invalid Params";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "gamma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Beta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alpha";
            // 
            // Integrator_CBox
            // 
            this.Integrator_CBox.FormattingEnabled = true;
            this.Integrator_CBox.Location = new System.Drawing.Point(143, 21);
            this.Integrator_CBox.Name = "Integrator_CBox";
            this.Integrator_CBox.Size = new System.Drawing.Size(148, 24);
            this.Integrator_CBox.TabIndex = 0;
            this.Integrator_CBox.SelectedIndexChanged += new System.EventHandler(this.Integrator_CBox_SelectedIndexChanged);
            // 
            // Time_History_ParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroundMotion_GB);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Time_History_ParametersControl";
            this.Size = new System.Drawing.Size(307, 542);
            this.Load += new System.EventHandler(this.IDA_ParametersControl_Load);
            this.GroundMotion_GB.ResumeLayout(false);
            this.GroundMotion_GB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroundMotion_GB;
        private System.Windows.Forms.Label NSteps_VLB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NSteps_TB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TimeStep_VLB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TimeStep_TB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label CDamping_VLB;
        private System.Windows.Forms.TextBox CDamping_TB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton CDamping_Rbtn;
        private System.Windows.Forms.TextBox BetaK_TB;
        private System.Windows.Forms.RadioButton RDamping_Rbtn;
        private System.Windows.Forms.TextBox alphaM_TB;
        private System.Windows.Forms.Label Damping_VLB;
        private System.Windows.Forms.Label BetaK_VLB;
        private System.Windows.Forms.Label alphaM_VLB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LoadFactor_VLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loadFactor_Tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Integrator_CBox;
        private System.Windows.Forms.TextBox Alpha_TB;
        private System.Windows.Forms.Label Integrator_VLB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Gamma_TB;
        private System.Windows.Forms.TextBox Beta_TB;
    }
}
