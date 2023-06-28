using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Topic
  {
    public string? TopicId { get; set; }
    public string? ParentID { get; set; }
    public string? NameTopic { get; set; }
    public string? TopicImage { get; set; }

    public string? TopicDesc { get; set; }
    public string? TopicAlias { get; set; }
    public int? ViewCount { get; set; }
    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Topic>().HasData(
        new Topic
        {
          TopicId = "TPFruits",
          ParentID = "TP01",
          NameTopic = "Family",

          TopicImage = "https://example.com/avatar.jpg",
          TopicDesc = "lorem abc das das was we awen",
          TopicAlias = "aaa",
          ViewCount = 0
        }


      );
    }
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
      public void Configure(EntityTypeBuilder<Topic> builder)
      {
        // table name
        builder.ToTable("Topics");

        // primary key
        builder.HasKey(x => x.TopicId);

        //property
        builder.Property(x => x.NameTopic)
               .IsRequired();

        builder.Property(x => x.ParentID)
               .HasMaxLength(50);
        builder.Property(x => x.TopicImage)
               .HasMaxLength(50);
        builder.Property(x => x.TopicDesc)
               .IsRequired();
        builder.Property(x => x.TopicAlias)
               .HasMaxLength(255);
        builder.Property(x => x.ViewCount)
               .HasMaxLength(255);
      }
    }
  }







}
