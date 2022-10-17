namespace SPSW_Solver
{
    partial class DialogRunControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SaveForces_LB = new System.Windows.Forms.Label();
            this.SaveDeformation_LB = new System.Windows.Forms.Label();
            this.Running_Lb = new System.Windows.Forms.Label();
            this.InputCreate_LB = new System.Windows.Forms.Label();
            this.Current_LB = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dialogSolvingOptions1 = new SPSW_Solver.UI.DialogsUserControl.DialogSolvingOptions();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SPSW_Solver.Properties.Resources.play_button__1_;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Monospac821 BT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 387);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 74);
            this.button1.TabIndex = 2;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 399);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Run analytical model\r\n  by OpenSees.exe";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.SaveForces_LB);
            this.groupBox1.Controls.Add(this.SaveDeformation_LB);
            this.groupBox1.Controls.Add(this.Running_Lb);
            this.groupBox1.Controls.Add(this.InputCreate_LB);
            this.groupBox1.Controls.Add(this.Current_LB);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(4, 469);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(331, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(233, 123);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 66);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // SaveForces_LB
            // 
            this.SaveForces_LB.AutoSize = true;
            this.SaveForces_LB.Location = new System.Drawing.Point(13, 209);
            this.SaveForces_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SaveForces_LB.Name = "SaveForces_LB";
            this.SaveForces_LB.Size = new System.Drawing.Size(46, 17);
            this.SaveForces_LB.TabIndex = 5;
            this.SaveForces_LB.Text = "label2";
            // 
            // SaveDeformation_LB
            // 
            this.SaveDeformation_LB.AutoSize = true;
            this.SaveDeformation_LB.Location = new System.Drawing.Point(13, 174);
            this.SaveDeformation_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SaveDeformation_LB.Name = "SaveDeformation_LB";
            this.SaveDeformation_LB.Size = new System.Drawing.Size(46, 17);
            this.SaveDeformation_LB.TabIndex = 4;
            this.SaveDeformation_LB.Text = "label2";
            // 
            // Running_Lb
            // 
            this.Running_Lb.AutoSize = true;
            this.Running_Lb.Location = new System.Drawing.Point(13, 138);
            this.Running_Lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Running_Lb.Name = "Running_Lb";
            this.Running_Lb.Size = new System.Drawing.Size(46, 17);
            this.Running_Lb.TabIndex = 3;
            this.Running_Lb.Text = "label2";
            // 
            // InputCreate_LB
            // 
            this.InputCreate_LB.AutoSize = true;
            this.InputCreate_LB.Location = new System.Drawing.Point(13, 105);
            this.InputCreate_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InputCreate_LB.Name = "InputCreate_LB";
            this.InputCreate_LB.Size = new System.Drawing.Size(46, 17);
            this.InputCreate_LB.TabIndex = 2;
            this.InputCreate_LB.Text = "label2";
            // 
            // Current_LB
            // 
            this.Current_LB.AutoSize = true;
            this.Current_LB.Location = new System.Drawing.Point(13, 20);
            this.Current_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Current_LB.Name = "Current_LB";
            this.Current_LB.Size = new System.Drawing.Size(46, 17);
            this.Current_LB.TabIndex = 1;
            this.Current_LB.Text = "label2";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 48);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(303, 28);
            this.progressBar1.Step = 2;
            this.progressBar1.TabIndex = 0;
            // 
            // dialogSolvingOptions1
            // 
            this.dialogSolvingOptions1.Location = new System.Drawing.Point(0, 3);
            this.dialogSolvingOptions1.Name = "dialogSolvingOptions1";
            this.dialogSolvingOptions1.Size = new System.Drawing.Size(336, 366);
            this.dialogSolvingOptions1.TabIndex = 5;
            // 
            // DialogRunControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dialogSolvingOptions1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DialogRunControl";
            this.Load += new System.EventHandler(this.DialogRunControl_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dialogSolvingOptions1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Running_Lb;
        private System.Windows.Forms.Label InputCreate_LB;
        private System.Windows.Forms.Label Current_LB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SaveForces_LB;
        private System.Windows.Forms.Label SaveDeformation_LB;
        private UI.DialogsUserControl.DialogSolvingOptions dialogSolvingOptions1;
    }
}
