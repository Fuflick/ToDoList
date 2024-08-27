﻿using Microsoft.EntityFrameworkCore;

namespace TodoList.DAL;

public class MyDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql("ConnectionString");
    }
}