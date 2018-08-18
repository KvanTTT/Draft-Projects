using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public abstract class Hmm
    {
        public HmmData HmmData
        {
            get;
            protected set;
        }

        public Hmm(HmmData data)
        {
            HmmData = data;
        }
    }
}
