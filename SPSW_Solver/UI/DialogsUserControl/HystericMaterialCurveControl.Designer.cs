namespace SPSW_Solver
{
    partial class HystericMaterialCurveControl
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
            this.Compression_Gbox = new System.Windows.Forms.GroupBox();
            this.CompressionPoints_VLB = new System.Windows.Forms.Label();
            this.CompressionGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tension_Gbox = new System.Windows.Forms.GroupBox();
            this.TensionPoints_VLB = new System.Windows.Forms.Label();
            this.TensionGridView = new System.Windows.Forms.DataGridView();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DfTension_Lb = new System.Windows.Forms.Label();
            this.DfTension_TB = new System.Windows.Forms.TextBox();
            this.DfTension_VLB = new System.Windows.Forms.Label();
            this.Tension_Gbox2 = new System.Windows.Forms.GroupBox();
            this.DfComp_Lb = new System.Windows.Forms.Label();
            this.DfComp_TB = new System.Windows.Forms.TextBox();
            this.DfComp_VLB = new System.Windows.Forms.Label();
            this.Compression_Gbox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowPdf_Btn = new System.Windows.Forms.Button();
            this.Compression_Gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompressionGridView)).BeginInit();
            this.Tension_Gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TensionGridView)).BeginInit();
            this.Tension_Gbox2.SuspendLayout();
            this.Compression_Gbox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Compression_Gbox
            // 
            this.Compression_Gbox.Controls.Add(this.CompressionPoints_VLB);
            this.Compression_Gbox.Controls.Add(this.CompressionGridView);
            this.Compression_Gbox.Location = new System.Drawing.Point(4, 288);
            this.Compression_Gbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Compression_Gbox.Name = "Compression_Gbox";
            this.Compression_Gbox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Compression_Gbox.Size = new System.Drawing.Size(209, 169);
            this.Compression_Gbox.TabIndex = 9;
            this.Compression_Gbox.TabStop = false;
            this.Compression_Gbox.Text = "Compression (-ve) Values";
            // 
            // CompressionPoints_VLB
            // 
            this.CompressionPoints_VLB.AutoSize = true;
            this.CompressionPoints_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.CompressionPoints_VLB.Location = new System.Drawing.Point(13, 142);
            this.CompressionPoints_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CompressionPoints_VLB.Name = "CompressionPoints_VLB";
            this.CompressionPoints_VLB.Size = new System.Drawing.Size(0, 17);
            this.CompressionPoints_VLB.TabIndex = 2;
            // 
            // CompressionGridView
            // 
            this.CompressionGridView.AllowUserToAddRows = false;
            this.CompressionGridView.AllowUserToDeleteRows = false;
            this.CompressionGridView.AllowUserToResizeColumns = false;
            this.CompressionGridView.AllowUserToResizeRows = false;
            this.CompressionGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.CompressionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompressionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.CompressionGridView.Location = new System.Drawing.Point(8, 23);
            this.CompressionGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CompressionGridView.Name = "CompressionGridView";
            this.CompressionGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.CompressionGridView.RowHeadersVisible = false;
            this.CompressionGridView.RowHeadersWidth = 51;
            this.CompressionGridView.Size = new System.Drawing.Size(193, 113);
            this.CompressionGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "P";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn1.Width = 22;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "X";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Y";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // Tension_Gbox
            // 
            this.Tension_Gbox.Controls.Add(this.TensionPoints_VLB);
            this.Tension_Gbox.Controls.Add(this.TensionGridView);
            this.Tension_Gbox.Location = new System.Drawing.Point(4, 4);
            this.Tension_Gbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tension_Gbox.Name = "Tension_Gbox";
            this.Tension_Gbox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tension_Gbox.Size = new System.Drawing.Size(209, 170);
            this.Tension_Gbox.TabIndex = 8;
            this.Tension_Gbox.TabStop = false;
            this.Tension_Gbox.Text = "Tension (+ve) Values";
            // 
            // TensionPoints_VLB
            // 
            this.TensionPoints_VLB.AutoSize = true;
            this.TensionPoints_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.TensionPoints_VLB.Location = new System.Drawing.Point(13, 142);
            this.TensionPoints_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TensionPoints_VLB.Name = "TensionPoints_VLB";
            this.TensionPoints_VLB.Size = new System.Drawing.Size(0, 17);
            this.TensionPoints_VLB.TabIndex = 1;
            // 
            // TensionGridView
            // 
            this.TensionGridView.AllowUserToAddRows = false;
            this.TensionGridView.AllowUserToDeleteRows = false;
            this.TensionGridView.AllowUserToResizeColumns = false;
            this.TensionGridView.AllowUserToResizeRows = false;
            this.TensionGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TensionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TensionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P,
            this.X,
            this.Y});
            this.TensionGridView.Location = new System.Drawing.Point(8, 23);
            this.TensionGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TensionGridView.Name = "TensionGridView";
            this.TensionGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TensionGridView.RowHeadersVisible = false;
            this.TensionGridView.RowHeadersWidth = 51;
            this.TensionGridView.Size = new System.Drawing.Size(193, 114);
            this.TensionGridView.TabIndex = 0;
            // 
            // P
            // 
            this.P.HeaderText = "Point";
            this.P.MinimumWidth = 6;
            this.P.Name = "P";
            this.P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.P.Width = 37;
            // 
            // X
            // 
            this.X.HeaderText = "Strain";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.X.Width = 51;
            // 
            // Y
            // 
            this.Y.HeaderText = "Stress";
            this.Y.MinimumWidth = 6;
            this.Y.Name = "Y";
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Y.Width = 51;
            // 
            // DfTension_Lb
            // 
            this.DfTension_Lb.AutoSize = true;
            this.DfTension_Lb.Location = new System.Drawing.Point(13, 22);
            this.DfTension_Lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DfTension_Lb.Name = "DfTension_Lb";
            this.DfTension_Lb.Size = new System.Drawing.Size(41, 17);
            this.DfTension_Lb.TabIndex = 9;
            this.DfTension_Lb.Text = "Max. ";
            // 
            // DfTension_TB
            // 
            this.DfTension_TB.Location = new System.Drawing.Point(49, 48);
            this.DfTension_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DfTension_TB.Name = "DfTension_TB";
            this.DfTension_TB.Size = new System.Drawing.Size(99, 22);
            this.DfTension_TB.TabIndex = 10;
            // 
            // DfTension_VLB
            // 
            this.DfTension_VLB.AutoSize = true;
            this.DfTension_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.DfTension_VLB.Location = new System.Drawing.Point(13, 86);
            this.DfTension_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DfTension_VLB.Name = "DfTension_VLB";
            this.DfTension_VLB.Size = new System.Drawing.Size(0, 17);
            this.DfTension_VLB.TabIndex = 11;
            // 
            // Tension_Gbox2
            // 
            this.Tension_Gbox2.Controls.Add(this.DfTension_VLB);
            this.Tension_Gbox2.Controls.Add(this.DfTension_TB);
            this.Tension_Gbox2.Controls.Add(this.DfTension_Lb);
            this.Tension_Gbox2.Location = new System.Drawing.Point(4, 172);
            this.Tension_Gbox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tension_Gbox2.Name = "Tension_Gbox2";
            this.Tension_Gbox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tension_Gbox2.Size = new System.Drawing.Size(209, 113);
            this.Tension_Gbox2.TabIndex = 10;
            this.Tension_Gbox2.TabStop = false;
            this.Tension_Gbox2.Text = "Tension Behavior Limits";
            // 
            // DfComp_Lb
            // 
            this.DfComp_Lb.AutoSize = true;
            this.DfComp_Lb.Location = new System.Drawing.Point(8, 22);
            this.DfComp_Lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DfComp_Lb.Name = "DfComp_Lb";
            this.DfComp_Lb.Size = new System.Drawing.Size(41, 17);
            this.DfComp_Lb.TabIndex = 14;
            this.DfComp_Lb.Text = "Max. ";
            // 
            // DfComp_TB
            // 
            this.DfComp_TB.Location = new System.Drawing.Point(80, 48);
            this.DfComp_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DfComp_TB.Name = "DfComp_TB";
            this.DfComp_TB.Size = new System.Drawing.Size(99, 22);
            this.DfComp_TB.TabIndex = 15;
            // 
            // DfComp_VLB
            // 
            this.DfComp_VLB.AutoSize = true;
            this.DfComp_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.DfComp_VLB.Location = new System.Drawing.Point(15, 86);
            this.DfComp_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DfComp_VLB.Name = "DfComp_VLB";
            this.DfComp_VLB.Size = new System.Drawing.Size(0, 17);
            this.DfComp_VLB.TabIndex = 16;
            // 
            // Compression_Gbox2
            // 
            this.Compression_Gbox2.Controls.Add(this.DfComp_VLB);
            this.Compression_Gbox2.Controls.Add(this.DfComp_TB);
            this.Compression_Gbox2.Controls.Add(this.DfComp_Lb);
            this.Compression_Gbox2.Location = new System.Drawing.Point(221, 340);
            this.Compression_Gbox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Compression_Gbox2.Name = "Compression_Gbox2";
            this.Compression_Gbox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Compression_Gbox2.Size = new System.Drawing.Size(217, 117);
            this.Compression_Gbox2.TabIndex = 11;
            this.Compression_Gbox2.TabStop = false;
            this.Compression_Gbox2.Text = "Compression Behavior Limits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(505, 339);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "For Help ?";
            // 
            // ShowPdf_Btn
            // 
            this.ShowPdf_Btn.BackgroundImage = global::SPSW_Solver.Properties.Resources.question;
            this.ShowPdf_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShowPdf_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowPdf_Btn.Location = new System.Drawing.Point(589, 362);
            this.ShowPdf_Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShowPdf_Btn.Name = "ShowPdf_Btn";
            this.ShowPdf_Btn.Size = new System.Drawing.Size(93, 86);
            this.ShowPdf_Btn.TabIndex = 13;
            this.ShowPdf_Btn.UseVisualStyleBackColor = true;
            this.ShowPdf_Btn.Click += new System.EventHandler(this.ShowPdf_Btn_Click);
            // 
            // HystericMaterialCurveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShowPdf_Btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Compression_Gbox2);
            this.Controls.Add(this.Tension_Gbox2);
            this.Controls.Add(this.Compression_Gbox);
            this.Controls.Add(this.Tension_Gbox);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "HystericMaterialCurveControl";
            this.Load += new System.EventHandler(this.HystericMaterialCurveControl_Load);
            this.Controls.SetChildIndex(this.Tension_Gbox, 0);
            this.Controls.SetChildIndex(this.Compression_Gbox, 0);
            this.Controls.SetChildIndex(this.Tension_Gbox2, 0);
            this.Controls.SetChildIndex(this.Compression_Gbox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ShowPdf_Btn, 0);
            this.Compression_Gbox.ResumeLayout(false);
            this.Compression_Gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompressionGridView)).EndInit();
            this.Tension_Gbox.ResumeLayout(false);
            this.Tension_Gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TensionGridView)).EndInit();
            this.Tension_Gbox2.ResumeLayout(false);
            this.Tension_Gbox2.PerformLayout();
            this.Compression_Gbox2.ResumeLayout(false);
            this.Compression_Gbox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Compression_Gbox;
        private System.Windows.Forms.GroupBox Tension_Gbox;
        private System.Windows.Forms.DataGridView TensionGridView;
        private System.Windows.Forms.DataGridView CompressionGridView;
        private System.Windows.Forms.Label CompressionPoints_VLB;
        private System.Windows.Forms.Label TensionPoints_VLB;
        private System.Windows.Forms.Label DfTension_Lb;
        private System.Windows.Forms.TextBox DfTension_TB;
        private System.Windows.Forms.Label DfTension_VLB;
        private System.Windows.Forms.GroupBox Tension_Gbox2;
        private System.Windows.Forms.Label DfComp_Lb;
        private System.Windows.Forms.TextBox DfComp_TB;
        private System.Windows.Forms.Label DfComp_VLB;
        private System.Windows.Forms.GroupBox Compression_Gbox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShowPdf_Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
    }
}
