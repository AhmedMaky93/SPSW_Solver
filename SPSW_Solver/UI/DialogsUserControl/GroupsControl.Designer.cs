namespace SPSW_Solver
{
    partial class GroupsControl
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
            this.Groups_TB = new System.Windows.Forms.TextBox();
            this.Ok_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VlB = new System.Windows.Forms.Label();
            this.Submit_button = new System.Windows.Forms.Button();
            this.Edit_button = new System.Windows.Forms.Button();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Groups ";
            // 
            // Groups_TB
            // 
            this.Groups_TB.Location = new System.Drawing.Point(73, 9);
            this.Groups_TB.Name = "Groups_TB";
            this.Groups_TB.Size = new System.Drawing.Size(60, 20);
            this.Groups_TB.TabIndex = 1;
            // 
            // Ok_button
            // 
            this.Ok_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ok_button.Location = new System.Drawing.Point(155, 7);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(63, 23);
            this.Ok_button.TabIndex = 2;
            this.Ok_button.Text = "Ok";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.StartIndex,
            this.EndIndex,
            this.Section,
            this.NumModel});
            this.dataGridView1.Location = new System.Drawing.Point(4, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(223, 269);
            this.dataGridView1.TabIndex = 3;
            // 
            // VlB
            // 
            this.VlB.AutoSize = true;
            this.VlB.ForeColor = System.Drawing.Color.DarkRed;
            this.VlB.Location = new System.Drawing.Point(13, 332);
            this.VlB.Name = "VlB";
            this.VlB.Size = new System.Drawing.Size(0, 13);
            this.VlB.TabIndex = 4;
            // 
            // Submit_button
            // 
            this.Submit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Submit_button.Location = new System.Drawing.Point(155, 359);
            this.Submit_button.Name = "Submit_button";
            this.Submit_button.Size = new System.Drawing.Size(63, 23);
            this.Submit_button.TabIndex = 5;
            this.Submit_button.Text = "Submit";
            this.Submit_button.UseVisualStyleBackColor = true;
            this.Submit_button.Click += new System.EventHandler(this.Submit_button_Click);
            // 
            // Edit_button
            // 
            this.Edit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit_button.Location = new System.Drawing.Point(73, 359);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(63, 23);
            this.Edit_button.TabIndex = 6;
            this.Edit_button.Text = "Edit";
            this.Edit_button.UseVisualStyleBackColor = true;
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // Index
            // 
            this.Index.FillWeight = 50F;
            this.Index.HeaderText = "Group";
            this.Index.Name = "Index";
            this.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Index.Width = 40;
            // 
            // StartIndex
            // 
            this.StartIndex.HeaderText = "Start Level Index";
            this.StartIndex.Name = "StartIndex";
            this.StartIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.StartIndex.Width = 40;
            // 
            // EndIndex
            // 
            this.EndIndex.HeaderText = "End Level Index";
            this.EndIndex.Name = "EndIndex";
            this.EndIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.EndIndex.Width = 40;
            // 
            // Section
            // 
            this.Section.HeaderText = "Section";
            this.Section.Name = "Section";
            this.Section.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Section.Width = 85;
            // 
            // NumModel
            // 
            this.NumModel.HeaderText = "Numeical Model";
            this.NumModel.Name = "NumModel";
            this.NumModel.Width = 85;
            // 
            // GroupsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Edit_button);
            this.Controls.Add(this.Submit_button);
            this.Controls.Add(this.VlB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.Groups_TB);
            this.Controls.Add(this.label1);
            this.Name = "GroupsControl";
            this.Size = new System.Drawing.Size(230, 396);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Groups_TB;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label VlB;
        private System.Windows.Forms.Button Submit_button;
        private System.Windows.Forms.Button Edit_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumModel;
    }
}
