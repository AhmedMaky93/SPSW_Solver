namespace SPSW_Solver.UI.Selection
{
    partial class NodesGraphsFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.M_rbt = new System.Windows.Forms.RadioButton();
            this.Ry_rbt = new System.Windows.Forms.RadioButton();
            this.Rx_rbt = new System.Windows.Forms.RadioButton();
            this.R_rbt = new System.Windows.Forms.RadioButton();
            this.Dy_rbt = new System.Windows.Forms.RadioButton();
            this.Dx_rbt = new System.Windows.Forms.RadioButton();
            this.Reaction_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.loadCaseControl1 = new SPSW_Solver.LoadCaseControl();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.M_rbt);
            this.groupBox1.Controls.Add(this.Ry_rbt);
            this.groupBox1.Controls.Add(this.Rx_rbt);
            this.groupBox1.Controls.Add(this.R_rbt);
            this.groupBox1.Controls.Add(this.Dy_rbt);
            this.groupBox1.Controls.Add(this.Dx_rbt);
            this.groupBox1.Controls.Add(this.Reaction_label);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 219);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph";
            // 
            // M_rbt
            // 
            this.M_rbt.AutoSize = true;
            this.M_rbt.Location = new System.Drawing.Point(43, 185);
            this.M_rbt.Name = "M_rbt";
            this.M_rbt.Size = new System.Drawing.Size(34, 17);
            this.M_rbt.TabIndex = 7;
            this.M_rbt.Text = "M";
            this.M_rbt.UseVisualStyleBackColor = true;
            this.M_rbt.CheckedChanged += new System.EventHandler(this.M_rbt_CheckedChanged);
            // 
            // Ry_rbt
            // 
            this.Ry_rbt.AutoSize = true;
            this.Ry_rbt.Location = new System.Drawing.Point(43, 162);
            this.Ry_rbt.Name = "Ry_rbt";
            this.Ry_rbt.Size = new System.Drawing.Size(38, 17);
            this.Ry_rbt.TabIndex = 6;
            this.Ry_rbt.Text = "Ry";
            this.Ry_rbt.UseVisualStyleBackColor = true;
            this.Ry_rbt.CheckedChanged += new System.EventHandler(this.Ry_rbt_CheckedChanged);
            // 
            // Rx_rbt
            // 
            this.Rx_rbt.AutoSize = true;
            this.Rx_rbt.Location = new System.Drawing.Point(43, 139);
            this.Rx_rbt.Name = "Rx_rbt";
            this.Rx_rbt.Size = new System.Drawing.Size(38, 17);
            this.Rx_rbt.TabIndex = 5;
            this.Rx_rbt.Text = "Rx";
            this.Rx_rbt.UseVisualStyleBackColor = true;
            this.Rx_rbt.CheckedChanged += new System.EventHandler(this.Rx_rbt_CheckedChanged);
            // 
            // R_rbt
            // 
            this.R_rbt.AutoSize = true;
            this.R_rbt.Location = new System.Drawing.Point(43, 87);
            this.R_rbt.Name = "R_rbt";
            this.R_rbt.Size = new System.Drawing.Size(65, 17);
            this.R_rbt.TabIndex = 4;
            this.R_rbt.Text = "Rotation";
            this.R_rbt.UseVisualStyleBackColor = true;
            this.R_rbt.CheckedChanged += new System.EventHandler(this.R_rbt_CheckedChanged);
            // 
            // Dy_rbt
            // 
            this.Dy_rbt.AutoSize = true;
            this.Dy_rbt.Location = new System.Drawing.Point(43, 64);
            this.Dy_rbt.Name = "Dy_rbt";
            this.Dy_rbt.Size = new System.Drawing.Size(99, 17);
            this.Dy_rbt.TabIndex = 3;
            this.Dy_rbt.Text = "Y Displacement";
            this.Dy_rbt.UseVisualStyleBackColor = true;
            this.Dy_rbt.CheckedChanged += new System.EventHandler(this.Dy_rbt_CheckedChanged);
            // 
            // Dx_rbt
            // 
            this.Dx_rbt.AutoSize = true;
            this.Dx_rbt.Location = new System.Drawing.Point(43, 41);
            this.Dx_rbt.Name = "Dx_rbt";
            this.Dx_rbt.Size = new System.Drawing.Size(99, 17);
            this.Dx_rbt.TabIndex = 2;
            this.Dx_rbt.Text = "X Displacement";
            this.Dx_rbt.UseVisualStyleBackColor = true;
            this.Dx_rbt.CheckedChanged += new System.EventHandler(this.Dx_rbt_CheckedChanged);
            // 
            // Reaction_label
            // 
            this.Reaction_label.AutoSize = true;
            this.Reaction_label.Location = new System.Drawing.Point(21, 123);
            this.Reaction_label.Name = "Reaction_label";
            this.Reaction_label.Size = new System.Drawing.Size(55, 13);
            this.Reaction_label.TabIndex = 1;
            this.Reaction_label.Text = "Reactions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deformations";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zedGraphControl1);
            this.panel1.Location = new System.Drawing.Point(269, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 452);
            this.panel1.TabIndex = 2;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(595, 452);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // loadCaseControl1
            // 
            this.loadCaseControl1.LoadCasesCount = 1;
            this.loadCaseControl1.Location = new System.Drawing.Point(2, 5);
            this.loadCaseControl1.Name = "loadCaseControl1";
            this.loadCaseControl1.Size = new System.Drawing.Size(261, 128);
            this.loadCaseControl1.TabIndex = 3;
            // 
            // NodesGraphsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 457);
            this.Controls.Add(this.loadCaseControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NodesGraphsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Node Analysis Result";
            this.Load += new System.EventHandler(this.NodesGraphsFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton M_rbt;
        private System.Windows.Forms.RadioButton Ry_rbt;
        private System.Windows.Forms.RadioButton Rx_rbt;
        private System.Windows.Forms.RadioButton R_rbt;
        private System.Windows.Forms.RadioButton Dy_rbt;
        private System.Windows.Forms.RadioButton Dx_rbt;
        private System.Windows.Forms.Label Reaction_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private LoadCaseControl loadCaseControl1;
    }
}