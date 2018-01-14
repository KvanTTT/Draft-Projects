namespace DotNetNavigator.GUI
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
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnOpenSolution = new System.Windows.Forms.Button();
            this.tbSolutionPath = new System.Windows.Forms.TextBox();
            this.btnExploreSolution = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ofdSolution = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tvFiles
            // 
            this.tvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFiles.Location = new System.Drawing.Point(12, 38);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.Size = new System.Drawing.Size(279, 514);
            this.tvFiles.TabIndex = 0;
            this.tvFiles.DoubleClick += new System.EventHandler(this.tvFiles_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Files";
            // 
            // tbCode
            // 
            this.tbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCode.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCode.Location = new System.Drawing.Point(314, 86);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ReadOnly = true;
            this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCode.Size = new System.Drawing.Size(748, 466);
            this.tbCode.TabIndex = 2;
            this.tbCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCode_KeyDown);
            this.tbCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCode_KeyPress);
            // 
            // btnOpenSolution
            // 
            this.btnOpenSolution.Location = new System.Drawing.Point(842, 9);
            this.btnOpenSolution.Name = "btnOpenSolution";
            this.btnOpenSolution.Size = new System.Drawing.Size(119, 23);
            this.btnOpenSolution.TabIndex = 3;
            this.btnOpenSolution.Text = "Open Solution";
            this.btnOpenSolution.UseVisualStyleBackColor = true;
            this.btnOpenSolution.Click += new System.EventHandler(this.btnOpenSolution_Click);
            // 
            // tbSolutionPath
            // 
            this.tbSolutionPath.Location = new System.Drawing.Point(399, 11);
            this.tbSolutionPath.Name = "tbSolutionPath";
            this.tbSolutionPath.Size = new System.Drawing.Size(389, 20);
            this.tbSolutionPath.TabIndex = 4;
            this.tbSolutionPath.Text = "C:\\Users\\ikochurkin\\Documents\\GitHub\\CSharp-Minifier\\CSharpMinifier.sln";
            // 
            // btnExploreSolution
            // 
            this.btnExploreSolution.Location = new System.Drawing.Point(794, 9);
            this.btnExploreSolution.Name = "btnExploreSolution";
            this.btnExploreSolution.Size = new System.Drawing.Size(29, 23);
            this.btnExploreSolution.TabIndex = 5;
            this.btnExploreSolution.Text = "...";
            this.btnExploreSolution.UseVisualStyleBackColor = true;
            this.btnExploreSolution.Click += new System.EventHandler(this.btnExploreSolution_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Solution Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Name";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(399, 38);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(389, 20);
            this.tbFileName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Code";
            // 
            // ofdSolution
            // 
            this.ofdSolution.FileName = "openFileDialog1";
            this.ofdSolution.Filter = "Solution files (*.sln)|*.sln";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 564);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExploreSolution);
            this.Controls.Add(this.tbSolutionPath);
            this.Controls.Add(this.btnOpenSolution);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvFiles);
            this.Name = "frmMain";
            this.Text = "DotNetNavigator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Button btnOpenSolution;
        private System.Windows.Forms.TextBox tbSolutionPath;
        private System.Windows.Forms.Button btnExploreSolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog ofdSolution;
    }
}

