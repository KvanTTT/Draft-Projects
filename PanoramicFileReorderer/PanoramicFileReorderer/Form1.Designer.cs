namespace PanoramicFileReorderer
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
			this.tbProjectPath = new System.Windows.Forms.TextBox();
			this.tbGroupsFolderName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbViewsFolderName = new System.Windows.Forms.TextBox();
			this.btnReorder = new System.Windows.Forms.Button();
			this.btnSelectProjectPath = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnOpenProjectFolder = new System.Windows.Forms.Button();
			this.cbMoveSourceToDestination = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(13, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Path of Project";
			// 
			// tbProjectPath
			// 
			this.tbProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbProjectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbProjectPath.Location = new System.Drawing.Point(152, 15);
			this.tbProjectPath.Margin = new System.Windows.Forms.Padding(4);
			this.tbProjectPath.Name = "tbProjectPath";
			this.tbProjectPath.Size = new System.Drawing.Size(350, 22);
			this.tbProjectPath.TabIndex = 1;
			this.tbProjectPath.Leave += new System.EventHandler(this.tbProjectPath_Leave);
			// 
			// tbGroupsFolderName
			// 
			this.tbGroupsFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbGroupsFolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbGroupsFolderName.Location = new System.Drawing.Point(152, 79);
			this.tbGroupsFolderName.Margin = new System.Windows.Forms.Padding(4);
			this.tbGroupsFolderName.Name = "tbGroupsFolderName";
			this.tbGroupsFolderName.Size = new System.Drawing.Size(385, 22);
			this.tbGroupsFolderName.TabIndex = 3;
			this.tbGroupsFolderName.Text = "Groups";
			this.tbGroupsFolderName.Leave += new System.EventHandler(this.tbProjectPath_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 63);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 16);
			this.label2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(13, 82);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Groups Folder Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(13, 50);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Views Folder Name";
			// 
			// tbViewsFolderName
			// 
			this.tbViewsFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbViewsFolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbViewsFolderName.Location = new System.Drawing.Point(152, 47);
			this.tbViewsFolderName.Margin = new System.Windows.Forms.Padding(4);
			this.tbViewsFolderName.Name = "tbViewsFolderName";
			this.tbViewsFolderName.Size = new System.Drawing.Size(385, 22);
			this.tbViewsFolderName.TabIndex = 5;
			this.tbViewsFolderName.Text = "Views";
			this.tbViewsFolderName.Leave += new System.EventHandler(this.tbProjectPath_Leave);
			// 
			// btnReorder
			// 
			this.btnReorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnReorder.Location = new System.Drawing.Point(437, 137);
			this.btnReorder.Margin = new System.Windows.Forms.Padding(4);
			this.btnReorder.Name = "btnReorder";
			this.btnReorder.Size = new System.Drawing.Size(100, 28);
			this.btnReorder.TabIndex = 7;
			this.btnReorder.Text = "Reorder";
			this.btnReorder.UseVisualStyleBackColor = true;
			this.btnReorder.Click += new System.EventHandler(this.btnReorder_Click);
			// 
			// btnSelectProjectPath
			// 
			this.btnSelectProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectProjectPath.Location = new System.Drawing.Point(509, 15);
			this.btnSelectProjectPath.Name = "btnSelectProjectPath";
			this.btnSelectProjectPath.Size = new System.Drawing.Size(28, 22);
			this.btnSelectProjectPath.TabIndex = 8;
			this.btnSelectProjectPath.Text = "...";
			this.btnSelectProjectPath.UseVisualStyleBackColor = true;
			this.btnSelectProjectPath.Click += new System.EventHandler(this.btnSelectProjectPath_Click);
			// 
			// btnOpenProjectFolder
			// 
			this.btnOpenProjectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOpenProjectFolder.Location = new System.Drawing.Point(16, 140);
			this.btnOpenProjectFolder.Name = "btnOpenProjectFolder";
			this.btnOpenProjectFolder.Size = new System.Drawing.Size(162, 28);
			this.btnOpenProjectFolder.TabIndex = 9;
			this.btnOpenProjectFolder.Text = "Open Project Folder";
			this.btnOpenProjectFolder.UseVisualStyleBackColor = true;
			this.btnOpenProjectFolder.Click += new System.EventHandler(this.btnOpenProjectFolder_Click);
			// 
			// cbMoveSourceToDestination
			// 
			this.cbMoveSourceToDestination.AutoSize = true;
			this.cbMoveSourceToDestination.Location = new System.Drawing.Point(16, 108);
			this.cbMoveSourceToDestination.Name = "cbMoveSourceToDestination";
			this.cbMoveSourceToDestination.Size = new System.Drawing.Size(187, 20);
			this.cbMoveSourceToDestination.TabIndex = 10;
			this.cbMoveSourceToDestination.Text = "Move source to destination";
			this.cbMoveSourceToDestination.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 178);
			this.Controls.Add(this.cbMoveSourceToDestination);
			this.Controls.Add(this.btnOpenProjectFolder);
			this.Controls.Add(this.btnSelectProjectPath);
			this.Controls.Add(this.btnReorder);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbViewsFolderName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbGroupsFolderName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbProjectPath);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "File Reorderer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbProjectPath;
		private System.Windows.Forms.TextBox tbGroupsFolderName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbViewsFolderName;
		private System.Windows.Forms.Button btnReorder;
		private System.Windows.Forms.Button btnSelectProjectPath;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnOpenProjectFolder;
		private System.Windows.Forms.CheckBox cbMoveSourceToDestination;
	}
}

