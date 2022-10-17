namespace SPSW_Solver
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.Preview_Panel = new System.Windows.Forms.Panel();
            this.Dialogs_Panel = new System.Windows.Forms.Panel();
            this.Drawing_Panel = new System.Windows.Forms.Panel();
            this.SelectionPanel = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Animation_Btn = new System.Windows.Forms.Button();
            this.Help_Btn = new System.Windows.Forms.Button();
            this.lateralLoadSettingsControl1 = new SPSW_Solver.LateralLoadSettingsControl();
            this.sketchStageControl1 = new SPSW_Solver.SketchStageControl();
            this.elementsFamilyControl1 = new SPSW_Solver.ElementsFamilyControl();
            this.materialControl1 = new SPSW_Solver.MaterialControl();
            this.modalAnalysisControl1 = new SPSW_Solver.ModalAnalysisControl();
            this.resultControl1 = new SPSW_Solver.ResultControl();
            this.runControl1 = new SPSW_Solver.RunControl();
            this.lateralLoadsControl1 = new SPSW_Solver.LateralLoadsControl();
            this.deadLoadsControl1 = new SPSW_Solver.DeadLoadsControl();
            this.sectionControl1 = new SPSW_Solver.SectionControl();
            this.modelStageControl1 = new SPSW_Solver.ModelStageControl();
            this.Preview_Panel.SuspendLayout();
            this.SelectionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Preview_Panel
            // 
            this.Preview_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Preview_Panel.Controls.Add(this.lateralLoadSettingsControl1);
            this.Preview_Panel.Controls.Add(this.sketchStageControl1);
            this.Preview_Panel.Controls.Add(this.elementsFamilyControl1);
            this.Preview_Panel.Controls.Add(this.materialControl1);
            this.Preview_Panel.Controls.Add(this.modalAnalysisControl1);
            this.Preview_Panel.Controls.Add(this.resultControl1);
            this.Preview_Panel.Controls.Add(this.runControl1);
            this.Preview_Panel.Controls.Add(this.lateralLoadsControl1);
            this.Preview_Panel.Controls.Add(this.deadLoadsControl1);
            this.Preview_Panel.Controls.Add(this.sectionControl1);
            this.Preview_Panel.Controls.Add(this.modelStageControl1);
            this.Preview_Panel.Location = new System.Drawing.Point(16, 4);
            this.Preview_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Preview_Panel.Name = "Preview_Panel";
            this.Preview_Panel.Size = new System.Drawing.Size(146, 843);
            this.Preview_Panel.TabIndex = 0;
            // 
            // Dialogs_Panel
            // 
            this.Dialogs_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dialogs_Panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Dialogs_Panel.Location = new System.Drawing.Point(171, 4);
            this.Dialogs_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Dialogs_Panel.Name = "Dialogs_Panel";
            this.Dialogs_Panel.Size = new System.Drawing.Size(346, 764);
            this.Dialogs_Panel.TabIndex = 1;
            // 
            // Drawing_Panel
            // 
            this.Drawing_Panel.BackColor = System.Drawing.Color.White;
            this.Drawing_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Drawing_Panel.Location = new System.Drawing.Point(525, 4);
            this.Drawing_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Drawing_Panel.Name = "Drawing_Panel";
            this.Drawing_Panel.Size = new System.Drawing.Size(587, 764);
            this.Drawing_Panel.TabIndex = 2;
            // 
            // SelectionPanel
            // 
            this.SelectionPanel.Controls.Add(this.propertyGrid1);
            this.SelectionPanel.Location = new System.Drawing.Point(1121, 65);
            this.SelectionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SelectionPanel.Name = "SelectionPanel";
            this.SelectionPanel.Size = new System.Drawing.Size(187, 780);
            this.SelectionPanel.TabIndex = 3;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(187, 780);
            this.propertyGrid1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.Animation_Btn);
            this.panel1.Location = new System.Drawing.Point(171, 775);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 71);
            this.panel1.TabIndex = 4;
            // 
            // trackBar1
            // 
            this.trackBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar1.Location = new System.Drawing.Point(84, 10);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(852, 56);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // Animation_Btn
            // 
            this.Animation_Btn.BackgroundImage = global::SPSW_Solver.Properties.Resources.start;
            this.Animation_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Animation_Btn.FlatAppearance.BorderSize = 0;
            this.Animation_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Animation_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Animation_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Animation_Btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Animation_Btn.Location = new System.Drawing.Point(16, 6);
            this.Animation_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Animation_Btn.Name = "Animation_Btn";
            this.Animation_Btn.Size = new System.Drawing.Size(60, 55);
            this.Animation_Btn.TabIndex = 8;
            this.Animation_Btn.UseVisualStyleBackColor = true;
            this.Animation_Btn.Visible = false;
            this.Animation_Btn.Click += new System.EventHandler(this.Animation_Btn_Click);
            // 
            // Help_Btn
            // 
            this.Help_Btn.BackgroundImage = global::SPSW_Solver.Properties.Resources.about_1;
            this.Help_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Help_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Help_Btn.Location = new System.Drawing.Point(1121, 4);
            this.Help_Btn.Name = "Help_Btn";
            this.Help_Btn.Size = new System.Drawing.Size(187, 51);
            this.Help_Btn.TabIndex = 6;
            this.Help_Btn.UseVisualStyleBackColor = true;
            this.Help_Btn.Click += new System.EventHandler(this.Help_Btn_Click);
            // 
            // lateralLoadSettingsControl1
            // 
            this.lateralLoadSettingsControl1.Location = new System.Drawing.Point(5, 530);
            this.lateralLoadSettingsControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lateralLoadSettingsControl1.Name = "lateralLoadSettingsControl1";
            this.lateralLoadSettingsControl1.Size = new System.Drawing.Size(137, 86);
            this.lateralLoadSettingsControl1.Status = SPSW_Solver.StageStatus.Default;
            this.lateralLoadSettingsControl1.TabIndex = 10;
            // 
            // sketchStageControl1
            // 
            this.sketchStageControl1.Location = new System.Drawing.Point(4, 289);
            this.sketchStageControl1.Margin = new System.Windows.Forms.Padding(5);
            this.sketchStageControl1.Name = "sketchStageControl1";
            this.sketchStageControl1.Size = new System.Drawing.Size(137, 70);
            this.sketchStageControl1.Status = SPSW_Solver.StageStatus.Default;
            this.sketchStageControl1.TabIndex = 9;
            // 
            // elementsFamilyControl1
            // 
            this.elementsFamilyControl1.Location = new System.Drawing.Point(8, 206);
            this.elementsFamilyControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.elementsFamilyControl1.Name = "elementsFamilyControl1";
            this.elementsFamilyControl1.Size = new System.Drawing.Size(137, 87);
            this.elementsFamilyControl1.Status = SPSW_Solver.StageStatus.Default;
            this.elementsFamilyControl1.TabIndex = 8;
            // 
            // materialControl1
            // 
            this.materialControl1.Location = new System.Drawing.Point(5, 66);
            this.materialControl1.Margin = new System.Windows.Forms.Padding(5);
            this.materialControl1.Name = "materialControl1";
            this.materialControl1.Size = new System.Drawing.Size(137, 74);
            this.materialControl1.Status = SPSW_Solver.StageStatus.Default;
            this.materialControl1.TabIndex = 2;
            // 
            // modalAnalysisControl1
            // 
            this.modalAnalysisControl1.Location = new System.Drawing.Point(8, 437);
            this.modalAnalysisControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.modalAnalysisControl1.Name = "modalAnalysisControl1";
            this.modalAnalysisControl1.Size = new System.Drawing.Size(137, 86);
            this.modalAnalysisControl1.Status = SPSW_Solver.StageStatus.Default;
            this.modalAnalysisControl1.TabIndex = 7;
            // 
            // resultControl1
            // 
            this.resultControl1.Location = new System.Drawing.Point(5, 769);
            this.resultControl1.Margin = new System.Windows.Forms.Padding(5);
            this.resultControl1.Name = "resultControl1";
            this.resultControl1.Size = new System.Drawing.Size(135, 68);
            this.resultControl1.Status = SPSW_Solver.StageStatus.Default;
            this.resultControl1.TabIndex = 6;
            // 
            // runControl1
            // 
            this.runControl1.Location = new System.Drawing.Point(7, 695);
            this.runControl1.Margin = new System.Windows.Forms.Padding(5);
            this.runControl1.Name = "runControl1";
            this.runControl1.Size = new System.Drawing.Size(133, 74);
            this.runControl1.Status = SPSW_Solver.StageStatus.Default;
            this.runControl1.TabIndex = 5;
            // 
            // lateralLoadsControl1
            // 
            this.lateralLoadsControl1.Location = new System.Drawing.Point(3, 613);
            this.lateralLoadsControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lateralLoadsControl1.Name = "lateralLoadsControl1";
            this.lateralLoadsControl1.Size = new System.Drawing.Size(137, 90);
            this.lateralLoadsControl1.Status = SPSW_Solver.StageStatus.Default;
            this.lateralLoadsControl1.TabIndex = 4;
            // 
            // deadLoadsControl1
            // 
            this.deadLoadsControl1.Location = new System.Drawing.Point(3, 356);
            this.deadLoadsControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.deadLoadsControl1.Name = "deadLoadsControl1";
            this.deadLoadsControl1.Size = new System.Drawing.Size(137, 86);
            this.deadLoadsControl1.Status = SPSW_Solver.StageStatus.Default;
            this.deadLoadsControl1.TabIndex = 3;
            // 
            // sectionControl1
            // 
            this.sectionControl1.Location = new System.Drawing.Point(8, 135);
            this.sectionControl1.Margin = new System.Windows.Forms.Padding(5);
            this.sectionControl1.Name = "sectionControl1";
            this.sectionControl1.Size = new System.Drawing.Size(137, 74);
            this.sectionControl1.Status = SPSW_Solver.StageStatus.Default;
            this.sectionControl1.TabIndex = 1;
            // 
            // modelStageControl1
            // 
            this.modelStageControl1.Location = new System.Drawing.Point(5, -1);
            this.modelStageControl1.Margin = new System.Windows.Forms.Padding(5);
            this.modelStageControl1.Name = "modelStageControl1";
            this.modelStageControl1.Size = new System.Drawing.Size(135, 71);
            this.modelStageControl1.Status = SPSW_Solver.StageStatus.Default;
            this.modelStageControl1.TabIndex = 0;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1312, 852);
            this.Controls.Add(this.Help_Btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SelectionPanel);
            this.Controls.Add(this.Drawing_Panel);
            this.Controls.Add(this.Dialogs_Panel);
            this.Controls.Add(this.Preview_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPSW Analysis";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Preview_Panel.ResumeLayout(false);
            this.SelectionPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Preview_Panel;
        private System.Windows.Forms.Panel Dialogs_Panel;
        private System.Windows.Forms.Panel Drawing_Panel;
        private ModelStageControl modelStageControl1;
        private SectionControl sectionControl1;
        private MaterialControl materialControl1;
        private DeadLoadsControl deadLoadsControl1;
        private LateralLoadsControl lateralLoadsControl1;
        private RunControl runControl1;
        private ResultControl resultControl1;
        private System.Windows.Forms.Panel SelectionPanel;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Animation_Btn;
        private System.Windows.Forms.TrackBar trackBar1;
        private ModalAnalysisControl modalAnalysisControl1;
        private ElementsFamilyControl elementsFamilyControl1;
        private SketchStageControl sketchStageControl1;
        private LateralLoadSettingsControl lateralLoadSettingsControl1;
        private System.Windows.Forms.Button Help_Btn;
    }
}

