using Microsoft.EntityFrameworkCore;

namespace TodoList.DAL;

public class MyDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql("Host=172.17.0.1;Database=notesDb;Username=postgres;Password=123");
    }
}