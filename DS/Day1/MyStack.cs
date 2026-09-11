using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day1
{
    public class MyStack<T> : DoublyLinkedList<T>
    {
        //push(data) , pop(), data peek(), isEmpty()
        public void Push(T data) => AddLast(data);
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            T data = GetTailData;
            RemoveLast();
            return data;
        }
        public T Peak => GetTailData;
        
        
        //is empty in the parent class



    }
}
