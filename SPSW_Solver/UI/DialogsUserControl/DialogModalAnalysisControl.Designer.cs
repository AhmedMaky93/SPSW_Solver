namespace SPSW_Solver
{
    partial class DialogModalAnalysisControl
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
            this.Run_Button = new System.Windows.Forms.Button();
            this.modeShapes_TB = new System.Windows.Forms.TextBox();
            this.ModeShapes_VLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FPS_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.nxt_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ModeShape_LB = new System.Windows.Forms.Label();
            this.Model_Shapes_Rbtn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.scaleTB = new System.Windows.Forms.TextBox();
            this.Default_Rbt = new System.Windows.Forms.RadioButton();
            this.Fail_Lb = new System.Windows.Forms.Label();
            this.dialogSolvingOptions1 = new SPSW_Solver.UI.DialogsUserControl.DialogSolvingOptions();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Run_Button
            // 
            this.Run_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Run_Button.FlatAppearance.BorderSize = 0;
            this.Run_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Run_Button.Location = new System.Drawing.Point(24, 390);
            this.Run_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(40, 37);
            this.Run_Button.TabIndex = 2;
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // modeShapes_TB
            // 
            this.modeShapes_TB.Location = new System.Drawing.Point(219, 390);
            this.modeShapes_TB.Margin = new System.Windows.Forms.Padding(4);
            this.modeShapes_TB.Name = "modeShapes_TB";
            this.modeShapes_TB.Size = new System.Drawing.Size(60, 22);
            this.modeShapes_TB.TabIndex = 3;
            this.modeShapes_TB.TextChanged += new System.EventHandler(this.ModeShapes_TB_TextChanged);
            // 
            // ModeShapes_VLB
            // 
            this.ModeShapes_VLB.AutoSize = true;
            this.ModeShapes_VLB.ForeColor = System.Drawing.Color.DarkRed;
            this.ModeShapes_VLB.Location = new System.Drawing.Point(124, 53);
            this.ModeShapes_VLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModeShapes_VLB.Name = "ModeShapes_VLB";
            this.ModeShapes_VLB.Size = new System.Drawing.Size(0, 17);
            this.ModeShapes_VLB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 390);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mode Shapes :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FPS_TB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.back_btn);
            this.groupBox2.Controls.Add(this.nxt_btn);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.ModeShape_LB);
            this.groupBox2.Controls.Add(this.Model_Shapes_Rbtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.scaleTB);
            this.groupBox2.Controls.Add(this.Default_Rbt);
            this.groupBox2.Location = new System.Drawing.Point(4, 452);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(305, 254);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // FPS_TB
            // 
            this.FPS_TB.Location = new System.Drawing.Point(224, 20);
            this.FPS_TB.Margin = new System.Windows.Forms.Padding(4);
            this.FPS_TB.Name = "FPS_TB";
            this.FPS_TB.Size = new System.Drawing.Size(51, 22);
            this.FPS_TB.TabIndex = 24;
            this.FPS_TB.TextChanged += new System.EventHandler(this.FPS_TB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "*10 seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Display a time step graph per :";
            // 
            // back_btn
            // 
            this.back_btn.BackgroundImage = global::SPSW_Solver.Properties.Resources.back;
            this.back_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back_btn.FlatAppearance.BorderSize = 0;
            this.back_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.Green;
            this.back_btn.Location = new System.Drawing.Point(87, 174);
            this.back_btn.Margin = new System.Windows.Forms.Padding(4);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(44, 34);
            this.back_btn.TabIndex = 21;
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // nxt_btn
            // 
            this.nxt_btn.BackgroundImage = global::SPSW_Solver.Properties.Resources.next;
            this.nxt_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nxt_btn.FlatAppearance.BorderSize = 0;
            this.nxt_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nxt_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxt_btn.ForeColor = System.Drawing.Color.Green;
            this.nxt_btn.Location = new System.Drawing.Point(205, 174);
            this.nxt_btn.Margin = new System.Windows.Forms.Padding(4);
            this.nxt_btn.Name = "nxt_btn";
            this.nxt_btn.Size = new System.Drawing.Size(44, 34);
            this.nxt_btn.TabIndex = 20;
            this.nxt_btn.UseVisualStyleBackColor = true;
            this.nxt_btn.Click += new System.EventHandler(this.Nxt_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 216);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 28);
            this.button1.TabIndex = 19;
            this.button1.Text = "Show Modal Analysis Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ModeShape_LB
            // 
            this.ModeShape_LB.AutoSize = true;
            this.ModeShape_LB.Enabled = false;
            this.ModeShape_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeShape_LB.Location = new System.Drawing.Point(152, 177);
            this.ModeShape_LB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModeShape_LB.Name = "ModeShape_LB";
            this.ModeShape_LB.Size = new System.Drawing.Size(24, 25);
            this.ModeShape_LB.TabIndex = 18;
            this.ModeShape_LB.Text = "1";
            // 
            // Model_Shapes_Rbtn
            // 
            this.Model_Shapes_Rbtn.AutoSize = true;
            this.Model_Shapes_Rbtn.Location = new System.Drawing.Point(20, 105);
            this.Model_Shapes_Rbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Model_Shapes_Rbtn.Name = "Model_Shapes_Rbtn";
            this.Model_Shapes_Rbtn.Size = new System.Drawing.Size(165, 21);
            this.Model_Shapes_Rbtn.TabIndex = 17;
            this.Model_Shapes_Rbtn.TabStop = true;
            this.Model_Shapes_Rbtn.Text = "Model Shapes Viewer";
            this.Model_Shapes_Rbtn.UseVisualStyleBackColor = true;
            this.Model_Shapes_Rbtn.CheckedChanged += new System.EventHandler(this.Model_Shapes_Rbtn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Displacements Scale :";
            // 
            // scaleTB
            // 
            this.scaleTB.Location = new System.Drawing.Point(220, 137);
            this.scaleTB.Margin = new System.Windows.Forms.Padding(4);
            this.scaleTB.Name = "scaleTB";
            this.scaleTB.Size = new System.Drawing.Size(51, 22);
            this.scaleTB.TabIndex = 15;
            this.scaleTB.TextChanged += new System.EventHandler(this.ScaleTB_TextChanged);
            // 
            // Default_Rbt
            // 
            this.Default_Rbt.AutoSize = true;
            this.Default_Rbt.Location = new System.Drawing.Point(20, 73);
            this.Default_Rbt.Margin = new System.Windows.Forms.Padding(4);
            this.Default_Rbt.Name = "Default_Rbt";
            this.Default_Rbt.Size = new System.Drawing.Size(120, 21);
            this.Default_Rbt.TabIndex = 14;
            this.Default_Rbt.TabStop = true;
            this.Default_Rbt.Text = "Default Viewer";
            this.Default_Rbt.UseVisualStyleBackColor = true;
            this.Default_Rbt.CheckedChanged += new System.EventHandler(this.Default_Rbt_CheckedChanged);
            // 
            // Fail_Lb
            // 
            this.Fail_Lb.AutoSize = true;
            this.Fail_Lb.ForeColor = System.Drawing.Color.DarkRed;
            this.Fail_Lb.Location = new System.Drawing.Point(21, 431);
            this.Fail_Lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Fail_Lb.Name = "Fail_Lb";
            this.Fail_Lb.Size = new System.Drawing.Size(114, 17);
            this.Fail_Lb.TabIndex = 7;
            this.Fail_Lb.Text = "Analysis Failed ..";
            this.Fail_Lb.Visible = false;
            // 
            // dialogSolvingOptions1
            // 
            this.dialogSolvingOptions1.Location = new System.Drawing.Point(0, 0);
            this.dialogSolvingOptions1.Name = "dialogSolvingOptions1";
            this.dialogSolvingOptions1.Size = new System.Drawing.Size(336, 368);
            this.dialogSolvingOptions1.TabIndex = 8;
            // 
            // DialogModalAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dialogSolvingOptions1);
            this.Controls.Add(this.Fail_Lb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ModeShapes_VLB);
            this.Controls.Add(this.modeShapes_TB);
            this.Controls.Add(this.Run_Button);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DialogModalAnalysisControl";
            this.Load += new System.EventHandler(this.DialogModalAnalysisControl_Load);
            this.Controls.SetChildIndex(this.Run_Button, 0);
            this.Controls.SetChildIndex(this.modeShapes_TB, 0);
            this.Controls.SetChildIndex(this.ModeShapes_VLB, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.Fail_Lb, 0);
            this.Controls.SetChildIndex(this.dialogSolvingOptions1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.TextBox modeShapes_TB;
        private System.Windows.Forms.Label ModeShapes_VLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Fail_Lb;
        private System.Windows.Forms.RadioButton Model_Shapes_Rbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scaleTB;
        private System.Windows.Forms.RadioButton Default_Rbt;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button nxt_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ModeShape_LB;
        private System.Windows.Forms.TextBox FPS_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private UI.DialogsUserControl.DialogSolvingOptions dialogSolvingOptions1;
    }
}
