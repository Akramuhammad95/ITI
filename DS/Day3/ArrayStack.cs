using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _count;
        private int _capacity;

        public int Count => _count;
        public int getLength => _array.Length;


        public bool isEmpty => _count == 0;

        public bool isFull => _count == _capacity;

        public T peak => _array[_count - 1];
        public ArrayStack(int capacity = 4)
        {
            _capacity = capacity;
            _array = new T[_capacity];
            _count = 0;
        }

        public void Push(T item)
        {
            if (isFull)
            {
                Resize();
            }

            _array[_count++] = item;

        }

        public T Pop()
        {
            T result;
            if (!isEmpty)
            {
                result = _array[--_count];
                return result;
            }
            throw new InvalidOperationException("Stack is empty");
        }

        private void Resize()
        {
            int newSize = _array.Length * 2;
            T[] newArr = new T[newSize];
            for (int i = 0; i < _capacity; i++)
            {
                newArr[i] = _array[i];
            }
            _array = newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {

            for (int i = 0; i < Count; i++)
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
