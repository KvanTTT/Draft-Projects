using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

using UnderTheCursorTranslatorLibrary;

namespace UnderTheCursorTranslator
{
	public partial class frmMain : Form
	{
		GeneralProcessor Processor;
		Settings Settings;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			Settings = LoadSettings();
			Processor = new GeneralProcessor(Settings);
			Processor.ProcessTranslation += ProcessTranslationEvent;
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			notifyIcon.BalloonTipTitle = "Under the cursor image translator";

			if (FormWindowState.Minimized == WindowState)
			{
				notifyIcon.Visible = true;
				notifyIcon.ShowBalloonTip(500);
				Hide();
			}
			else if (FormWindowState.Normal == WindowState)
			{
				notifyIcon.Visible = false;
			}
		}

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
		}

		private void tbInput_TextChanged(object sender, EventArgs e)
		{
			Translate();
		}

		private void btnTranslate_Click(object sender, EventArgs e)
		{
			Translate();
		}

		private void Translate()
		{
			var translation = Processor.TextTranslators[0].Translate(tbInput.Text);
			if (translation != null)
				tbTranslation.Text = translation.Translation;
			else
				tbTranslation.Text = string.Empty;
		}

		TranscriptionTranslation oldTranslation;

		private void ProcessTranslationEvent(IList<TranscriptionTranslation> transcriptionTranslations)
		{
			foreach (var transcriptionTranslation in transcriptionTranslations)
			{
				notifyIcon.ShowBalloonTip(4000,
					transcriptionTranslation.Word +
						(!string.IsNullOrEmpty(transcriptionTranslation.Transcription) ?
						(" - " + transcriptionTranslation.Transcription) : string.Empty),
						transcriptionTranslation.Translation, ToolTipIcon.Info);
				oldTranslation = transcriptionTranslation;
			}
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			var frmSettings = new frmSettings();
			frmSettings.ShowDialog();
		}

		private Settings LoadSettings()
		{
			var settings = new Settings();
			settings.InputCombination = new InputCombination(
				UnderTheCursorTranslator.Properties.Settings.Default.InputCombination);
			settings.AffixDictionaryFileName = UnderTheCursorTranslator.Properties.Settings.Default.AffixDictionaryFileName;
			settings.DictionariesFileNames = new DictionariesFileNames(
				UnderTheCursorTranslator.Properties.Settings.Default.DictionariesFileNames);
			return settings;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var dic = new WordTranslatorXdxf();
			dic.LoadFromXdxf("Dictionaries\\eng-rus.xdxf");
			dic.Save("Dictionaries\\eng-rus.bin");
			dic = new WordTranslatorXdxf("Dictionaries\\eng-rus.bin");
		}
	}
}
