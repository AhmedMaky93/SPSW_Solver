namespace SPSW_Solver
{
    partial class PlasticHingePropertiesfrm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Validation_label = new System.Windows.Forms.Label();
            this.Ok_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Relative_Rbtn = new System.Windows.Forms.RadioButton();
            this.Absolute_Rbtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.A_Tb = new System.Windows.Forms.TextBox();
            this.B_Tb = new System.Windows.Forms.TextBox();
            this.A_VLB = new System.Windows.Forms.Label();
            this.B_VLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(1, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(342, 389);
            this.dataGridView1.TabIndex = 0;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.Width = 71;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "value";
            this.Column1.Name = "Column1";
            this.Column1.Width = 58;
            // 
            // Validation_label
            // 
            this.Validation_label.AutoSize = true;
            this.Validation_label.ForeColor = System.Drawing.Color.DarkRed;
            this.Validation_label.Location = new System.Drawing.Point(12, 419);
            this.Validation_label.Name = "Validation_label";
            this.Validation_label.Size = new System.Drawing.Size(0, 13);
            this.Validation_label.TabIndex = 1;
            // 
            // Ok_button
            // 
            this.Ok_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ok_button.Location = new System.Drawing.Point(124, 494);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(102, 31);
            this.Ok_button.TabIndex = 2;
            this.Ok_button.Text = "Ok";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SPSW_Solver.Properties.Resources.ModIKModel;
            this.pictureBox1.Location = new System.Drawing.Point(349, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 521);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Relative_Rbtn
            // 
            this.Relative_Rbtn.AutoSize = true;
            this.Relative_Rbtn.Location = new System.Drawing.Point(11, 18);
            this.Relative_Rbtn.Name = "Relative_Rbtn";
            this.Relative_Rbtn.Size = new System.Drawing.Size(177, 17);
            this.Relative_Rbtn.TabIndex = 4;
            this.Relative_Rbtn.TabStop = true;
            this.Relative_Rbtn.Text = "Relative To yield Rotation Angle";
            this.Relative_Rbtn.UseVisualStyleBackColor = true;
            this.Relative_Rbtn.CheckedChanged += new System.EventHandler(this.Relative_Rbtn_CheckedChanged);
            // 
            // Absolute_Rbtn
            // 
            this.Absolute_Rbtn.AutoSize = true;
            this.Absolute_Rbtn.Location = new System.Drawing.Point(201, 20);
            this.Absolute_Rbtn.Name = "Absolute_Rbtn";
            this.Absolute_Rbtn.Size = new System.Drawing.Size(135, 17);
            this.Absolute_Rbtn.TabIndex = 5;
            this.Absolute_Rbtn.TabStop = true;
            this.Absolute_Rbtn.Text = "Absolute radian angles ";
            this.Absolute_Rbtn.UseVisualStyleBackColor = true;
            this.Absolute_Rbtn.CheckedChanged += new System.EventHandler(this.Absolute_Rbtn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B_VLb);
            this.groupBox1.Controls.Add(this.A_VLB);
            this.groupBox1.Controls.Add(this.B_Tb);
            this.groupBox1.Controls.Add(this.A_Tb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Absolute_Rbtn);
            this.groupBox1.Controls.Add(this.Relative_Rbtn);
            this.groupBox1.Location = new System.Drawing.Point(1, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 89);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plastic rotation angle ranges";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "b";
            // 
            // A_Tb
            // 
            this.A_Tb.Location = new System.Drawing.Point(30, 44);
            this.A_Tb.Name = "A_Tb";
            this.A_Tb.Size = new System.Drawing.Size(100, 20);
            this.A_Tb.TabIndex = 8;
            this.A_Tb.TextChanged += new System.EventHandler(this.A_Tb_TextChanged);
            // 
            // B_Tb
            // 
            this.B_Tb.Location = new System.Drawing.Point(221, 44);
            this.B_Tb.Name = "B_Tb";
            this.B_Tb.Size = new System.Drawing.Size(100, 20);
            this.B_Tb.TabIndex = 9;
            this.B_Tb.TextChanged += new System.EventHandler(this.B_Tb_TextChanged);
            // 
            // A_VLB
            // 
            this.A_VLB.AutoSize = true;
            this.A_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.A_VLB.Location = new System.Drawing.Point(40, 67);
            this.A_VLB.Name = "A_VLB";
            this.A_VLB.Size = new System.Drawing.Size(35, 13);
            this.A_VLB.TabIndex = 10;
            this.A_VLB.Text = "label3";
            // 
            // B_VLb
            // 
            this.B_VLb.AutoSize = true;
            this.B_VLb.ForeColor = System.Drawing.Color.DarkRed;
            this.B_VLb.Location = new System.Drawing.Point(233, 67);
            this.B_VLb.Name = "B_VLb";
            this.B_VLb.Size = new System.Drawing.Size(35, 13);
            this.B_VLb.TabIndex = 11;
            this.B_VLb.Text = "label4";
            // 
            // PlasticHingePropertiesfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 537);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.Validation_label);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlasticHingePropertiesfrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beam-Column (Plastic Hinge) Connection Properties";
            this.Load += new System.EventHandler(this.PlasticHingeProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label Validation_label;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton Relative_Rbtn;
        private System.Windows.Forms.RadioButton Absolute_Rbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label B_VLb;
        private System.Windows.Forms.Label A_VLB;
        private System.Windows.Forms.TextBox B_Tb;
        private System.Windows.Forms.TextBox A_Tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}