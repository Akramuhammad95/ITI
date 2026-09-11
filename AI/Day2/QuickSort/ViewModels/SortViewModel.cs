using System.ComponentModel.DataAnnotations;

namespace QuickSort.ViewModels
{
    public class SortViewModel
    {
        [Required]
        [Display(Name = "Numbers (comma-separated)")]
        public string Numbers { get; set; } = string.Empty;

        public string Sorted { get; set; } = string.Empty;

        public long ElapsedMilliseconds { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public string Algorithm { get; set; } = "recursive";
    }
}
