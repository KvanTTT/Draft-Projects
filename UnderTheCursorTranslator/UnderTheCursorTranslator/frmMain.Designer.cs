namespace UnderTheCursorTranslator
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.tbInput = new System.Windows.Forms.TextBox();
			this.btnTranslate = new System.Windows.Forms.Button();
			this.tbTranslation = new System.Windows.Forms.TextBox();
			this.btnSettings = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "notifyIcon1";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
			// 
			// tbInput
			// 
			this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInput.Location = new System.Drawing.Point(12, 12);
			this.tbInput.Name = "tbInput";
			this.tbInput.Size = new System.Drawing.Size(437, 20);
			this.tbInput.TabIndex = 0;
			this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
			// 
			// btnTranslate
			// 
			this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTranslate.Location = new System.Drawing.Point(312, 394);
			this.btnTranslate.Name = "btnTranslate";
			this.btnTranslate.Size = new System.Drawing.Size(137, 40);
			this.btnTranslate.TabIndex = 1;
			this.btnTranslate.Text = "Translate";
			this.btnTranslate.UseVisualStyleBackColor = true;
			this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
			// 
			// tbTranslation
			// 
			this.tbTranslation.AcceptsReturn = true;
			this.tbTranslation.AcceptsTab = true;
			this.tbTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTranslation.Location = new System.Drawing.Point(12, 38);
			this.tbTranslation.Multiline = true;
			this.tbTranslation.Name = "tbTranslation";
			this.tbTranslation.ReadOnly = true;
			this.tbTranslation.Size = new System.Drawing.Size(437, 350);
			this.tbTranslation.TabIndex = 2;
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSettings.Location = new System.Drawing.Point(12, 394);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(125, 40);
			this.btnSettings.TabIndex = 3;
			this.btnSettings.Text = "Setting";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(173, 393);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(103, 40);
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 446);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.tbTranslation);
			this.Controls.Add(this.btnTranslate);
			this.Controls.Add(this.tbInput);
			this.Name = "frmMain";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.Button btnTranslate;
		private System.Windows.Forms.TextBox tbTranslation;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Button button1;
	}
}