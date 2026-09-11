using System;

namespace QuickSort.Services.Interfaces
{
    /// <summary>
    /// Service contract for QuickSort implementations and helpers.
    /// </summary>
    public interface IQuickSortService
    {
        /// <summary>
        /// Sorts the provided array using a recursive QuickSort implementation.
        /// Returns a new sorted array and does not modify the input.
        /// </summary>
        int[] QuickSortRecursive(int[] items);

        /// <summary>
        /// Sorts the provided array using an iterative QuickSort implementation.
        /// Returns a new sorted array and does not modify the input.
        /// </summary>
        int[] QuickSortIterative(int[] items);
    }
}
