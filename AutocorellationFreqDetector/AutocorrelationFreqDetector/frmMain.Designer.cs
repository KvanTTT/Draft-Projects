namespace AutocorrelationFreqDetector
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectDataFile = new System.Windows.Forms.Button();
            this.tbDataPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBreath1Period = new System.Windows.Forms.TextBox();
            this.tbBreath2Period = new System.Windows.Forms.TextBox();
            this.cbBreath1 = new System.Windows.Forms.CheckBox();
            this.cbBreath2 = new System.Windows.Forms.CheckBox();
            this.graphBreath = new ZedGraph.ZedGraphControl();
            this.graphAutocorrelation = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "xlsx data folder path";
            // 
            // btnSelectDataFile
            // 
            this.btnSelectDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDataFile.Location = new System.Drawing.Point(852, 7);
            this.btnSelectDataFile.Name = "btnSelectDataFile";
            this.btnSelectDataFile.Size = new System.Drawing.Size(28, 22);
            this.btnSelectDataFile.TabIndex = 9;
            this.btnSelectDataFile.Text = "...";
            this.btnSelectDataFile.UseVisualStyleBackColor = true;
            this.btnSelectDataFile.Click += new System.EventHandler(this.btnSelectDataFile_Click);
            // 
            // tbDataPath
            // 
            this.tbDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDataPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDataPath.Location = new System.Drawing.Point(145, 7);
            this.tbDataPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbDataPath.Name = "tbDataPath";
            this.tbDataPath.Size = new System.Drawing.Size(700, 22);
            this.tbDataPath.TabIndex = 11;
            this.tbDataPath.Text = "..\\..\\..\\Samples";
            this.tbDataPath.TextChanged += new System.EventHandler(this.tbDataPath_TextChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(15, 592);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(123, 32);
            this.btnCalculate.TabIndex = 12;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 857);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Breath 1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(519, 857);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Breath 2";
            // 
            // tbBreath1Period
            // 
            this.tbBreath1Period.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBreath1Period.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBreath1Period.Location = new System.Drawing.Point(79, 854);
            this.tbBreath1Period.Margin = new System.Windows.Forms.Padding(4);
            this.tbBreath1Period.Name = "tbBreath1Period";
            this.tbBreath1Period.ReadOnly = true;
            this.tbBreath1Period.Size = new System.Drawing.Size(294, 22);
            this.tbBreath1Period.TabIndex = 18;
            // 
            // tbBreath2Period
            // 
            this.tbBreath2Period.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBreath2Period.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBreath2Period.Location = new System.Drawing.Point(584, 854);
            this.tbBreath2Period.Margin = new System.Windows.Forms.Padding(4);
            this.tbBreath2Period.Name = "tbBreath2Period";
            this.tbBreath2Period.ReadOnly = true;
            this.tbBreath2Period.Size = new System.Drawing.Size(296, 22);
            this.tbBreath2Period.TabIndex = 20;
            // 
            // cbBreath1
            // 
            this.cbBreath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBreath1.AutoSize = true;
            this.cbBreath1.Checked = true;
            this.cbBreath1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBreath1.Location = new System.Drawing.Point(522, 807);
            this.cbBreath1.Name = "cbBreath1";
            this.cbBreath1.Size = new System.Drawing.Size(66, 17);
            this.cbBreath1.TabIndex = 21;
            this.cbBreath1.Text = "Breath 1";
            this.cbBreath1.UseVisualStyleBackColor = true;
            this.cbBreath1.CheckedChanged += new System.EventHandler(this.cbBreath1_CheckedChanged);
            // 
            // cbBreath2
            // 
            this.cbBreath2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBreath2.AutoSize = true;
            this.cbBreath2.Checked = true;
            this.cbBreath2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBreath2.Location = new System.Drawing.Point(522, 830);
            this.cbBreath2.Name = "cbBreath2";
            this.cbBreath2.Size = new System.Drawing.Size(66, 17);
            this.cbBreath2.TabIndex = 22;
            this.cbBreath2.Text = "Breath 2";
            this.cbBreath2.UseVisualStyleBackColor = true;
            this.cbBreath2.CheckedChanged += new System.EventHandler(this.cbBreath2_CheckedChanged);
            // 
            // graphBreath
            // 
            this.graphBreath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphBreath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graphBreath.Location = new System.Drawing.Point(15, 37);
            this.graphBreath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphBreath.Name = "graphBreath";
            this.graphBreath.ScrollGrace = 0D;
            this.graphBreath.ScrollMaxX = 0D;
            this.graphBreath.ScrollMaxY = 0D;
            this.graphBreath.ScrollMaxY2 = 0D;
            this.graphBreath.ScrollMinX = 0D;
            this.graphBreath.ScrollMinY = 0D;
            this.graphBreath.ScrollMinY2 = 0D;
            this.graphBreath.Size = new System.Drawing.Size(865, 270);
            this.graphBreath.TabIndex = 10;
            this.graphBreath.UseExtendedPrintDialog = true;
            // 
            // graphAutocorrelation
            // 
            this.graphAutocorrelation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphAutocorrelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graphAutocorrelation.Location = new System.Drawing.Point(15, 320);
            this.graphAutocorrelation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphAutocorrelation.Name = "graphAutocorrelation";
            this.graphAutocorrelation.ScrollGrace = 0D;
            this.graphAutocorrelation.ScrollMaxX = 0D;
            this.graphAutocorrelation.ScrollMaxY = 0D;
            this.graphAutocorrelation.ScrollMaxY2 = 0D;
            this.graphAutocorrelation.ScrollMinX = 0D;
            this.graphAutocorrelation.ScrollMinY = 0D;
            this.graphAutocorrelation.ScrollMinY2 = 0D;
            this.graphAutocorrelation.Size = new System.Drawing.Size(865, 265);
            this.graphAutocorrelation.TabIndex = 17;
            this.graphAutocorrelation.UseExtendedPrintDialog = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 636);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectDataFile);
            this.Controls.Add(this.tbDataPath);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBreath1Period);
            this.Controls.Add(this.tbBreath2Period);
            this.Controls.Add(this.cbBreath1);
            this.Controls.Add(this.cbBreath2);
            this.Controls.Add(this.graphBreath);
            this.Controls.Add(this.graphAutocorrelation);
            this.Name = "frmMain";
            this.Text = "Autocorrelation Frequency Detector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectDataFile;
        private ZedGraph.ZedGraphControl graphBreath;
        private System.Windows.Forms.TextBox tbDataPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBreath1Period;
        private System.Windows.Forms.TextBox tbBreath2Period;
        private System.Windows.Forms.CheckBox cbBreath1;
        private System.Windows.Forms.CheckBox cbBreath2;
        private ZedGraph.ZedGraphControl graphAutocorrelation;
    }
}