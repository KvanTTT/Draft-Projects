using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public class HmmOnlineNode
    {
        public int Position
        {
            get;
            internal set;
        }

        public int State
        {
            get;
            internal set;
        }

        private HmmOnlineNode _parent;
        public HmmOnlineNode Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent != null)
                    --_parent.ChildNumber;
                _parent = value;
                if (_parent != null)
                    ++_parent.ChildNumber;
            }
        }

        public HmmOnlineNode Next
        {
            get;
            internal set;
        }

        public HmmOnlineNode Previous
        {
            get;
            internal set;
        }

        public int ChildNumber
        {
            get;
            internal set;
        }

        public HmmOnlineNode()
        {
            Position = State = -1;
            Parent = Next = Previous = null;
            ChildNumber = 0;
        }

        public static int Write(BiDictionary<HmmOnlineNode, int> map, HashSet<HmmOnlineNode> written, HmmOnlineNode node, BinaryWriter output)
        {
            if (node == null)
            {
                output.Write(false);
                output.Write(-1);
                return -1;
            }
            int index = map[node];
            if (!written.Contains(node))
            {
                output.Write(true);
                output.Write(index);
                output.Write(node.Position);
                output.Write(node.State);
                output.Write(node.ChildNumber);
                written.Add(node);
                Write(map, written, node.Parent, output);
            }
            else
            {
                output.Write(false);
                output.Write(index);
            }

            return index;
        }

        public static HmmOnlineNode Read(BiDictionary<HmmOnlineNode, int> map, BinaryReader input)
        {
            bool first = input.ReadBoolean();
            int index = input.ReadInt32();
            if (first)
            {
                HmmOnlineNode node = new HmmOnlineNode();
                node.Position = input.ReadInt32();
                node.State = input.ReadInt32();
                node.ChildNumber = input.ReadInt32();
                map.Add(node, index);
                node.Parent = Read(map, input);
                return node;
            }
            if (index == -1)
                return null;

            return map.Reverse[index];
        }


        public override bool Equals(object obj)
        {
            if (obj is HmmOnlineNode)
            {
                var node = (HmmOnlineNode)obj;
                return (Position == node.Position) && 
                    (State == node.State) && 
                    (ChildNumber == node.ChildNumber) &&
                    (Parent != null ? Parent.Equals(Parent) : node.Parent == null);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)((long)Position + State + ChildNumber + Convert.ToInt64(Parent != null ? Parent.Equals(Parent) : Parent == null));
        }
    }
}
