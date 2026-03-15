using System;
using System.Collections.Generic;

namespace Day4.Searchers
{
    public class BinarySearch<T> : ISearchers<T>
    {
        private IComparer<T> _comparer;

        public BinarySearch(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        // Iterative Binary Search
        public int Search(List<T> list, T value)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                int result = _comparer.Compare(list[mid], value);

                if (result == 0)
                    return mid;

                if (result < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        // Recursive Binary Search
        public int SearchRecursive(List<T> list, T value)
        {
            return Recursive(list, value, 0, list.Count - 1);
        }

        private int Recursive(List<T> list, T value, int left, int right)
        {
            if (left > right)
                return -1;

            int mid = (left + right) / 2;

            int result = _comparer.Compare(list[mid], value);

            if (result == 0)
                return mid;

            if (result < 0)
                return Recursive(list, value, mid + 1, right);
            else
                return Recursive(list, value, left, mid - 1);
        }
    }
}