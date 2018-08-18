using System;
using static System.Console;

namespace ProgrammerCoffe
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int codeLinesCount = (int)ParseLong("Enter code lines count or leave empty (10 by default): ", 10);
                int maxCoffeCupCount = (int)ParseLong("Enter max coffe cup count or leave empty (2 by default): ", 2);
                long coffeTime = ParseLong("Enter coffe time or leave empty (in minutes, 10 by default): ", 10);
                long startLineTime = ParseLong("Enter init line time or leave empty (in minutes, 1 by default): ", 1);
                Func<long, long> nextLineTime = x => x == 0 ? startLineTime : x * 2;

                long minTime = long.MaxValue;
                long minTimeCoffeCupCount = 0;
                bool[] minTimeCoffeBreaks = null;
                bool[] coffeBreaks;
                for (int coffeCupCount = 0; coffeCupCount <= maxCoffeCupCount; coffeCupCount++)
                {
                    coffeBreaks = InitCombination(codeLinesCount, coffeCupCount);

                    do
                    {
                        long currentLineTime = 0;
                        long totalTime = 0;
                        for (int j = 0; j < codeLinesCount; j++)
                        {
                            if (coffeBreaks[j])
                            {
                                totalTime += coffeTime;
                                currentLineTime = nextLineTime(0);
                            }
                            else
                            {
                                currentLineTime = nextLineTime(currentLineTime);
                            }
                            totalTime += currentLineTime;
                        }

                        if (totalTime < minTime)
                        {
                            minTime = totalTime;
                            minTimeCoffeCupCount = coffeCupCount;
                            minTimeCoffeBreaks = (bool[])coffeBreaks.Clone();
                        }
                    }
                    while (NextCombination(coffeBreaks));
                }

                WriteLine();
                WriteLine($"Min Time: {minTime}");
                WriteLine($"Min Time Coffe Cup Count: {minTimeCoffeCupCount}");
                Write($"Optimal cup combination: ");
                for (int i = 0; i < minTimeCoffeBreaks.Length; i++)
                    if (minTimeCoffeBreaks[i])
                        Write($"{i + 1} ");
                WriteLine();

                WriteLine();
                Write($"Try again? (Y = yes, Other = exit) ");
            }
            while (ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase));
        }

        private static long ParseLong(string message, long defaultValue)
        {
            bool error = false;
            long value;
            do
            {
                Write(message);
                string input = ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return defaultValue;
                }
                if (!long.TryParse(input, out value))
                {
                    WriteLine("Value is incorrect, please enter again");
                    error = true;
                }
            }
            while (error);

            return value;
        }

        private static bool[] InitCombination(int elementsCount, int count)
        {
            var elements = new bool[elementsCount];
            for (int j = 0; j < count; j++)
                elements[j] = true;
            return elements;
        }

        private static bool NextCombination(bool[] elements)
        {
            int i = elements.Length - 1;
            int restCount = 0;
            while (i >= 0)
            {
                if (elements[i])
                {
                    if (i + 1 != elements.Length && !elements[i + 1])
                    {
                        elements[i] = false;
                        elements[i + 1] = true;
                        for (int j = elements.Length - restCount; j < elements.Length; j++)
                            elements[j] = false;
                        for (int j = 0; j < restCount; j++)
                            elements[i + 2 + j] = true;
                        return true;
                    }
                    else
                    {
                        restCount++;
                    }
                }
                i--;
            }
            return false;
        }
    }
}
