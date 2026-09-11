using System;
using QuickSort.Services.Interfaces;

namespace QuickSort.Services
{
    /// <summary>
    /// Provides QuickSort implementations (recursive and iterative) and helpers.
    /// </summary>
    public class QuickSortService : IQuickSortService
    {
        /// <inheritdoc />
        public int[] QuickSortRecursive(int[] items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var arr = (int[])items.Clone();
            QuickSortRecursiveImpl(arr, 0, arr.Length - 1);
            return arr;
        }

        /// <inheritdoc />
        public int[] QuickSortIterative(int[] items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var arr = (int[])items.Clone();
            QuickSortIterativeImpl(arr);
            return arr;
        }

        // Recursive implementation using Lomuto partition and tail recursion optimization.
        private void QuickSortRecursiveImpl(int[] arr, int left, int right)
        {
            while (left < right)
            {
                int pivotIndex = Partition(arr, left, right);

                // Recur on smaller partition first to limit stack depth
                if (pivotIndex - left < right - pivotIndex)
                {
                    QuickSortRecursiveImpl(arr, left, pivotIndex - 1);
                    left = pivotIndex + 1; // Tail recursion on the right side
                }
                else
                {
                    QuickSortRecursiveImpl(arr, pivotIndex + 1, right);
                    right = pivotIndex - 1; // Tail recursion on the left side
                }
            }
        }

        // Iterative implementation using an explicit stack
        private void QuickSortIterativeImpl(int[] arr)
        {
            int n = arr.Length;
            if (n < 2) return;

            var stack = new System.Collections.Generic.Stack<(int left, int right)>();
            stack.Push((0, n - 1));

            while (stack.Count > 0)
            {
                var (left, right) = stack.Pop();
                if (left >= right) continue;

                int pivot = Partition(arr, left, right);

                // Push larger partition first to keep stack small
                if (pivot - 1 - left > right - (pivot + 1))
                {
                    stack.Push((left, pivot - 1));
                    stack.Push((pivot + 1, right));
                }
                else
                {
                    stack.Push((pivot + 1, right));
                    stack.Push((left, pivot - 1));
                }
            }
        }

        // Partition using Lomuto scheme and choose pivot as median-of-three for better performance
        private int Partition(int[] arr, int left, int right)
        {
            // Median-of-three pivot selection
            int mid = left + (right - left) / 2;
            int pivotIndex = MedianOfThree(arr, left, mid, right);
            int pivotValue = arr[pivotIndex];
            Swap(arr, pivotIndex, right); // move pivot to end

            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivotValue)
                {
                    Swap(arr, i, storeIndex);
                    storeIndex++;
                }
            }
            Swap(arr, storeIndex, right); // move pivot to its final place
            return storeIndex;
        }

        private int MedianOfThree(int[] arr, int a, int b, int c)
        {
            int A = arr[a], B = arr[b], C = arr[c];
            if ((A - B) * (C - A) >= 0) return a;
            if ((B - A) * (C - B) >= 0) return b;
            return c;
        }

        private void Swap(int[] arr, int i, int j)
        {
            if (i == j) return;
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
