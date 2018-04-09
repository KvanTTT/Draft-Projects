using System.Collections.Generic;
using System.Windows.Forms;
using MouseKeyboardLibrary;
using System;
using System.Threading;
using NLog;

namespace UnderTheCursorTranslatorLibrary
{
	public class InputHookWin : InputHook
	{
		private MouseHook MouseHook_;
		private KeyboardHook KeyboardHook_;

		private Dictionary<MouseButtons, bool> PressedMouseButtons_;
		private Dictionary<Keys, bool> PressedKeyboardKeys_;

		public InputHookWin(InputCombination inputCombination, ProcessFunction imageProcessFunction)
			: base(inputCombination, imageProcessFunction)
		{
			MouseHook_ = new MouseHook();
			KeyboardHook_ = new KeyboardHook();

			MouseHook_.MouseDown += MouseHook_MouseDown;
			MouseHook_.MouseUp += MouseHook_MouseUp;
			KeyboardHook_.KeyDown += KeyboardHook_KeyDown;
			KeyboardHook_.KeyUp += KeyboardHook_KeyUp;

			InputCombination = inputCombination;
			PressedMouseButtons_ = new Dictionary<MouseButtons, bool>();
			PressedKeyboardKeys_ = new Dictionary<Keys, bool>();
			foreach (var button in InputCombination.MouseButtons)
				PressedMouseButtons_.Add(button, false);
			foreach (var key in InputCombination.KeyboardKeys)
				PressedKeyboardKeys_.Add(key, false);

			MouseHook_.Start();
			KeyboardHook_.Start();
		}

		private void MouseHook_MouseDown(object sender, MouseEventArgs e)
		{
			if (PressedMouseButtons_.ContainsKey(e.Button))
			{
				PressedMouseButtons_[e.Button] = true;
				if (CheckCombination())
					ImageProcessFunctionAsync();
			}
		}

		private void MouseHook_MouseUp(object sender, MouseEventArgs e)
		{
			if (PressedMouseButtons_.ContainsKey(e.Button))
				PressedMouseButtons_[e.Button] = false;
		}

		private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
		{
			if (PressedKeyboardKeys_.ContainsKey(e.KeyData))
			{
				PressedKeyboardKeys_[e.KeyData] = true;
				if (CheckCombination())
					ImageProcessFunctionAsync();
			}
		}

		private void KeyboardHook_KeyUp(object sender, KeyEventArgs e)
		{
			if (PressedKeyboardKeys_.ContainsKey(e.KeyData))
				PressedKeyboardKeys_[e.KeyData] = false;
		}

		protected override bool CheckCombination()
		{
			foreach (var button in PressedMouseButtons_)
				if (!button.Value)
					return false;

			foreach (var key in PressedKeyboardKeys_)
				if (!key.Value)
					return false;

			foreach (var key in InputCombination.MouseButtons)
				PressedMouseButtons_[key] = false;
			foreach (var key in InputCombination.KeyboardKeys)
				PressedKeyboardKeys_[key] = false;

			return true;
		}
	}
}
