using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public class HmmOffline : Hmm, ISynchronizer
    {
        public bool Parallel
        {
            get;
            private set;
        }

        public double LogLikelihood
        {
            get;
            private set;
        }

        public HmmOffline(HmmData data, bool parallel)
            : base(data)
        {
            Parallel = parallel;
        }

        public int[] SyncEvent(List<OnlineEvent> events)
        {
            int[] hmmObservations = events.Select(ev => ev.Value).ToArray();

            int observsCount = hmmObservations.Length;
            int statesCount = HmmData.HiddenStatesCount;

            int[,] forwardStates = new int[statesCount, observsCount];
            double[,] forwardLogs = new double[statesCount, observsCount];

            for (int i = 0; i < statesCount; i++)
                forwardLogs[i, 0] = HmmData.InitialLogs[i] + HmmData.EmissionsLogs[i, hmmObservations[0]];

            for (int k = 1; k < observsCount; k++)
            {
                if (Parallel)
                {
                    System.Threading.Tasks.Parallel.For(0, statesCount, j =>
                    {
                        DecodePart(forwardLogs, forwardStates, hmmObservations, k, j);
                    });
                }
                else
                {
                    for (int j = 0; j < statesCount; j++)
                    {
                        DecodePart(forwardLogs, forwardStates, hmmObservations, k, j);
                    }
                }
            }

            int maxState = 0;
            double maxWeight = forwardLogs[0, observsCount - 1];

            for (int i = 1; i < statesCount; i++)
            {
                if (forwardLogs[i, observsCount - 1] > maxWeight)
                {
                    maxState = i;
                    maxWeight = forwardLogs[i, observsCount - 1];
                }
            }

            int[] path = new int[observsCount];
            path[observsCount - 1] = maxState;

            for (int t = observsCount - 2; t >= 0; t--)
                path[t] = forwardStates[path[t + 1], t + 1];

            LogLikelihood = maxWeight;

            return path;
        }

        private void DecodePart(double[,] forwardLogs, int[,] forwardStates, int[] hmmObservations, int k, int j)
        {
            int maxState = 0;
            var transLogs = HmmData.TransitionsLogs;
            double maxWeight = forwardLogs[0, k - 1] + transLogs[0, j];
            for (int i = 1; i < forwardLogs.GetLength(0); i++)
            {
                double weight = forwardLogs[i, k - 1] + transLogs[i, j];
                if (weight > maxWeight)
                {
                    maxState = i;
                    maxWeight = weight;
                }
            }
            forwardLogs[j, k] = maxWeight + HmmData.EmissionsLogs[j, hmmObservations[k]];
            forwardStates[j, k] = maxState;
        }

        private double[,] Forward(int[] observations, out double[] c)
        {
            int statesCount = HmmData.Transitions.GetLength(0);
            int observsCount = observations.Length;

            double[,] fwd = new double[observsCount, statesCount];
            c = new double[observsCount];

            for (int i = 0; i < statesCount; i++)
            {
                fwd[0, i] = HmmData.Initial[i] * HmmData.Emissions[i, observations[0]];
                c[0] += fwd[0, i];
            }

            if (c[0] != 0)
            {
                for (int i = 0; i < statesCount; i++)
                    fwd[0, i] = fwd[0, i] / c[0];
            }

            for (int t = 1; t < observsCount; t++)
            {
                for (int i = 0; i < statesCount; i++)
                {
                    double p = HmmData.Emissions[i, observations[t]];

                    double sum = 0.0;
                    for (int j = 0; j < statesCount; j++)
                        sum += fwd[t - 1, j] * HmmData.Transitions[j, i];
                    fwd[t, i] = sum * p;

                    c[t] += fwd[t, i];
                }

                if (c[t] != 0)
                {
                    for (int i = 0; i < statesCount; i++)
                        fwd[t, i] = fwd[t, i] / c[t];
                }
            }

            return fwd;
        }

        private double[,] Backward(int[] observations, double[] c)
        {
            int statesCount = HmmData.Transitions.GetLength(0);
            int observsCount = observations.Length;

            double[,] bwd = new double[observations.Length, statesCount];

            for (int i = 0; i < statesCount; i++)
                bwd[0, i] = HmmData.Initial[i] * HmmData.Emissions[i, observations[0]];
            
            for (int i = 0; i < statesCount; i++)
                bwd[observsCount - 1, i] = 1.0 / c[observsCount - 1];

            for (int t = observsCount - 2; t >= 0; t--)
            {
                for (int i = 0; i < statesCount; i++)
                {
                    double sum = 0.0;
                    for (int j = 0; j < statesCount; j++)
                        sum += bwd[t + 1, j] * HmmData.Transitions[i, j] * HmmData.Emissions[j, observations[t + 1]];
                    bwd[t, i] += sum / c[t];
                }
            }

            return bwd;
        }
    }
}
