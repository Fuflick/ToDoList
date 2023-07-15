using Microsoft.EntityFrameworkCore;
using ToDoLIst.Domain.Entity;

namespace ToDoList.DAL;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<TaskEntity> Tasks { get; set; }
}