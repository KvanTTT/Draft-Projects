using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextFollowerFactory
    {
        public static ITypingTextFollower Get(TypingTextFollowerType type, string text)
        {
            switch (type)
            {
                case TypingTextFollowerType.Simple:
                    return new TypingTextSimpleFollower(text);
                case TypingTextFollowerType.HMM:
                    var data = new TypingTextHmmDataGenerator(text);
                    return new TypingTextHmmOnline((TypingTextHmmData)data.Get());
                default:
                    return null;
            }
        }
    }
}
