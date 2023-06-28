using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Question
  {
    public string QuestionId { get; set; }


    public string QuestionString { get; set; }
    public string Answer { get; set; }
    public bool isTuluan { get; set; }
    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Question>().HasData(
        new Question
        {
          QuestionId = "TP01a",
          QuestionString = "TP01",
          Answer = "Family",

          isTuluan = false
        }


      );
    }

  }
}