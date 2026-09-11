using System;
using Xunit;
using QuickSort.Services;

namespace QuickSort.Tests
{
    public class QuickSortTests
    {
        private readonly QuickSortService _svc = new QuickSortService();

        [Fact]
        public void Sort_EmptyArray_ReturnsEmpty()
        {
            int[] arr = Array.Empty<int>();
            var r = _svc.QuickSortRecursive(arr);
            Assert.Empty(r);

            var i = _svc.QuickSortIterative(arr);
            Assert.Empty(i);
        }

        [Fact]
        public void Sort_SingleElement_ReturnsSame()
        {
            int[] arr = { 5 };
            var r = _svc.QuickSortRecursive(arr);
            Assert.Single(r);
            Assert.Equal(5, r[0]);

            var i = _svc.QuickSortIterative(arr);
            Assert.Single(i);
            Assert.Equal(5, i[0]);
        }

        [Fact]
        public void Sort_SortedArray_ReturnsSame()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var r = _svc.QuickSortRecursive(arr);
            Assert.Equal(arr, r);

            var i = _svc.QuickSortIterative(arr);
            Assert.Equal(arr, i);
        }

        [Fact]
        public void Sort_ReverseArray_Sorts()
        {
            int[] arr = { 5, 4, 3, 2, 1 };
            var expected = new int[] { 1,2,3,4,5 };
            var r = _svc.QuickSortRecursive(arr);
            Assert.Equal(expected, r);

            var i = _svc.QuickSortIterative(arr);
            Assert.Equal(expected, i);
        }

        [Fact]
        public void Sort_Duplicates_Sorts()
        {
            int[] arr = { 3,1,2,3,3 };
            var expected = new int[] {1,2,3,3,3};
            var r = _svc.QuickSortRecursive(arr);
            Assert.Equal(expected, r);

            var i = _svc.QuickSortIterative(arr);
            Assert.Equal(expected, i);
        }

        [Fact]
        public void Sort_NegativeNumbers_Sorts()
        {
            int[] arr = { -1, 5, 0, -2 };
            var expected = new int[] { -2, -1, 0, 5 };
            var r = _svc.QuickSortRecursive(arr);
            Assert.Equal(expected, r);

            var i = _svc.QuickSortIterative(arr);
            Assert.Equal(expected, i);
        }

        [Fact]
        public void Sort_LargeRandomArray_Sorts()
        {
            var rnd = new Random(123);
            int[] arr = new int[1000];
            for (int i = 0; i < arr.Length; i++) arr[i] = rnd.Next();

            var r = _svc.QuickSortRecursive(arr);
            Array.Sort(arr);
            Assert.Equal(arr, r);

            var i = _svc.QuickSortIterative(arr);
            Assert.Equal(arr, i);
        }
    }
}
