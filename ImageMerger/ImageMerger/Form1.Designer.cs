namespace ImageMerger
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
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSelectImages = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdImages = new System.Windows.Forms.OpenFileDialog();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.cbEveryNStrip = new System.Windows.Forms.CheckBox();
            this.nudPixelsWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelsWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(23, 102);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(166, 173);
            this.lbFiles.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(23, 300);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(166, 27);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnSelectImages
            // 
            this.btnSelectImages.Location = new System.Drawing.Point(23, 26);
            this.btnSelectImages.Name = "btnSelectImages";
            this.btnSelectImages.Size = new System.Drawing.Size(166, 27);
            this.btnSelectImages.TabIndex = 2;
            this.btnSelectImages.Text = "Add Images";
            this.btnSelectImages.UseVisualStyleBackColor = true;
            this.btnSelectImages.Click += new System.EventHandler(this.btnSelectImages_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.pbResult);
            this.panel1.Location = new System.Drawing.Point(231, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 295);
            this.panel1.TabIndex = 4;
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(22, 10);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(335, 268);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbResult.TabIndex = 4;
            this.pbResult.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Result";
            // 
            // ofdImages
            // 
            this.ofdImages.FileName = "openFileDialog1";
            this.ofdImages.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.ofdImages.Multiselect = true;
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.cmbDirection.Location = new System.Drawing.Point(231, 10);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(155, 21);
            this.cmbDirection.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(23, 59);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(166, 27);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Width";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(196, 109);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(20, 23);
            this.btnMoveUp.TabIndex = 5;
            this.btnMoveUp.Text = "↑";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Visible = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(196, 135);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(20, 23);
            this.btnMoveDown.TabIndex = 10;
            this.btnMoveDown.Text = "↓";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Visible = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // cbEveryNStrip
            // 
            this.cbEveryNStrip.AutoSize = true;
            this.cbEveryNStrip.Checked = true;
            this.cbEveryNStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEveryNStrip.Location = new System.Drawing.Point(680, 12);
            this.cbEveryNStrip.Name = "cbEveryNStrip";
            this.cbEveryNStrip.Size = new System.Drawing.Size(86, 17);
            this.cbEveryNStrip.TabIndex = 11;
            this.cbEveryNStrip.Text = "Every N strip";
            this.cbEveryNStrip.UseVisualStyleBackColor = true;
            // 
            // nudPixelsWidth
            // 
            this.nudPixelsWidth.Location = new System.Drawing.Point(477, 11);
            this.nudPixelsWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPixelsWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPixelsWidth.Name = "nudPixelsWidth";
            this.nudPixelsWidth.Size = new System.Drawing.Size(120, 20);
            this.nudPixelsWidth.TabIndex = 12;
            this.nudPixelsWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "px";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 363);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudPixelsWidth);
            this.Controls.Add(this.cbEveryNStrip);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectImages);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lbFiles);
            this.Name = "frmMain";
            this.Text = "Image by Strips Merger";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelsWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSelectImages;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdImages;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.CheckBox cbEveryNStrip;
        private System.Windows.Forms.NumericUpDown nudPixelsWidth;
        private System.Windows.Forms.Label label3;
    }
}

