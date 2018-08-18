using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RecursionIteration;
using System.Diagnostics;

namespace RecursionIteration.Tests
{
	[TestFixture]
	public class FactorialTests
	{
		[Test]
		public void FactorialTest()
		{
			var rec = Samples.FactorialRec(0);
			var iter = Samples.FactorialIter(0);
			Assert.AreEqual(rec, iter);

			rec = Samples.FactorialRec(1);
			iter = Samples.FactorialIter(1);
			Assert.AreEqual(rec, iter);

			rec = Samples.FactorialRec(2);
			iter = Samples.FactorialIter(2);
			Assert.AreEqual(rec, iter);

			rec = Samples.FactorialRec(3);
			iter = Samples.FactorialIter(3);
			Assert.AreEqual(rec, iter);
		}
	}
}
