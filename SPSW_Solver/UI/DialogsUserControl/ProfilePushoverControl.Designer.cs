namespace SPSW_Solver
{
    partial class ProfilePushoverControl
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
            this.DisControl_Rtb = new System.Windows.Forms.RadioButton();
            this.LoadControl_Rtb = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NSteps_VLB = new System.Windows.Forms.Label();
            this.MaxDrift_VLB = new System.Windows.Forms.Label();
            this.NSteps_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Drift_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.K_VLB = new System.Windows.Forms.Label();
            this.Omega_VLB = new System.Windows.Forms.Label();
            this.textBox_Omega = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Vd_Label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisControl_Rtb
            // 
            this.DisControl_Rtb.AutoSize = true;
            this.DisControl_Rtb.Location = new System.Drawing.Point(6, 45);
            this.DisControl_Rtb.Name = "DisControl_Rtb";
            this.DisControl_Rtb.Size = new System.Drawing.Size(125, 17);
            this.DisControl_Rtb.TabIndex = 1;
            this.DisControl_Rtb.TabStop = true;
            this.DisControl_Rtb.Text = "Displacement Control";
            this.DisControl_Rtb.UseVisualStyleBackColor = true;
            this.DisControl_Rtb.CheckedChanged += new System.EventHandler(this.DisControl_Rtb_CheckedChanged);
            // 
            // LoadControl_Rtb
            // 
            this.LoadControl_Rtb.AutoSize = true;
            this.LoadControl_Rtb.Location = new System.Drawing.Point(6, 111);
            this.LoadControl_Rtb.Name = "LoadControl_Rtb";
            this.LoadControl_Rtb.Size = new System.Drawing.Size(172, 17);
            this.LoadControl_Rtb.TabIndex = 2;
            this.LoadControl_Rtb.TabStop = true;
            this.LoadControl_Rtb.Text = "Load Control (Max Base Shear)";
            this.LoadControl_Rtb.UseVisualStyleBackColor = true;
            this.LoadControl_Rtb.CheckedChanged += new System.EventHandler(this.LoadControl_Rtb_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Vd_Label);
            this.groupBox1.Controls.Add(this.Omega_VLB);
            this.groupBox1.Controls.Add(this.textBox_Omega);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NSteps_VLB);
            this.groupBox1.Controls.Add(this.MaxDrift_VLB);
            this.groupBox1.Controls.Add(this.NSteps_TB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Drift_TB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DisControl_Rtb);
            this.groupBox1.Controls.Add(this.LoadControl_Rtb);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 219);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // NSteps_VLB
            // 
            this.NSteps_VLB.AutoSize = true;
            this.NSteps_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.NSteps_VLB.Location = new System.Drawing.Point(131, 16);
            this.NSteps_VLB.Name = "NSteps_VLB";
            this.NSteps_VLB.Size = new System.Drawing.Size(0, 13);
            this.NSteps_VLB.TabIndex = 6;
            // 
            // MaxDrift_VLB
            // 
            this.MaxDrift_VLB.AutoSize = true;
            this.MaxDrift_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.MaxDrift_VLB.Location = new System.Drawing.Point(55, 94);
            this.MaxDrift_VLB.Name = "MaxDrift_VLB";
            this.MaxDrift_VLB.Size = new System.Drawing.Size(0, 13);
            this.MaxDrift_VLB.TabIndex = 6;
            // 
            // NSteps_TB
            // 
            this.NSteps_TB.Location = new System.Drawing.Point(74, 13);
            this.NSteps_TB.Name = "NSteps_TB";
            this.NSteps_TB.Size = new System.Drawing.Size(49, 20);
            this.NSteps_TB.TabIndex = 5;
            this.NSteps_TB.TextChanged += new System.EventHandler(this.NSteps_TB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "% of Total Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "NO. Steps :";
            // 
            // Drift_TB
            // 
            this.Drift_TB.Location = new System.Drawing.Point(88, 68);
            this.Drift_TB.Name = "Drift_TB";
            this.Drift_TB.Size = new System.Drawing.Size(31, 20);
            this.Drift_TB.TabIndex = 4;
            this.Drift_TB.TextChanged += new System.EventHandler(this.Drift_TB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max. Drift";
            // 
            // K_VLB
            // 
            this.K_VLB.AutoSize = true;
            this.K_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.K_VLB.Location = new System.Drawing.Point(12, 251);
            this.K_VLB.Name = "K_VLB";
            this.K_VLB.Size = new System.Drawing.Size(0, 13);
            this.K_VLB.TabIndex = 9;
            // 
            // Omega_VLB
            // 
            this.Omega_VLB.AutoSize = true;
            this.Omega_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Omega_VLB.Location = new System.Drawing.Point(55, 187);
            this.Omega_VLB.Name = "Omega_VLB";
            this.Omega_VLB.Size = new System.Drawing.Size(0, 13);
            this.Omega_VLB.TabIndex = 10;
            // 
            // textBox_Omega
            // 
            this.textBox_Omega.Location = new System.Drawing.Point(128, 161);
            this.textBox_Omega.Name = "textBox_Omega";
            this.textBox_Omega.Size = new System.Drawing.Size(55, 20);
            this.textBox_Omega.TabIndex = 8;
            this.textBox_Omega.TextChanged += new System.EventHandler(this.TextBox_Omega_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ω (Overstrength)";
            // 
            // Vd_Label
            // 
            this.Vd_Label.AutoSize = true;
            this.Vd_Label.Location = new System.Drawing.Point(33, 135);
            this.Vd_Label.Name = "Vd_Label";
            this.Vd_Label.Size = new System.Drawing.Size(35, 13);
            this.Vd_Label.TabIndex = 11;
            this.Vd_Label.Text = "label4";
            // 
            // ProfilePushoverControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.K_VLB);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProfilePushoverControl";
            this.Size = new System.Drawing.Size(230, 440);
            this.Load += new System.EventHandler(this.ProfilePushoverControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton DisControl_Rtb;
        private System.Windows.Forms.RadioButton LoadControl_Rtb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label MaxDrift_VLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Drift_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NSteps_TB;
        private System.Windows.Forms.Label NSteps_VLB;
        private System.Windows.Forms.Label K_VLB;
        private System.Windows.Forms.Label Vd_Label;
        private System.Windows.Forms.Label Omega_VLB;
        private System.Windows.Forms.TextBox textBox_Omega;
        private System.Windows.Forms.Label label6;
    }
}
