using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace HW5
{
    public class LinkedList
    {
        public Node root;

        public LinkedList(Node head)
        {
            root = head;
        }

        public void AddHead(Node newHead)
        {
            Node oldHead;
            do
            {
                oldHead = root;
                newHead.Next = oldHead;
            } while (
            ReferenceEquals(
                Interlocked.CompareExchange(ref root, newHead, oldHead),
                root));
        }
    }
}
