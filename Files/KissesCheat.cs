using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace KissesCheat
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			tbBluredImageURL_TextChanged(sender, e);
		}

		private void tbBluredImageURL_TextChanged(object sender, EventArgs e)
		{
			string url = tbBluredImageURL.Text;
			string fileName = Path.GetFileNameWithoutExtension(url);
			string bigFileName = fileName.Replace("sml", "big");

			string filePath = url.Remove(url.LastIndexOf('/') + 1);

			string curUrl = null;
			for (int i = 0; i < 16; i++)
			{
				using (var webClient = new WebClient())
				{
					try
					{
						curUrl = filePath + bigFileName + i.ToString("X") + ".jpg";
						byte[] data = webClient.DownloadData(curUrl);
						using (var stream = new MemoryStream(data))
						{
							Bitmap bitmap = new Bitmap(stream);
							pbImage.Image = bitmap;
							pbImage.Invalidate();

							tbBigImageURL.Text = curUrl;
							break;
						}
					}
					catch
					{
						curUrl = null;
					}
				}
			}

			if (curUrl == null)
			{
				tbBigImageURL.Text = null;
				pbImage.Image = null;
				pbImage.Invalidate();
			}
		}
	}
}
