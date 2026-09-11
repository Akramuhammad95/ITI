namespace AIStudio.Models.ViewModels;

public class ChatViewModel
{
    public List<ChatMessageItemViewModel> Messages { get; set; } = [];
    public int DailyLimit { get; set; }
    public int UsedToday { get; set; }
}
