using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _capacity;
        private int _head = 0;
        private int _tail = 0;

        public int head
        {
            get
            {
                return _head;
            }
        }
        public int Count => _tail - _head;

        public bool isEmpty => Count == 0;
        public bool isFull => _tail == _array.Length;

        public T Front => _array[head];

        public ArrayQueue(int capacity =4)
        {
            _capacity = capacity;
            _array = new T[_capacity];
        }
        public void Enqueue(T item)
        {
            if (isFull)
            {
                Resize();
            }
            _array[_tail++] = item;
        }


        public T Dequeue()
        {
            if (_head != _tail)
            {
                return _array[_head++];
            }
            throw new InvalidOperationException("Queue is empty");
        }
        private void Resize()
        {
            int newCapacity = _array.Length * 2;
            T[] newArray = new T[newCapacity];

            int count = _tail - _head;
            for (int i = 0; i < count; i++)
            {
                newArray[i] = _array[_head + i];
            }

            _array = newArray;
            _tail = count;
            _head = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _head; i < _tail; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
