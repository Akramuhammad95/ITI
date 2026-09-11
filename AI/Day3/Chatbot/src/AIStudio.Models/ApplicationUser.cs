using Microsoft.AspNetCore.Identity;

namespace AIStudio.Models;

public class ApplicationUser : IdentityUser
{
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
