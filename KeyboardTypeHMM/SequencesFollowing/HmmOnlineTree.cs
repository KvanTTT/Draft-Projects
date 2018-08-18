using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public class HmmOnlineTree
    {
        public HmmOnlineNode First
        {
            get;
            private set;
        }

        public HmmOnlineNode Last
        {
            get;
            private set;
        }

        public HmmOnlineNode Root
        {
            get
            {
                var node = First;
                while (node != null && node.ChildNumber < 2)
                    node = node.Next;
                return node;
            }
        }

        public int Size
        {
            get;
            private set;
        }

        public HmmOnlineTree()
        {
            First = null;
            Size = 0;
        }

        public void AddLast(HmmOnlineNode node)
        {
            if (First == null)
                First = node;
            if (Last != null)
                Last.Next = node;
            node.Next = null;
            node.Previous = Last;
            Last = node;
            ++Size;
        }

        public void Remove(HmmOnlineNode node)
        {
            if (node.Previous != null)
                node.Previous.Next = node.Next;
            if (node.Next != null)
                node.Next.Previous = node.Previous;

            if (First == node)
                First = First.Next;
            if (Last == node)
                Last = Last.Previous;

            --Size;
        }

        public void Compress()
        {
            var node = First;
            while (node != null)
            {
                if (node.ChildNumber < 1)
                {
                    if (node.Parent != null)
                    {
                        --node.Parent.ChildNumber;
                    }
                    Remove(node);
                }
                else
                {
                    while (node.Parent != null && node.Parent.ChildNumber == 1)
                    {
                        Remove(node.Parent);
                        node.Parent = node.Parent.Parent;
                    }
                }
                node = node.Next;
            }
        }
    }
}
