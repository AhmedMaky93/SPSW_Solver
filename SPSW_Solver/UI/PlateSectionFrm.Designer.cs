namespace SPSW_Solver
{
    partial class PlateSectionFrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.Material_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_VLB = new System.Windows.Forms.Label();
            this.Name_Tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Thickness_VLB = new System.Windows.Forms.Label();
            this.Thickness_Tb = new System.Windows.Forms.TextBox();
            this.Modifier_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Modifier_VLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(97, 288);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 28);
            this.button1.TabIndex = 15;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Material_comboBox
            // 
            this.Material_comboBox.FormattingEnabled = true;
            this.Material_comboBox.Location = new System.Drawing.Point(188, 96);
            this.Material_comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Material_comboBox.Name = "Material_comboBox";
            this.Material_comboBox.Size = new System.Drawing.Size(160, 24);
            this.Material_comboBox.TabIndex = 13;
            this.Material_comboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.Material_comboBox_Format);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Material    : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Plate thickness  : ";
            // 
            // Name_VLB
            // 
            this.Name_VLB.AutoSize = true;
            this.Name_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Name_VLB.Location = new System.Drawing.Point(163, 58);
            this.Name_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name_VLB.Name = "Name_VLB";
            this.Name_VLB.Size = new System.Drawing.Size(0, 17);
            this.Name_VLB.TabIndex = 10;
            // 
            // Name_Tb
            // 
            this.Name_Tb.Location = new System.Drawing.Point(155, 18);
            this.Name_Tb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name_Tb.Name = "Name_Tb";
            this.Name_Tb.Size = new System.Drawing.Size(160, 22);
            this.Name_Tb.TabIndex = 9;
            this.Name_Tb.TextChanged += new System.EventHandler(this.Name_Tb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Section Name : ";
            // 
            // Thickness_VLB
            // 
            this.Thickness_VLB.AutoSize = true;
            this.Thickness_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Thickness_VLB.Location = new System.Drawing.Point(136, 192);
            this.Thickness_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Thickness_VLB.Name = "Thickness_VLB";
            this.Thickness_VLB.Size = new System.Drawing.Size(0, 17);
            this.Thickness_VLB.TabIndex = 17;
            // 
            // Thickness_Tb
            // 
            this.Thickness_Tb.Location = new System.Drawing.Point(188, 153);
            this.Thickness_Tb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Thickness_Tb.Name = "Thickness_Tb";
            this.Thickness_Tb.Size = new System.Drawing.Size(160, 22);
            this.Thickness_Tb.TabIndex = 16;
            this.Thickness_Tb.TextChanged += new System.EventHandler(this.Thickness_Tb_TextChanged);
            // 
            // Modifier_TB
            // 
            this.Modifier_TB.Location = new System.Drawing.Point(188, 222);
            this.Modifier_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Modifier_TB.Name = "Modifier_TB";
            this.Modifier_TB.Size = new System.Drawing.Size(160, 22);
            this.Modifier_TB.TabIndex = 20;
            this.Modifier_TB.TextChanged += new System.EventHandler(this.Modifier_TB_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Section area modifier : ";
            // 
            // Modifier_VLB
            // 
            this.Modifier_VLB.AutoSize = true;
            this.Modifier_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Modifier_VLB.Location = new System.Drawing.Point(136, 251);
            this.Modifier_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Modifier_VLB.Name = "Modifier_VLB";
            this.Modifier_VLB.Size = new System.Drawing.Size(0, 17);
            this.Modifier_VLB.TabIndex = 21;
            // 
            // PlateSectionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 331);
            this.Controls.Add(this.Modifier_VLB);
            this.Controls.Add(this.Modifier_TB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Thickness_VLB);
            this.Controls.Add(this.Thickness_Tb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Material_comboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Name_VLB);
            this.Controls.Add(this.Name_Tb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlateSectionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Section Area Modifier";
            this.Load += new System.EventHandler(this.PlateSectionFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Material_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Name_VLB;
        private System.Windows.Forms.TextBox Name_Tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Thickness_VLB;
        private System.Windows.Forms.TextBox Thickness_Tb;
        private System.Windows.Forms.TextBox Modifier_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Modifier_VLB;
    }
}