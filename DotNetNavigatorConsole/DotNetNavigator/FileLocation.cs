using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetNavigator
{
    public class FileLocation
    {
        public string FileName { get; set; }

        public int StartPosition { get; set; }

        public int EndPosition { get; set; }

        public FileLocation(string fileName, int position)
            : this(fileName, position, position)
        {
        }

        public FileLocation(string fileName, int startPosition, int endPosition)
        {
            FileName = fileName;
            StartPosition = startPosition;
            EndPosition = endPosition;
        }

        public FileLocation()
        {
        }
    }
}
