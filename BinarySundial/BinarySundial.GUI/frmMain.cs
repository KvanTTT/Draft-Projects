using BinarySundial.GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BinarySundial.GUI
{
	public partial class frmMain : Form
	{
		const int Dim = 30;

		public frmMain()
		{
			InitializeComponent();

			var bitmap = new Bitmap(360, Dim);
			using (var graphics = Graphics.FromImage(bitmap))
				for (int i = 0; i < bitmap.Width; i++)
				{
					var color = ColorHelper.HsvToRgb(i / 360.0, 1, 1);
					graphics.DrawLine(new Pen(color), i, 0, i, bitmap.Height);
				}
			pbSpectr.Image = bitmap;

			var codingFormatNames = Enum.GetNames(typeof(CodingFormat));
			foreach (var name in codingFormatNames)
				cmbCodingFormat.Items.Add(name);
			cmbCodingFormat.SelectedIndex = 0;

			tbLatitude.Text = Settings.Default.Latitude.ToString();
			tbLongitude.Text = Settings.Default.Longitude.ToString();
			try
			{
				dtpDate.Value = Settings.Default.Date;
			}
			catch
			{
				dtpDate.Value = DateTime.Now;
			}
			nudColorsCount.Value = Settings.Default.ColorsCount;
			tbOffset.Text = Settings.Default.ColorOffset.ToString();
			tbLuminosity.Text = Settings.Default.ColorLuminosity.ToString();

			btnCalculateAltitudeAzimuth_Click(this, null);
			btnGetColors_Click(this, null);
		}

		private void btnGetCurrentLatLng_Click(object sender, EventArgs e)
		{
			var geoInfo = GeoHelper.GetCurrentGetInfo();
			tbLatitude.Text = geoInfo.Latitude.ToString();
			tbLongitude.Text = geoInfo.Longitude.ToString();
		}

		private void btnCalculateAltitudeAzimuth_Click(object sender, EventArgs e)
		{
			var output = new StringBuilder();
			var date = dtpDate.Value;
			var latitude = double.Parse(tbLatitude.Text);
			var longitude = double.Parse(tbLongitude.Text);
			for (int i = 0; i < 24; i++)
			{
				var hourDate = new DateTime(date.Year, date.Month, date.Day, i, 0, 0);
				output.AppendLine("Time: " + hourDate.ToShortTimeString() + "; " + SunHelper.CalculateSunPosition(hourDate, latitude, longitude).ToString());
			}
			tbOutput.Text = output.ToString();
		}

		private void btnGetCurrentDate_Click(object sender, EventArgs e)
		{
			dtpDate.Value = DateTime.Now;
		}

		private void nudColorsCount_ValueChanged(object sender, EventArgs e)
		{
			btnGetColors_Click(sender, e);
		}

		private void tbOffset_TextChanged(object sender, EventArgs e)
		{
			try
			{
				btnGetColors_Click(sender, e);
			}
			catch
			{
			}
		}

		private void tbLuminosity_TextChanged(object sender, EventArgs e)
		{
			try
			{
				btnGetColors_Click(sender, e);
			}
			catch
			{
			}
		}

		private void cmbCodingFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				btnGetColors_Click(sender, e);
			}
			catch
			{
			}
		}

		private void btnGetColors_Click(object sender, EventArgs e)
		{
			var inputColors = ColorHelper.DivideSpectrum((int)nudColorsCount.Value, double.Parse(tbOffset.Text),
				double.Parse(tbLuminosity.Text));
			var bitmap = new Bitmap(Dim * inputColors.Length, Dim);

			var colorsString = new StringBuilder();
			using (var graphics = Graphics.FromImage(bitmap))
			{
				for (int i = 0; i < inputColors.Length; i++)
				{
					var brush = new SolidBrush(inputColors[i]);
					graphics.FillRectangle(brush, i * Dim, 0, Dim, Dim);
					colorsString.AppendLine(inputColors[i].ToString());
				}
			}

			pbColors.Size = new Size(bitmap.Width, bitmap.Height);
			pbColors.Image = bitmap;
			tbColors.Text = colorsString.ToString();

			var resultColors = ColorHelper.GetBlendingColors(inputColors,
				cmbCodingFormat.SelectedItem == null ? CodingFormat.Standart :
				(CodingFormat)Enum.Parse(typeof(CodingFormat), (string)cmbCodingFormat.SelectedItem));
			var resultBitmap = new Bitmap(Dim, Dim * resultColors.Length);
			using (var graphics = Graphics.FromImage(resultBitmap))
			{
				for (int i = 0; i < resultColors.Length; i++)
				{
					var brush = new SolidBrush(resultColors[i]);
					graphics.FillRectangle(brush, 0, i * Dim, Dim, Dim);
					//colorsString.AppendLine(inputColors[i].ToString());
				}
			}

			pbResultColors.Size = new Size(resultBitmap.Width, resultBitmap.Height);
			pbResultColors.Image = resultBitmap;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{

		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				Settings.Default.Latitude = double.Parse(tbLatitude.Text);
				Settings.Default.Longitude = double.Parse(tbLongitude.Text);
				Settings.Default.Date = dtpDate.Value;
				Settings.Default.ColorsCount = (int)nudColorsCount.Value;
				Settings.Default.ColorOffset = double.Parse(tbOffset.Text);
				Settings.Default.ColorLuminosity = double.Parse(tbLuminosity.Text);
				Settings.Default.Save();
			}
			catch
			{
			}
		}
	}
}
