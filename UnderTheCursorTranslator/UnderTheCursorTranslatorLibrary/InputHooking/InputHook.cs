using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace UnderTheCursorTranslatorLibrary
{
	public abstract class InputHook
	{
		Logger Logger;

		public InputCombination InputCombination
		{
			get;
			protected set;
		}

		public ProcessFunction ImageProcessFunction
		{
			get;
			protected set;
		}

		public InputHook(InputCombination inputCombination, ProcessFunction imageProcessFunction)
		{
			Logger = LogManager.GetCurrentClassLogger();
			InputCombination = inputCombination;
			ImageProcessFunction = imageProcessFunction;
		}

		protected abstract bool CheckCombination();
		
		protected void ImageProcessFunctionAsync()
		{
			var func = new ProcessFunction(ImageProcessFunction);
			func.BeginInvoke(null, null);
			Logger.Trace("Image Processing Function has been invoked");
		}
	}
}
