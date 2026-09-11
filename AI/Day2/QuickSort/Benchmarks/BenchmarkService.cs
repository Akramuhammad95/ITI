using System;
using System.Diagnostics;
using QuickSort.Services.Interfaces;

namespace QuickSort.Benchmarks
{
    public class BenchmarkService
    {
        private readonly IQuickSortService _service;

        public BenchmarkService(IQuickSortService service)
        {
            _service = service;
        }

        public (long recursiveMs, long iterativeMs, long builtinMs) Run(int[] dataset)
        {
            var a = (int[])dataset.Clone();
            var sw = Stopwatch.StartNew();
            _service.QuickSortRecursive(a);
            sw.Stop();
            long recursiveMs = sw.ElapsedMilliseconds;

            a = (int[])dataset.Clone();
            sw.Restart();
            _service.QuickSortIterative(a);
            sw.Stop();
            long iterativeMs = sw.ElapsedMilliseconds;

            a = (int[])dataset.Clone();
            sw.Restart();
            Array.Sort(a);
            sw.Stop();
            long builtinMs = sw.ElapsedMilliseconds;

            return (recursiveMs, iterativeMs, builtinMs);
        }
    }
}
