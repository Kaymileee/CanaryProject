using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Question
  {
    public int QuestionId { get; set; }


    public string QuestionString { get; set; }
    public string? Answer { get; set; }
    public string? TopicId { get; set; }
    public string? ImageURL { get; set; }


    public bool isTuluan { get; set; }
    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Question>().HasData(
        new Question
        {
          QuestionId = 1,
          QuestionString = "This is a test question",
          Answer = "Apple",
          ImageURL = "",
          isTuluan = false,
          TopicId = "TPFruits",
        }


      );
    }


  }
  public class QuestionConfiguration : IEntityTypeConfiguration<Question>
  {
    public void Configure(EntityTypeBuilder<Question> builder)
    {
      // table name
      builder.ToTable("Questions");

      // primary key
      builder.HasKey(x => x.QuestionId);

      //property
      builder.Property(x => x.QuestionId)
             .UseIdentityColumn()
             .IsRequired();
      builder.Property(x => x.QuestionString)
             .IsRequired();
      builder.Property(x => x.Answer);
      builder.Property(x => x.TopicId);
      builder.Property(x => x.ImageURL);

    }
  }
}