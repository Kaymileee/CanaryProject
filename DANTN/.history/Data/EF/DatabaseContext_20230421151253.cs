using DANTN.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DANTN.Data.EF;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    User.SeedData(modelBuilder);

  }

  public DbSet<User> Users { set; get; } = default!;
  public DbSet<Topic> Topics { set; get; } = default!;
  public DbSet<Vocabulary> Vocabularies { set; get; } = default!;



}
