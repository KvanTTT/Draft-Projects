using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing.Tests
{
    [TestFixture]
    public class OfflineViterbi
    {
        [Test]
        public void TestProperlyPath()
        {
            var text = File.ReadAllText(@"..\..\..\KeyboardTypeHMM\Data\Отрывок из книги (Глина).txt");
        }
    }
}
