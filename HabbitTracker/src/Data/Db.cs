using HabbitTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HabbitTracker.Data;

public class Db : DbContext
{
    public DbSet<User> Users { get; set; } =  null!;
    public DbSet<Habbit> Habits { get; set; } =  null!;
    
    public Db(DbContextOptions<Db> options) : base(options)
    {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("User");
        
        var adminPassword = BCrypt.Net.BCrypt.HashPassword("admin123");
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            FirstName = "Admin",
            Email = "admin@habits.com",
            HashedPassword = adminPassword,
            Role = "Admin",
            Balance = 0
        });
    }
    
 
  
}