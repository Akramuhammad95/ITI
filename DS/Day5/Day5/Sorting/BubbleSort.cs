using System;
using System.Collections.Generic;
using System.Text;

namespace Day5.Sorting
{
    public class BubbleSort<T>
    {
        private readonly IComparer<T> _comparer;

        public BubbleSort(IComparer<T> comparer)
        {
            _comparer = comparer ?? Comparer<T>.Default;
        }
        public void Sort(List<T> array, int start, int end)
        {
            if (array == null || array.Count <= 1)
                return;
            int n = array.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (_comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        // swap
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

        }
    }
}
