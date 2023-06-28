using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Level
  {
    public int LevelId { get; set; }
    public string? LevelName { get; set; }
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