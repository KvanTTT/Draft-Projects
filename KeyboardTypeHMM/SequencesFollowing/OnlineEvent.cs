using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public class OnlineEvent
    {
        public int Value
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }

        public OnlineEvent(int value, DateTime time)
        {
            Value = value;
            Time = time;
        }
    }
}
