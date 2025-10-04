using HabbitTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HabbitTracker.Data;

public class Db : DbContext
{
    public DbSet<User> Users { get; set; } =  null!;
    public DbSet<Habbit> Habits { get; set; } =  null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=habittracker");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("User");
    }
    
 
  
}