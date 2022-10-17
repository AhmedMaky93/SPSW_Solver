namespace SPSW_Solver
{
    partial class EditNumModelFrm
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
            this.Viewer_panel = new System.Windows.Forms.Panel();
            this.Control_panel = new System.Windows.Forms.Panel();
            this.Edit_btn = new System.Windows.Forms.Button();
            this.Check_btn = new System.Windows.Forms.Button();
            this.Ok_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Stirups_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Angle_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Floor_TB = new System.Windows.Forms.TextBox();
            this.D_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BaseColumn_btn = new System.Windows.Forms.RadioButton();
            this.Column_btn = new System.Windows.Forms.RadioButton();
            this.Beam_btn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Viewer_panel
            // 
            this.Viewer_panel.Location = new System.Drawing.Point(5, 15);
            this.Viewer_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Viewer_panel.Name = "Viewer_panel";
            this.Viewer_panel.Size = new System.Drawing.Size(468, 541);
            this.Viewer_panel.TabIndex = 0;
            // 
            // Control_panel
            // 
            this.Control_panel.Location = new System.Drawing.Point(481, 241);
            this.Control_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Control_panel.Name = "Control_panel";
            this.Control_panel.Size = new System.Drawing.Size(373, 279);
            this.Control_panel.TabIndex = 1;
            // 
            // Edit_btn
            // 
            this.Edit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit_btn.Location = new System.Drawing.Point(481, 528);
            this.Edit_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Edit_btn.Name = "Edit_btn";
            this.Edit_btn.Size = new System.Drawing.Size(100, 28);
            this.Edit_btn.TabIndex = 2;
            this.Edit_btn.Text = "Edit";
            this.Edit_btn.UseVisualStyleBackColor = true;
            this.Edit_btn.Click += new System.EventHandler(this.Edit_btn_Click);
            // 
            // Check_btn
            // 
            this.Check_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Check_btn.Location = new System.Drawing.Point(618, 528);
            this.Check_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Check_btn.Name = "Check_btn";
            this.Check_btn.Size = new System.Drawing.Size(100, 28);
            this.Check_btn.TabIndex = 3;
            this.Check_btn.Text = "Check";
            this.Check_btn.UseVisualStyleBackColor = true;
            this.Check_btn.Click += new System.EventHandler(this.Check_btn_Click);
            // 
            // Ok_button
            // 
            this.Ok_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ok_button.Location = new System.Drawing.Point(754, 528);
            this.Ok_button.Margin = new System.Windows.Forms.Padding(4);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(100, 28);
            this.Ok_button.TabIndex = 4;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Stirups_TB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Angle_TB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Floor_TB);
            this.groupBox1.Controls.Add(this.D_TB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BaseColumn_btn);
            this.groupBox1.Controls.Add(this.Column_btn);
            this.groupBox1.Controls.Add(this.Beam_btn);
            this.groupBox1.Location = new System.Drawing.Point(481, -1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(375, 234);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Element";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "No. of Strips";
            // 
            // Stirups_TB
            // 
            this.Stirups_TB.Location = new System.Drawing.Point(273, 204);
            this.Stirups_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Stirups_TB.Name = "Stirups_TB";
            this.Stirups_TB.Size = new System.Drawing.Size(100, 22);
            this.Stirups_TB.TabIndex = 10;
            this.Stirups_TB.TextChanged += new System.EventHandler(this.Stirups_TB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vertical Angle";
            // 
            // Angle_TB
            // 
            this.Angle_TB.Location = new System.Drawing.Point(137, 204);
            this.Angle_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Angle_TB.Name = "Angle_TB";
            this.Angle_TB.Size = new System.Drawing.Size(100, 22);
            this.Angle_TB.TabIndex = 8;
            this.Angle_TB.TextChanged += new System.EventHandler(this.Angle_TB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Section Depth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Floor No:";
            // 
            // Floor_TB
            // 
            this.Floor_TB.Location = new System.Drawing.Point(225, 23);
            this.Floor_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Floor_TB.Name = "Floor_TB";
            this.Floor_TB.Size = new System.Drawing.Size(112, 22);
            this.Floor_TB.TabIndex = 5;
            this.Floor_TB.TextChanged += new System.EventHandler(this.Floor_TB_TextChanged);
            // 
            // D_TB
            // 
            this.D_TB.Location = new System.Drawing.Point(0, 204);
            this.D_TB.Margin = new System.Windows.Forms.Padding(4);
            this.D_TB.Name = "D_TB";
            this.D_TB.Size = new System.Drawing.Size(100, 22);
            this.D_TB.TabIndex = 4;
            this.D_TB.TextChanged += new System.EventHandler(this.D_TB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Arbitrary properties (For in viewer example only):";
            // 
            // BaseColumn_btn
            // 
            this.BaseColumn_btn.AutoSize = true;
            this.BaseColumn_btn.Location = new System.Drawing.Point(9, 122);
            this.BaseColumn_btn.Margin = new System.Windows.Forms.Padding(4);
            this.BaseColumn_btn.Name = "BaseColumn_btn";
            this.BaseColumn_btn.Size = new System.Drawing.Size(110, 21);
            this.BaseColumn_btn.TabIndex = 2;
            this.BaseColumn_btn.TabStop = true;
            this.BaseColumn_btn.Text = "radioButton3";
            this.BaseColumn_btn.UseVisualStyleBackColor = true;
            this.BaseColumn_btn.CheckedChanged += new System.EventHandler(this.BaseColumn_btn_CheckedChanged);
            // 
            // Column_btn
            // 
            this.Column_btn.AutoSize = true;
            this.Column_btn.Location = new System.Drawing.Point(11, 94);
            this.Column_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Column_btn.Name = "Column_btn";
            this.Column_btn.Size = new System.Drawing.Size(110, 21);
            this.Column_btn.TabIndex = 1;
            this.Column_btn.TabStop = true;
            this.Column_btn.Text = "radioButton2";
            this.Column_btn.UseVisualStyleBackColor = true;
            this.Column_btn.CheckedChanged += new System.EventHandler(this.Column_btn_CheckedChanged);
            // 
            // Beam_btn
            // 
            this.Beam_btn.AutoSize = true;
            this.Beam_btn.Location = new System.Drawing.Point(11, 65);
            this.Beam_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Beam_btn.Name = "Beam_btn";
            this.Beam_btn.Size = new System.Drawing.Size(110, 21);
            this.Beam_btn.TabIndex = 0;
            this.Beam_btn.TabStop = true;
            this.Beam_btn.Text = "radioButton1";
            this.Beam_btn.UseVisualStyleBackColor = true;
            this.Beam_btn.CheckedChanged += new System.EventHandler(this.Beam_btn_CheckedChanged);
            // 
            // EditNumModelFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 569);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.Check_btn);
            this.Controls.Add(this.Edit_btn);
            this.Controls.Add(this.Control_panel);
            this.Controls.Add(this.Viewer_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditNumModelFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditNumModelFrm";
            this.Load += new System.EventHandler(this.EditNumModelFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Viewer_panel;
        private System.Windows.Forms.Panel Control_panel;
        private System.Windows.Forms.Button Edit_btn;
        private System.Windows.Forms.Button Check_btn;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton BaseColumn_btn;
        private System.Windows.Forms.RadioButton Column_btn;
        private System.Windows.Forms.RadioButton Beam_btn;
        private System.Windows.Forms.TextBox D_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Floor_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Angle_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Stirups_TB;
    }
}