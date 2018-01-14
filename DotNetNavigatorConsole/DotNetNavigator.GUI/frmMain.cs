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

namespace DotNetNavigator.GUI
{
    public partial class frmMain : Form
    {
        string SelectedFile;
        ISolutionNavigator Navigator;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOpenSolution_Click(object sender, EventArgs e)
        {
            tvFiles.Nodes.Clear();
            tbCode.Clear();
            tbFileName.Clear();
            
            Navigator = new SolutionNavigatorRoslyn();
            Navigator.Compile(tbSolutionPath.Text);

            var sourceFiles = Navigator.GetSourceFiles();
            foreach (var file in sourceFiles)
                tvFiles.Nodes.Add(file, Path.GetFileName(file));
        }

        private void tvFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFile(tvFiles.SelectedNode.Name);
        }

        private void tbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                var region = Navigator.GoToDefinition(new FileLocation(SelectedFile, tbCode.SelectionStart));

                if (region != null)
                {
                    if (region.FileName != SelectedFile)
                        OpenFile(region.FileName);
                    tbCode.Select(region.StartPosition, region.EndPosition - region.StartPosition);
                    tbCode.ScrollToCaret();
                }
            }
        }

        private void OpenFile(string fileName)
        {
            SelectedFile = fileName;
            tbFileName.Text = Path.GetFileName(SelectedFile);
            tbCode.Text = File.ReadAllText(SelectedFile);
        }

        private void btnExploreSolution_Click(object sender, EventArgs e)
        {
            if (ofdSolution.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbSolutionPath.Text = ofdSolution.FileName;
                btnOpenSolution_Click(sender, e);
            }
        }
    }
}
