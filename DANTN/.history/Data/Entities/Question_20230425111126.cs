using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Question
  {
    public int QuestionId { get; set; }


    public string QuestionString { get; set; }
    public string Answer { get; set; }
    public string TopicId { get; set; }
    public Topic Topic { get; set; }
    public string ImageURL { get; set; }


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
          Topic = new Topic()
        }


      );
    }

  }
}