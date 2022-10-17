namespace SPSW_Solver
{
    partial class DialogDeadLoadControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AutomaticDeadLoads_Chb = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gravity_LB = new System.Windows.Forms.Label();
            this.Gravity_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 111);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(320, 448);
            this.dataGridView1.TabIndex = 1;
            // 
            // AutomaticDeadLoads_Chb
            // 
            this.AutomaticDeadLoads_Chb.AutoSize = true;
            this.AutomaticDeadLoads_Chb.Location = new System.Drawing.Point(19, 23);
            this.AutomaticDeadLoads_Chb.Margin = new System.Windows.Forms.Padding(4);
            this.AutomaticDeadLoads_Chb.Name = "AutomaticDeadLoads_Chb";
            this.AutomaticDeadLoads_Chb.Size = new System.Drawing.Size(276, 21);
            this.AutomaticDeadLoads_Chb.TabIndex = 4;
            this.AutomaticDeadLoads_Chb.Text = "Add elements dead loads automatically";
            this.AutomaticDeadLoads_Chb.UseVisualStyleBackColor = true;
            this.AutomaticDeadLoads_Chb.CheckedChanged += new System.EventHandler(this.AutomaticDeadLoads_Chb_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gravity_LB);
            this.groupBox1.Controls.Add(this.Gravity_TB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AutomaticDeadLoads_Chb);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(4, 140);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(335, 566);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gravity Loads";
            // 
            // gravity_LB
            // 
            this.gravity_LB.AutoSize = true;
            this.gravity_LB.ForeColor = System.Drawing.Color.DarkRed;
            this.gravity_LB.Location = new System.Drawing.Point(53, 81);
            this.gravity_LB.Name = "gravity_LB";
            this.gravity_LB.Size = new System.Drawing.Size(173, 17);
            this.gravity_LB.TabIndex = 7;
            this.gravity_LB.Text = "G must be more than zero";
            this.gravity_LB.Visible = false;
            // 
            // Gravity_TB
            // 
            this.Gravity_TB.Location = new System.Drawing.Point(53, 52);
            this.Gravity_TB.Name = "Gravity_TB";
            this.Gravity_TB.Size = new System.Drawing.Size(110, 22);
            this.Gravity_TB.TabIndex = 6;
            this.Gravity_TB.TextChanged += new System.EventHandler(this.Gravity_TB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "G :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(335, 129);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stiffness modifier ";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Element,
            this.Property,
            this.Modifier});
            this.dataGridView2.Location = new System.Drawing.Point(7, 23);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(320, 98);
            this.dataGridView2.TabIndex = 0;
            // 
            // Element
            // 
            this.Element.HeaderText = "Element";
            this.Element.MinimumWidth = 6;
            this.Element.Name = "Element";
            this.Element.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Element.Width = 75;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.MinimumWidth = 6;
            this.Property.Name = "Property";
            this.Property.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Property.Width = 75;
            // 
            // Modifier
            // 
            this.Modifier.HeaderText = "Modifier";
            this.Modifier.MinimumWidth = 6;
            this.Modifier.Name = "Modifier";
            this.Modifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Modifier.Width = 75;
            // 
            // DialogDeadLoadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DialogDeadLoadControl";
            this.Load += new System.EventHandler(this.DialogDeadLoadControl_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.CheckBox AutomaticDeadLoads_Chb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modifier;
        private System.Windows.Forms.Label gravity_LB;
        private System.Windows.Forms.TextBox Gravity_TB;
        private System.Windows.Forms.Label label1;
    }
}
