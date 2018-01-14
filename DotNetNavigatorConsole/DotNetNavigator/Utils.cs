using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetNavigator
{
    public class Utils
    {
        public static int GetPosFromLineColumn(string text, int line, int column)
        {
            var strs = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var result = strs.Take(line - 1).Aggregate(0, (count, str) => count += str.Length + Environment.NewLine.Length) + column - 1;
            if (result < 0)
                result = 0;
            return result;
        } 
    }
}
