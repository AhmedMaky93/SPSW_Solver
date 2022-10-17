namespace SPSW_Solver.UI.Selection
{
    partial class FrameElementResultfrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FPS_TB = new System.Windows.Forms.TextBox();
            this.Deformation_Rbt = new System.Windows.Forms.RadioButton();
            this.NormalForces_Rbt = new System.Windows.Forms.RadioButton();
            this.Moment_Rbt = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.ShearForces_Rb = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.loadCaseControl1 = new SPSW_Solver.LoadCaseControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(293, 48);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(469, 369);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Display a time step graph per :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "*10 seconds";
            // 
            // FPS_TB
            // 
            this.FPS_TB.Location = new System.Drawing.Point(499, 9);
            this.FPS_TB.Name = "FPS_TB";
            this.FPS_TB.Size = new System.Drawing.Size(39, 20);
            this.FPS_TB.TabIndex = 3;
            this.FPS_TB.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // Deformation_Rbt
            // 
            this.Deformation_Rbt.AutoSize = true;
            this.Deformation_Rbt.Location = new System.Drawing.Point(18, 27);
            this.Deformation_Rbt.Name = "Deformation_Rbt";
            this.Deformation_Rbt.Size = new System.Drawing.Size(82, 17);
            this.Deformation_Rbt.TabIndex = 4;
            this.Deformation_Rbt.TabStop = true;
            this.Deformation_Rbt.Text = "Deformation";
            this.Deformation_Rbt.UseVisualStyleBackColor = true;
            this.Deformation_Rbt.CheckedChanged += new System.EventHandler(this.Deformation_Rbt_CheckedChanged);
            // 
            // NormalForces_Rbt
            // 
            this.NormalForces_Rbt.AutoSize = true;
            this.NormalForces_Rbt.Location = new System.Drawing.Point(18, 66);
            this.NormalForces_Rbt.Name = "NormalForces_Rbt";
            this.NormalForces_Rbt.Size = new System.Drawing.Size(130, 17);
            this.NormalForces_Rbt.TabIndex = 5;
            this.NormalForces_Rbt.TabStop = true;
            this.NormalForces_Rbt.Text = "Normal ( Axial ) Forces";
            this.NormalForces_Rbt.UseVisualStyleBackColor = true;
            this.NormalForces_Rbt.CheckedChanged += new System.EventHandler(this.NormalForces_Rbt_CheckedChanged);
            // 
            // Moment_Rbt
            // 
            this.Moment_Rbt.AutoSize = true;
            this.Moment_Rbt.Location = new System.Drawing.Point(18, 133);
            this.Moment_Rbt.Name = "Moment_Rbt";
            this.Moment_Rbt.Size = new System.Drawing.Size(105, 17);
            this.Moment_Rbt.TabIndex = 6;
            this.Moment_Rbt.TabStop = true;
            this.Moment_Rbt.Text = "Bending Moment";
            this.Moment_Rbt.UseVisualStyleBackColor = true;
            this.Moment_Rbt.CheckedChanged += new System.EventHandler(this.Moment_Rbt_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SPSW_Solver.Properties.Resources.start;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(164, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 86);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ShearForces_Rb
            // 
            this.ShearForces_Rb.AutoSize = true;
            this.ShearForces_Rb.Location = new System.Drawing.Point(18, 99);
            this.ShearForces_Rb.Name = "ShearForces_Rb";
            this.ShearForces_Rb.Size = new System.Drawing.Size(88, 17);
            this.ShearForces_Rb.TabIndex = 8;
            this.ShearForces_Rb.TabStop = true;
            this.ShearForces_Rb.Text = "Shear Forces";
            this.ShearForces_Rb.UseVisualStyleBackColor = true;
            this.ShearForces_Rb.CheckedChanged += new System.EventHandler(this.ShearForces_Rb_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Check);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(-2, 433);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(764, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // loadCaseControl1
            // 
            this.loadCaseControl1.LoadCasesCount = 1;
            this.loadCaseControl1.Location = new System.Drawing.Point(26, 12);
            this.loadCaseControl1.Name = "loadCaseControl1";
            this.loadCaseControl1.Size = new System.Drawing.Size(261, 132);
            this.loadCaseControl1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Deformation_Rbt);
            this.groupBox1.Controls.Add(this.NormalForces_Rbt);
            this.groupBox1.Controls.Add(this.Moment_Rbt);
            this.groupBox1.Controls.Add(this.ShearForces_Rb);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 169);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // FrameElementResultfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 490);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loadCaseControl1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.FPS_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrameElementResultfrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Element Result";
            this.Load += new System.EventHandler(this.FrameElementResultfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FPS_TB;
        private System.Windows.Forms.RadioButton Deformation_Rbt;
        private System.Windows.Forms.RadioButton NormalForces_Rbt;
        private System.Windows.Forms.RadioButton Moment_Rbt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton ShearForces_Rb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private LoadCaseControl loadCaseControl1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}