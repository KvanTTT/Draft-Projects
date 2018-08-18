using System.Collections.Generic;

namespace RecursionIteration
{
    public class Samples
	{
		public static ulong FactorialRec(ulong n)
		{
			return n == 0 ? 1 : FactorialRec(n - 1) * n;
		}

		public static ulong FactorialRecTail(ulong n)
		{
			return n == 0 ? 1 : n * FactorialRecTail(n - 1);
		}

		public static ulong FactorialIter(ulong n)
		{
			var stack = new List<ulong>();

			var k = n;
			while (k != 0)
			{
				stack.Add(k);
				k = k - 1;
			}
			stack.Add(1);

			var result = stack[stack.Count - 1];
			for (int i = stack.Count - 2; i >= 0; i--)
				result = result * stack[i];

			return result;
		}

		public static ulong FactorialIterOpt(ulong n)
		{
			ulong result = 1;
			for (ulong i = 1; i <= n; i++)
				result = result * i;
			return result;
		}

		public static int FibonacciRecursive(int n)
		{
			if (n == 0) return 0;
			if (n == 1) return 1;

			return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
		}
	}
}
