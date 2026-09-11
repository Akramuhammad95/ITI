using System;
using System.Collections.Generic;

namespace Day5.Sorting
{
    public class SelectionSort<T>
    {
        private readonly IComparer<T> _comparer;

        // Dependency Injection
        public SelectionSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public SelectionSort()
        {
            _comparer = Comparer<T>.Default;
        }
        public void Sort(List<T> array, int start, int end)
        {
            if (array == null || array.Count <= 1)
                return;

            int n = array.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (_comparer.Compare(array[j], array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                // swap
                if (minIndex != i)
                {
                    T temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }
    }
}