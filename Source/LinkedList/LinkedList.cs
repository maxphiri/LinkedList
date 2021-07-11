using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; }

        public string PrintList()
        {
            var sb = new StringBuilder();

            Node<T> node = Head;
            while (node != null)
            {
                sb.Append($"{node.Data.ToString()},");
                node = node.Next;
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        /* Inserts a new Node at front of the list. */
        public void Push(Node<T> node)
        {
            node.Next = Head;
            Head = node;
        }

        /* Inserts a new node after the given prev_node. */
        public void InsertAfter(Node<T> prevNode, Node<T> node)
        {
            if (prevNode == null)
            {
                throw new Exception("Previous node of null value not allowed");
            }

            node.Next = prevNode.Next;

            prevNode.Next = node;
        }

        /* Inserts a new node after the given prev_node. */
        public void InsertBefore(Node<T> nextNode, Node<T> node)
        {
            if (nextNode == null)
            {
                throw new Exception("Next node of null value not allowed");
            }

            node.Next = nextNode;

            if (Head == nextNode)
            {
                Head = node;
            }
        }

        public void Append(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                return;
            }

            node.Next = null;

            var lastNode = Head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            lastNode.Next = node;
            return;
        }

        public void DeleteByData(Node<T> node)
        {

            if (Head == null)
                return;

            Node<T> temp = Head, prev = null;

            if (temp.Data.Equals(node.Data))
            {
                Head = temp.Next;
                return;
            }

            while (!temp.Data.Equals(node.Data))
            {
                prev = temp;
                temp = temp.Next;
            }

            // Key not present in list
            if (temp == null)
                return;

            // Found it - unlink the node from linked list
            prev.Next = temp.Next;
        }

        public void DeleteByPositin(int position)
        {
            if (Head == null)
                return;

            Node<T> temp = Head;

            if (position == 0)
            {
                Head = temp.Next;
                return;
            }

            for (int i = 0; i < position - 1; i++)
            {
                if (temp == null)
                    break;

                //Last Node temp.next is the node to be deleted
                temp = temp.Next;
            }

            if (temp == null || temp.Next == null)
                return;

            Node<T> next = temp.Next.Next;

            // Unlink the deleted node from list
            temp.Next = next;
        }

        public int Length()
        {
            if (Head == null)
            {
                return 0;
            }

            int count = 1;
            var lastNode = Head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
                count++;
            }

            return count;
        }
    }
}
