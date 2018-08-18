using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextHmmWindow : HmmOnline, ITypingTextFollower
    {
        public TypingTextHmmWindow(HmmData data)
            : base(data)
        {
        }

        public int[] AddEvent(TypingTextEvent ev)
        {
            throw new NotImplementedException();
        }
    }
}
