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
    public string isCorret { get; set; }
    public string isTuluan { get; set; }


  }
}