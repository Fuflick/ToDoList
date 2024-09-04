using Microsoft.EntityFrameworkCore;
using TodoList.Domain;

namespace TodoList.DAL;

public class MyDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql("Host=172.26.0.2;Username=postgres;Port=5432;Password=123;Database=TodoListDb");
    }
}