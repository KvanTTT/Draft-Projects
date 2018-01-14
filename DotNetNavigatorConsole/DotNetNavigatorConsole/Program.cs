using DotNetNavigator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetNavigatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var nav = new SolutionNavigatorRoslyn();
            nav.Compile("asdf");
        }
    }
}
