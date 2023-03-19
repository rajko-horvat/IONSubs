namespace IONSubs
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtPath = new System.Windows.Forms.TextBox();
			this.ctlFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.cmdBrowse = new System.Windows.Forms.Button();
			this.cmdStart = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(12, 12);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(479, 27);
			this.txtPath.TabIndex = 0;
			this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
			// 
			// ctlFolderBrowser
			// 
			this.ctlFolderBrowser.ShowNewFolderButton = false;
			// 
			// cmdBrowse
			// 
			this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdBrowse.Location = new System.Drawing.Point(497, 12);
			this.cmdBrowse.Name = "cmdBrowse";
			this.cmdBrowse.Size = new System.Drawing.Size(94, 29);
			this.cmdBrowse.TabIndex = 1;
			this.cmdBrowse.Text = "Browse";
			this.cmdBrowse.UseVisualStyleBackColor = true;
			this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
			// 
			// cmdStart
			// 
			this.cmdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdStart.Enabled = false;
			this.cmdStart.Location = new System.Drawing.Point(597, 12);
			this.cmdStart.Name = "cmdStart";
			this.cmdStart.Size = new System.Drawing.Size(94, 29);
			this.cmdStart.TabIndex = 2;
			this.cmdStart.Text = "Start";
			this.cmdStart.UseVisualStyleBackColor = true;
			this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(703, 53);
			this.Controls.Add(this.cmdStart);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.cmdBrowse);
			this.Name = "Form1";
			this.Text = "ION Subtitles";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox txtPath;
		private FolderBrowserDialog ctlFolderBrowser;
		private Button cmdBrowse;
		private Button cmdStart;
	}
}