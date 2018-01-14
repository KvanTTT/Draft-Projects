using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMerger
{
    public partial class frmMain : Form
    {
        class ListBoxItem
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public ListBoxItem(string key, string value)
            {
                Key = key;
                Value = value;
            }

            public override string ToString()
            {
                return Value;
            }
        }

        public frmMain()
        {
            InitializeComponent();
            cmbDirection.SelectedIndex = 0;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (lbFiles.Items.Count == 0)
                return;

            var bitmaps = new List<Bitmap>(lbFiles.Items.Count);
            foreach (var item in lbFiles.Items)
                bitmaps.Add(new Bitmap(((ListBoxItem)item).Key));

            var minSize = bitmaps.First().Size;
            foreach (var bitmap in bitmaps)
            {
                if (bitmap.Width < minSize.Width)
                    minSize.Width = bitmap.Width;
                if (bitmap.Height < minSize.Height)
                    minSize.Height = bitmap.Height;
            }
            for (int i = 0; i < bitmaps.Count; i++)
            {
                if (bitmaps[i].Size != minSize)
                {
                    var newBitmap = new Bitmap(minSize.Width, minSize.Height);
                    using (var graphics = Graphics.FromImage(newBitmap))
                    {
                        graphics.DrawImageUnscaledAndClipped(bitmaps[i], new Rectangle(0, 0, minSize.Width, minSize.Height));
                    }
                    bitmaps[i] = newBitmap;
                    newBitmap.Save("temp.jpg");
                }
            }

            Bitmap resultImage;
            int partsCount;

            if (!cbEveryNStrip.Checked)
                if (cmbDirection.SelectedIndex == 0)
                    resultImage = new Bitmap(minSize.Width * lbFiles.Items.Count, minSize.Height);
                else
                    resultImage = new Bitmap(minSize.Width, minSize.Height * lbFiles.Items.Count);
            else
                resultImage = new Bitmap(minSize.Width, minSize.Height);

            if (cmbDirection.SelectedIndex == 0)
                partsCount = (int)Math.Round(resultImage.Width / nudPixelsWidth.Value);
            else
                partsCount = (int)Math.Round(resultImage.Height / nudPixelsWidth.Value);
            int imageCount = lbFiles.Items.Count;

            using (var graphics = Graphics.FromImage(resultImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.PixelOffsetMode= System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                double partSize; 
                double resultPartSize;
                float notDirSize;
                float floatPartSize;
                if (cmbDirection.SelectedIndex == 0)
                {
                    partSize = (double)resultImage.Width / partsCount;
                    floatPartSize = (int)Math.Round(partSize);
                    resultPartSize = partSize * imageCount;
                    notDirSize = resultImage.Height;
                    for (int i = 0; i < imageCount; i++)
                    {
                        var image = bitmaps[i];
                        for (int j = 0; j < partsCount; j++)
                        {
                            if (!cbEveryNStrip.Checked)
                                graphics.DrawImage(image,
                                    new RectangleF((float)(j * resultPartSize + i * partSize), 0, floatPartSize, notDirSize),
                                    new RectangleF((float)(j * partSize), 0, floatPartSize, notDirSize), GraphicsUnit.Pixel);
                            else
                                graphics.DrawImage(image,
                                    new RectangleF((float)Math.Round(j * resultPartSize + i * partSize), 0, floatPartSize, notDirSize),
                                    new RectangleF((float)Math.Round(j * resultPartSize + i * partSize), 0, floatPartSize, notDirSize), GraphicsUnit.Pixel);
                        }
                    }

                }
                else if (cmbDirection.SelectedIndex == 1)
                {
                    partSize = (double)resultImage.Height / partsCount;
                    floatPartSize = (int)Math.Round(partSize);
                    resultPartSize = partSize * imageCount;
                    notDirSize = resultImage.Width;
                    for (int i = 0; i < imageCount; i++)
                    {
                        var image = bitmaps[i];
                        for (int j = 0; j < partsCount; j++)
                        {
                            if (!cbEveryNStrip.Checked)
                                graphics.DrawImage(image,
                                    new RectangleF(0, (float)(j * resultPartSize + i * partSize), notDirSize, floatPartSize),
                                    new RectangleF(0, (float)(j * partSize), notDirSize, floatPartSize), GraphicsUnit.Pixel);
                            else
                                graphics.DrawImage(image,
                                    new RectangleF(0, (float)(j * resultPartSize + i * partSize), notDirSize, floatPartSize),
                                    new RectangleF(0, (float)(j * resultPartSize + i * partSize), notDirSize, floatPartSize), GraphicsUnit.Pixel);
                        }
                    }
                }
            }

            pbResult.Image = resultImage;
            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = "result.png";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                resultImage.Save(saveDialog.FileName);
            }
        }

        private void btnSelectImages_Click(object sender, EventArgs e)
        {
            if (ofdImages.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Size? size;
                if (lbFiles.Items.Count > 0)
                    size = new Bitmap(((ListBoxItem)lbFiles.Items[0]).Key).Size;
                else
                    size = null;
                foreach (var fileName in ofdImages.FileNames)
                {
                    if (size == null)
                    {
                        size = new Bitmap(fileName).Size;
                        lbFiles.Items.Add(new ListBoxItem(fileName, Path.GetFileName(fileName)));
                    }
                    else //if (size == new Bitmap(fileName).Size)
                        lbFiles.Items.Add(new ListBoxItem(fileName, Path.GetFileName(fileName)));
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {

        }
    }
}
