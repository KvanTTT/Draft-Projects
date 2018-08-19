namespace CenterOfMass
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbInert2 = new System.Windows.Forms.TextBox();
            this.tbCircle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbInertion = new System.Windows.Forms.TextBox();
            this.tbMass = new System.Windows.Forms.TextBox();
            this.tbSquare = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDensity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbConvex = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.edtEdgesCount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblSelfintersect = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConvex = new System.Windows.Forms.Label();
            this.lblBypass = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEdgesCount)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.cbConvex);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.edtEdgesCount);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(754, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 627);
            this.panel3.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Aquamarine;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(16, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 29);
            this.button2.TabIndex = 45;
            this.button2.Text = "Generate demo shape";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbCount);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbInert2);
            this.groupBox1.Controls.Add(this.tbCircle);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbInertion);
            this.groupBox1.Controls.Add(this.tbMass);
            this.groupBox1.Controls.Add(this.tbSquare);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDensity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox1.Location = new System.Drawing.Point(16, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 218);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Body properties";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(9, 164);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 15);
            this.label18.TabIndex = 14;
            this.label18.Text = "Inertia 2:";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(101, 188);
            this.tbCount.Name = "tbCount";
            this.tbCount.ReadOnly = true;
            this.tbCount.Size = new System.Drawing.Size(142, 21);
            this.tbCount.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(10, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 15);
            this.label17.TabIndex = 12;
            this.label17.Text = "Count:";
            // 
            // tbInert2
            // 
            this.tbInert2.Location = new System.Drawing.Point(101, 161);
            this.tbInert2.Name = "tbInert2";
            this.tbInert2.ReadOnly = true;
            this.tbInert2.Size = new System.Drawing.Size(142, 21);
            this.tbInert2.TabIndex = 11;
            // 
            // tbCircle
            // 
            this.tbCircle.Location = new System.Drawing.Point(101, 134);
            this.tbCircle.Name = "tbCircle";
            this.tbCircle.ReadOnly = true;
            this.tbCircle.Size = new System.Drawing.Size(142, 21);
            this.tbCircle.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Circle inertia:";
            // 
            // tbInertion
            // 
            this.tbInertion.Location = new System.Drawing.Point(101, 107);
            this.tbInertion.Name = "tbInertion";
            this.tbInertion.ReadOnly = true;
            this.tbInertion.Size = new System.Drawing.Size(142, 21);
            this.tbInertion.TabIndex = 7;
            // 
            // tbMass
            // 
            this.tbMass.Location = new System.Drawing.Point(101, 80);
            this.tbMass.Name = "tbMass";
            this.tbMass.ReadOnly = true;
            this.tbMass.Size = new System.Drawing.Size(142, 21);
            this.tbMass.TabIndex = 6;
            // 
            // tbSquare
            // 
            this.tbSquare.Location = new System.Drawing.Point(101, 54);
            this.tbSquare.Name = "tbSquare";
            this.tbSquare.ReadOnly = true;
            this.tbSquare.Size = new System.Drawing.Size(142, 21);
            this.tbSquare.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Inertia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mass:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Square:";
            // 
            // tbDensity
            // 
            this.tbDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDensity.Location = new System.Drawing.Point(101, 26);
            this.tbDensity.Name = "tbDensity";
            this.tbDensity.Size = new System.Drawing.Size(142, 21);
            this.tbDensity.TabIndex = 1;
            this.tbDensity.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Density";
            // 
            // cbConvex
            // 
            this.cbConvex.AutoSize = true;
            this.cbConvex.Checked = true;
            this.cbConvex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConvex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbConvex.Location = new System.Drawing.Point(31, 155);
            this.cbConvex.Name = "cbConvex";
            this.cbConvex.Size = new System.Drawing.Size(66, 19);
            this.cbConvex.TabIndex = 42;
            this.cbConvex.Text = "Convex";
            this.cbConvex.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Aquamarine;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(16, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(260, 29);
            this.button4.TabIndex = 41;
            this.button4.Text = "Generate polygon";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // edtEdgesCount
            // 
            this.edtEdgesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edtEdgesCount.Location = new System.Drawing.Point(180, 124);
            this.edtEdgesCount.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.edtEdgesCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.edtEdgesCount.Name = "edtEdgesCount";
            this.edtEdgesCount.Size = new System.Drawing.Size(46, 21);
            this.edtEdgesCount.TabIndex = 40;
            this.edtEdgesCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(28, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 39;
            this.label10.Text = "Edges count";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aquamarine;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.Location = new System.Drawing.Point(16, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 30);
            this.button1.TabIndex = 22;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblSelfintersect);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.lblConvex);
            this.groupBox5.Controls.Add(this.lblBypass);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox5.Location = new System.Drawing.Point(16, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(260, 93);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Statistics";
            // 
            // lblSelfintersect
            // 
            this.lblSelfintersect.AutoSize = true;
            this.lblSelfintersect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelfintersect.Location = new System.Drawing.Point(140, 63);
            this.lblSelfintersect.Name = "lblSelfintersect";
            this.lblSelfintersect.Size = new System.Drawing.Size(19, 15);
            this.lblSelfintersect.TabIndex = 7;
            this.lblSelfintersect.Text = "---";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(106, -1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 19);
            this.checkBox1.TabIndex = 44;
            this.checkBox1.Text = "Show splitting";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Self intersection:";
            // 
            // lblConvex
            // 
            this.lblConvex.AutoSize = true;
            this.lblConvex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblConvex.Location = new System.Drawing.Point(98, 41);
            this.lblConvex.Name = "lblConvex";
            this.lblConvex.Size = new System.Drawing.Size(19, 15);
            this.lblConvex.TabIndex = 5;
            this.lblConvex.Text = "---";
            // 
            // lblBypass
            // 
            this.lblBypass.AutoSize = true;
            this.lblBypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBypass.Location = new System.Drawing.Point(98, 21);
            this.lblBypass.Name = "lblBypass";
            this.lblBypass.Size = new System.Drawing.Size(19, 15);
            this.lblBypass.TabIndex = 4;
            this.lblBypass.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(103, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 15);
            this.label11.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(103, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 15);
            this.label12.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(18, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Convexity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(18, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Bypass:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Aquamarine;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdate.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.btnUpdate.Location = new System.Drawing.Point(16, 532);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(260, 30);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictBox
            // 
            this.pictBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictBox.Location = new System.Drawing.Point(8, 5);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(740, 627);
            this.pictBox.TabIndex = 9;
            this.pictBox.TabStop = false;
            this.pictBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictBox_MouseUp_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(252)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(1051, 644);
            this.Controls.Add(this.pictBox);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Center of Mass (Vertex, Edge, Face), Inertia";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEdgesCount)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblConvex;
        private System.Windows.Forms.Label lblBypass;
        private System.Windows.Forms.Label lblSelfintersect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbConvex;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown edtEdgesCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInertion;
        private System.Windows.Forms.TextBox tbMass;
        private System.Windows.Forms.TextBox tbSquare;
        private System.Windows.Forms.TextBox tbCircle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbInert2;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}

