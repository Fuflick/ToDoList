using Microsoft.EntityFrameworkCore;
using TodoList.Domain;

namespace TodoList.DAL;

public class MyDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql("Host=todolist-db-container;Port=5432;Database=TodoListDb;Username=postgres;Password=123");
    }
}