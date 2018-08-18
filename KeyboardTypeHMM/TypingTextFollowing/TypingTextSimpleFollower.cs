using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextSimpleFollower : ITypingTextFollower
    {
        public int Position
        {
            get;
            set;
        }

        public string Text
        {
            get;
            private set;
        }

        public TypingTextSimpleFollower(string text)
        {
            Text = text;
            Position = 0;
        }

        public int[] AddEvent(TypingTextEvent ev)
        {
            return AddEvent(new OnlineEvent((int)ev.Char, ev.Time));
        }

        public int[] AddEvent(OnlineEvent ev)
        {
            int[] result = null;
            if (Position < Text.Length && Text[Position] == ev.Value)
            {
                result = new int[] { Position };
                Position++;
            }
            return result;
        }
    }
}
