using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using UnderTheCursorTranslatorLibrary;

namespace UnderTheCursorTranslatorTests
{
	[TestFixture]
	public class InputCombinationTest
	{
		[Test]
		public void ToStringFromStringTest()
		{
			var combination = new InputCombination(new Keys[] { Keys.Control, Keys.Left, Keys.F2 }, 
				new MouseButtons[] { MouseButtons.Left, MouseButtons.Middle });

			var combinationString = combination.ToString();
			Assert.AreEqual(combinationString, "Keyboard.Control + Keyboard.Left + Keyboard.F2 + Mouse.Left + Mouse.Middle");

			var newCombination = new InputCombination(combinationString);
			Assert.AreEqual(combination, newCombination);
		}
	}
}
