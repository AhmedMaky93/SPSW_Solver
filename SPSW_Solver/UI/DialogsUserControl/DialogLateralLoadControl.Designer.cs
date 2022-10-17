namespace SPSW_Solver
{
    partial class DialogLateralLoadControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AISCE_Rbtn = new System.Windows.Forms.RadioButton();
            this.TimeHistory_Rbtn = new System.Windows.Forms.RadioButton();
            this.LateralPushover_RBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(331, 703);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analysis Parameters";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 135);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 560);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AISCE_Rbtn);
            this.groupBox2.Controls.Add(this.TimeHistory_Rbtn);
            this.groupBox2.Controls.Add(this.LateralPushover_RBtn);
            this.groupBox2.Location = new System.Drawing.Point(13, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(309, 105);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analysis method";
            // 
            // AISCE_Rbtn
            // 
            this.AISCE_Rbtn.AutoSize = true;
            this.AISCE_Rbtn.Location = new System.Drawing.Point(7, 48);
            this.AISCE_Rbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AISCE_Rbtn.Name = "AISCE_Rbtn";
            this.AISCE_Rbtn.Size = new System.Drawing.Size(183, 21);
            this.AISCE_Rbtn.TabIndex = 2;
            this.AISCE_Rbtn.TabStop = true;
            this.AISCE_Rbtn.Text = "Cyclic pushover analysis";
            this.AISCE_Rbtn.UseVisualStyleBackColor = true;
            this.AISCE_Rbtn.CheckedChanged += new System.EventHandler(this.AISCE_Rbtn_CheckedChanged);
            // 
            // TimeHistory_Rbtn
            // 
            this.TimeHistory_Rbtn.AutoSize = true;
            this.TimeHistory_Rbtn.Location = new System.Drawing.Point(7, 76);
            this.TimeHistory_Rbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TimeHistory_Rbtn.Name = "TimeHistory_Rbtn";
            this.TimeHistory_Rbtn.Size = new System.Drawing.Size(222, 21);
            this.TimeHistory_Rbtn.TabIndex = 1;
            this.TimeHistory_Rbtn.TabStop = true;
            this.TimeHistory_Rbtn.Text = "Time History Dynamic Analysis";
            this.TimeHistory_Rbtn.UseVisualStyleBackColor = true;
            this.TimeHistory_Rbtn.CheckedChanged += new System.EventHandler(this.IDA_Rbtn_CheckedChanged);
            // 
            // LateralPushover_RBtn
            // 
            this.LateralPushover_RBtn.AutoSize = true;
            this.LateralPushover_RBtn.Location = new System.Drawing.Point(8, 22);
            this.LateralPushover_RBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LateralPushover_RBtn.Name = "LateralPushover_RBtn";
            this.LateralPushover_RBtn.Size = new System.Drawing.Size(214, 21);
            this.LateralPushover_RBtn.TabIndex = 0;
            this.LateralPushover_RBtn.TabStop = true;
            this.LateralPushover_RBtn.Text = "Monotonic Pushover Analysis";
            this.LateralPushover_RBtn.UseVisualStyleBackColor = true;
            this.LateralPushover_RBtn.CheckedChanged += new System.EventHandler(this.Pushover_RBtn_CheckedChanged);
            // 
            // DialogLateralLoadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "DialogLateralLoadControl";
            this.Load += new System.EventHandler(this.DialogLateralLoadControl_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton TimeHistory_Rbtn;
        private System.Windows.Forms.RadioButton LateralPushover_RBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton AISCE_Rbtn;
    }
}
