namespace SPSW_Solver
{
    partial class FibersZeroLengthNumModelUC
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
            this.End_DGV = new System.Windows.Forms.DataGridView();
            this.Panel_btn = new System.Windows.Forms.RadioButton();
            this.Depth_btn = new System.Windows.Forms.RadioButton();
            this.Zero_btn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Additional_DGV = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.End_DGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Additional_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.End_DGV);
            this.groupBox1.Controls.Add(this.Panel_btn);
            this.groupBox1.Controls.Add(this.Depth_btn);
            this.groupBox1.Controls.Add(this.Zero_btn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plastic hinges at ends :";
            // 
            // End_DGV
            // 
            this.End_DGV.AllowUserToAddRows = false;
            this.End_DGV.AllowUserToDeleteRows = false;
            this.End_DGV.AllowUserToResizeColumns = false;
            this.End_DGV.AllowUserToResizeRows = false;
            this.End_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.End_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Location,
            this.Add,
            this.PLength});
            this.End_DGV.Location = new System.Drawing.Point(0, 137);
            this.End_DGV.Name = "End_DGV";
            this.End_DGV.RowHeadersVisible = false;
            this.End_DGV.Size = new System.Drawing.Size(131, 71);
            this.End_DGV.TabIndex = 4;
            // 
            // Panel_btn
            // 
            this.Panel_btn.AutoSize = true;
            this.Panel_btn.Location = new System.Drawing.Point(11, 94);
            this.Panel_btn.Name = "Panel_btn";
            this.Panel_btn.Size = new System.Drawing.Size(110, 30);
            this.Panel_btn.TabIndex = 3;
            this.Panel_btn.TabStop = true;
            this.Panel_btn.Text = "Section Depth /2 \r\n+Panel Zone ";
            this.Panel_btn.UseVisualStyleBackColor = true;
            this.Panel_btn.CheckedChanged += new System.EventHandler(this.Panel_btn_CheckedChanged);
            // 
            // Depth_btn
            // 
            this.Depth_btn.AutoSize = true;
            this.Depth_btn.Location = new System.Drawing.Point(9, 71);
            this.Depth_btn.Name = "Depth_btn";
            this.Depth_btn.Size = new System.Drawing.Size(107, 17);
            this.Depth_btn.TabIndex = 2;
            this.Depth_btn.TabStop = true;
            this.Depth_btn.Text = "Section Depth /2";
            this.Depth_btn.UseVisualStyleBackColor = true;
            this.Depth_btn.CheckedChanged += new System.EventHandler(this.Depth_btn_CheckedChanged);
            // 
            // Zero_btn
            // 
            this.Zero_btn.AutoSize = true;
            this.Zero_btn.Location = new System.Drawing.Point(9, 48);
            this.Zero_btn.Name = "Zero_btn";
            this.Zero_btn.Size = new System.Drawing.Size(47, 17);
            this.Zero_btn.TabIndex = 1;
            this.Zero_btn.TabStop = true;
            this.Zero_btn.Text = "Zero";
            this.Zero_btn.UseVisualStyleBackColor = true;
            this.Zero_btn.CheckedChanged += new System.EventHandler(this.Zero_btn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "plastic hinge distance \r\nfrom connection joint :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Additional_DGV);
            this.groupBox2.Location = new System.Drawing.Point(144, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Hinges :";
            // 
            // Additional_DGV
            // 
            this.Additional_DGV.AllowUserToResizeColumns = false;
            this.Additional_DGV.AllowUserToResizeRows = false;
            this.Additional_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Additional_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.Length});
            this.Additional_DGV.Location = new System.Drawing.Point(0, 19);
            this.Additional_DGV.Name = "Additional_DGV";
            this.Additional_DGV.RowHeadersWidth = 20;
            this.Additional_DGV.Size = new System.Drawing.Size(133, 189);
            this.Additional_DGV.TabIndex = 5;
            // 
            // Position
            // 
            this.Position.HeaderText = "Relative Position";
            this.Position.Name = "Position";
            this.Position.Width = 55;
            // 
            // Length
            // 
            this.Length.HeaderText = "Lp/D";
            this.Length.Name = "Length";
            this.Length.Width = 55;
            // 
            // Location
            // 
            this.Location.HeaderText = "";
            this.Location.Name = "Location";
            this.Location.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Location.Width = 40;
            // 
            // Add
            // 
            this.Add.FalseValue = "false";
            this.Add.HeaderText = "Add";
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Add.TrueValue = "true";
            this.Add.Width = 40;
            // 
            // PLength
            // 
            this.PLength.HeaderText = "Lp/D";
            this.PLength.Name = "PLength";
            this.PLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PLength.Width = 45;
            // 
            // FibersZeroLengthNumModelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FibersZeroLengthNumModelUC";
            this.Load += new System.EventHandler(this.FibersZeroLengthNumModelUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.End_DGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Additional_DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView End_DGV;
        private System.Windows.Forms.RadioButton Panel_btn;
        private System.Windows.Forms.RadioButton Depth_btn;
        private System.Windows.Forms.RadioButton Zero_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Additional_DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLength;
    }
}
