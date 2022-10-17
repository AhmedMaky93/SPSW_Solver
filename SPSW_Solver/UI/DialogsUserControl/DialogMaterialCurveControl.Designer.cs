namespace SPSW_Solver
{
    partial class DialogMaterialCurveControl
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
            this.Back_btn = new System.Windows.Forms.Button();
            this.Next_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Edit_button = new System.Windows.Forms.Button();
            this.Check_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Back_btn
            // 
            this.Back_btn.Location = new System.Drawing.Point(24, 387);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(97, 23);
            this.Back_btn.TabIndex = 17;
            this.Back_btn.Text = "<< Back";
            this.Back_btn.UseVisualStyleBackColor = true;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // Next_btn
            // 
            this.Next_btn.Enabled = false;
            this.Next_btn.Location = new System.Drawing.Point(401, 387);
            this.Next_btn.Name = "Next_btn";
            this.Next_btn.Size = new System.Drawing.Size(97, 23);
            this.Next_btn.TabIndex = 16;
            this.Next_btn.Text = "Next >>";
            this.Next_btn.UseVisualStyleBackColor = true;
            this.Next_btn.Click += new System.EventHandler(this.Next_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 378);
            this.panel1.TabIndex = 19;
            // 
            // Edit_button
            // 
            this.Edit_button.Enabled = false;
            this.Edit_button.Location = new System.Drawing.Point(148, 387);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(97, 23);
            this.Edit_button.TabIndex = 20;
            this.Edit_button.Text = "Edit";
            this.Edit_button.UseVisualStyleBackColor = true;
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // Check_button
            // 
            this.Check_button.Location = new System.Drawing.Point(268, 387);
            this.Check_button.Name = "Check_button";
            this.Check_button.Size = new System.Drawing.Size(97, 23);
            this.Check_button.TabIndex = 21;
            this.Check_button.Text = "Check";
            this.Check_button.UseVisualStyleBackColor = true;
            this.Check_button.Click += new System.EventHandler(this.Check_button_Click);
            // 
            // DialogMaterialCurveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Check_button);
            this.Controls.Add(this.Edit_button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Back_btn);
            this.Controls.Add(this.Next_btn);
            this.Name = "DialogMaterialCurveControl";
            this.Load += new System.EventHandler(this.DialogMaterialCurveControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Back_btn;
        private System.Windows.Forms.Button Next_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Edit_button;
        private System.Windows.Forms.Button Check_button;
    }
}
