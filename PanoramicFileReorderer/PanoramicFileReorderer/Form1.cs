using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PanoramicFileReorderer.Properties;

namespace PanoramicFileReorderer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			if (!string.IsNullOrEmpty(Settings.Default.ProjectPath))
				tbProjectPath.Text = Settings.Default.ProjectPath;
			if (!string.IsNullOrEmpty(Settings.Default.ViewsFolderName))
				tbViewsFolderName.Text = Settings.Default.ViewsFolderName;
			if (!string.IsNullOrEmpty(Settings.Default.GroupsFolderName))
				tbGroupsFolderName.Text = Settings.Default.GroupsFolderName;
			cbMoveSourceToDestination.Checked = Settings.Default.MoveSourceToDestination;
		}

		private int GetFileNumber(string fileName)
		{
			var shortName = Path.GetFileNameWithoutExtension(fileName);
			int i = shortName.Length - 1;
			while (shortName[i] >= '0' && shortName[i] <= '9')
				i--;
			return int.Parse(shortName.Substring(i + 1));
		}

		private void Reorder(string projectPath, string viewsFolderName, string groupsFolderName,
			bool moveSourceToDestination = false)
		{
			if (!Directory.Exists(projectPath))
				throw new Exception("Project path does not exists.");

			var viewsPath = Path.Combine(projectPath, viewsFolderName);
			var groupsPath = Path.Combine(projectPath, groupsFolderName);

			DirectoryInfo[] viewDirectories;
			try
			{
				viewDirectories = new DirectoryInfo(viewsPath).GetDirectories();
			}
			catch
			{
				throw new Exception("Views folder not found.");
			}
			
			int groupsCount = 0;
			int startIndex = int.MaxValue;
			int fileNumber = 0;
			bool unorderedExists = false;
			foreach (var viewDirectory in viewDirectories)
			{
				var files = viewDirectory.GetFiles();
				if (files.Length > groupsCount)
					groupsCount = files.Length;
				foreach (var file in files)
				{
					try
					{
						fileNumber = GetFileNumber(file.FullName);
						if (fileNumber < startIndex)
							startIndex = fileNumber;
					}
					catch
					{
						unorderedExists = true;
					}
				}
			}
			string groupsFormatString;

			try
			{
				groupsFormatString = "".PadLeft((int)Math.Log10(groupsCount + startIndex - 0.5) + 1, '0');
			}
			catch
			{
				throw new Exception("Files to reorder has not been founded.");
			}

			var groupFolderName = groupsFolderName.Substring(groupsFolderName.Length - 3, 3) == "ies" ?
				groupsFolderName.Remove(groupsFolderName.Length - 3) + "y" :
				groupsFolderName[groupsFolderName.Length - 1] == 's' ?
				groupsFolderName.Remove(groupsFolderName.Length - 1) :
				groupsFolderName;
			if (!Directory.Exists(groupsPath))
				Directory.CreateDirectory(groupsPath);
			for (int i = 0; i < groupsCount; i++)
				if (!Directory.Exists(Path.Combine(groupsPath, groupFolderName + "-" + (i + startIndex).ToString(groupsFormatString))))
					Directory.CreateDirectory(Path.Combine(groupsPath, groupFolderName + "-" + (i + startIndex).ToString(groupsFormatString)));
			if (unorderedExists)
				Directory.CreateDirectory(Path.Combine(groupsPath, "Unordered"));

			foreach (var viewDirectory in viewDirectories)
				foreach (var file in viewDirectory.GetFiles())
				{
					try
					{
						fileNumber = GetFileNumber(file.FullName);
					}
					catch
					{
						fileNumber = -1;
					}
					try
					{
						var destinationFileName = fileNumber != -1 ?
							Path.Combine(projectPath, groupsFolderName,
							groupFolderName + "-" + fileNumber.ToString(groupsFormatString), Path.GetFileName(file.FullName)) :
							Path.Combine(projectPath, groupsFolderName, "Unordered", Path.GetFileName(file.FullName));
						if (moveSourceToDestination)
						{
							if (File.Exists(destinationFileName))
								File.Delete(destinationFileName);
							file.MoveTo(destinationFileName);
						}
						else
							file.CopyTo(destinationFileName, true);
					}
					catch
					{
					}
				}

			foreach (var groupDirectory in new DirectoryInfo(groupsPath).GetDirectories())
				if (groupDirectory.GetFiles().Length == 0)
					groupDirectory.Delete();

			if (moveSourceToDestination)
				if (Directory.Exists(viewsPath))
					Directory.Delete(viewsPath, true);
		}

		private void btnReorder_Click(object sender, EventArgs e)
		{
			try
			{
				Reorder(tbProjectPath.Text, tbViewsFolderName.Text, tbGroupsFolderName.Text, cbMoveSourceToDestination.Checked);
				MessageBox.Show("Reordering has been completed!");
			}
			catch (Exception exception)
			{
				MessageBox.Show("An error occurred during reordering: " + exception.Message);
			}
		}

		private void tbProjectPath_Leave(object sender, EventArgs e)
		{
			Settings.Default.ProjectPath = tbProjectPath.Text;
			Settings.Default.ViewsFolderName = tbViewsFolderName.Text;
			Settings.Default.GroupsFolderName = tbGroupsFolderName.Text;
			Settings.Default.MoveSourceToDestination = cbMoveSourceToDestination.Checked;
			Settings.Default.Save();
		}

		private void btnSelectProjectPath_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.SelectedPath = tbProjectPath.Text;
			if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				tbProjectPath.Text = folderBrowserDialog1.SelectedPath;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.ProjectPath = tbProjectPath.Text;
			Settings.Default.ViewsFolderName = tbViewsFolderName.Text;
			Settings.Default.GroupsFolderName = tbGroupsFolderName.Text;
			Settings.Default.MoveSourceToDestination = cbMoveSourceToDestination.Checked;
			Settings.Default.Save();
		}

		private void btnOpenProjectFolder_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(tbProjectPath.Text);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
