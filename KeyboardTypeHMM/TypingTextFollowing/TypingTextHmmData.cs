using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextHmmData : HmmData 
    {
        public Dictionary<char, int> CharValues
        {
            get;
            private set;
        }

        public TypingTextHmmData(double[] initial, double[,] emissions, double[,] transitions,
            Dictionary<char, int> charValues)
            : base(initial, emissions, transitions)
        {
            CharValues = charValues;
        }
    }
}
