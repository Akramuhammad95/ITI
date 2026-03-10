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
        public void Pop() => RemoveLast();
        public T Peak => GetTailData;
        
        //is empty in the parent class



    }
}
