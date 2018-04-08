namespace Medicine
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.tbK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.btnCalculateKreatinin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbKreatinin = new System.Windows.Forms.TextBox();
            this.tbKreatininClearance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.tbAUC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbKarboplatinDose = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(153, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "K =";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMale.Location = new System.Drawing.Point(12, 12);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(86, 20);
            this.rbMale.TabIndex = 1;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Мужчина";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbSex_CheckedChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFemale.Location = new System.Drawing.Point(12, 35);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(88, 20);
            this.rbFemale.TabIndex = 2;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Женщина";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbSex_CheckedChanged);
            // 
            // tbK
            // 
            this.tbK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbK.Location = new System.Drawing.Point(185, 24);
            this.tbK.Name = "tbK";
            this.tbK.Size = new System.Drawing.Size(39, 22);
            this.tbK.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Возраст";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Масса тела (кг)";
            // 
            // tbWeight
            // 
            this.tbWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWeight.Location = new System.Drawing.Point(156, 111);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(68, 22);
            this.tbWeight.TabIndex = 7;
            // 
            // btnCalculateKreatinin
            // 
            this.btnCalculateKreatinin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculateKreatinin.Location = new System.Drawing.Point(12, 411);
            this.btnCalculateKreatinin.Name = "btnCalculateKreatinin";
            this.btnCalculateKreatinin.Size = new System.Drawing.Size(124, 28);
            this.btnCalculateKreatinin.TabIndex = 8;
            this.btnCalculateKreatinin.Text = "Рассчитать";
            this.btnCalculateKreatinin.UseVisualStyleBackColor = true;
            this.btnCalculateKreatinin.Click += new System.EventHandler(this.btnCalculateKreatinin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Креатинин сыворотки (мкмоль/л)";
            // 
            // tbKreatinin
            // 
            this.tbKreatinin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKreatinin.Location = new System.Drawing.Point(238, 161);
            this.tbKreatinin.Name = "tbKreatinin";
            this.tbKreatinin.Size = new System.Drawing.Size(68, 22);
            this.tbKreatinin.TabIndex = 10;
            // 
            // tbKreatininClearance
            // 
            this.tbKreatininClearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKreatininClearance.Location = new System.Drawing.Point(180, 212);
            this.tbKreatininClearance.Name = "tbKreatininClearance";
            this.tbKreatininClearance.ReadOnly = true;
            this.tbKreatininClearance.Size = new System.Drawing.Size(100, 22);
            this.tbKreatininClearance.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Клиренс креатинина";
            // 
            // tbAge
            // 
            this.tbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAge.Location = new System.Drawing.Point(156, 68);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(68, 22);
            this.tbAge.TabIndex = 13;
            // 
            // tbAUC
            // 
            this.tbAUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAUC.Location = new System.Drawing.Point(180, 255);
            this.tbAUC.Name = "tbAUC";
            this.tbAUC.Size = new System.Drawing.Size(68, 22);
            this.tbAUC.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "AUC";
            // 
            // tbKarboplatinDose
            // 
            this.tbKarboplatinDose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKarboplatinDose.Location = new System.Drawing.Point(172, 462);
            this.tbKarboplatinDose.Name = "tbKarboplatinDose";
            this.tbKarboplatinDose.ReadOnly = true;
            this.tbKarboplatinDose.Size = new System.Drawing.Size(100, 22);
            this.tbKarboplatinDose.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 465);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Доза карбоплатина";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(9, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(334, 40);
            this.label8.TabIndex = 18;
            this.label8.Text = "AUC = 5-7 при монохимиотерапии и у ранее нелеченных больных";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(9, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(334, 50);
            this.label9.TabIndex = 19;
            this.label9.Text = "AUC = 4-6 при использовании карбоплатина в комбинации и у ранее леченных больных";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 503);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbKarboplatinDose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbAUC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbKreatininClearance);
            this.Controls.Add(this.tbKreatinin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCalculateKreatinin);
            this.Controls.Add(this.tbWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbK);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Клиренс креатинина и доза карбоплатина";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.TextBox tbK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.Button btnCalculateKreatinin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbKreatinin;
        private System.Windows.Forms.TextBox tbKreatininClearance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.TextBox tbAUC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbKarboplatinDose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

