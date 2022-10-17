namespace SPSW_Solver
{
    partial class DialogMaterialBasicDataControl
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
            this.Name_TB = new System.Windows.Forms.TextBox();
            this.Name_VLB = new System.Windows.Forms.Label();
            this.E_VLB = new System.Windows.Forms.Label();
            this.E_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Nu_VLB = new System.Windows.Forms.Label();
            this.Nu_TB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Density_VLB = new System.Windows.Forms.Label();
            this.Density_TB = new System.Windows.Forms.TextBox();
            this.Density_Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.generic_Rtbn = new System.Windows.Forms.RadioButton();
            this.Symmetric_Rtbn = new System.Windows.Forms.RadioButton();
            this.NoCompression_Rbtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Next_btn = new System.Windows.Forms.Button();
            this.Back_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // Name_TB
            // 
            this.Name_TB.Location = new System.Drawing.Point(122, 28);
            this.Name_TB.Name = "Name_TB";
            this.Name_TB.Size = new System.Drawing.Size(100, 20);
            this.Name_TB.TabIndex = 1;
            this.Name_TB.TextChanged += new System.EventHandler(this.Name_TB_TextChanged);
            // 
            // Name_VLB
            // 
            this.Name_VLB.AutoSize = true;
            this.Name_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Name_VLB.Location = new System.Drawing.Point(122, 65);
            this.Name_VLB.Name = "Name_VLB";
            this.Name_VLB.Size = new System.Drawing.Size(35, 13);
            this.Name_VLB.TabIndex = 2;
            this.Name_VLB.Text = "label2";
            // 
            // E_VLB
            // 
            this.E_VLB.AutoSize = true;
            this.E_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.E_VLB.Location = new System.Drawing.Point(366, 65);
            this.E_VLB.Name = "E_VLB";
            this.E_VLB.Size = new System.Drawing.Size(35, 13);
            this.E_VLB.TabIndex = 5;
            this.E_VLB.Text = "label3";
            // 
            // E_TB
            // 
            this.E_TB.Location = new System.Drawing.Point(366, 28);
            this.E_TB.Name = "E_TB";
            this.E_TB.Size = new System.Drawing.Size(100, 20);
            this.E_TB.TabIndex = 4;
            this.E_TB.TextChanged += new System.EventHandler(this.E_TB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modulus of Elasticity";
            // 
            // Nu_VLB
            // 
            this.Nu_VLB.AutoSize = true;
            this.Nu_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Nu_VLB.Location = new System.Drawing.Point(122, 163);
            this.Nu_VLB.Name = "Nu_VLB";
            this.Nu_VLB.Size = new System.Drawing.Size(35, 13);
            this.Nu_VLB.TabIndex = 8;
            this.Nu_VLB.Text = "label5";
            // 
            // Nu_TB
            // 
            this.Nu_TB.Location = new System.Drawing.Point(122, 126);
            this.Nu_TB.Name = "Nu_TB";
            this.Nu_TB.Size = new System.Drawing.Size(100, 20);
            this.Nu_TB.TabIndex = 7;
            this.Nu_TB.TextChanged += new System.EventHandler(this.Nu_TB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Poisson \'s Ratio";
            // 
            // Density_VLB
            // 
            this.Density_VLB.AutoSize = true;
            this.Density_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Density_VLB.Location = new System.Drawing.Point(366, 163);
            this.Density_VLB.Name = "Density_VLB";
            this.Density_VLB.Size = new System.Drawing.Size(35, 13);
            this.Density_VLB.TabIndex = 11;
            this.Density_VLB.Text = "label7";
            // 
            // Density_TB
            // 
            this.Density_TB.Location = new System.Drawing.Point(366, 126);
            this.Density_TB.Name = "Density_TB";
            this.Density_TB.Size = new System.Drawing.Size(100, 20);
            this.Density_TB.TabIndex = 10;
            this.Density_TB.TextChanged += new System.EventHandler(this.Density_TB_TextChanged);
            // 
            // Density_Label
            // 
            this.Density_Label.AutoSize = true;
            this.Density_Label.Location = new System.Drawing.Point(280, 129);
            this.Density_Label.Name = "Density_Label";
            this.Density_Label.Size = new System.Drawing.Size(42, 13);
            this.Density_Label.TabIndex = 9;
            this.Density_Label.Text = "Density";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.generic_Rtbn);
            this.groupBox1.Controls.Add(this.Symmetric_Rtbn);
            this.groupBox1.Controls.Add(this.NoCompression_Rbtn);
            this.groupBox1.Location = new System.Drawing.Point(18, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 108);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material Behavior curve";
            // 
            // generic_Rtbn
            // 
            this.generic_Rtbn.AutoSize = true;
            this.generic_Rtbn.Location = new System.Drawing.Point(20, 66);
            this.generic_Rtbn.Name = "generic_Rtbn";
            this.generic_Rtbn.Size = new System.Drawing.Size(333, 17);
            this.generic_Rtbn.TabIndex = 2;
            this.generic_Rtbn.TabStop = true;
            this.generic_Rtbn.Text = "Generic curve ( tension and compression values aren\'t symmetric)";
            this.generic_Rtbn.UseVisualStyleBackColor = true;
            this.generic_Rtbn.CheckedChanged += new System.EventHandler(this.Generic_Rtbn_CheckedChanged);
            // 
            // Symmetric_Rtbn
            // 
            this.Symmetric_Rtbn.AutoSize = true;
            this.Symmetric_Rtbn.Location = new System.Drawing.Point(190, 29);
            this.Symmetric_Rtbn.Name = "Symmetric_Rtbn";
            this.Symmetric_Rtbn.Size = new System.Drawing.Size(229, 17);
            this.Symmetric_Rtbn.TabIndex = 1;
            this.Symmetric_Rtbn.TabStop = true;
            this.Symmetric_Rtbn.Text = "Tension and compression symmetric values";
            this.Symmetric_Rtbn.UseVisualStyleBackColor = true;
            this.Symmetric_Rtbn.CheckedChanged += new System.EventHandler(this.Symmetric_Rtbn_CheckedChanged);
            // 
            // NoCompression_Rbtn
            // 
            this.NoCompression_Rbtn.AutoSize = true;
            this.NoCompression_Rbtn.Location = new System.Drawing.Point(20, 29);
            this.NoCompression_Rbtn.Name = "NoCompression_Rbtn";
            this.NoCompression_Rbtn.Size = new System.Drawing.Size(142, 17);
            this.NoCompression_Rbtn.TabIndex = 0;
            this.NoCompression_Rbtn.TabStop = true;
            this.NoCompression_Rbtn.Text = "No compression strength";
            this.NoCompression_Rbtn.UseVisualStyleBackColor = true;
            this.NoCompression_Rbtn.CheckedChanged += new System.EventHandler(this.NoCompression_Rbtn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Name_TB);
            this.groupBox2.Controls.Add(this.Density_VLB);
            this.groupBox2.Controls.Add(this.Name_VLB);
            this.groupBox2.Controls.Add(this.Density_TB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Density_Label);
            this.groupBox2.Controls.Add(this.E_TB);
            this.groupBox2.Controls.Add(this.Nu_VLB);
            this.groupBox2.Controls.Add(this.E_VLB);
            this.groupBox2.Controls.Add(this.Nu_TB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(18, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 212);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // Next_btn
            // 
            this.Next_btn.Location = new System.Drawing.Point(370, 382);
            this.Next_btn.Name = "Next_btn";
            this.Next_btn.Size = new System.Drawing.Size(97, 23);
            this.Next_btn.TabIndex = 14;
            this.Next_btn.Text = "Next >>";
            this.Next_btn.UseVisualStyleBackColor = true;
            this.Next_btn.Click += new System.EventHandler(this.Next_btn_Click);
            // 
            // Back_btn
            // 
            this.Back_btn.Location = new System.Drawing.Point(49, 382);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(97, 23);
            this.Back_btn.TabIndex = 15;
            this.Back_btn.Text = "<< Back";
            this.Back_btn.UseVisualStyleBackColor = true;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // DialogMaterialBasicDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Back_btn);
            this.Controls.Add(this.Next_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DialogMaterialBasicDataControl";
            this.Load += new System.EventHandler(this.DialogMaterialBasicDataControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Name_TB;
        private System.Windows.Forms.Label Name_VLB;
        private System.Windows.Forms.Label E_VLB;
        private System.Windows.Forms.TextBox E_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Nu_VLB;
        private System.Windows.Forms.TextBox Nu_TB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Density_VLB;
        private System.Windows.Forms.TextBox Density_TB;
        private System.Windows.Forms.Label Density_Label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton generic_Rtbn;
        private System.Windows.Forms.RadioButton Symmetric_Rtbn;
        private System.Windows.Forms.RadioButton NoCompression_Rbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Next_btn;
        private System.Windows.Forms.Button Back_btn;
    }
}
