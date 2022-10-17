namespace SPSW_Solver.UI.Selection
{
    partial class ShearPlateResultFrm
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
            this.ViewerPanel = new System.Windows.Forms.Panel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.Forces_Rtbn = new System.Windows.Forms.RadioButton();
            this.Strain_Rbtn = new System.Windows.Forms.RadioButton();
            this.StrainForce_Rtbn = new System.Windows.Forms.RadioButton();
            this.loadCaseControl1 = new SPSW_Solver.LoadCaseControl();
            this.Export_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewerPanel
            // 
            this.ViewerPanel.Location = new System.Drawing.Point(524, 139);
            this.ViewerPanel.Name = "ViewerPanel";
            this.ViewerPanel.Size = new System.Drawing.Size(271, 307);
            this.ViewerPanel.TabIndex = 0;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsEnableWheelZoom = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 41);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(506, 405);
            this.zedGraphControl1.TabIndex = 1;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // Forces_Rtbn
            // 
            this.Forces_Rtbn.AutoSize = true;
            this.Forces_Rtbn.Location = new System.Drawing.Point(12, 12);
            this.Forces_Rtbn.Name = "Forces_Rtbn";
            this.Forces_Rtbn.Size = new System.Drawing.Size(111, 17);
            this.Forces_Rtbn.TabIndex = 2;
            this.Forces_Rtbn.TabStop = true;
            this.Forces_Rtbn.Text = "Time - axial Force ";
            this.Forces_Rtbn.UseVisualStyleBackColor = true;
            this.Forces_Rtbn.CheckedChanged += new System.EventHandler(this.Forces_Rtbn_CheckedChanged);
            // 
            // Strain_Rbtn
            // 
            this.Strain_Rbtn.AutoSize = true;
            this.Strain_Rbtn.Location = new System.Drawing.Point(129, 12);
            this.Strain_Rbtn.Name = "Strain_Rbtn";
            this.Strain_Rbtn.Size = new System.Drawing.Size(119, 17);
            this.Strain_Rbtn.TabIndex = 3;
            this.Strain_Rbtn.TabStop = true;
            this.Strain_Rbtn.Text = "Time - Deformations";
            this.Strain_Rbtn.UseVisualStyleBackColor = true;
            this.Strain_Rbtn.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // StrainForce_Rtbn
            // 
            this.StrainForce_Rtbn.AutoSize = true;
            this.StrainForce_Rtbn.Location = new System.Drawing.Point(254, 12);
            this.StrainForce_Rtbn.Name = "StrainForce_Rtbn";
            this.StrainForce_Rtbn.Size = new System.Drawing.Size(123, 17);
            this.StrainForce_Rtbn.TabIndex = 4;
            this.StrainForce_Rtbn.TabStop = true;
            this.StrainForce_Rtbn.Text = "Deformations - Force";
            this.StrainForce_Rtbn.UseVisualStyleBackColor = true;
            this.StrainForce_Rtbn.CheckedChanged += new System.EventHandler(this.StrainForce_Rtbn_CheckedChanged);
            // 
            // loadCaseControl1
            // 
            this.loadCaseControl1.LoadCasesCount = 1;
            this.loadCaseControl1.Location = new System.Drawing.Point(524, 5);
            this.loadCaseControl1.Name = "loadCaseControl1";
            this.loadCaseControl1.Size = new System.Drawing.Size(264, 128);
            this.loadCaseControl1.TabIndex = 5;
            // 
            // Export_btn
            // 
            this.Export_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export_btn.Location = new System.Drawing.Point(397, 7);
            this.Export_btn.Name = "Export_btn";
            this.Export_btn.Size = new System.Drawing.Size(101, 27);
            this.Export_btn.TabIndex = 6;
            this.Export_btn.Text = "Export To Excel sheets";
            this.Export_btn.UseVisualStyleBackColor = true;
            this.Export_btn.Click += new System.EventHandler(this.Export_btn_Click);
            // 
            // ShearPlateResultFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Export_btn);
            this.Controls.Add(this.loadCaseControl1);
            this.Controls.Add(this.StrainForce_Rtbn);
            this.Controls.Add(this.Strain_Rbtn);
            this.Controls.Add(this.Forces_Rtbn);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.ViewerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShearPlateResultFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shear Plate Results";
            this.Load += new System.EventHandler(this.ShearPlateResultFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ViewerPanel;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.RadioButton Forces_Rtbn;
        private System.Windows.Forms.RadioButton Strain_Rbtn;
        private System.Windows.Forms.RadioButton StrainForce_Rtbn;
        private LoadCaseControl loadCaseControl1;
        private System.Windows.Forms.Button Export_btn;
    }
}