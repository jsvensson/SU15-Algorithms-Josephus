using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josephus
{
    class CircularList<T> : IEnumerable<T>
    {
        public Node<T> First { get; private set; }
        public Node<T> Last { get; private set; }
        public Node<T> Current { get; private set; }
        public int Count { get; private set; }

        public void Add(T value)
        {
            // Empty list, insert first node
            if (First == null)
            {
                First = new Node<T> { Value = value };
                Count++;
                First.Next = First;
                First.Previous = First;
                Last = First;
                Current = First;
                return;
            }

            // Non-empty list, add to end of list
            Last.Next = new Node<T>
            {
                Value = value,
                Next = First,
                Previous = Last
            };
            Count++;
            Last = Last.Next;
            First.Previous = Last;
        }

        public void Step()
        {
            Current = Current.Next;
        }

        public void Step(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                Step();
            }
        }

        public void RemoveCurrent()
        {
            var nextNode = Current.Next;
            var prevNode = Current.Previous;

            prevNode.Next = nextNode;
            nextNode.Previous = prevNode;

            // Check if we're removing First/Last
            if (Current == First) { First = nextNode; }
            if (Current == Last) { Last = prevNode; }

            Current = nextNode;
            Count--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = First;

            do
            {
                yield return node.Value;
                node = node.Next;
            } while (node != First);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
