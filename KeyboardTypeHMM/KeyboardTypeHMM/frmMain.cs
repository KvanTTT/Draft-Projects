using SequencesFollowing;
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
using TypingTextFollowing;

namespace KeyboardTypeHMM
{
    public partial class frmMain : Form
    {
        ITypingTextFollower Follower;
        Font Font;
        Font HighlightedFont;
        int LastPos;
        int LastLength;

        public frmMain()
        {
            InitializeComponent();

            Font = new Font(rtbText.Font, FontStyle.Regular);
            HighlightedFont = new Font(rtbText.Font, FontStyle.Bold);

            btnStart_Click(null, null);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnGeneratedHMM_Click(object sender, EventArgs e)
        {
            var generator = new TypingTextHmmDataGenerator(rtbText.Text);
            var data = generator.Get();

            File.WriteAllText("initial.txt", Utils.MatrixToString(data.Initial));
            File.WriteAllText("transitions.txt", Utils.MatrixToString(data.Transitions));
            File.WriteAllText("emissions.txt", Utils.MatrixToString(data.Emissions));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Follower = TypingTextFollowerFactory.Get(
                rbSimple.Checked ? TypingTextFollowerType.Simple : TypingTextFollowerType.HMM,
                rtbText.Text);
            HighlighRichTextBox(0);
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            var sequence = Follower.AddEvent(new TypingTextEvent(e.KeyChar, DateTime.Now));
            if (sequence != null)
            {
                var lastPos = sequence.Last();
                HighlighRichTextBox(lastPos + 1);
            }
        }

        private void HighlighRichTextBox(int position, int length = 1)
        {
            rtbText.Select(LastPos, LastLength);
            rtbText.SelectionColor = Color.Black;
            rtbText.Select(position, length);
            rtbText.SelectionFont = DefaultFont;
            rtbText.SelectionColor = Color.Red;
            rtbText.SelectionFont = HighlightedFont;
            LastPos = position;
            LastLength = length;
        }
    }
}
