using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextHmmOnline : HmmOnline, ITypingTextFollower
    {
        public TypingTextHmmData TextHmmData
        {
            get;
            private set;
        }

        public TypingTextHmmOnline(TypingTextHmmData data)
            : base(data)
        {
            TextHmmData = data;
        }

        public int[] AddEvent(TypingTextEvent ev)
        {
            return AddEvent(new OnlineEvent(TextHmmData.CharValues[ev.Char], ev.Time));
        }
    }
}
