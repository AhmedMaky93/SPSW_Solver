namespace SPSW_Solver
{
    partial class ModelSettingDialogControl
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Ground_Beam_btn = new System.Windows.Forms.RadioButton();
            this.Fixed_Btn = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.BaseOffset_TB = new System.Windows.Forms.TextBox();
            this.BaseOffset_VLB = new System.Windows.Forms.Label();
            this.Model_Layout_Btn = new System.Windows.Forms.Button();
            this.PanelZones_Chbox = new System.Windows.Forms.CheckBox();
            this.Width_VLB = new System.Windows.Forms.Label();
            this.ModelName_TB = new System.Windows.Forms.TextBox();
            this.ModelName_VLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Basler_linkLabel = new System.Windows.Forms.LinkLabel();
            this.Cardiff_linkLabel = new System.Windows.Forms.LinkLabel();
            this.AISC_linkLabel = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.MinStr_Tb = new System.Windows.Forms.TextBox();
            this.degrres_Tb = new System.Windows.Forms.Label();
            this.Min_Str_VLB = new System.Windows.Forms.Label();
            this.Angle_VLB = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Angle_TB = new System.Windows.Forms.TextBox();
            this.UserAngle_btn = new System.Windows.Forms.RadioButton();
            this.Basler = new System.Windows.Forms.RadioButton();
            this.Carddif_Btn = new System.Windows.Forms.RadioButton();
            this.AISC_Btn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.Model_Layout_Btn);
            this.groupBox1.Controls.Add(this.PanelZones_Chbox);
            this.groupBox1.Controls.Add(this.Width_VLB);
            this.groupBox1.Controls.Add(this.ModelName_TB);
            this.groupBox1.Controls.Add(this.ModelName_VLB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(331, 377);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Building Information";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Ground_Beam_btn);
            this.groupBox3.Controls.Add(this.Fixed_Btn);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.BaseOffset_TB);
            this.groupBox3.Controls.Add(this.BaseOffset_VLB);
            this.groupBox3.Location = new System.Drawing.Point(8, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 197);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Base Properties";
            // 
            // Ground_Beam_btn
            // 
            this.Ground_Beam_btn.AutoSize = true;
            this.Ground_Beam_btn.Location = new System.Drawing.Point(33, 79);
            this.Ground_Beam_btn.Name = "Ground_Beam_btn";
            this.Ground_Beam_btn.Size = new System.Drawing.Size(141, 21);
            this.Ground_Beam_btn.TabIndex = 21;
            this.Ground_Beam_btn.TabStop = true;
            this.Ground_Beam_btn.Text = "Using Base Beam";
            this.Ground_Beam_btn.UseVisualStyleBackColor = true;
            this.Ground_Beam_btn.CheckedChanged += new System.EventHandler(this.Ground_Beam_btn_CheckedChanged);
            // 
            // Fixed_Btn
            // 
            this.Fixed_Btn.AutoSize = true;
            this.Fixed_Btn.Location = new System.Drawing.Point(32, 38);
            this.Fixed_Btn.Name = "Fixed_Btn";
            this.Fixed_Btn.Size = new System.Drawing.Size(180, 21);
            this.Fixed_Btn.TabIndex = 20;
            this.Fixed_Btn.TabStop = true;
            this.Fixed_Btn.Text = "Fixed with Ground Level";
            this.Fixed_Btn.UseVisualStyleBackColor = true;
            this.Fixed_Btn.CheckedChanged += new System.EventHandler(this.Fixed_Btn_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 127);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Base Beam Elevation";
            // 
            // BaseOffset_TB
            // 
            this.BaseOffset_TB.Location = new System.Drawing.Point(190, 127);
            this.BaseOffset_TB.Margin = new System.Windows.Forms.Padding(4);
            this.BaseOffset_TB.Name = "BaseOffset_TB";
            this.BaseOffset_TB.Size = new System.Drawing.Size(103, 22);
            this.BaseOffset_TB.TabIndex = 19;
            this.BaseOffset_TB.TextChanged += new System.EventHandler(this.BaseOffset_TB_TextChanged);
            // 
            // BaseOffset_VLB
            // 
            this.BaseOffset_VLB.AutoSize = true;
            this.BaseOffset_VLB.ForeColor = System.Drawing.Color.Red;
            this.BaseOffset_VLB.Location = new System.Drawing.Point(39, 160);
            this.BaseOffset_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BaseOffset_VLB.Name = "BaseOffset_VLB";
            this.BaseOffset_VLB.Size = new System.Drawing.Size(46, 17);
            this.BaseOffset_VLB.TabIndex = 18;
            this.BaseOffset_VLB.Text = "label9";
            this.BaseOffset_VLB.Visible = false;
            // 
            // Model_Layout_Btn
            // 
            this.Model_Layout_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Model_Layout_Btn.Location = new System.Drawing.Point(46, 90);
            this.Model_Layout_Btn.Name = "Model_Layout_Btn";
            this.Model_Layout_Btn.Size = new System.Drawing.Size(226, 28);
            this.Model_Layout_Btn.TabIndex = 23;
            this.Model_Layout_Btn.Text = "Model Layout";
            this.Model_Layout_Btn.UseVisualStyleBackColor = true;
            this.Model_Layout_Btn.Click += new System.EventHandler(this.Model_Layout_Btn_Click);
            // 
            // PanelZones_Chbox
            // 
            this.PanelZones_Chbox.AutoSize = true;
            this.PanelZones_Chbox.Location = new System.Drawing.Point(20, 338);
            this.PanelZones_Chbox.Margin = new System.Windows.Forms.Padding(4);
            this.PanelZones_Chbox.Name = "PanelZones_Chbox";
            this.PanelZones_Chbox.Size = new System.Drawing.Size(289, 21);
            this.PanelZones_Chbox.TabIndex = 22;
            this.PanelZones_Chbox.Text = "Include Panel Zone in Beam-Column joint";
            this.PanelZones_Chbox.UseVisualStyleBackColor = true;
            this.PanelZones_Chbox.CheckedChanged += new System.EventHandler(this.PanelZones_Chbox_CheckedChanged);
            // 
            // Width_VLB
            // 
            this.Width_VLB.AutoSize = true;
            this.Width_VLB.ForeColor = System.Drawing.Color.Red;
            this.Width_VLB.Location = new System.Drawing.Point(5, 193);
            this.Width_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Width_VLB.Name = "Width_VLB";
            this.Width_VLB.Size = new System.Drawing.Size(0, 17);
            this.Width_VLB.TabIndex = 7;
            this.Width_VLB.Visible = false;
            // 
            // ModelName_TB
            // 
            this.ModelName_TB.Location = new System.Drawing.Point(140, 34);
            this.ModelName_TB.Margin = new System.Windows.Forms.Padding(4);
            this.ModelName_TB.Name = "ModelName_TB";
            this.ModelName_TB.Size = new System.Drawing.Size(132, 22);
            this.ModelName_TB.TabIndex = 2;
            this.ModelName_TB.TextChanged += new System.EventHandler(this.ModelName_TB_TextChanged);
            // 
            // ModelName_VLB
            // 
            this.ModelName_VLB.AutoSize = true;
            this.ModelName_VLB.ForeColor = System.Drawing.Color.Red;
            this.ModelName_VLB.Location = new System.Drawing.Point(47, 55);
            this.ModelName_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelName_VLB.Name = "ModelName_VLB";
            this.ModelName_VLB.Size = new System.Drawing.Size(46, 17);
            this.ModelName_VLB.TabIndex = 1;
            this.ModelName_VLB.Text = "label2";
            this.ModelName_VLB.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Basler_linkLabel);
            this.groupBox2.Controls.Add(this.Cardiff_linkLabel);
            this.groupBox2.Controls.Add(this.AISC_linkLabel);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.MinStr_Tb);
            this.groupBox2.Controls.Add(this.degrres_Tb);
            this.groupBox2.Controls.Add(this.Min_Str_VLB);
            this.groupBox2.Controls.Add(this.Angle_VLB);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.Angle_TB);
            this.groupBox2.Controls.Add(this.UserAngle_btn);
            this.groupBox2.Controls.Add(this.Basler);
            this.groupBox2.Controls.Add(this.Carddif_Btn);
            this.groupBox2.Controls.Add(this.AISC_Btn);
            this.groupBox2.Location = new System.Drawing.Point(4, 388);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(331, 319);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analysis Approach";
            // 
            // Basler_linkLabel
            // 
            this.Basler_linkLabel.AutoSize = true;
            this.Basler_linkLabel.Location = new System.Drawing.Point(43, 164);
            this.Basler_linkLabel.Name = "Basler_linkLabel";
            this.Basler_linkLabel.Size = new System.Drawing.Size(86, 17);
            this.Basler_linkLabel.TabIndex = 29;
            this.Basler_linkLabel.TabStop = true;
            this.Basler_linkLabel.Text = "Reference ..";
            this.Basler_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Basler_linkLabel_LinkClicked);
            // 
            // Cardiff_linkLabel
            // 
            this.Cardiff_linkLabel.AutoSize = true;
            this.Cardiff_linkLabel.Location = new System.Drawing.Point(43, 110);
            this.Cardiff_linkLabel.Name = "Cardiff_linkLabel";
            this.Cardiff_linkLabel.Size = new System.Drawing.Size(86, 17);
            this.Cardiff_linkLabel.TabIndex = 28;
            this.Cardiff_linkLabel.TabStop = true;
            this.Cardiff_linkLabel.Text = "Reference ..";
            this.Cardiff_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Cardiff_linkLabel_LinkClicked);
            // 
            // AISC_linkLabel
            // 
            this.AISC_linkLabel.AutoSize = true;
            this.AISC_linkLabel.Location = new System.Drawing.Point(43, 62);
            this.AISC_linkLabel.Name = "AISC_linkLabel";
            this.AISC_linkLabel.Size = new System.Drawing.Size(86, 17);
            this.AISC_linkLabel.TabIndex = 27;
            this.AISC_linkLabel.TabStop = true;
            this.AISC_linkLabel.Text = "Reference ..";
            this.AISC_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AISC_linkLabel_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(239, 251);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "(10 or more)";
            // 
            // MinStr_Tb
            // 
            this.MinStr_Tb.Location = new System.Drawing.Point(169, 247);
            this.MinStr_Tb.Margin = new System.Windows.Forms.Padding(4);
            this.MinStr_Tb.Name = "MinStr_Tb";
            this.MinStr_Tb.Size = new System.Drawing.Size(57, 22);
            this.MinStr_Tb.TabIndex = 25;
            this.MinStr_Tb.TextChanged += new System.EventHandler(this.MinStr_Tb_TextChanged);
            // 
            // degrres_Tb
            // 
            this.degrres_Tb.AutoSize = true;
            this.degrres_Tb.Location = new System.Drawing.Point(241, 203);
            this.degrres_Tb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.degrres_Tb.Name = "degrres_Tb";
            this.degrres_Tb.Size = new System.Drawing.Size(60, 17);
            this.degrres_Tb.TabIndex = 22;
            this.degrres_Tb.Text = "degrees";
            // 
            // Min_Str_VLB
            // 
            this.Min_Str_VLB.AutoSize = true;
            this.Min_Str_VLB.ForeColor = System.Drawing.Color.Red;
            this.Min_Str_VLB.Location = new System.Drawing.Point(24, 283);
            this.Min_Str_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Min_Str_VLB.Name = "Min_Str_VLB";
            this.Min_Str_VLB.Size = new System.Drawing.Size(46, 17);
            this.Min_Str_VLB.TabIndex = 24;
            this.Min_Str_VLB.Text = "label9";
            this.Min_Str_VLB.Visible = false;
            // 
            // Angle_VLB
            // 
            this.Angle_VLB.AutoSize = true;
            this.Angle_VLB.ForeColor = System.Drawing.Color.Red;
            this.Angle_VLB.Location = new System.Drawing.Point(161, 235);
            this.Angle_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Angle_VLB.Name = "Angle_VLB";
            this.Angle_VLB.Size = new System.Drawing.Size(0, 17);
            this.Angle_VLB.TabIndex = 23;
            this.Angle_VLB.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 251);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Min. number of strips ";
            // 
            // Angle_TB
            // 
            this.Angle_TB.Location = new System.Drawing.Point(147, 201);
            this.Angle_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Angle_TB.Name = "Angle_TB";
            this.Angle_TB.Size = new System.Drawing.Size(73, 22);
            this.Angle_TB.TabIndex = 9;
            this.Angle_TB.TextChanged += new System.EventHandler(this.Angle_TB_TextChanged);
            // 
            // UserAngle_btn
            // 
            this.UserAngle_btn.AutoSize = true;
            this.UserAngle_btn.Location = new System.Drawing.Point(12, 201);
            this.UserAngle_btn.Margin = new System.Windows.Forms.Padding(4);
            this.UserAngle_btn.Name = "UserAngle_btn";
            this.UserAngle_btn.Size = new System.Drawing.Size(112, 21);
            this.UserAngle_btn.TabIndex = 5;
            this.UserAngle_btn.TabStop = true;
            this.UserAngle_btn.Text = "User Defined";
            this.UserAngle_btn.UseVisualStyleBackColor = true;
            this.UserAngle_btn.CheckedChanged += new System.EventHandler(this.UserAngle_btn_CheckedChanged);
            // 
            // Basler
            // 
            this.Basler.AutoSize = true;
            this.Basler.Location = new System.Drawing.Point(12, 139);
            this.Basler.Margin = new System.Windows.Forms.Padding(4);
            this.Basler.Name = "Basler";
            this.Basler.Size = new System.Drawing.Size(69, 21);
            this.Basler.TabIndex = 2;
            this.Basler.TabStop = true;
            this.Basler.Text = "Basler";
            this.Basler.UseVisualStyleBackColor = true;
            this.Basler.CheckedChanged += new System.EventHandler(this.Brussil_CheckedChanged);
            // 
            // Carddif_Btn
            // 
            this.Carddif_Btn.AutoSize = true;
            this.Carddif_Btn.Location = new System.Drawing.Point(12, 85);
            this.Carddif_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Carddif_Btn.Name = "Carddif_Btn";
            this.Carddif_Btn.Size = new System.Drawing.Size(74, 21);
            this.Carddif_Btn.TabIndex = 1;
            this.Carddif_Btn.TabStop = true;
            this.Carddif_Btn.Text = "Carddif";
            this.Carddif_Btn.UseVisualStyleBackColor = true;
            this.Carddif_Btn.CheckedChanged += new System.EventHandler(this.Carddif_Btn_CheckedChanged);
            // 
            // AISC_Btn
            // 
            this.AISC_Btn.AutoSize = true;
            this.AISC_Btn.Location = new System.Drawing.Point(12, 37);
            this.AISC_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.AISC_Btn.Name = "AISC_Btn";
            this.AISC_Btn.Size = new System.Drawing.Size(309, 21);
            this.AISC_Btn.TabIndex = 0;
            this.AISC_Btn.TabStop = true;
            this.AISC_Btn.Text = "AISC Tension Field Angle (SPSW -Guide 20)";
            this.AISC_Btn.UseVisualStyleBackColor = true;
            this.AISC_Btn.CheckedChanged += new System.EventHandler(this.AISC_Btn_CheckedChanged);
            // 
            // ModelSettingDialogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ModelSettingDialogControl";
            this.Load += new System.EventHandler(this.ModelSettingDialogControl_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Width_VLB;
        private System.Windows.Forms.TextBox ModelName_TB;
        private System.Windows.Forms.Label ModelName_VLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Basler;
        private System.Windows.Forms.RadioButton Carddif_Btn;
        private System.Windows.Forms.RadioButton AISC_Btn;
        private System.Windows.Forms.TextBox BaseOffset_TB;
        private System.Windows.Forms.Label BaseOffset_VLB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Angle_VLB;
        private System.Windows.Forms.TextBox Angle_TB;
        private System.Windows.Forms.RadioButton UserAngle_btn;
        private System.Windows.Forms.Label degrres_Tb;
        private System.Windows.Forms.CheckBox PanelZones_Chbox;
        private System.Windows.Forms.TextBox MinStr_Tb;
        private System.Windows.Forms.Label Min_Str_VLB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel Cardiff_linkLabel;
        private System.Windows.Forms.LinkLabel AISC_linkLabel;
        private System.Windows.Forms.LinkLabel Basler_linkLabel;
        private System.Windows.Forms.Button Model_Layout_Btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Ground_Beam_btn;
        private System.Windows.Forms.RadioButton Fixed_Btn;
    }
}
