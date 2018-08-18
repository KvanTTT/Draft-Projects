using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextHmmOffline : HmmOffline
    {
        public TypingTextHmmOffline(HmmData data, bool parallel)
            : base(data, parallel)
        {
        }
    }
}
