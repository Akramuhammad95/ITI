using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{



        public class EmpList
        {
            private Node<Employee> head;
            private int count;

            public int Count => count;

            public void AddFirst(Employee employee)
            {
                var node = new Node<Employee>(employee);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    node.Next = head;
                    head.Prev = node;
                    head = node;
                }

                count++;
            }

            public bool Delete(Employee employee)
            {
                var current = Search(employee);

                if (current == null)
                    return false;

                // Case 1: delete head
                if (current == head)
                {
                    head = head.Next;

                    if (head != null)
                        head.Prev = null;
                }

                // Case 2: delete middle or last
                else
                {
                    current.Prev.Next = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                }

                count--;
                return true;
            }

            private Node<Employee> Search(Employee employee)
            {
                var current = head;

                while (current != null)
                {
                    if (current.Data == employee)
                        return current;

                    current = current.Next;
                }

                return null;
            }
            

            public override string ToString()
            {
                var current = head;
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