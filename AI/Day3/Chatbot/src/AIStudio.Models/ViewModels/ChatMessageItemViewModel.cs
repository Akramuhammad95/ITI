namespace AIStudio.Models.ViewModels;

public class ChatMessageItemViewModel
{
    public int Id { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string AiResponse { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
}
