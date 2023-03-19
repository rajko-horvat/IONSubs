namespace IONSubs
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void cmdBrowse_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtPath.Text) && Directory.Exists(this.txtPath.Text))
			{
				ctlFolderBrowser.SelectedPath = this.txtPath.Text;
			}
			if (ctlFolderBrowser.ShowDialog() == DialogResult.OK)
			{
				this.txtPath.Text = ctlFolderBrowser.SelectedPath;

				this.cmdStart.Enabled = !string.IsNullOrEmpty(this.txtPath.Text);
			}
		}

		private void cmdStart_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtPath.Text) ||
				!Directory.Exists(this.txtPath.Text))
			{
				MessageBox.Show("The selected folder doesn't exist", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				this.cmdStart.Enabled = false;
				Application.DoEvents();
				ProcessDirectory(this.txtPath.Text);
				this.cmdStart.Enabled = true;
			}
		}

		private void ProcessDirectory(string path) 
		{
			string subsPath = $"{path}{Path.DirectorySeparatorChar}Subs";

			if (Directory.Exists(path))
			{
				if (Directory.Exists(subsPath))
				{
					string[] aVideoFiles = Directory.GetFiles(path, "*.mp4");

					if (aVideoFiles.Length > 0)
					{
						if (aVideoFiles.Length == 1)
						{
							// single file
							string videoFile = aVideoFiles[0];
							string[] aSubs = Directory.GetFiles(subsPath, "*english*.srt");
							string sSubFile = "";
							long lSubSize = 0;

							for (int i = 0; i < aSubs.Length; i++)
							{
								FileInfo info = new FileInfo(aSubs[i]);
								if (info.Length > lSubSize)
								{
									lSubSize = info.Length;
									sSubFile = aSubs[i];
								}
							}

							if (!string.IsNullOrEmpty(sSubFile))
							{
								File.Copy(sSubFile, $"{path}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(videoFile)}{Path.GetExtension(sSubFile)}", true);
							}
						}
						else
						{
							// multiple files
							for (int i = 0; i < aVideoFiles.Length; i++)
							{
								string videoFile = aVideoFiles[i];
								string subPath = $"{subsPath}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(videoFile)}";
								if (Directory.Exists(subPath))
								{
									string[] aSubs = Directory.GetFiles(subPath, "*english*.srt");
									string sSubFile = "";
									long lSubSize = 0;

									for (int j = 0; j < aSubs.Length; j++)
									{
										FileInfo info = new FileInfo(aSubs[j]);
										if (info.Length > lSubSize)
										{
											lSubSize = info.Length;
											sSubFile = aSubs[j];
										}
									}

									if (!string.IsNullOrEmpty(sSubFile))
									{
										File.Copy(sSubFile, $"{path}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(videoFile)}{Path.GetExtension(sSubFile)}", true);
									}
								}
								else if (File.Exists($"{subPath}.srt"))
								{
									File.Copy($"{subPath}.srt", $"{path}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(videoFile)}.srt", true);
								}
								else
								{
									MessageBox.Show($"The subtitle path {subPath} doesn't exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
								}
							}
						}
					}
				}
				else
				{
					// recurse directories
					string[] aDirs = Directory.GetDirectories(path);

					for (int i = 0; i < aDirs.Length; i++)
					{
						ProcessDirectory(aDirs[i]);
					}
				}
			}
		}

		private void txtPath_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtPath.Text) && Directory.Exists(this.txtPath.Text))
			{
				this.cmdStart.Enabled = true;
			}
			else
			{
				this.cmdStart.Enabled = false;
			}
		}
	}
}