using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public interface ITypingTextFollower : IFollower
    {
        int[] AddEvent(TypingTextEvent ev);
    }
}
