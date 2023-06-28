using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Exercise
  {
    public string idExercise { get; set; }
    public string nameExercise { get; set; }


    public string Answer_1 { get; set; }
    public string Answer_2 { get; set; }
    public string Answer_3 { get; set; }
    public string Answer_4 { get; set; }
    public IsCorrect isCorrect { get; set; }
    public bool isTuluan { get; set; }
    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Exercise>().HasData(
        new Exercise
        {
          idExercise = "TP01a",
          nameExercise = "TP01",
          Answer_1 = "Family",
          Answer_2 = "https://example.com/avatar.jpg",
          Answer_3 = "https://example.com/avatar.jpg",
          Answer_4 = "lorem abc das das was we awen",
          isCorrect = IsCorrect.Answer_1,
          isTuluan = false
        }


      );
    }

  }
}