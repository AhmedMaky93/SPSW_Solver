namespace SPSW_Solver
{
    partial class LoadCaseControl
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
            this.back_btn = new System.Windows.Forms.Button();
            this.nxt_btn = new System.Windows.Forms.Button();
            this.ModeShape_LB = new System.Windows.Forms.Label();
            this.SingleRun_btn = new System.Windows.Forms.RadioButton();
            this.SRss_Rbtn = new System.Windows.Forms.RadioButton();
            this.Peak_Rbtn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Peak_Rbtn);
            this.groupBox1.Controls.Add(this.SRss_Rbtn);
            this.groupBox1.Controls.Add(this.SingleRun_btn);
            this.groupBox1.Controls.Add(this.back_btn);
            this.groupBox1.Controls.Add(this.nxt_btn);
            this.groupBox1.Controls.Add(this.ModeShape_LB);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Case";
            // 
            // back_btn
            // 
            this.back_btn.BackgroundImage = global::SPSW_Solver.Properties.Resources.back;
            this.back_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back_btn.FlatAppearance.BorderSize = 0;
            this.back_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.Green;
            this.back_btn.Location = new System.Drawing.Point(126, 22);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(33, 28);
            this.back_btn.TabIndex = 24;
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // nxt_btn
            // 
            this.nxt_btn.BackgroundImage = global::SPSW_Solver.Properties.Resources.next;
            this.nxt_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nxt_btn.FlatAppearance.BorderSize = 0;
            this.nxt_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nxt_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxt_btn.ForeColor = System.Drawing.Color.Green;
            this.nxt_btn.Location = new System.Drawing.Point(215, 22);
            this.nxt_btn.Name = "nxt_btn";
            this.nxt_btn.Size = new System.Drawing.Size(33, 28);
            this.nxt_btn.TabIndex = 23;
            this.nxt_btn.UseVisualStyleBackColor = true;
            this.nxt_btn.Click += new System.EventHandler(this.Nxt_btn_Click);
            // 
            // ModeShape_LB
            // 
            this.ModeShape_LB.AutoSize = true;
            this.ModeShape_LB.Enabled = false;
            this.ModeShape_LB.Font = new System.Drawing.Font("Neo Tech Alt Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeShape_LB.Location = new System.Drawing.Point(175, 25);
            this.ModeShape_LB.Name = "ModeShape_LB";
            this.ModeShape_LB.Size = new System.Drawing.Size(18, 20);
            this.ModeShape_LB.TabIndex = 22;
            this.ModeShape_LB.Text = "1";
            // 
            // SingleRun_btn
            // 
            this.SingleRun_btn.AutoSize = true;
            this.SingleRun_btn.Location = new System.Drawing.Point(6, 28);
            this.SingleRun_btn.Name = "SingleRun_btn";
            this.SingleRun_btn.Size = new System.Drawing.Size(103, 17);
            this.SingleRun_btn.TabIndex = 25;
            this.SingleRun_btn.TabStop = true;
            this.SingleRun_btn.Text = "Single load case";
            this.SingleRun_btn.UseVisualStyleBackColor = true;
            this.SingleRun_btn.CheckedChanged += new System.EventHandler(this.SingleRun_btn_CheckedChanged);
            // 
            // SRss_Rbtn
            // 
            this.SRss_Rbtn.AutoSize = true;
            this.SRss_Rbtn.Location = new System.Drawing.Point(6, 63);
            this.SRss_Rbtn.Name = "SRss_Rbtn";
            this.SRss_Rbtn.Size = new System.Drawing.Size(120, 17);
            this.SRss_Rbtn.TabIndex = 26;
            this.SRss_Rbtn.TabStop = true;
            this.SRss_Rbtn.Text = "SRSS of load cases";
            this.SRss_Rbtn.UseVisualStyleBackColor = true;
            this.SRss_Rbtn.CheckedChanged += new System.EventHandler(this.SRss_Rbtn_CheckedChanged);
            // 
            // Peak_Rbtn
            // 
            this.Peak_Rbtn.AutoSize = true;
            this.Peak_Rbtn.Location = new System.Drawing.Point(6, 97);
            this.Peak_Rbtn.Name = "Peak_Rbtn";
            this.Peak_Rbtn.Size = new System.Drawing.Size(147, 17);
            this.Peak_Rbtn.TabIndex = 27;
            this.Peak_Rbtn.TabStop = true;
            this.Peak_Rbtn.Text = "max. values of load cases";
            this.Peak_Rbtn.UseVisualStyleBackColor = true;
            this.Peak_Rbtn.CheckedChanged += new System.EventHandler(this.Peak_Rbtn_CheckedChanged);
            // 
            // LoadCaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "LoadCaseControl";
            this.Size = new System.Drawing.Size(261, 128);
            this.Load += new System.EventHandler(this.LoadCaseControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button nxt_btn;
        private System.Windows.Forms.Label ModeShape_LB;
        private System.Windows.Forms.RadioButton Peak_Rbtn;
        private System.Windows.Forms.RadioButton SRss_Rbtn;
        private System.Windows.Forms.RadioButton SingleRun_btn;
    }
}
