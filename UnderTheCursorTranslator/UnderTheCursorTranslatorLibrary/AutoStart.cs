using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace UnderTheCursorTranslatorLibrary
{
	public static class AutoStart
	{
		private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";
		private const string VALUE_NAME = "ScreenPaste";

		public static bool Enabled
		{
			get
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
				if (key == null)
					return false;

				string value = (string)key.GetValue(VALUE_NAME);
				if (value == null)
					return false;
				return (value == System.Reflection.Assembly.GetExecutingAssembly().Location);
			}
			set
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
				if (value)
					key.SetValue(VALUE_NAME, System.Reflection.Assembly.GetExecutingAssembly().Location);
				else
					key.DeleteValue(VALUE_NAME);
			}
		}
	}
}
