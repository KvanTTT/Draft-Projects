namespace BinarySundial.GUI
{
	partial class frmMain
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
			this.btnGetCurrentLatLng = new System.Windows.Forms.Button();
			this.tbLatitude = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbLongitude = new System.Windows.Forms.TextBox();
			this.btnCalculateAltitudeAzimuth = new System.Windows.Forms.Button();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnGetCurrentDate = new System.Windows.Forms.Button();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.btnGetColors = new System.Windows.Forms.Button();
			this.pbColors = new System.Windows.Forms.PictureBox();
			this.tbColors = new System.Windows.Forms.TextBox();
			this.nudColorsCount = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.pbResultColors = new System.Windows.Forms.PictureBox();
			this.pbSpectr = new System.Windows.Forms.PictureBox();
			this.tbOffset = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbLuminosity = new System.Windows.Forms.TextBox();
			this.cmbCodingFormat = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbColors)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColorsCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbResultColors)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSpectr)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGetCurrentLatLng
			// 
			this.btnGetCurrentLatLng.Location = new System.Drawing.Point(26, 39);
			this.btnGetCurrentLatLng.Name = "btnGetCurrentLatLng";
			this.btnGetCurrentLatLng.Size = new System.Drawing.Size(181, 24);
			this.btnGetCurrentLatLng.TabIndex = 0;
			this.btnGetCurrentLatLng.Text = "Get Current Latitude Longitude";
			this.btnGetCurrentLatLng.UseVisualStyleBackColor = true;
			this.btnGetCurrentLatLng.Click += new System.EventHandler(this.btnGetCurrentLatLng_Click);
			// 
			// tbLatitude
			// 
			this.tbLatitude.Location = new System.Drawing.Point(298, 42);
			this.tbLatitude.Name = "tbLatitude";
			this.tbLatitude.Size = new System.Drawing.Size(100, 20);
			this.tbLatitude.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(232, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Latitude";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(232, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Longitude";
			// 
			// tbLongitude
			// 
			this.tbLongitude.Location = new System.Drawing.Point(298, 68);
			this.tbLongitude.Name = "tbLongitude";
			this.tbLongitude.Size = new System.Drawing.Size(100, 20);
			this.tbLongitude.TabIndex = 4;
			// 
			// btnCalculateAltitudeAzimuth
			// 
			this.btnCalculateAltitudeAzimuth.Location = new System.Drawing.Point(26, 119);
			this.btnCalculateAltitudeAzimuth.Name = "btnCalculateAltitudeAzimuth";
			this.btnCalculateAltitudeAzimuth.Size = new System.Drawing.Size(181, 24);
			this.btnCalculateAltitudeAzimuth.TabIndex = 5;
			this.btnCalculateAltitudeAzimuth.Text = "Calculate Altitude Azimuth";
			this.btnCalculateAltitudeAzimuth.UseVisualStyleBackColor = true;
			this.btnCalculateAltitudeAzimuth.Click += new System.EventHandler(this.btnCalculateAltitudeAzimuth_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Location = new System.Drawing.Point(235, 119);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(400, 243);
			this.tbOutput.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(446, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Date";
			// 
			// btnGetCurrentDate
			// 
			this.btnGetCurrentDate.Location = new System.Drawing.Point(441, 39);
			this.btnGetCurrentDate.Name = "btnGetCurrentDate";
			this.btnGetCurrentDate.Size = new System.Drawing.Size(143, 24);
			this.btnGetCurrentDate.TabIndex = 7;
			this.btnGetCurrentDate.Text = "Get Current Date";
			this.btnGetCurrentDate.UseVisualStyleBackColor = true;
			this.btnGetCurrentDate.Click += new System.EventHandler(this.btnGetCurrentDate_Click);
			// 
			// dtpDate
			// 
			this.dtpDate.Location = new System.Drawing.Point(496, 71);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(151, 20);
			this.dtpDate.TabIndex = 10;
			// 
			// btnGetColors
			// 
			this.btnGetColors.Location = new System.Drawing.Point(26, 374);
			this.btnGetColors.Name = "btnGetColors";
			this.btnGetColors.Size = new System.Drawing.Size(181, 31);
			this.btnGetColors.TabIndex = 11;
			this.btnGetColors.Text = "Get Colors";
			this.btnGetColors.UseVisualStyleBackColor = true;
			this.btnGetColors.Click += new System.EventHandler(this.btnGetColors_Click);
			// 
			// pbColors
			// 
			this.pbColors.Location = new System.Drawing.Point(235, 477);
			this.pbColors.Name = "pbColors";
			this.pbColors.Size = new System.Drawing.Size(218, 31);
			this.pbColors.TabIndex = 12;
			this.pbColors.TabStop = false;
			// 
			// tbColors
			// 
			this.tbColors.Location = new System.Drawing.Point(235, 525);
			this.tbColors.Multiline = true;
			this.tbColors.Name = "tbColors";
			this.tbColors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbColors.Size = new System.Drawing.Size(218, 202);
			this.tbColors.TabIndex = 13;
			// 
			// nudColorsCount
			// 
			this.nudColorsCount.Location = new System.Drawing.Point(330, 381);
			this.nudColorsCount.Name = "nudColorsCount";
			this.nudColorsCount.Size = new System.Drawing.Size(87, 20);
			this.nudColorsCount.TabIndex = 14;
			this.nudColorsCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.nudColorsCount.ValueChanged += new System.EventHandler(this.nudColorsCount_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(241, 383);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Colors Count";
			// 
			// pbResultColors
			// 
			this.pbResultColors.Location = new System.Drawing.Point(705, 328);
			this.pbResultColors.Name = "pbResultColors";
			this.pbResultColors.Size = new System.Drawing.Size(34, 484);
			this.pbResultColors.TabIndex = 16;
			this.pbResultColors.TabStop = false;
			// 
			// pbSpectr
			// 
			this.pbSpectr.Location = new System.Drawing.Point(235, 753);
			this.pbSpectr.Name = "pbSpectr";
			this.pbSpectr.Size = new System.Drawing.Size(312, 31);
			this.pbSpectr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbSpectr.TabIndex = 17;
			this.pbSpectr.TabStop = false;
			// 
			// tbOffset
			// 
			this.tbOffset.Location = new System.Drawing.Point(330, 407);
			this.tbOffset.Name = "tbOffset";
			this.tbOffset.Size = new System.Drawing.Size(87, 20);
			this.tbOffset.TabIndex = 20;
			this.tbOffset.Text = "0";
			this.tbOffset.TextChanged += new System.EventHandler(this.tbOffset_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(241, 410);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 21;
			this.label5.Text = "Offset";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(436, 410);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Luminosity";
			// 
			// tbLuminosity
			// 
			this.tbLuminosity.Location = new System.Drawing.Point(515, 407);
			this.tbLuminosity.Name = "tbLuminosity";
			this.tbLuminosity.Size = new System.Drawing.Size(87, 20);
			this.tbLuminosity.TabIndex = 22;
			this.tbLuminosity.Text = "1";
			this.tbLuminosity.TextChanged += new System.EventHandler(this.tbLuminosity_TextChanged);
			// 
			// cmbCodingFormat
			// 
			this.cmbCodingFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCodingFormat.FormattingEnabled = true;
			this.cmbCodingFormat.Location = new System.Drawing.Point(330, 437);
			this.cmbCodingFormat.Name = "cmbCodingFormat";
			this.cmbCodingFormat.Size = new System.Drawing.Size(121, 21);
			this.cmbCodingFormat.TabIndex = 24;
			this.cmbCodingFormat.SelectedIndexChanged += new System.EventHandler(this.cmbCodingFormat_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(241, 440);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 13);
			this.label7.TabIndex = 25;
			this.label7.Text = "Coding Format";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(871, 824);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cmbCodingFormat);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbLuminosity);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbOffset);
			this.Controls.Add(this.pbSpectr);
			this.Controls.Add(this.pbResultColors);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nudColorsCount);
			this.Controls.Add(this.tbColors);
			this.Controls.Add(this.pbColors);
			this.Controls.Add(this.btnGetColors);
			this.Controls.Add(this.dtpDate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnGetCurrentDate);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.btnCalculateAltitudeAzimuth);
			this.Controls.Add(this.tbLongitude);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbLatitude);
			this.Controls.Add(this.btnGetCurrentLatLng);
			this.Name = "frmMain";
			this.Text = "Binary Sundial GUI";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbColors)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColorsCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbResultColors)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSpectr)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGetCurrentLatLng;
		private System.Windows.Forms.TextBox tbLatitude;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbLongitude;
		private System.Windows.Forms.Button btnCalculateAltitudeAzimuth;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnGetCurrentDate;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Button btnGetColors;
		private System.Windows.Forms.PictureBox pbColors;
		private System.Windows.Forms.TextBox tbColors;
		private System.Windows.Forms.NumericUpDown nudColorsCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pbResultColors;
		private System.Windows.Forms.PictureBox pbSpectr;
		private System.Windows.Forms.TextBox tbOffset;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbLuminosity;
		private System.Windows.Forms.ComboBox cmbCodingFormat;
		private System.Windows.Forms.Label label7;
	}
}

