namespace SPSW_Solver
{
    partial class ModalAnalysisReportFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAMBDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OMEGA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FREQUENCY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERIOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUMMX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUMMY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUMMRZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TMRZ_LB = new System.Windows.Forms.Label();
            this.TMY_LB = new System.Windows.Forms.Label();
            this.TMX_LB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MODE,
            this.LAMBDA,
            this.OMEGA,
            this.FREQUENCY,
            this.PERIOD,
            this.MX,
            this.MY,
            this.MRZ,
            this.SUMMX,
            this.SUMMY,
            this.SUMMRZ});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(742, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // MODE
            // 
            this.MODE.HeaderText = "Mode";
            this.MODE.Name = "MODE";
            this.MODE.Width = 59;
            // 
            // LAMBDA
            // 
            this.LAMBDA.HeaderText = "Eigen value (rad /s)^2";
            this.LAMBDA.Name = "LAMBDA";
            this.LAMBDA.Width = 103;
            // 
            // OMEGA
            // 
            this.OMEGA.HeaderText = "Omega (rad/s)";
            this.OMEGA.Name = "OMEGA";
            this.OMEGA.Width = 92;
            // 
            // FREQUENCY
            // 
            this.FREQUENCY.HeaderText = "Frequency (Hrz)";
            this.FREQUENCY.Name = "FREQUENCY";
            this.FREQUENCY.Width = 98;
            // 
            // PERIOD
            // 
            this.PERIOD.HeaderText = "Period (s)";
            this.PERIOD.Name = "PERIOD";
            this.PERIOD.Width = 70;
            // 
            // MX
            // 
            this.MX.HeaderText = "Mx (%)";
            this.MX.Name = "MX";
            this.MX.Width = 46;
            // 
            // MY
            // 
            this.MY.HeaderText = "My (%)";
            this.MY.Name = "MY";
            this.MY.Width = 46;
            // 
            // MRZ
            // 
            this.MRZ.HeaderText = "Mrz (%)";
            this.MRZ.Name = "MRZ";
            this.MRZ.Width = 49;
            // 
            // SUMMX
            // 
            this.SUMMX.HeaderText = "Cumulative Mx (%)";
            this.SUMMX.Name = "SUMMX";
            this.SUMMX.Width = 96;
            // 
            // SUMMY
            // 
            this.SUMMY.HeaderText = "Cumulative My (%)";
            this.SUMMY.Name = "SUMMY";
            this.SUMMY.Width = 96;
            // 
            // SUMMRZ
            // 
            this.SUMMRZ.HeaderText = "Cumulative  Mrz (%)";
            this.SUMMRZ.Name = "SUMMRZ";
            this.SUMMRZ.Width = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total mass of the structure :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(439, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "My";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(586, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mr z";
            // 
            // TMRZ_LB
            // 
            this.TMRZ_LB.AutoSize = true;
            this.TMRZ_LB.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMRZ_LB.Location = new System.Drawing.Point(589, 46);
            this.TMRZ_LB.Name = "TMRZ_LB";
            this.TMRZ_LB.Size = new System.Drawing.Size(28, 16);
            this.TMRZ_LB.TabIndex = 7;
            this.TMRZ_LB.Text = "0.0";
            // 
            // TMY_LB
            // 
            this.TMY_LB.AutoSize = true;
            this.TMY_LB.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMY_LB.Location = new System.Drawing.Point(442, 46);
            this.TMY_LB.Name = "TMY_LB";
            this.TMY_LB.Size = new System.Drawing.Size(28, 16);
            this.TMY_LB.TabIndex = 6;
            this.TMY_LB.Text = "0.0";
            // 
            // TMX_LB
            // 
            this.TMX_LB.AutoSize = true;
            this.TMX_LB.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMX_LB.Location = new System.Drawing.Point(289, 46);
            this.TMX_LB.Name = "TMX_LB";
            this.TMX_LB.Size = new System.Drawing.Size(28, 16);
            this.TMX_LB.TabIndex = 5;
            this.TMX_LB.Text = "0.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TMRZ_LB);
            this.groupBox1.Controls.Add(this.TMX_LB);
            this.groupBox1.Controls.Add(this.TMY_LB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 77);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 343);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(132, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 8;
            // 
            // ModalAnalysisReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalAnalysisReportFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modal Analysis Report";
            this.Load += new System.EventHandler(this.ModalAnalysisReportFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TMRZ_LB;
        private System.Windows.Forms.Label TMY_LB;
        private System.Windows.Forms.Label TMX_LB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAMBDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OMEGA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FREQUENCY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERIOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX;
        private System.Windows.Forms.DataGridViewTextBoxColumn MY;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUMMX;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUMMY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUMMRZ;
        private System.Windows.Forms.Label label5;
    }
}