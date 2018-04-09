using System.Windows.Forms;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnderTheCursorTranslatorLibrary
{
	public class InputCombination : IEquatable<InputCombination>
	{
		const string KeyboardKeyPrefix = "Keyboard";
		const string MouseButtonPrefix = "Mouse";

		public MouseButtons[] MouseButtons;
		public Keys[] KeyboardKeys;

		#region Constructors
		
		public InputCombination(string combination)
		{
			var buttonsStrs = combination.Split(new string[] { " + " }, StringSplitOptions.RemoveEmptyEntries);
			List<MouseButtons> mouseButtons = new List<MouseButtons>();
			List<Keys> keyboardKeys = new List<Keys>();
			MouseButtons mouseButton;
			Keys keyboardKey;
			
			foreach (var buttonStr in buttonsStrs)
			{
				var strs = buttonStr.Split('.');
				if (strs[0] == MouseButtonPrefix)
				{
					if (Enum.TryParse<MouseButtons>(strs[1], out mouseButton))
						mouseButtons.Add(mouseButton);
					else
						throw new Exception("Unsupported mouse button");
				}
				else if (strs[0] == KeyboardKeyPrefix)
				{
					if (Enum.TryParse<Keys>(strs[1], out keyboardKey))
						keyboardKeys.Add(keyboardKey);
					else
						throw new Exception("Unsupported keyboard key");
				}
				else
					throw new Exception("Unsupported mouse button or keyboard key");
			}

			MouseButtons = mouseButtons.ToArray();
			KeyboardKeys = keyboardKeys.ToArray();
		}

		public InputCombination(Keys[] keyboardKeys, MouseButtons[] mouseButtons)
		{
			MouseButtons = mouseButtons;
			KeyboardKeys = keyboardKeys;
		}
		
		#endregion

		#region Overrides
		
		public override string ToString()
		{
			var result = new StringBuilder();
			foreach (var key in KeyboardKeys)
				result.AppendFormat("{0}.{1} + ", KeyboardKeyPrefix, key);
			foreach (var button in MouseButtons)
				result.AppendFormat("{0}.{1} + ", MouseButtonPrefix, button);
			if (result.Length != 0)
				result.Remove(result.Length - 3, 3);
			return result.ToString();
		}

		public bool Equals(InputCombination other)
		{
			foreach (var button in MouseButtons)
				if (!other.MouseButtons.Contains(button))
					return false;
			foreach (var key in KeyboardKeys)
				if (!other.KeyboardKeys.Contains(key))
					return false;
			return true;
		}

		#endregion
	}
}
