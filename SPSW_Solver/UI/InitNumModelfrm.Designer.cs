namespace SPSW_Solver
{
    partial class InitNumModelfrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.VLB = new System.Windows.Forms.Label();
            this.Elastic_btn = new System.Windows.Forms.RadioButton();
            this.NonLinear_btn = new System.Windows.Forms.RadioButton();
            this.DP_btn = new System.Windows.Forms.RadioButton();
            this.Fiber_btn = new System.Windows.Forms.RadioButton();
            this.BWH_btn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.OK_btn = new System.Windows.Forms.Button();
            this.elasticBeamColumn_Label = new System.Windows.Forms.LinkLabel();
            this.ZeroLengthSection_Label = new System.Windows.Forms.LinkLabel();
            this.nonlinearBeamColumn_Label = new System.Windows.Forms.LinkLabel();
            this.dispBeamColumn_Label = new System.Windows.Forms.LinkLabel();
            this.beamWithHinges_Label = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // VLB
            // 
            this.VLB.AutoSize = true;
            this.VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.VLB.Location = new System.Drawing.Point(124, 62);
            this.VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VLB.Name = "VLB";
            this.VLB.Size = new System.Drawing.Size(0, 17);
            this.VLB.TabIndex = 2;
            // 
            // Elastic_btn
            // 
            this.Elastic_btn.AutoSize = true;
            this.Elastic_btn.Checked = true;
            this.Elastic_btn.Location = new System.Drawing.Point(13, 134);
            this.Elastic_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Elastic_btn.Name = "Elastic_btn";
            this.Elastic_btn.Size = new System.Drawing.Size(310, 21);
            this.Elastic_btn.TabIndex = 3;
            this.Elastic_btn.TabStop = true;
            this.Elastic_btn.Text = "Model all segments as \"elasticBeamColumn\".";
            this.Elastic_btn.UseVisualStyleBackColor = true;
            // 
            // NonLinear_btn
            // 
            this.NonLinear_btn.AutoSize = true;
            this.NonLinear_btn.Location = new System.Drawing.Point(13, 236);
            this.NonLinear_btn.Margin = new System.Windows.Forms.Padding(4);
            this.NonLinear_btn.Name = "NonLinear_btn";
            this.NonLinear_btn.Size = new System.Drawing.Size(359, 21);
            this.NonLinear_btn.TabIndex = 4;
            this.NonLinear_btn.Text = "Use \"nonlinearBeamColumn\" at ends of the element.";
            this.NonLinear_btn.UseVisualStyleBackColor = true;
            // 
            // DP_btn
            // 
            this.DP_btn.AutoSize = true;
            this.DP_btn.Location = new System.Drawing.Point(13, 287);
            this.DP_btn.Margin = new System.Windows.Forms.Padding(4);
            this.DP_btn.Name = "DP_btn";
            this.DP_btn.Size = new System.Drawing.Size(377, 21);
            this.DP_btn.TabIndex = 5;
            this.DP_btn.Text = "Use \"dispBeamColumn\" to model all or some segments.";
            this.DP_btn.UseVisualStyleBackColor = true;
            // 
            // Fiber_btn
            // 
            this.Fiber_btn.AutoSize = true;
            this.Fiber_btn.Location = new System.Drawing.Point(13, 185);
            this.Fiber_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Fiber_btn.Name = "Fiber_btn";
            this.Fiber_btn.Size = new System.Drawing.Size(301, 21);
            this.Fiber_btn.TabIndex = 6;
            this.Fiber_btn.Text = "Use a list of \"zeroLengthSection\" elements.";
            this.Fiber_btn.UseVisualStyleBackColor = true;
            // 
            // BWH_btn
            // 
            this.BWH_btn.AutoSize = true;
            this.BWH_btn.Location = new System.Drawing.Point(13, 338);
            this.BWH_btn.Margin = new System.Windows.Forms.Padding(4);
            this.BWH_btn.Name = "BWH_btn";
            this.BWH_btn.Size = new System.Drawing.Size(320, 21);
            this.BWH_btn.TabIndex = 7;
            this.BWH_btn.Text = "Use \"beamWithHinges\" to model all segments.";
            this.BWH_btn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Modeling nonlinearoty behavior  :";
            // 
            // OK_btn
            // 
            this.OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_btn.Location = new System.Drawing.Point(147, 414);
            this.OK_btn.Margin = new System.Windows.Forms.Padding(4);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(133, 28);
            this.OK_btn.TabIndex = 9;
            this.OK_btn.Text = "OK";
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // elasticBeamColumn_Label
            // 
            this.elasticBeamColumn_Label.AutoSize = true;
            this.elasticBeamColumn_Label.Location = new System.Drawing.Point(52, 161);
            this.elasticBeamColumn_Label.Name = "elasticBeamColumn_Label";
            this.elasticBeamColumn_Label.Size = new System.Drawing.Size(198, 17);
            this.elasticBeamColumn_Label.TabIndex = 10;
            this.elasticBeamColumn_Label.TabStop = true;
            this.elasticBeamColumn_Label.Text = "elasticBeamColumn Command";
            this.elasticBeamColumn_Label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.elasticBeamColumn_Label_LinkClicked);
            // 
            // ZeroLengthSection_Label
            // 
            this.ZeroLengthSection_Label.AutoSize = true;
            this.ZeroLengthSection_Label.Location = new System.Drawing.Point(52, 210);
            this.ZeroLengthSection_Label.Name = "ZeroLengthSection_Label";
            this.ZeroLengthSection_Label.Size = new System.Drawing.Size(196, 17);
            this.ZeroLengthSection_Label.TabIndex = 11;
            this.ZeroLengthSection_Label.TabStop = true;
            this.ZeroLengthSection_Label.Text = "ZeroLengthSection Command";
            this.ZeroLengthSection_Label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ZeroLengthSection_Label_LinkClicked);
            // 
            // nonlinearBeamColumn_Label
            // 
            this.nonlinearBeamColumn_Label.AutoSize = true;
            this.nonlinearBeamColumn_Label.Location = new System.Drawing.Point(52, 261);
            this.nonlinearBeamColumn_Label.Name = "nonlinearBeamColumn_Label";
            this.nonlinearBeamColumn_Label.Size = new System.Drawing.Size(217, 17);
            this.nonlinearBeamColumn_Label.TabIndex = 12;
            this.nonlinearBeamColumn_Label.TabStop = true;
            this.nonlinearBeamColumn_Label.Text = "nonlinearBeamColumn Command";
            this.nonlinearBeamColumn_Label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nonlinearBeamColumn_Label_LinkClicked);
            // 
            // dispBeamColumn_Label
            // 
            this.dispBeamColumn_Label.AutoSize = true;
            this.dispBeamColumn_Label.Location = new System.Drawing.Point(52, 312);
            this.dispBeamColumn_Label.Name = "dispBeamColumn_Label";
            this.dispBeamColumn_Label.Size = new System.Drawing.Size(184, 17);
            this.dispBeamColumn_Label.TabIndex = 13;
            this.dispBeamColumn_Label.TabStop = true;
            this.dispBeamColumn_Label.Text = "dispBeamColumn Command";
            this.dispBeamColumn_Label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dispBeamColumn_Label_LinkClicked);
            // 
            // beamWithHinges_Label
            // 
            this.beamWithHinges_Label.AutoSize = true;
            this.beamWithHinges_Label.Location = new System.Drawing.Point(52, 363);
            this.beamWithHinges_Label.Name = "beamWithHinges_Label";
            this.beamWithHinges_Label.Size = new System.Drawing.Size(182, 17);
            this.beamWithHinges_Label.TabIndex = 14;
            this.beamWithHinges_Label.TabStop = true;
            this.beamWithHinges_Label.Text = "beamWithHinges Command";
            this.beamWithHinges_Label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.beamWithHinges_Label_LinkClicked);
            // 
            // InitNumModelfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 461);
            this.Controls.Add(this.beamWithHinges_Label);
            this.Controls.Add(this.dispBeamColumn_Label);
            this.Controls.Add(this.nonlinearBeamColumn_Label);
            this.Controls.Add(this.ZeroLengthSection_Label);
            this.Controls.Add(this.elasticBeamColumn_Label);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BWH_btn);
            this.Controls.Add(this.Fiber_btn);
            this.Controls.Add(this.DP_btn);
            this.Controls.Add(this.NonLinear_btn);
            this.Controls.Add(this.Elastic_btn);
            this.Controls.Add(this.VLB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitNumModelfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define new numerical model";
            this.Load += new System.EventHandler(this.InitNumModelfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label VLB;
        private System.Windows.Forms.RadioButton Elastic_btn;
        private System.Windows.Forms.RadioButton NonLinear_btn;
        private System.Windows.Forms.RadioButton DP_btn;
        private System.Windows.Forms.RadioButton Fiber_btn;
        private System.Windows.Forms.RadioButton BWH_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.LinkLabel elasticBeamColumn_Label;
        private System.Windows.Forms.LinkLabel ZeroLengthSection_Label;
        private System.Windows.Forms.LinkLabel nonlinearBeamColumn_Label;
        private System.Windows.Forms.LinkLabel dispBeamColumn_Label;
        private System.Windows.Forms.LinkLabel beamWithHinges_Label;
    }
}