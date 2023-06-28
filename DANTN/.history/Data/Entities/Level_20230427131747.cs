using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


    }
  }
}