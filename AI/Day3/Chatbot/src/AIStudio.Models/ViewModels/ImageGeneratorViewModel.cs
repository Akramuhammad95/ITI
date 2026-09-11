namespace AIStudio.Models.ViewModels;

public class ImageGeneratorViewModel
{
    public List<GeneratedImageItemViewModel> Images { get; set; } = [];
    public int DailyLimit { get; set; }
    public int UsedToday { get; set; }
}
