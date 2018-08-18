using SequencesFollowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTextFollowing
{
    public class TypingTextHmmDataGenerator : IHmmDataGetter
    {
        public double MinProbab = 0; //double.Epsilon;

        public int GhostStatesCount
        {
            get;
            set;
        }

        public string Text
        {
            get;
            private set;
        }

        public TypingTextHmmDataGenerator(string text)
        {
            Text = text;
            GhostStatesCount = 1;
        }

        public HmmData Get()
        {
            var charValues = GenerateCharValues(Text);
            var initial = GenerateInitialProbabs(Text);
            var emissions = GenerateEmissios(Text, charValues);
            var transitions = GenerateStateTransitions(Text);
            HmmData result = new TypingTextHmmData(initial, emissions, transitions, charValues);
            return result;
        }

        private double[,] GenerateStateTransitions(string text)
        {
            int statesCount = text.Length * (GhostStatesCount + 1) + 1;
            var transitions = new double[statesCount, statesCount];

            for (int i = 0; i < statesCount; i++)
            {
                if (i % (GhostStatesCount + 1) == 0)
                {
                    if (i != statesCount - 2)
                    {
                        CheckAndSet(transitions, i, i + 1, 0.45);
                        CheckAndSet(transitions, i, i + 2, 0.1);
                        CheckAndSet(transitions, i, i + 3, 0.45);
                    }
                    else
                    {
                        CheckAndSet(transitions, i, i + 1, 0.5);
                        CheckAndSet(transitions, i + 1, i + 1, 0.5);
                        CheckAndSet(transitions, i - 1, i + 1, 0.98);
                        CheckAndSet(transitions, i - 2, i + 1, 0.45);
                        CheckAndSet(transitions, i - 3, i + 1, 0.01);
                        CheckAndSet(transitions, i - 5, i + 1, 0.01);
                        CheckAndSet(transitions, i - 7, i + 1, 0.01);
                    }
                }
                else
                {
                    if (i != statesCount - 1)
                    {
                        CheckAndSet(transitions, i, i, 0.01);
                        CheckAndSet(transitions, i, i + 1, 0.02);
                        CheckAndSet(transitions, i, i + 2, 0.95);
                        CheckAndSet(transitions, i, i + 4, 0.01);
                        CheckAndSet(transitions, i, i + 6, 0.01);
                        CheckAndSet(transitions, i, i + 8, 0.01);
                    }
                    else
                    {
                        CheckAndSet(transitions, i, i + 1, 0.5);
                        CheckAndSet(transitions, i - 1, i + 1, 0.5);
                        CheckAndSet(transitions, i + 1, i + 1, 1);
                    }
                }
            }

            return transitions;
        }

        private Dictionary<char, int> GenerateCharValues(string text)
        {
            var sortedChars = new SortedSet<char>(text.ToCharArray());
            var chars = new Dictionary<char, int>(sortedChars.Count);
            int charNumber = 0;
            foreach (var c in sortedChars)
                chars.Add(c, charNumber++);
            return chars;
        }

        private double[,] GenerateEmissios(string text, Dictionary<char, int> charValues)
        {
            int statesCount = text.Length * (GhostStatesCount + 1) + 1;
            var emissions = new double[statesCount, charValues.Count];

            double wrongProbab = 1.0 / charValues.Count;
            double[] ghostNotes = new double[] { MinProbab, 0.004, 0.008 };
            double[] stateNotes = new double[] { 1, 0.95, 0.90 };

            int ind = 0;
            foreach (var c in text)
            {
                if (GhostStatesCount >= 1)
                {
                    FillRow(emissions, ind, wrongProbab);
                    emissions[ind, charValues[c]] = GetByIndexOrLast(ghostNotes, 0);
                    ind++;

                    FillRow(emissions, ind, MinProbab);
                    emissions[ind, charValues[c]] = GetByIndexOrLast(stateNotes, 0);
                    ind++;
                }
                else
                {
                    FillRow(emissions, ind, MinProbab);
                    emissions[ind, charValues[c]] = GetByIndexOrLast(stateNotes, 0);

                    ind++;
                }
            }

            FillRow(emissions, ind, 1.0 / charValues.Count);

            return emissions;
        }

        private double[] GenerateInitialProbabs(string text)
        {
            int statesCount = text.Length * (GhostStatesCount + 1) + 1;
            int coef = (GhostStatesCount + 1);
            var initial = new double[statesCount];
            CheckAndSet(initial, 0, 0.1);
            CheckAndSet(initial, 1, 0.75);
            CheckAndSet(initial, 1 + coef, 0.05);
            CheckAndSet(initial, 1 + coef * 2, 0.04);
            CheckAndSet(initial, 1 + coef * 3, 0.03);
            CheckAndSet(initial, 1 + coef * 4, 0.02);
            CheckAndSet(initial, 1 + coef * 5, 0.007);
            CheckAndSet(initial, 1 + coef * 6, 0.003);

            return initial;
        }

        private static void FillRow(double[,] array, int row, double value)
        {
            for (int i = 0; i < array.GetLength(1); i++)
                array[row, i] = value;
        }

        private static double GetByIndexOrLast(double[] array, int index)
        {
            if (index < 0)
                return array[0];
            else if (index >= array.Length)
                return array[array.Length - 1];
            else
                return array[index];
        }

        private static bool CheckAndSet(double[,] array, int i, int j, double value)
        {
            if (i >= 0 && i < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
            {
                array[i, j] = value;
                return true;
            }
            else
                return false;
        }

        private static bool CheckAndSet(double[] array, int i, double value)
        {
            if (i >= 0 && i < array.Length)
            {
                array[i] = value;
                return true;
            }
            else
                return false;
        }
    }
}
