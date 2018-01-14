using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using AutocorrelationFreqDetector.Properties;
using ZedGraph;

namespace AutocorrelationFreqDetector
{
    public partial class frmMain : Form
    {
        double[] TimeData;
        double[] Breath1Data;
        double[] Breath2Data;

        double TimeDelta;
        PointPairList Breath1PointPairList;
        PointPairList Breath2PointPairList;
        double[] Breath1Autocorrel;
        double[] Breath2Autocorrel;
        PointPairList Breath1AutocorrelPointPairList;
        PointPairList Breath2AutocorrelPointPairList;
        List<int> Breath1MaxIndiciesOfMax;
        List<int> Breath2MaxIndiciesOfMax;

        public frmMain()
        {
            InitializeComponent();

            tbDataPath.Text = Settings.Default.DataFolderPath;
            cbBreath1.Checked = Settings.Default.ShowBreath1Graph;
            cbBreath2.Checked = Settings.Default.ShowBreath2Graph;
        }

        private void tbDataPath_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.DataFolderPath = tbDataPath.Text;
            Settings.Default.Save();
        }

        private void cbBreath1_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideGrahps();

            Settings.Default.ShowBreath1Graph = cbBreath1.Checked;
            Settings.Default.Save();
        }

        private void cbBreath2_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideGrahps();

            Settings.Default.ShowBreath2Graph = cbBreath2.Checked;
            Settings.Default.Save();
        }

        private void btnSelectDataFile_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbDataPath.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tbDataPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!GetBreathData())
                return;

            TimeDelta = TimeData[1] - TimeData[0];

            Breath1PointPairList = new PointPairList(TimeData, Breath1Data);
            Breath2PointPairList = new PointPairList(TimeData, Breath2Data);
            Breath1Autocorrel = AutocorrelationAlgorithm.GetAutocorrelation2(Breath1Data);
            Breath2Autocorrel = AutocorrelationAlgorithm.GetAutocorrelation2(Breath2Data);
            AutocorrelationAlgorithm.Normalize(Breath1Autocorrel);
            AutocorrelationAlgorithm.Normalize(Breath2Autocorrel);
            Breath1AutocorrelPointPairList = new PointPairList(TimeData, Breath1Autocorrel);
            Breath2AutocorrelPointPairList = new PointPairList(TimeData, Breath2Autocorrel);
            Breath1MaxIndiciesOfMax = AutocorrelationAlgorithm.IndiciesOfMax(Breath1Autocorrel);
            Breath2MaxIndiciesOfMax = AutocorrelationAlgorithm.IndiciesOfMax(Breath2Autocorrel);

            double period1 = Breath1MaxIndiciesOfMax[1] * TimeDelta;
            double period2 = Breath2MaxIndiciesOfMax[1] * TimeDelta;

            tbBreath1Period.Text = string.Format("Period: {0} [сек], Freq: {1} [мОм/сек]", period1.ToString("0.0000"), (1.0 / period1).ToString("0.0000"));
            tbBreath2Period.Text = string.Format("Period: {0} [сек], Freq: {1} [мОм/сек]", period2.ToString("0.0000"), (1.0 / period2).ToString("0.0000"));

            ShowHideGrahps();
        }

        private bool GetBreathData()
        {
            var timeData = new List<double>();
            var breath1Data = new List<double>();
            var breath2Data = new List<double>();

            string[] dataFiles;
            try
            {
                dataFiles = Directory.GetFiles(tbDataPath.Text, "*.xlsx");
            }
            catch
            {
                MessageBox.Show("Empty or wrong xlsx data folder path!");
                return false;
            }

            foreach (var fileName in dataFiles)
            {
                try
                {
                    SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false);
                    var sheets = document.WorkbookPart.Workbook.Descendants<Sheet>();
                    WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheets.First().Id);

                    List<double> data;

                    data = GetColumn(worksheetPart.Worksheet, "A", 3)
                        .Select(cell => double.Parse(cell.InnerText, CultureInfo.InvariantCulture)).ToList();
                    timeData.AddRange(data);

                    data = GetColumn(worksheetPart.Worksheet, "D", 3)
                        .Select(cell => double.Parse(cell.InnerText, CultureInfo.InvariantCulture)).ToList();
                    breath1Data.AddRange(data);

                    data = GetColumn(worksheetPart.Worksheet, "M", 3)
                        .Select(cell => double.Parse(cell.InnerText, CultureInfo.InvariantCulture)).ToList();
                    breath2Data.AddRange(data);
                }
                catch (Exception e)
                {
                    MessageBox.Show(fileName + " processing error: " + Environment.NewLine + e.Message);
                    return false;
                }
            }

            TimeData = timeData.ToArray();
            Breath1Data = breath1Data.ToArray();
            Breath2Data = breath2Data.ToArray();

            return true;
        }

        private void ShowHideGrahps()
        {
            var breathGraphPane = graphBreath.GraphPane;
            breathGraphPane.CurveList.Clear();
            breathGraphPane.Title.Text = "Breath";
            breathGraphPane.XAxis.Title.Text = "t (сек)";
            breathGraphPane.YAxis.Title.Text = "мОм";

            var breathAutocorrelGraphPane = graphAutocorrelation.GraphPane;
            breathAutocorrelGraphPane.CurveList.Clear();
            breathAutocorrelGraphPane.Title.Text = "Autocorrelation";
            breathAutocorrelGraphPane.XAxis.Title.Text = "t (сек)";
            breathAutocorrelGraphPane.YAxis.Title.Text = "мОм";

            breathGraphPane.GraphObjList.Clear();
            breathAutocorrelGraphPane.GraphObjList.Clear();

            double x;
            LineObj line;

            if (cbBreath1.Checked && Breath1MaxIndiciesOfMax != null)
            {
                breathGraphPane.AddCurve("breath 1", Breath1PointPairList, System.Drawing.Color.OrangeRed, SymbolType.None);
                breathAutocorrelGraphPane.AddCurve("breath 1", Breath1AutocorrelPointPairList, System.Drawing.Color.OrangeRed, SymbolType.None);

                x = Breath1MaxIndiciesOfMax[1] * TimeDelta;
                line = new LineObj(System.Drawing.Color.OrangeRed, x, Breath1Data.Min(), x, Breath1Data.Max());
                line.Location.CoordinateFrame = CoordType.AxisXYScale;
                breathGraphPane.GraphObjList.Add(line);

                line = new LineObj(System.Drawing.Color.OrangeRed, x, Breath1Autocorrel.Min(), x, Breath1Autocorrel.Max());
                line.Location.CoordinateFrame = CoordType.AxisXYScale;
                breathAutocorrelGraphPane.GraphObjList.Add(line);
            }
            if (cbBreath2.Checked && Breath2MaxIndiciesOfMax != null)
            {
                breathGraphPane.AddCurve("breath 2", Breath2PointPairList, System.Drawing.Color.SteelBlue, SymbolType.None);
                breathAutocorrelGraphPane.AddCurve("breath 2", Breath2AutocorrelPointPairList, System.Drawing.Color.SteelBlue, SymbolType.None);

                x = Breath2MaxIndiciesOfMax[1] * TimeDelta;
                line = new LineObj(System.Drawing.Color.SteelBlue, x, Breath2Data.Min(), x, Breath2Data.Max());
                line.Location.CoordinateFrame = CoordType.AxisXYScale;
                breathGraphPane.GraphObjList.Add(line);

                line = new LineObj(System.Drawing.Color.SteelBlue, x, Breath2Autocorrel.Min(), x, Breath2Autocorrel.Max());
                line.Location.CoordinateFrame = CoordType.AxisXYScale;
                breathAutocorrelGraphPane.GraphObjList.Add(line);
            }

            graphBreath.AxisChange();
            graphBreath.Refresh();
            graphAutocorrelation.AxisChange();
            graphAutocorrelation.Refresh();
        }

        private static IEnumerable<Cell> GetColumn(Worksheet worksheet, string columnName, int skipCount)
        {
            return worksheet
                .GetFirstChild<SheetData>()
                .Elements<Row>()
                .Select(rows =>
                {
                    var column = rows.Elements<Cell>()
                        .Where(c => c.CellReference.Value.Contains(columnName));
                    if (column.Count() > 0)
                        return column.First();
                    else
                        return new Cell();
                }).Skip(skipCount);
        }
    }
}
