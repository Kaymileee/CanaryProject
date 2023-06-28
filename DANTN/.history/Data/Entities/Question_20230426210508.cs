using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Question
  {
    public int QuestionId { get; set; }
    public string? QuestionString { get; set; }
    public string? TopicId { get; set; }
    public virtual Topic? Topic { get; set; }
    public string? Answer_1 { get; set; }
    public string? Answer_2 { get; set; }
    public string? Answer_3 { get; set; }
    public string? Answer_4 { get; set; }
    public IsCorrect IsCorrect { get; set; }
    public string? ImageURL { get; set; }
    public bool isTuluan { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Question>().HasData(
        new Question
        {
          QuestionId = 1,
          QuestionString = "This is a test question",
          Answer_1 = "Apple",
          Answer_2 = "Banana",
          Answer_3 = "Lemon",
          Answer_4 = "Kiwi",
          IsCorrect = IsCorrect.Answer_1,
          ImageURL = "",
          isTuluan = false,
          TopicId = "TPFruits",
        },
         new Question
         {
           QuestionId = 2,
           QuestionString = "Số táo viết như thế nào",
           Answer_1 = "Apple",
           Answer_2 = "",
           Answer_3 = "",
           Answer_4 = "",

           ImageURL = "",
           isTuluan = true,
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
      builder.Property(x => x.Answer_1);
      builder.Property(x => x.Answer_2);
      builder.Property(x => x.Answer_3);
      builder.Property(x => x.Answer_4);

      builder.Property(x => x.TopicId);
      builder.Property(x => x.ImageURL);

    }
  }
}