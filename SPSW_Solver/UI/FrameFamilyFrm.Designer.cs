namespace SPSW_Solver
{
    partial class FrameFamilyFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Name_Tb = new System.Windows.Forms.TextBox();
            this.Name_VLB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Material_comboBox = new System.Windows.Forms.ComboBox();
            this.Section_comboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.E_TB = new System.Windows.Forms.TextBox();
            this.E_VLB = new System.Windows.Forms.Label();
            this.Flange_comboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Modifiers_DGV = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Fibers_DGV = new System.Windows.Forms.DataGridView();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Modifiers_DGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fibers_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Section Name : ";
            // 
            // Name_Tb
            // 
            this.Name_Tb.Location = new System.Drawing.Point(344, 7);
            this.Name_Tb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name_Tb.Name = "Name_Tb";
            this.Name_Tb.Size = new System.Drawing.Size(160, 22);
            this.Name_Tb.TabIndex = 1;
            this.Name_Tb.TextChanged += new System.EventHandler(this.Name_Tb_TextChanged);
            // 
            // Name_VLB
            // 
            this.Name_VLB.AutoSize = true;
            this.Name_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.Name_VLB.Location = new System.Drawing.Point(340, 48);
            this.Name_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name_VLB.Name = "Name_VLB";
            this.Name_VLB.Size = new System.Drawing.Size(0, 17);
            this.Name_VLB.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cross Section  : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Web Fibers Material    : ";
            // 
            // Material_comboBox
            // 
            this.Material_comboBox.FormattingEnabled = true;
            this.Material_comboBox.Location = new System.Drawing.Point(211, 27);
            this.Material_comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Material_comboBox.Name = "Material_comboBox";
            this.Material_comboBox.Size = new System.Drawing.Size(160, 24);
            this.Material_comboBox.TabIndex = 5;
            this.Material_comboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.Material_comboBox_Format);
            // 
            // Section_comboBox
            // 
            this.Section_comboBox.FormattingEnabled = true;
            this.Section_comboBox.Location = new System.Drawing.Point(343, 76);
            this.Section_comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Section_comboBox.Name = "Section_comboBox";
            this.Section_comboBox.Size = new System.Drawing.Size(160, 24);
            this.Section_comboBox.TabIndex = 6;
            this.Section_comboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.Section_comboBox_Format);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(288, 406);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "E - Elastic  : ";
            // 
            // E_TB
            // 
            this.E_TB.Location = new System.Drawing.Point(139, 50);
            this.E_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.E_TB.Name = "E_TB";
            this.E_TB.Size = new System.Drawing.Size(109, 22);
            this.E_TB.TabIndex = 9;
            this.E_TB.TextChanged += new System.EventHandler(this.E_TB_TextChanged);
            // 
            // E_VLB
            // 
            this.E_VLB.AutoSize = true;
            this.E_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.E_VLB.Location = new System.Drawing.Point(135, 92);
            this.E_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.E_VLB.Name = "E_VLB";
            this.E_VLB.Size = new System.Drawing.Size(0, 17);
            this.E_VLB.TabIndex = 11;
            // 
            // Flange_comboBox
            // 
            this.Flange_comboBox.FormattingEnabled = true;
            this.Flange_comboBox.Location = new System.Drawing.Point(211, 68);
            this.Flange_comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Flange_comboBox.Name = "Flange_comboBox";
            this.Flange_comboBox.Size = new System.Drawing.Size(160, 24);
            this.Flange_comboBox.TabIndex = 13;
            this.Flange_comboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.Flange_comboBox_Format);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Flange Fibers Material    : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Modifiers_DGV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_TB);
            this.groupBox1.Controls.Add(this.E_VLB);
            this.groupBox1.Location = new System.Drawing.Point(8, 124);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(371, 274);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elastic Properties :";
            // 
            // Modifiers_DGV
            // 
            this.Modifiers_DGV.AllowUserToAddRows = false;
            this.Modifiers_DGV.AllowUserToDeleteRows = false;
            this.Modifiers_DGV.AllowUserToResizeColumns = false;
            this.Modifiers_DGV.AllowUserToResizeRows = false;
            this.Modifiers_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Modifiers_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Modifier});
            this.Modifiers_DGV.Location = new System.Drawing.Point(8, 154);
            this.Modifiers_DGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Modifiers_DGV.Name = "Modifiers_DGV";
            this.Modifiers_DGV.RowHeadersVisible = false;
            this.Modifiers_DGV.RowHeadersWidth = 51;
            this.Modifiers_DGV.Size = new System.Drawing.Size(355, 113);
            this.Modifiers_DGV.TabIndex = 12;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property ";
            this.Property.MinimumWidth = 6;
            this.Property.Name = "Property";
            this.Property.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Property.Width = 130;
            // 
            // Modifier
            // 
            this.Modifier.HeaderText = "Modifier";
            this.Modifier.MinimumWidth = 6;
            this.Modifier.Name = "Modifier";
            this.Modifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Modifier.Width = 130;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.Fibers_DGV);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Material_comboBox);
            this.groupBox2.Controls.Add(this.Flange_comboBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(387, 124);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(416, 274);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plastic Properties";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 119);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Number of Fibers ";
            // 
            // Fibers_DGV
            // 
            this.Fibers_DGV.AllowUserToAddRows = false;
            this.Fibers_DGV.AllowUserToDeleteRows = false;
            this.Fibers_DGV.AllowUserToResizeColumns = false;
            this.Fibers_DGV.AllowUserToResizeRows = false;
            this.Fibers_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Fibers_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Direction,
            this.X,
            this.Y});
            this.Fibers_DGV.Location = new System.Drawing.Point(21, 154);
            this.Fibers_DGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Fibers_DGV.Name = "Fibers_DGV";
            this.Fibers_DGV.RowHeadersVisible = false;
            this.Fibers_DGV.RowHeadersWidth = 51;
            this.Fibers_DGV.Size = new System.Drawing.Size(383, 113);
            this.Fibers_DGV.TabIndex = 13;
            // 
            // Direction
            // 
            this.Direction.HeaderText = "Direction";
            this.Direction.MinimumWidth = 6;
            this.Direction.Name = "Direction";
            this.Direction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Direction.Width = 125;
            // 
            // X
            // 
            this.X.HeaderText = "Horizontal";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.X.Width = 90;
            // 
            // Y
            // 
            this.Y.HeaderText = "Vertical";
            this.Y.MinimumWidth = 6;
            this.Y.Name = "Y";
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Y.Width = 90;
            // 
            // FrameFamilyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 444);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Section_comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Name_VLB);
            this.Controls.Add(this.Name_Tb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrameFamilyFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame Element Section";
            this.Load += new System.EventHandler(this.FrameFamilyFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Modifiers_DGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fibers_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Name_Tb;
        private System.Windows.Forms.Label Name_VLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Material_comboBox;
        private System.Windows.Forms.ComboBox Section_comboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_TB;
        private System.Windows.Forms.Label E_VLB;
        private System.Windows.Forms.ComboBox Flange_comboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Modifiers_DGV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView Fibers_DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
    }
}