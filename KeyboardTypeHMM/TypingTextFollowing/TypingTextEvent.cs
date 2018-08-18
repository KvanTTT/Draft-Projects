using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextEvent
    {
        public char Char
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }

        public TypingTextEvent(char c, DateTime time)
        {
            Char = c;
            Time = time;
        }

        public OnlineEvent ToOnlineEvent()
        {
            return new OnlineEvent((int)Char, Time);
        }
    }
}