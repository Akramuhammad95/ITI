using Presentation.Models;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

    public DbSet<GeneratedImage> GeneratedImages => Set<GeneratedImage>();
}