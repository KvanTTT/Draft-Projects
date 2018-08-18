using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public interface IFollower
    {
        int Position
        {
            get;
            set;
        }

        int[] AddEvent(OnlineEvent ev);
    }
}
