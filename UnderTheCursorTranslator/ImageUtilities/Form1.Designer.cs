namespace ImageUtilities
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
			this.pbImage = new System.Windows.Forms.PictureBox();
			this.vertical = new System.Windows.Forms.PictureBox();
			this.horizontal = new System.Windows.Forms.PictureBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.vertical2 = new System.Windows.Forms.PictureBox();
			this.horizontal2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vertical)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.horizontal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vertical2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.horizontal2)).BeginInit();
			this.SuspendLayout();
			// 
			// pbImage
			// 
			this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbImage.Location = new System.Drawing.Point(104, 85);
			this.pbImage.Name = "pbImage";
			this.pbImage.Size = new System.Drawing.Size(511, 477);
			this.pbImage.TabIndex = 0;
			this.pbImage.TabStop = false;
			// 
			// vertical
			// 
			this.vertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.vertical.Location = new System.Drawing.Point(58, 85);
			this.vertical.Name = "vertical";
			this.vertical.Size = new System.Drawing.Size(40, 477);
			this.vertical.TabIndex = 1;
			this.vertical.TabStop = false;
			// 
			// horizontal
			// 
			this.horizontal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.horizontal.Location = new System.Drawing.Point(104, 44);
			this.horizontal.Name = "horizontal";
			this.horizontal.Size = new System.Drawing.Size(511, 35);
			this.horizontal.TabIndex = 2;
			this.horizontal.TabStop = false;
			// 
			// btnLoad
			// 
			this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoad.Location = new System.Drawing.Point(621, 12);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(105, 37);
			this.btnLoad.TabIndex = 3;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnCalculate
			// 
			this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCalculate.Location = new System.Drawing.Point(621, 55);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(105, 37);
			this.btnCalculate.TabIndex = 4;
			this.btnCalculate.Text = "Calculate";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// vertical2
			// 
			this.vertical2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.vertical2.Location = new System.Drawing.Point(12, 85);
			this.vertical2.Name = "vertical2";
			this.vertical2.Size = new System.Drawing.Size(40, 477);
			this.vertical2.TabIndex = 5;
			this.vertical2.TabStop = false;
			// 
			// horizontal2
			// 
			this.horizontal2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.horizontal2.Location = new System.Drawing.Point(104, 3);
			this.horizontal2.Name = "horizontal2";
			this.horizontal2.Size = new System.Drawing.Size(511, 35);
			this.horizontal2.TabIndex = 6;
			this.horizontal2.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 574);
			this.Controls.Add(this.horizontal2);
			this.Controls.Add(this.vertical2);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.horizontal);
			this.Controls.Add(this.vertical);
			this.Controls.Add(this.pbImage);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vertical)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.horizontal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vertical2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.horizontal2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbImage;
		private System.Windows.Forms.PictureBox vertical;
		private System.Windows.Forms.PictureBox horizontal;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox vertical2;
		private System.Windows.Forms.PictureBox horizontal2;
	}
}

