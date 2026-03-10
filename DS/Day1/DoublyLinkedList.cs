using System;
using System.Text;
using System.Collections.Generic;

namespace Day1
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public int Count => count;

        // Check if the list is empty
        public bool IsEmpty() => count == 0; //1

        // Get data safely
        public T GetHeadData =>
            !IsEmpty() ? head.Data : throw new InvalidOperationException("List is empty");

        public T GetTailData =>
            !IsEmpty() ? tail.Data : throw new InvalidOperationException("List is empty");

        // Add first node
        public void AddFirst(T item) //o(1)
        {
            Node<T> node = new Node<T>(item);

            if (IsEmpty())
                head = tail = node;
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }

            count++;
        }

        // Add last node
        public void AddLast(T item) //o(1)
        {
            Node<T> node = new Node<T>(item);

            if (IsEmpty())
                head = tail = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }

            count++;
        }

        // Search for a node
        private Node<T> Search(T item) //o(n)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                    return current;

                current = current.Next;
            }

            return null;
        }

        // Check if list contains item
        public bool Contains(T item) => Search(item) != null;

        // Delete specific item
        public bool Delete(T item) //o(n)
        {
            Node<T> current = Search(item);

            if (current == null)
                return false;

            // Delete head
            if (current == head)
            {
                head = head.Next;

                if (head != null)
                    head.Prev = null;
                else
                    tail = null;
            }
            // Delete tail
            else if (current == tail)
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            // Delete middle
            else
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }

            count--;
            return true;
        }

        // Remove first node
        public bool RemoveFirst() //(1)
        {
            if (IsEmpty())
                return false;

            if (head == tail)
                head = tail = null;
            else
            {
                head = head.Next;
                head.Prev = null;
            }

            count--;
            return true;
        }

        // Remove last node
        public bool RemoveLast() //(1)
        {
            if (IsEmpty())
                return false;

            if (head == tail)
                head = tail = null;
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }

            count--;
            return true;
        }

        // Print list
        public override string ToString() //(n)
        {
            if (IsEmpty())
                return "List is empty";

            Node<T> current = head;
            StringBuilder result = new StringBuilder();

            while (current != null)
            {
                result.AppendLine(current.Data.ToString());
                current = current.Next;
            }

            return result.ToString();
        }
    }
}