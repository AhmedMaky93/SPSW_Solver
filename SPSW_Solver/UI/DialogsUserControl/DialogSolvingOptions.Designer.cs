
namespace SPSW_Solver.UI.DialogsUserControl
{
    partial class DialogSolvingOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.Constraints_CBox = new System.Windows.Forms.ComboBox();
            this.AlphaS_LB = new System.Windows.Forms.Label();
            this.AlphaM_LB = new System.Windows.Forms.Label();
            this.alphaS_TB = new System.Windows.Forms.TextBox();
            this.alphaM_TB = new System.Windows.Forms.TextBox();
            this.AlphaS_VLB = new System.Windows.Forms.Label();
            this.AlphaM_VLB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Numberer_CBox = new System.Windows.Forms.ComboBox();
            this.System_CBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Test_CBox = new System.Windows.Forms.ComboBox();
            this.Tolerance_LB = new System.Windows.Forms.Label();
            this.MaxIter_LB = new System.Windows.Forms.Label();
            this.Tolerance_TB = new System.Windows.Forms.TextBox();
            this.MaxIter_TB = new System.Windows.Forms.TextBox();
            this.Tolerance_VLB = new System.Windows.Forms.Label();
            this.MaxIter_VLB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Constraints";
            // 
            // Constraints_CBox
            // 
            this.Constraints_CBox.FormattingEnabled = true;
            this.Constraints_CBox.Location = new System.Drawing.Point(120, 31);
            this.Constraints_CBox.Name = "Constraints_CBox";
            this.Constraints_CBox.Size = new System.Drawing.Size(200, 28);
            this.Constraints_CBox.TabIndex = 1;
            this.Constraints_CBox.SelectedIndexChanged += new System.EventHandler(this.Constraints_CBox_SelectedIndexChanged);
            // 
            // AlphaS_LB
            // 
            this.AlphaS_LB.AutoSize = true;
            this.AlphaS_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaS_LB.Location = new System.Drawing.Point(3, 71);
            this.AlphaS_LB.Name = "AlphaS_LB";
            this.AlphaS_LB.Size = new System.Drawing.Size(67, 20);
            this.AlphaS_LB.TabIndex = 2;
            this.AlphaS_LB.Text = "AlphaS ";
            // 
            // AlphaM_LB
            // 
            this.AlphaM_LB.AutoSize = true;
            this.AlphaM_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaM_LB.Location = new System.Drawing.Point(3, 113);
            this.AlphaM_LB.Name = "AlphaM_LB";
            this.AlphaM_LB.Size = new System.Drawing.Size(70, 20);
            this.AlphaM_LB.TabIndex = 3;
            this.AlphaM_LB.Text = "AlphaM ";
            // 
            // alphaS_TB
            // 
            this.alphaS_TB.Location = new System.Drawing.Point(120, 68);
            this.alphaS_TB.Name = "alphaS_TB";
            this.alphaS_TB.Size = new System.Drawing.Size(109, 26);
            this.alphaS_TB.TabIndex = 4;
            this.alphaS_TB.TextChanged += new System.EventHandler(this.alphaS_TB_TextChanged);
            // 
            // alphaM_TB
            // 
            this.alphaM_TB.Location = new System.Drawing.Point(120, 110);
            this.alphaM_TB.Name = "alphaM_TB";
            this.alphaM_TB.Size = new System.Drawing.Size(109, 26);
            this.alphaM_TB.TabIndex = 5;
            this.alphaM_TB.TextChanged += new System.EventHandler(this.alphaM_TB_TextChanged);
            // 
            // AlphaS_VLB
            // 
            this.AlphaS_VLB.AutoSize = true;
            this.AlphaS_VLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaS_VLB.ForeColor = System.Drawing.Color.Red;
            this.AlphaS_VLB.Location = new System.Drawing.Point(264, 74);
            this.AlphaS_VLB.Name = "AlphaS_VLB";
            this.AlphaS_VLB.Size = new System.Drawing.Size(56, 20);
            this.AlphaS_VLB.TabIndex = 6;
            this.AlphaS_VLB.Text = "Invalid";
            // 
            // AlphaM_VLB
            // 
            this.AlphaM_VLB.AutoSize = true;
            this.AlphaM_VLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaM_VLB.ForeColor = System.Drawing.Color.Red;
            this.AlphaM_VLB.Location = new System.Drawing.Point(264, 113);
            this.AlphaM_VLB.Name = "AlphaM_VLB";
            this.AlphaM_VLB.Size = new System.Drawing.Size(56, 20);
            this.AlphaM_VLB.TabIndex = 7;
            this.AlphaM_VLB.Text = "Invalid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Numberer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "System";
            // 
            // Numberer_CBox
            // 
            this.Numberer_CBox.FormattingEnabled = true;
            this.Numberer_CBox.Location = new System.Drawing.Point(120, 150);
            this.Numberer_CBox.Name = "Numberer_CBox";
            this.Numberer_CBox.Size = new System.Drawing.Size(200, 28);
            this.Numberer_CBox.TabIndex = 10;
            // 
            // System_CBox
            // 
            this.System_CBox.FormattingEnabled = true;
            this.System_CBox.Location = new System.Drawing.Point(120, 190);
            this.System_CBox.Name = "System_CBox";
            this.System_CBox.Size = new System.Drawing.Size(200, 28);
            this.System_CBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Test";
            // 
            // Test_CBox
            // 
            this.Test_CBox.FormattingEnabled = true;
            this.Test_CBox.Location = new System.Drawing.Point(120, 232);
            this.Test_CBox.Name = "Test_CBox";
            this.Test_CBox.Size = new System.Drawing.Size(200, 28);
            this.Test_CBox.TabIndex = 13;
            this.Test_CBox.SelectedIndexChanged += new System.EventHandler(this.Test_CBox_SelectedIndexChanged);
            // 
            // Tolerance_LB
            // 
            this.Tolerance_LB.AutoSize = true;
            this.Tolerance_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tolerance_LB.Location = new System.Drawing.Point(3, 274);
            this.Tolerance_LB.Name = "Tolerance_LB";
            this.Tolerance_LB.Size = new System.Drawing.Size(92, 20);
            this.Tolerance_LB.TabIndex = 14;
            this.Tolerance_LB.Text = "Tolearance";
            // 
            // MaxIter_LB
            // 
            this.MaxIter_LB.AutoSize = true;
            this.MaxIter_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxIter_LB.Location = new System.Drawing.Point(3, 321);
            this.MaxIter_LB.Name = "MaxIter_LB";
            this.MaxIter_LB.Size = new System.Drawing.Size(73, 20);
            this.MaxIter_LB.TabIndex = 15;
            this.MaxIter_LB.Text = "Max. Iter";
            // 
            // Tolerance_TB
            // 
            this.Tolerance_TB.Location = new System.Drawing.Point(120, 274);
            this.Tolerance_TB.Name = "Tolerance_TB";
            this.Tolerance_TB.Size = new System.Drawing.Size(109, 26);
            this.Tolerance_TB.TabIndex = 16;
            this.Tolerance_TB.TextChanged += new System.EventHandler(this.Tolerance_TB_TextChanged);
            // 
            // MaxIter_TB
            // 
            this.MaxIter_TB.Location = new System.Drawing.Point(120, 318);
            this.MaxIter_TB.Name = "MaxIter_TB";
            this.MaxIter_TB.Size = new System.Drawing.Size(109, 26);
            this.MaxIter_TB.TabIndex = 17;
            this.MaxIter_TB.TextChanged += new System.EventHandler(this.MaxIter_TB_TextChanged);
            // 
            // Tolerance_VLB
            // 
            this.Tolerance_VLB.AutoSize = true;
            this.Tolerance_VLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tolerance_VLB.ForeColor = System.Drawing.Color.Red;
            this.Tolerance_VLB.Location = new System.Drawing.Point(264, 277);
            this.Tolerance_VLB.Name = "Tolerance_VLB";
            this.Tolerance_VLB.Size = new System.Drawing.Size(56, 20);
            this.Tolerance_VLB.TabIndex = 18;
            this.Tolerance_VLB.Text = "Invalid";
            // 
            // MaxIter_VLB
            // 
            this.MaxIter_VLB.AutoSize = true;
            this.MaxIter_VLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxIter_VLB.ForeColor = System.Drawing.Color.Red;
            this.MaxIter_VLB.Location = new System.Drawing.Point(264, 321);
            this.MaxIter_VLB.Name = "MaxIter_VLB";
            this.MaxIter_VLB.Size = new System.Drawing.Size(56, 20);
            this.MaxIter_VLB.TabIndex = 19;
            this.MaxIter_VLB.Text = "Invalid";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.MaxIter_VLB);
            this.groupBox1.Controls.Add(this.Constraints_CBox);
            this.groupBox1.Controls.Add(this.Tolerance_VLB);
            this.groupBox1.Controls.Add(this.AlphaS_LB);
            this.groupBox1.Controls.Add(this.MaxIter_TB);
            this.groupBox1.Controls.Add(this.AlphaM_LB);
            this.groupBox1.Controls.Add(this.Tolerance_TB);
            this.groupBox1.Controls.Add(this.alphaS_TB);
            this.groupBox1.Controls.Add(this.MaxIter_LB);
            this.groupBox1.Controls.Add(this.alphaM_TB);
            this.groupBox1.Controls.Add(this.Tolerance_LB);
            this.groupBox1.Controls.Add(this.AlphaS_VLB);
            this.groupBox1.Controls.Add(this.Test_CBox);
            this.groupBox1.Controls.Add(this.AlphaM_VLB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.System_CBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Numberer_CBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 361);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solving Options";
            // 
            // DialogSolvingOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DialogSolvingOptions";
            this.Size = new System.Drawing.Size(332, 366);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Constraints_CBox;
        private System.Windows.Forms.Label AlphaS_LB;
        private System.Windows.Forms.Label AlphaM_LB;
        private System.Windows.Forms.TextBox alphaS_TB;
        private System.Windows.Forms.TextBox alphaM_TB;
        private System.Windows.Forms.Label AlphaS_VLB;
        private System.Windows.Forms.Label AlphaM_VLB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Numberer_CBox;
        private System.Windows.Forms.ComboBox System_CBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Test_CBox;
        private System.Windows.Forms.Label Tolerance_LB;
        private System.Windows.Forms.Label MaxIter_LB;
        private System.Windows.Forms.TextBox Tolerance_TB;
        private System.Windows.Forms.TextBox MaxIter_TB;
        private System.Windows.Forms.Label Tolerance_VLB;
        private System.Windows.Forms.Label MaxIter_VLB;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
