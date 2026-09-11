namespace AIStudio.Models.ViewModels;

public class GeneratedImageItemViewModel
{
    public int Id { get; set; }
    public string Prompt { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
}
