using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  [Keyless]
  public class Vocabulary
  {

    public int VocId { get; set; }

    public string? TopicId { get; set; }
    public string? WordVoc { get; set; }
    public string? vocImgUrl { get; set; }
    public string? vocExample { get; set; }
    public string? vocIPA { get; set; }
    public int? level { get; set; }
    public string? typeVoc { get; set; }
    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Vocabulary>().HasData(
        new Vocabulary
        {
          VocId = "voc01",

          TopicId = "TPFamily",
          WordVoc = "Father",
          vocExample = "Thí is m,y father",

          vocIPA = "Thí is m,y father",
          level = 1,
          typeVoc = "N",

          vocImgUrl = "https://example.com/avatar.jpg"
        }


      );
    }
  }
  public class VocabularyConfiguration : IEntityTypeConfiguration<Vocabulary>
  {
    public void Configure(EntityTypeBuilder<Vocabulary> builder)
    {
      builder.ToTable("Vocabularies");

      builder.HasKey(x => x.VocId);


      builder.Property(x => x.VocId)
             .UseIdentityColumn()
             .IsRequired();
      builder.Property(x => x.TopicId)
             .IsRequired();
      builder.Property(x => x.WordVoc)
             .IsRequired();
      builder.Property(x => x.vocImgUrl).HasMaxLength(255);
      builder.Property(x => x.vocExample)
             .HasMaxLength(255);
      builder.Property(x => x.level)
             .HasMaxLength(255);
      builder.Property(x => x.typeVoc)
             .HasMaxLength(255);
      builder.Property(x => x.vocIPA)
             .HasMaxLength(255);


    }
  }
}




