using System;
using System.Collections.Generic;

namespace Day5.Sorting
{
    public class MergeSort<T>
    {
        private readonly IComparer<T> _comparer;

        public MergeSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }
        public MergeSort()
        {
            _comparer = Comparer<T>.Default;
        }

        public void Sort(List<T> array, int start, int end)
        {
            if (start >= end)
                return;

            int mid = start + (end - start) / 2;

            Sort(array, start, mid);
            Sort(array, mid + 1, end);

            Merge(array, start, mid, end);
        }

        private void Merge(List<T> array, int left, int mid, int end)
        {
            int l = left;
            int r = mid + 1;

            List<T> temp = new List<T>();

            while (l <= mid && r <= end && l < array.Count && r < array.Count)
            {
                if (l >= array.Count || r >= array.Count)
                    throw new Exception("Index out of range manually detected");
                if (_comparer.Compare(array[l], array[r]) <= 0)
                    temp.Add(array[l++]);
                else
                    temp.Add(array[r++]);
            }

            while (l <= mid)
                temp.Add(array[l++]);

            while (r <= end)
                temp.Add(array[r++]);

            // copy back
            for (int i = 0; i < temp.Count; i++)
            {
                array[left + i] = temp[i];
            }
        }
    }
}