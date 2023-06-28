using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Exercise
  {
    public string idBaitap { get; set; }

    public string cauTraloi1 { get; set; }
    public string cauTraloi2 { get; set; }
    public string cauTraloi3 { get; set; }
    public string cauTraloi4 { get; set; }
    public string isCorret { get; set; }
    public string isTuluan { get; set; }


  }
}