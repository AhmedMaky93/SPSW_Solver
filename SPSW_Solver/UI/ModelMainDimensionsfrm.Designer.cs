
namespace SPSW_Solver
{
    partial class ModelMainDimensionsfrm
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
            this.label7 = new System.Windows.Forms.Label();
            this.Heights_TB = new System.Windows.Forms.TextBox();
            this.Heights_VLB = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Width_TB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FloorsNo_TB = new System.Windows.Forms.TextBox();
            this.FloorsNo_VLB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WidthGroupBox = new System.Windows.Forms.GroupBox();
            this.Width_VLB = new System.Windows.Forms.Label();
            this.Group1_btn = new System.Windows.Forms.Button();
            this.HeightGroupBox = new System.Windows.Forms.GroupBox();
            this.Ok_Button = new System.Windows.Forms.Button();
            this.Heights_DGV = new System.Windows.Forms.DataGridView();
            this.Aspect_Ratio_LB = new System.Windows.Forms.Label();
            this.HeightGrps_VLB = new System.Windows.Forms.Label();
            this.Start_Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End_Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aspect_Ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WidthGroupBox.SuspendLayout();
            this.HeightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Heights_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "( Centerlines Dimensions )";
            // 
            // Heights_TB
            // 
            this.Heights_TB.Location = new System.Drawing.Point(598, 53);
            this.Heights_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Heights_TB.Name = "Heights_TB";
            this.Heights_TB.Size = new System.Drawing.Size(101, 22);
            this.Heights_TB.TabIndex = 29;
            this.Heights_TB.TextChanged += new System.EventHandler(this.Height_TB_TextChanged);
            // 
            // Heights_VLB
            // 
            this.Heights_VLB.AutoSize = true;
            this.Heights_VLB.ForeColor = System.Drawing.Color.Red;
            this.Heights_VLB.Location = new System.Drawing.Point(500, 79);
            this.Heights_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Heights_VLB.Name = "Heights_VLB";
            this.Heights_VLB.Size = new System.Drawing.Size(46, 17);
            this.Heights_VLB.TabIndex = 28;
            this.Heights_VLB.Text = "label9";
            this.Heights_VLB.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(469, 53);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Heights Groups";
            // 
            // Width_TB
            // 
            this.Width_TB.Location = new System.Drawing.Point(326, 53);
            this.Width_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Width_TB.Name = "Width_TB";
            this.Width_TB.Size = new System.Drawing.Size(101, 22);
            this.Width_TB.TabIndex = 26;
            this.Width_TB.TextChanged += new System.EventHandler(this.Width_TB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Floor Width";
            // 
            // FloorsNo_TB
            // 
            this.FloorsNo_TB.Location = new System.Drawing.Point(100, 53);
            this.FloorsNo_TB.Margin = new System.Windows.Forms.Padding(4);
            this.FloorsNo_TB.Name = "FloorsNo_TB";
            this.FloorsNo_TB.Size = new System.Drawing.Size(101, 22);
            this.FloorsNo_TB.TabIndex = 24;
            this.FloorsNo_TB.TextChanged += new System.EventHandler(this.FloorsNo_TB_TextChanged);
            // 
            // FloorsNo_VLB
            // 
            this.FloorsNo_VLB.AutoSize = true;
            this.FloorsNo_VLB.ForeColor = System.Drawing.Color.Red;
            this.FloorsNo_VLB.Location = new System.Drawing.Point(23, 79);
            this.FloorsNo_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FloorsNo_VLB.Name = "FloorsNo_VLB";
            this.FloorsNo_VLB.Size = new System.Drawing.Size(46, 17);
            this.FloorsNo_VLB.TabIndex = 23;
            this.FloorsNo_VLB.Text = "label3";
            this.FloorsNo_VLB.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Floors No.";
            // 
            // WidthGroupBox
            // 
            this.WidthGroupBox.Controls.Add(this.Width_VLB);
            this.WidthGroupBox.Controls.Add(this.label7);
            this.WidthGroupBox.Controls.Add(this.Heights_TB);
            this.WidthGroupBox.Controls.Add(this.label4);
            this.WidthGroupBox.Controls.Add(this.Heights_VLB);
            this.WidthGroupBox.Controls.Add(this.FloorsNo_VLB);
            this.WidthGroupBox.Controls.Add(this.label10);
            this.WidthGroupBox.Controls.Add(this.FloorsNo_TB);
            this.WidthGroupBox.Controls.Add(this.Width_TB);
            this.WidthGroupBox.Controls.Add(this.label6);
            this.WidthGroupBox.Location = new System.Drawing.Point(12, 12);
            this.WidthGroupBox.Name = "WidthGroupBox";
            this.WidthGroupBox.Size = new System.Drawing.Size(715, 115);
            this.WidthGroupBox.TabIndex = 31;
            this.WidthGroupBox.TabStop = false;
            // 
            // Width_VLB
            // 
            this.Width_VLB.AutoSize = true;
            this.Width_VLB.ForeColor = System.Drawing.Color.Red;
            this.Width_VLB.Location = new System.Drawing.Point(255, 79);
            this.Width_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Width_VLB.Name = "Width_VLB";
            this.Width_VLB.Size = new System.Drawing.Size(46, 17);
            this.Width_VLB.TabIndex = 31;
            this.Width_VLB.Text = "label9";
            this.Width_VLB.Visible = false;
            // 
            // Group1_btn
            // 
            this.Group1_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Group1_btn.Location = new System.Drawing.Point(254, 134);
            this.Group1_btn.Name = "Group1_btn";
            this.Group1_btn.Size = new System.Drawing.Size(206, 29);
            this.Group1_btn.TabIndex = 32;
            this.Group1_btn.Text = "Submit";
            this.Group1_btn.UseVisualStyleBackColor = true;
            this.Group1_btn.Click += new System.EventHandler(this.Group1_btn_Click);
            // 
            // HeightGroupBox
            // 
            this.HeightGroupBox.Controls.Add(this.HeightGrps_VLB);
            this.HeightGroupBox.Controls.Add(this.Aspect_Ratio_LB);
            this.HeightGroupBox.Controls.Add(this.Heights_DGV);
            this.HeightGroupBox.Controls.Add(this.Ok_Button);
            this.HeightGroupBox.Location = new System.Drawing.Point(13, 169);
            this.HeightGroupBox.Name = "HeightGroupBox";
            this.HeightGroupBox.Size = new System.Drawing.Size(715, 383);
            this.HeightGroupBox.TabIndex = 33;
            this.HeightGroupBox.TabStop = false;
            // 
            // Ok_Button
            // 
            this.Ok_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ok_Button.Location = new System.Drawing.Point(240, 338);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(206, 31);
            this.Ok_Button.TabIndex = 0;
            this.Ok_Button.Text = "OK";
            this.Ok_Button.UseVisualStyleBackColor = true;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Heights_DGV
            // 
            this.Heights_DGV.AllowUserToAddRows = false;
            this.Heights_DGV.AllowUserToDeleteRows = false;
            this.Heights_DGV.AllowUserToResizeColumns = false;
            this.Heights_DGV.AllowUserToResizeRows = false;
            this.Heights_DGV.CausesValidation = false;
            this.Heights_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Heights_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Start_Floor,
            this.End_Floor,
            this.Height,
            this.Aspect_Ratio});
            this.Heights_DGV.Location = new System.Drawing.Point(11, 55);
            this.Heights_DGV.Name = "Heights_DGV";
            this.Heights_DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Heights_DGV.RowHeadersVisible = false;
            this.Heights_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Heights_DGV.RowTemplate.Height = 24;
            this.Heights_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Heights_DGV.Size = new System.Drawing.Size(698, 241);
            this.Heights_DGV.TabIndex = 1;
            this.Heights_DGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Heights_DGV_CellValueChanged);
            // 
            // Aspect_Ratio_LB
            // 
            this.Aspect_Ratio_LB.AutoSize = true;
            this.Aspect_Ratio_LB.Location = new System.Drawing.Point(11, 22);
            this.Aspect_Ratio_LB.Name = "Aspect_Ratio_LB";
            this.Aspect_Ratio_LB.Size = new System.Drawing.Size(46, 17);
            this.Aspect_Ratio_LB.TabIndex = 2;
            this.Aspect_Ratio_LB.Text = "label1";
            // 
            // HeightGrps_VLB
            // 
            this.HeightGrps_VLB.AutoSize = true;
            this.HeightGrps_VLB.ForeColor = System.Drawing.Color.Red;
            this.HeightGrps_VLB.Location = new System.Drawing.Point(11, 309);
            this.HeightGrps_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeightGrps_VLB.Name = "HeightGrps_VLB";
            this.HeightGrps_VLB.Size = new System.Drawing.Size(46, 17);
            this.HeightGrps_VLB.TabIndex = 32;
            this.HeightGrps_VLB.Text = "label9";
            this.HeightGrps_VLB.Visible = false;
            // 
            // Start_Floor
            // 
            this.Start_Floor.HeaderText = "Start Floor";
            this.Start_Floor.MinimumWidth = 6;
            this.Start_Floor.Name = "Start_Floor";
            this.Start_Floor.Width = 125;
            // 
            // End_Floor
            // 
            this.End_Floor.HeaderText = "End Floor";
            this.End_Floor.MinimumWidth = 6;
            this.End_Floor.Name = "End_Floor";
            this.End_Floor.Width = 125;
            // 
            // Height
            // 
            this.Height.HeaderText = "Height";
            this.Height.MinimumWidth = 6;
            this.Height.Name = "Height";
            this.Height.Width = 125;
            // 
            // Aspect_Ratio
            // 
            this.Aspect_Ratio.HeaderText = "Aspect Ratio";
            this.Aspect_Ratio.MinimumWidth = 6;
            this.Aspect_Ratio.Name = "Aspect_Ratio";
            this.Aspect_Ratio.ReadOnly = true;
            this.Aspect_Ratio.Width = 125;
            // 
            // ModelMainDimensionsfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 564);
            this.Controls.Add(this.HeightGroupBox);
            this.Controls.Add(this.Group1_btn);
            this.Controls.Add(this.WidthGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelMainDimensionsfrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Layout";
            this.Load += new System.EventHandler(this.ModelMainDimensionsfrm_Load);
            this.WidthGroupBox.ResumeLayout(false);
            this.WidthGroupBox.PerformLayout();
            this.HeightGroupBox.ResumeLayout(false);
            this.HeightGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Heights_DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Heights_TB;
        private System.Windows.Forms.Label Heights_VLB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Width_TB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FloorsNo_TB;
        private System.Windows.Forms.Label FloorsNo_VLB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox WidthGroupBox;
        private System.Windows.Forms.Label Width_VLB;
        private System.Windows.Forms.Button Group1_btn;
        private System.Windows.Forms.GroupBox HeightGroupBox;
        private System.Windows.Forms.Button Ok_Button;
        private System.Windows.Forms.Label HeightGrps_VLB;
        private System.Windows.Forms.Label Aspect_Ratio_LB;
        private System.Windows.Forms.DataGridView Heights_DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aspect_Ratio;
    }
}