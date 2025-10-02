using HabbitTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HabbitTracker.Data;

public class Db : DbContext
{
  public DbSet<User> Users { get; set; } =  null!;
  
  public Db(DbContextOptions<Db> options) : base(options) { }
}