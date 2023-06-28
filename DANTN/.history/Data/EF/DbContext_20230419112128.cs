using DANTN.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DANTN.Data.EF;

public class DbContext : DbContext
{
  public DbContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    User.SeedData(modelBuilder);
  }

  public DbSet<User> Users { set; get; } = default!;
}
