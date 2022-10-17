namespace SPSW_Solver
{
    partial class DialogResultControl
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
            this.FPS_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PushOver_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MinV_Lb = new System.Windows.Forms.Label();
            this.MaxV_Lb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scaleTB = new System.Windows.Forms.TextBox();
            this.FM_Rbt = new System.Windows.Forms.RadioButton();
            this.SF_Rbt = new System.Windows.Forms.RadioButton();
            this.N_Rbt = new System.Windows.Forms.RadioButton();
            this.Deformation_Rbt = new System.Windows.Forms.RadioButton();
            this.Default_Rbt = new System.Windows.Forms.RadioButton();
            this.loadCaseControl1 = new SPSW_Solver.LoadCaseControl();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FPS_TB
            // 
            this.FPS_TB.Location = new System.Drawing.Point(158, 7);
            this.FPS_TB.Name = "FPS_TB";
            this.FPS_TB.Size = new System.Drawing.Size(29, 20);
            this.FPS_TB.TabIndex = 6;
            this.FPS_TB.TextChanged += new System.EventHandler(this.FPS_TB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "*10 seconds";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Display a time step graph per :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PushOver_btn);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.scaleTB);
            this.groupBox1.Controls.Add(this.FM_Rbt);
            this.groupBox1.Controls.Add(this.SF_Rbt);
            this.groupBox1.Controls.Add(this.N_Rbt);
            this.groupBox1.Controls.Add(this.Deformation_Rbt);
            this.groupBox1.Controls.Add(this.Default_Rbt);
            this.groupBox1.Location = new System.Drawing.Point(3, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 413);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Viewer";
            // 
            // PushOver_btn
            // 
            this.PushOver_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PushOver_btn.Location = new System.Drawing.Point(9, 368);
            this.PushOver_btn.Name = "PushOver_btn";
            this.PushOver_btn.Size = new System.Drawing.Size(132, 23);
            this.PushOver_btn.TabIndex = 11;
            this.PushOver_btn.Text = "Show pushover curve";
            this.PushOver_btn.UseVisualStyleBackColor = true;
            this.PushOver_btn.Click += new System.EventHandler(this.PushOver_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MinV_Lb);
            this.panel1.Controls.Add(this.MaxV_Lb);
            this.panel1.Location = new System.Drawing.Point(147, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 397);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // MinV_Lb
            // 
            this.MinV_Lb.AutoSize = true;
            this.MinV_Lb.BackColor = System.Drawing.SystemColors.Control;
            this.MinV_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinV_Lb.Location = new System.Drawing.Point(3, 364);
            this.MinV_Lb.Name = "MinV_Lb";
            this.MinV_Lb.Size = new System.Drawing.Size(46, 17);
            this.MinV_Lb.TabIndex = 1;
            this.MinV_Lb.Text = "label4";
            this.MinV_Lb.Visible = false;
            // 
            // MaxV_Lb
            // 
            this.MaxV_Lb.AutoSize = true;
            this.MaxV_Lb.BackColor = System.Drawing.SystemColors.Control;
            this.MaxV_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxV_Lb.Location = new System.Drawing.Point(3, 9);
            this.MaxV_Lb.Name = "MaxV_Lb";
            this.MaxV_Lb.Size = new System.Drawing.Size(46, 17);
            this.MaxV_Lb.TabIndex = 0;
            this.MaxV_Lb.Text = "label4";
            this.MaxV_Lb.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Displacements Scale :";
            // 
            // scaleTB
            // 
            this.scaleTB.Location = new System.Drawing.Point(92, 132);
            this.scaleTB.Name = "scaleTB";
            this.scaleTB.Size = new System.Drawing.Size(39, 20);
            this.scaleTB.TabIndex = 9;
            this.scaleTB.TextChanged += new System.EventHandler(this.ScaleTB_TextChanged);
            // 
            // FM_Rbt
            // 
            this.FM_Rbt.AutoSize = true;
            this.FM_Rbt.Location = new System.Drawing.Point(9, 264);
            this.FM_Rbt.Name = "FM_Rbt";
            this.FM_Rbt.Size = new System.Drawing.Size(134, 17);
            this.FM_Rbt.TabIndex = 4;
            this.FM_Rbt.TabStop = true;
            this.FM_Rbt.Text = "Bening Moment Viewer";
            this.FM_Rbt.UseVisualStyleBackColor = true;
            this.FM_Rbt.CheckedChanged += new System.EventHandler(this.FM_Rbt_CheckedChanged);
            // 
            // SF_Rbt
            // 
            this.SF_Rbt.AutoSize = true;
            this.SF_Rbt.Location = new System.Drawing.Point(7, 221);
            this.SF_Rbt.Name = "SF_Rbt";
            this.SF_Rbt.Size = new System.Drawing.Size(123, 17);
            this.SF_Rbt.TabIndex = 3;
            this.SF_Rbt.TabStop = true;
            this.SF_Rbt.Text = "Shear Forces Viewer";
            this.SF_Rbt.UseVisualStyleBackColor = true;
            this.SF_Rbt.CheckedChanged += new System.EventHandler(this.SF_Rbt_CheckedChanged);
            // 
            // N_Rbt
            // 
            this.N_Rbt.AutoSize = true;
            this.N_Rbt.Location = new System.Drawing.Point(9, 177);
            this.N_Rbt.Name = "N_Rbt";
            this.N_Rbt.Size = new System.Drawing.Size(128, 17);
            this.N_Rbt.TabIndex = 2;
            this.N_Rbt.TabStop = true;
            this.N_Rbt.Text = "Normal Forces Viewer";
            this.N_Rbt.UseVisualStyleBackColor = true;
            this.N_Rbt.CheckedChanged += new System.EventHandler(this.N_Rbt_CheckedChanged);
            // 
            // Deformation_Rbt
            // 
            this.Deformation_Rbt.AutoSize = true;
            this.Deformation_Rbt.Location = new System.Drawing.Point(9, 72);
            this.Deformation_Rbt.Name = "Deformation_Rbt";
            this.Deformation_Rbt.Size = new System.Drawing.Size(122, 17);
            this.Deformation_Rbt.TabIndex = 1;
            this.Deformation_Rbt.TabStop = true;
            this.Deformation_Rbt.Text = "Deformations Viewer";
            this.Deformation_Rbt.UseVisualStyleBackColor = true;
            this.Deformation_Rbt.CheckedChanged += new System.EventHandler(this.Deformation_Rbt_CheckedChanged);
            // 
            // Default_Rbt
            // 
            this.Default_Rbt.AutoSize = true;
            this.Default_Rbt.Location = new System.Drawing.Point(9, 30);
            this.Default_Rbt.Name = "Default_Rbt";
            this.Default_Rbt.Size = new System.Drawing.Size(94, 17);
            this.Default_Rbt.TabIndex = 0;
            this.Default_Rbt.TabStop = true;
            this.Default_Rbt.Text = "Default Viewer";
            this.Default_Rbt.UseVisualStyleBackColor = true;
            this.Default_Rbt.CheckedChanged += new System.EventHandler(this.Default_Rbt_CheckedChanged);
            // 
            // loadCaseControl1
            // 
            this.loadCaseControl1.LoadCasesCount = 1;
            this.loadCaseControl1.Location = new System.Drawing.Point(-3, 446);
            this.loadCaseControl1.Name = "loadCaseControl1";
            this.loadCaseControl1.Size = new System.Drawing.Size(251, 128);
            this.loadCaseControl1.TabIndex = 9;
            // 
            // DialogResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadCaseControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FPS_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DialogResultControl";
            this.Load += new System.EventHandler(this.DialogResultControl_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.FPS_TB, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.loadCaseControl1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FPS_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton FM_Rbt;
        private System.Windows.Forms.RadioButton SF_Rbt;
        private System.Windows.Forms.RadioButton N_Rbt;
        private System.Windows.Forms.RadioButton Deformation_Rbt;
        private System.Windows.Forms.RadioButton Default_Rbt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scaleTB;
        private System.Windows.Forms.Label MinV_Lb;
        private System.Windows.Forms.Label MaxV_Lb;
        private System.Windows.Forms.Button PushOver_btn;
        private LoadCaseControl loadCaseControl1;
    }
}
