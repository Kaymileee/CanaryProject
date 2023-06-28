using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Level
  {
    public int? LevelId { get; set; }
    public string? LevelName { get; set; }
    List<Topic>? Topics { get; set; }
    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Level>().HasData(
        new Level
        {
          LevelId = 0,
          LevelName = "Level 1",
        }

      );
    }
  }
  public class LevelConfiguration : IEntityTypeConfiguration<Level>
  {
    public void Configure(EntityTypeBuilder<Level> builder)
    {
      builder.ToTable("Levels");
      builder.HasKey(x => x.LevelId);
      builder.Property(y => y.LevelId).UseIdentityColumn().IsRequired();
    }
  }
}