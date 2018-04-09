using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Drawing;

namespace UnderTheCursorTranslatorLibrary
{
	public class TextExtractorUiAutomation : TextExtractor
	{
		AutomationElement Element;

		#region Implementation

		public override void SetPosition(Point position)
		{
			base.SetPosition(position);
			Element = AutomationElement.FromPoint(new System.Windows.Point(Position.X, position.Y));
		}

		public override string NextVariant()
		{
			/*if (CurrentVariantNumber == -1)
			{
				CurrentVariantNumber++;
				if (Element == null)
					return null;
			}

			Element.Current.Name;

			object pattern = null;
			if (Element.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
			{
				ValuePattern valuePattern = (ValuePattern)pattern;
				Console.WriteLine(" Value=" + valuePattern.Current.Value);
			}

			if (Element.TryGetCurrentPattern(TextPattern.Pattern, out pattern))
			{
				TextPattern textPattern = (TextPattern)pattern;
				foreach (var range in textPattern.GetSelection())
					range.GetText(-1);
			}*/

			return string.Empty;
		}
		
		#endregion
	}
}
