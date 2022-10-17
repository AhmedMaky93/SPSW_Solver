
namespace SPSW_Solver
{
    partial class AboutDocsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDocsFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OpenSees_Btn = new System.Windows.Forms.RadioButton();
            this.Acknowledgement_Btn = new System.Windows.Forms.RadioButton();
            this.About_btn = new System.Windows.Forms.RadioButton();
            this.License = new System.Windows.Forms.RadioButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.OpenSees_Btn);
            this.groupBox1.Controls.Add(this.Acknowledgement_Btn);
            this.groupBox1.Controls.Add(this.About_btn);
            this.groupBox1.Controls.Add(this.License);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documents";
            // 
            // OpenSees_Btn
            // 
            this.OpenSees_Btn.AutoSize = true;
            this.OpenSees_Btn.Location = new System.Drawing.Point(9, 177);
            this.OpenSees_Btn.Name = "OpenSees_Btn";
            this.OpenSees_Btn.Size = new System.Drawing.Size(146, 21);
            this.OpenSees_Btn.TabIndex = 5;
            this.OpenSees_Btn.Text = "OpenSees Manual";
            this.OpenSees_Btn.UseVisualStyleBackColor = true;
            this.OpenSees_Btn.CheckedChanged += new System.EventHandler(this.OpenSees_Btn_CheckedChanged);
            // 
            // Acknowledgement_Btn
            // 
            this.Acknowledgement_Btn.AutoSize = true;
            this.Acknowledgement_Btn.Location = new System.Drawing.Point(9, 133);
            this.Acknowledgement_Btn.Name = "Acknowledgement_Btn";
            this.Acknowledgement_Btn.Size = new System.Drawing.Size(150, 21);
            this.Acknowledgement_Btn.TabIndex = 4;
            this.Acknowledgement_Btn.Text = "Acknowledgements";
            this.Acknowledgement_Btn.UseVisualStyleBackColor = true;
            this.Acknowledgement_Btn.CheckedChanged += new System.EventHandler(this.Acknowledgement_Btn_CheckedChanged);
            // 
            // About_btn
            // 
            this.About_btn.AutoSize = true;
            this.About_btn.Location = new System.Drawing.Point(9, 48);
            this.About_btn.Name = "About_btn";
            this.About_btn.Size = new System.Drawing.Size(87, 21);
            this.About_btn.TabIndex = 2;
            this.About_btn.Text = "About Us";
            this.About_btn.UseVisualStyleBackColor = true;
            this.About_btn.CheckedChanged += new System.EventHandler(this.About_btn_CheckedChanged);
            // 
            // License
            // 
            this.License.AutoSize = true;
            this.License.Location = new System.Drawing.Point(9, 91);
            this.License.Name = "License";
            this.License.Size = new System.Drawing.Size(151, 21);
            this.License.TabIndex = 3;
            this.License.Text = "License Agreement";
            this.License.UseVisualStyleBackColor = true;
            this.License.CheckedChanged += new System.EventHandler(this.License_CheckedChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(183, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(587, 488);
            this.webBrowser1.TabIndex = 1;
            // 
            // AboutDocsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 503);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "AboutDocsFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSPECT-SPSW About";
            this.Load += new System.EventHandler(this.AboutDocsFrm_Load);
            this.Resize += new System.EventHandler(this.AboutDocsFrm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.RadioButton OpenSees_Btn;
        private System.Windows.Forms.RadioButton Acknowledgement_Btn;
        private System.Windows.Forms.RadioButton About_btn;
        private System.Windows.Forms.RadioButton License;
    }
}