namespace UnderTheCursorTranslator
{
	partial class frmSettings
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
			this.tcSettings = new System.Windows.Forms.TabControl();
			this.tpCursorTranslation = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btnAddException = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.dgvApplicationExceptions = new System.Windows.Forms.DataGridView();
			this.clnApplication = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnWindow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lblDelyay = new System.Windows.Forms.Label();
			this.lblMouseKeyboardCombonation = new System.Windows.Forms.Label();
			this.tpDictionaries = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tcSettings.SuspendLayout();
			this.tpCursorTranslation.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvApplicationExceptions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.tpDictionaries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tcSettings
			// 
			this.tcSettings.Controls.Add(this.tpCursorTranslation);
			this.tcSettings.Controls.Add(this.tpDictionaries);
			this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcSettings.Location = new System.Drawing.Point(0, 0);
			this.tcSettings.Name = "tcSettings";
			this.tcSettings.SelectedIndex = 0;
			this.tcSettings.Size = new System.Drawing.Size(553, 633);
			this.tcSettings.TabIndex = 3;
			// 
			// tpCursorTranslation
			// 
			this.tpCursorTranslation.Controls.Add(this.groupBox1);
			this.tpCursorTranslation.Location = new System.Drawing.Point(4, 22);
			this.tpCursorTranslation.Name = "tpCursorTranslation";
			this.tpCursorTranslation.Padding = new System.Windows.Forms.Padding(3);
			this.tpCursorTranslation.Size = new System.Drawing.Size(545, 607);
			this.tpCursorTranslation.TabIndex = 0;
			this.tpCursorTranslation.Text = "Cursor Translation";
			this.tpCursorTranslation.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.btnAddException);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.dgvApplicationExceptions);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.lblDelyay);
			this.groupBox1.Controls.Add(this.lblMouseKeyboardCombonation);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(539, 601);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text translation under the cursor";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(409, 563);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Remove";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// btnAddException
			// 
			this.btnAddException.Location = new System.Drawing.Point(330, 563);
			this.btnAddException.Name = "btnAddException";
			this.btnAddException.Size = new System.Drawing.Size(73, 23);
			this.btnAddException.TabIndex = 8;
			this.btnAddException.Text = "Add";
			this.btnAddException.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 150);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Application exceptions";
			// 
			// dgvApplicationExceptions
			// 
			this.dgvApplicationExceptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvApplicationExceptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnApplication,
            this.clnWindow,
            this.clnComment});
			this.dgvApplicationExceptions.Location = new System.Drawing.Point(9, 166);
			this.dgvApplicationExceptions.Name = "dgvApplicationExceptions";
			this.dgvApplicationExceptions.Size = new System.Drawing.Size(475, 391);
			this.dgvApplicationExceptions.TabIndex = 6;
			// 
			// clnApplication
			// 
			this.clnApplication.HeaderText = "Application";
			this.clnApplication.Name = "clnApplication";
			// 
			// clnWindow
			// 
			this.clnWindow.HeaderText = "Window";
			this.clnWindow.Name = "clnWindow";
			// 
			// clnComment
			// 
			this.clnComment.HeaderText = "Comment";
			this.clnComment.Name = "clnComment";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(9, 111);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(98, 17);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "Error correction";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 39);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(192, 20);
			this.textBox1.TabIndex = 4;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(9, 85);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(93, 20);
			this.numericUpDown1.TabIndex = 3;
			this.numericUpDown1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// lblDelyay
			// 
			this.lblDelyay.AutoSize = true;
			this.lblDelyay.Location = new System.Drawing.Point(6, 69);
			this.lblDelyay.Name = "lblDelyay";
			this.lblDelyay.Size = new System.Drawing.Size(34, 13);
			this.lblDelyay.TabIndex = 2;
			this.lblDelyay.Text = "Delay";
			this.lblDelyay.Click += new System.EventHandler(this.label2_Click);
			// 
			// lblMouseKeyboardCombonation
			// 
			this.lblMouseKeyboardCombonation.AutoSize = true;
			this.lblMouseKeyboardCombonation.Location = new System.Drawing.Point(6, 23);
			this.lblMouseKeyboardCombonation.Name = "lblMouseKeyboardCombonation";
			this.lblMouseKeyboardCombonation.Size = new System.Drawing.Size(155, 13);
			this.lblMouseKeyboardCombonation.TabIndex = 1;
			this.lblMouseKeyboardCombonation.Text = "Mouse && keyboard combination";
			// 
			// tpDictionaries
			// 
			this.tpDictionaries.Controls.Add(this.button3);
			this.tpDictionaries.Controls.Add(this.button1);
			this.tpDictionaries.Controls.Add(this.dataGridView1);
			this.tpDictionaries.Location = new System.Drawing.Point(4, 22);
			this.tpDictionaries.Name = "tpDictionaries";
			this.tpDictionaries.Padding = new System.Windows.Forms.Padding(3);
			this.tpDictionaries.Size = new System.Drawing.Size(545, 607);
			this.tpDictionaries.TabIndex = 1;
			this.tpDictionaries.Text = "Dictionaries";
			this.tpDictionaries.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnName});
			this.dataGridView1.Location = new System.Drawing.Point(8, 6);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(478, 443);
			this.dataGridView1.TabIndex = 0;
			// 
			// clnName
			// 
			this.clnName.HeaderText = "Name";
			this.clnName.Name = "clnName";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(326, 471);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(411, 471);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Remove";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(553, 633);
			this.Controls.Add(this.tcSettings);
			this.Name = "frmSettings";
			this.Text = "Settings";
			this.tcSettings.ResumeLayout(false);
			this.tpCursorTranslation.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvApplicationExceptions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.tpDictionaries.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tcSettings;
		private System.Windows.Forms.TabPage tpCursorTranslation;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dgvApplicationExceptions;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label lblDelyay;
		private System.Windows.Forms.Label lblMouseKeyboardCombonation;
		private System.Windows.Forms.TabPage tpDictionaries;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnApplication;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnWindow;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnComment;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnAddException;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button1;

	}
}