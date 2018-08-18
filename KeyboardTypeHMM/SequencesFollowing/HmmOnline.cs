using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public class HmmOnline : Hmm, IFollower
    {
        private double[] _probs;
        private HmmOnlineNode[] _leaves;
        private List<int[]> _backpointers = new List<int[]>();
        private Action<int[]> _output;

        public int Position
        {
            get;
            set;
        }

        public HmmOnlineNode Root
        {
            get;
            private set;
        }

        public HmmOnlineTree Tree
        {
            get;
            private set;
        }

        public double LastLikelihood
        {
            get;
            private set;
        }

        public HmmOnline(HmmData data)
            : base(data)
        {
        }

        public HmmOnline(HmmData data, Action<int[]> output)
            : base(data)
        {
            _output = output;
        }

        public int[] AddEvent(OnlineEvent ev)
        {
            int[] result = null;
            if (Position == 0)
            {
                Clear();
                _probs = GetInitialProbabilities(HmmData, ev.Value);
                Position = 1;
            }
            else
            {
                var observation = ev.Value;
                double[] newProbs = new double[HmmData.HiddenStatesCount];
                int[] optimalStates = new int[HmmData.HiddenStatesCount];
                var newLeaves = new HmmOnlineNode[HmmData.HiddenStatesCount];
                for (int k = 0; k < HmmData.HiddenStatesCount; ++k)
                {
                    int maxState = -1;
                    double maxProb = Double.MinValue;
                    for (int t = 0; t < HmmData.HiddenStatesCount; ++t)
                    {
                        double currentProb = GetTransitionProbability(HmmData, k, t) + _probs[t];
                        if (maxProb < currentProb)
                        {
                            maxProb = currentProb;
                            maxState = t;
                        }
                    }
                    optimalStates[k] = maxState;
                    newProbs[k] = maxProb + GetEmissionProbability(HmmData, ev.Value, k);

                    var node = new HmmOnlineNode();
                    node.Position = Position;
                    node.State = k;
                    node.Parent = _leaves[maxState];
                    newLeaves[k] = node;
                }
                _backpointers.Add(optimalStates);

                Tree.Compress();
                var newRoot = Tree.Root;
                if (Root != newRoot && newRoot != null)
                {
                    LastLikelihood = newProbs[newRoot.State];
                    result = Traceback(Position - newRoot.Position - 1, newRoot.State, false);
                    _leaves = newLeaves;
                    Root = newRoot;
                }

                foreach (var leave in newLeaves)
                    Tree.AddLast(leave);
                _probs = newProbs;
                ++Position;
            }

            return result;
        }

        private void Clear()
        {
            _probs = null;
            Tree = new HmmOnlineTree();
            _leaves = new HmmOnlineNode[HmmData.HiddenStatesCount];
            Root = null;
            for (int i = 0; i < HmmData.HiddenStatesCount; ++i)
            {
                var node = new HmmOnlineNode();
                node.Position = 0;
                node.State = i;
                Tree.AddLast(node);
                _leaves[i] = node;
            }

            _backpointers = new List<int[]>();
            Position = 0;

            LastLikelihood = Double.MinValue;
        }

        /**
       * Forces the decoding of hidden variables using the last observed variable as the end of sequence.
       * Also resets the algorithm state which could be used for decoding again after calling this method
       * @return log-likelihood of last decoded hidden variable
       */
        public int[] Finish(out double logLikehood)
        {
            int maxState = 0;
            for (int k = 1; k < _probs.Length; ++k)
            {
                if (_probs[k] > _probs[maxState])
                    maxState = k;
            }

            var result = Traceback(_backpointers.Count, maxState, true);

            logLikehood = _probs[maxState];
            Position = 0;

            return result;
        }

        private int[] Traceback(int i, int state, bool last)
        {
            int[] result = new int[i + 1];
            result[i] = state;
            if (!last)
                _backpointers.RemoveAt(i);
            --i;
            while (i >= 0)
            {
                int[] optimalStates = _backpointers[i];
                _backpointers.RemoveAt(i);
                result[i] = optimalStates[result[i + 1]];
                --i;
            }

            if (_output != null)
                _output(result);

            return result;
        }

        static int MapNode(BiDictionary<HmmOnlineNode, int> map, HmmOnlineNode node)
        {
            if (node == null)
                return -1;
            int value;
            if (!map.TryGetValue(node, out value))
            {
                value = map.Count;
                map.Add(node, value);
                return value;
            }
            return value;
        }

        public void Write(BinaryWriter output)
        {
            output.Write(_probs.Length);
            foreach (var p in _probs)
                output.Write(p);

            output.Write(_backpointers.Count);
            output.Write(_leaves.Length);
            foreach (var optimalStates in _backpointers)
            {
                foreach (var state in optimalStates)
                {
                    output.Write(state);
                }
            }

            output.Write(Position);
            output.Write(LastLikelihood);

            //serializing compressed backpointers tree
            //3 * |H| - 2 is the upper bound of node number
            var nodeMap = new BiDictionary<HmmOnlineNode, int>(); // 3 * leaves.length - 2;

            var node = Tree.First;
            while (node != null)
            {
                MapNode(nodeMap, node);
                node = node.Next;
            }

            MapNode(nodeMap, Root);
            foreach (var leave in _leaves)
                MapNode(nodeMap, leave);

            var alreadyWritten = new HashSet<HmmOnlineNode>();

            output.Write(nodeMap.Count);
            foreach (var entry in nodeMap.Keys)
                HmmOnlineNode.Write(nodeMap, alreadyWritten, entry, output);

            output.Write(Tree.Size);
            node = Tree.First;
            while (node != null)
            {
                HmmOnlineNode.Write(nodeMap, alreadyWritten, node, output);
                node = node.Next;
            }

            HmmOnlineNode.Write(nodeMap, alreadyWritten, Root, output);

            foreach (var leave in _leaves)
                HmmOnlineNode.Write(nodeMap, alreadyWritten, leave, output);
        }

        public void ReadFields(BinaryReader input)
        {
            var probsLength = input.ReadInt32();
            _probs = new double[probsLength];
            for (int i = 0; i < probsLength; i++)
                _probs[i] = input.ReadDouble();

            _backpointers = new List<int[]>();
            int backpointersSize = input.ReadInt32();
            int stateNumber = input.ReadInt32();
            for (int i = 0; i < backpointersSize; ++i)
            {
                int[] optimalStates = new int[stateNumber];
                for (int j = 0; j < optimalStates.Length; ++j)
                    optimalStates[j] = input.ReadInt32();
                _backpointers.Add(optimalStates);
            }

            Position = input.ReadInt32();
            LastLikelihood = input.ReadDouble();

            int mapSize = input.ReadInt32();
            var nodeMap = new BiDictionary<HmmOnlineNode, int>(); // HashBiMap.create(mapSize);
            for (int i = 0; i < mapSize; ++i)
                HmmOnlineNode.Read(nodeMap, input);

            Tree = new HmmOnlineTree();
            int treeSize = input.ReadInt32();
            for (int i = 0; i < treeSize; ++i)
                Tree.AddLast(HmmOnlineNode.Read(nodeMap, input));

            Root = HmmOnlineNode.Read(nodeMap, input);

            _leaves = new HmmOnlineNode[stateNumber];
            for (int i = 0; i < _leaves.Length; ++i)
                _leaves[i] = HmmOnlineNode.Read(nodeMap, input);
        }

        public PosBeat GetPosBeat()
        {
            throw new NotSupportedException();
        }

        private static double GetTransitionProbability(HmmData model, int i, int j)
        {
            return Math.Log(model.Transitions[j, i] + Double.Epsilon);
        }

        private static double GetEmissionProbability(HmmData model, int o, int h)
        {
            return Math.Log(model.Transitions[h, o] + Double.Epsilon);
        }

        private static double[] GetInitialProbabilities(HmmData model, int startObservation)
        {
            double[] probs = new double[model.HiddenStatesCount];
            for (int h = 0; h < probs.Length; ++h)
                probs[h] = Math.Log(model.Initial[h] + Double.Epsilon) + Math.Log(model.Emissions[h, startObservation]);
            return probs;
        }
    }
}
