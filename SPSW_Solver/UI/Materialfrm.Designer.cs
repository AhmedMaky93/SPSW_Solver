namespace SPSW_Solver
{
    partial class Materialfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materialfrm));
            this.Stages_panel = new System.Windows.Forms.Panel();
            this.Dialogs_panel = new System.Windows.Forms.Panel();
            this.materialCurveStageContro11 = new SPSW_Solver.MaterialCurveStageContro1();
            this.materialPropertiesStageControl1 = new SPSW_Solver.MaterialPropertiesStageControl();
            this.materialBehaviorStageControl1 = new SPSW_Solver.MaterialBehaviorStageControl();
            this.Stages_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stages_panel
            // 
            this.Stages_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stages_panel.Controls.Add(this.materialCurveStageContro11);
            this.Stages_panel.Controls.Add(this.materialPropertiesStageControl1);
            this.Stages_panel.Controls.Add(this.materialBehaviorStageControl1);
            this.Stages_panel.Location = new System.Drawing.Point(12, 12);
            this.Stages_panel.Name = "Stages_panel";
            this.Stages_panel.Size = new System.Drawing.Size(121, 426);
            this.Stages_panel.TabIndex = 0;
            // 
            // Dialogs_panel
            // 
            this.Dialogs_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dialogs_panel.Location = new System.Drawing.Point(139, 12);
            this.Dialogs_panel.Name = "Dialogs_panel";
            this.Dialogs_panel.Size = new System.Drawing.Size(529, 426);
            this.Dialogs_panel.TabIndex = 1;
            // 
            // materialCurveStageContro11
            // 
            this.materialCurveStageContro11.Location = new System.Drawing.Point(3, 304);
            this.materialCurveStageContro11.Name = "materialCurveStageContro11";
            this.materialCurveStageContro11.Size = new System.Drawing.Size(116, 69);
            this.materialCurveStageContro11.Status = SPSW_Solver.StageStatus.Default;
            this.materialCurveStageContro11.TabIndex = 2;
            // 
            // materialPropertiesStageControl1
            // 
            this.materialPropertiesStageControl1.Location = new System.Drawing.Point(3, 168);
            this.materialPropertiesStageControl1.Name = "materialPropertiesStageControl1";
            this.materialPropertiesStageControl1.Size = new System.Drawing.Size(115, 64);
            this.materialPropertiesStageControl1.Status = SPSW_Solver.StageStatus.Default;
            this.materialPropertiesStageControl1.TabIndex = 1;
            // 
            // materialBehaviorStageControl1
            // 
            this.materialBehaviorStageControl1.Location = new System.Drawing.Point(3, 37);
            this.materialBehaviorStageControl1.Name = "materialBehaviorStageControl1";
            this.materialBehaviorStageControl1.Size = new System.Drawing.Size(111, 60);
            this.materialBehaviorStageControl1.Status = SPSW_Solver.StageStatus.Default;
            this.materialBehaviorStageControl1.TabIndex = 0;
            // 
            // Materialfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.Dialogs_panel);
            this.Controls.Add(this.Stages_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Materialfrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Settings";
            this.Load += new System.EventHandler(this.Materialfrm_Load);
            this.Stages_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Stages_panel;
        private System.Windows.Forms.Panel Dialogs_panel;
        private MaterialBehaviorStageControl materialBehaviorStageControl1;
        private MaterialCurveStageContro1 materialCurveStageContro11;
        private MaterialPropertiesStageControl materialPropertiesStageControl1;
    }
}