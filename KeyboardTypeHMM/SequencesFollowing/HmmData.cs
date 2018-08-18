using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public class HmmData
    {
        private double[] _initialLogs = null;
        private double[,] _emissionsLogs = null;
        private double[,] _transitionsLogs = null;

        public HmmData(double[] initial, double[,] emissions, double[,] transitions)
        {
            Initial = initial;
            Emissions = emissions;
            Transitions = transitions;
            HiddenStatesCount = transitions.GetLength(0);
            OutputStatesCount = emissions.GetLength(1);
        }

        public double[] Initial
        {
            get;
            protected set;
        }

        public double[,] Emissions
        {
            get;
            protected set;
        }

        public double[,] Transitions
        {
            get;
            protected set;
        }

        public double[] InitialLogs
        {
            get
            {
                if (_initialLogs == null)
                    _initialLogs = Utils.Log(Initial);
                return _initialLogs;
            }
        }

        public double[,] EmissionsLogs
        {
            get
            {
                if (_emissionsLogs == null)
                    _emissionsLogs = Utils.Log(Emissions);
                return _emissionsLogs;
            }
        }

        public double[,] TransitionsLogs
        {
            get
            {
                if (_transitionsLogs == null)
                    _transitionsLogs = Utils.Log(Transitions);
                return _transitionsLogs;
            }
        }

        public int HiddenStatesCount
        {
            get;
            private set;
        }

        public int OutputStatesCount
        {
            get;
            private set;
        }
    }
}
