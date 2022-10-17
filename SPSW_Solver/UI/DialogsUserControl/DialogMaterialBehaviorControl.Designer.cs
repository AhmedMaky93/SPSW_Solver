namespace SPSW_Solver
{
    partial class DialogMaterialBehaviorControl
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
            this.ElasticGraphControl = new SPSW_Solver.MaterialBehaviorGraphControl();
            this.Steel01GraphControl = new SPSW_Solver.MaterialBehaviorGraphControl();
            this.PlastticGraphControl = new SPSW_Solver.MaterialBehaviorGraphControl();
            this.HysetricGraphControl = new SPSW_Solver.MaterialBehaviorGraphControl();
            this.SuspendLayout();
            // 
            // ElasticGraphControl
            // 
            this.ElasticGraphControl.Location = new System.Drawing.Point(0, -12);
            this.ElasticGraphControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ElasticGraphControl.Name = "ElasticGraphControl";
            this.ElasticGraphControl.Size = new System.Drawing.Size(348, 258);
            this.ElasticGraphControl.TabIndex = 0;
            // 
            // Steel01GraphControl
            // 
            this.Steel01GraphControl.Location = new System.Drawing.Point(-6, 256);
            this.Steel01GraphControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Steel01GraphControl.Name = "Steel01GraphControl";
            this.Steel01GraphControl.Size = new System.Drawing.Size(348, 258);
            this.Steel01GraphControl.TabIndex = 1;
            // 
            // PlastticGraphControl
            // 
            this.PlastticGraphControl.Location = new System.Drawing.Point(352, -12);
            this.PlastticGraphControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PlastticGraphControl.Name = "PlastticGraphControl";
            this.PlastticGraphControl.Size = new System.Drawing.Size(348, 258);
            this.PlastticGraphControl.TabIndex = 2;
            // 
            // HysetricGraphControl
            // 
            this.HysetricGraphControl.Location = new System.Drawing.Point(352, 256);
            this.HysetricGraphControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.HysetricGraphControl.Name = "HysetricGraphControl";
            this.HysetricGraphControl.Size = new System.Drawing.Size(348, 258);
            this.HysetricGraphControl.TabIndex = 3;
            // 
            // DialogMaterialBehaviorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HysetricGraphControl);
            this.Controls.Add(this.PlastticGraphControl);
            this.Controls.Add(this.Steel01GraphControl);
            this.Controls.Add(this.ElasticGraphControl);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "DialogMaterialBehaviorControl";
            this.Load += new System.EventHandler(this.DialogMaterialBehaviorControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialBehaviorGraphControl ElasticGraphControl;
        private MaterialBehaviorGraphControl Steel01GraphControl;
        private MaterialBehaviorGraphControl PlastticGraphControl;
        private MaterialBehaviorGraphControl HysetricGraphControl;
    }
}
