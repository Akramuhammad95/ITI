using Microsoft.AspNetCore.Mvc;
using QuickSort.Services.Interfaces;
using QuickSort.ViewModels;
using System.Diagnostics;

namespace QuickSort.Controllers
{
    public class SortController : Controller
    {
        private readonly IQuickSortService _sortService;

        public SortController(IQuickSortService sortService)
        {
            _sortService = sortService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SortViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SortViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var parts = model.Numbers.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var arr = parts.Select(p => int.Parse(p)).ToArray();

                var sw = Stopwatch.StartNew();
                int[] sorted;
                if (model.Algorithm == "iterative")
                    sorted = _sortService.QuickSortIterative(arr);
                else
                    sorted = _sortService.QuickSortRecursive(arr);
                sw.Stop();

                model.Sorted = string.Join(",", sorted);
                model.ElapsedMilliseconds = sw.ElapsedMilliseconds;
            }
            catch (FormatException)
            {
                model.ErrorMessage = "Invalid input. Please enter comma-separated integers.";
            }
            catch (Exception ex)
            {
                model.ErrorMessage = "An error occurred: " + ex.Message;
            }

            return View(model);
        }
    }
}
