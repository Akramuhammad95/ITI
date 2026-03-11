using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{

    public class MyQueue<T> :  DoublyLinkedList<T>
    {
        //enqueue(DataMisalignedException) ,peek(), dequeue(), isEmpty()

        public void enqueue(T data) => AddLast(data);
        public T Peak() => GetHeadData;

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            T data = GetHeadData;
            RemoveFirst();
            return data;
        }
        //is empty in the parent class


    }
}
