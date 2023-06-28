using DANTN.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DANTN.Data.Entities
{
  public class Topic
  {
    public string TopicId { get; set; }
    public string ParentID { get; set; }
    public string NameTopic { get; set; }
    public string? TopicImage { get; set; }
    public string? ImageURL { get; set; }
    public string? TopicDesc { get; set; }
    public string? TopicAlias { get; set; }
    public int? ViewCount { get; set; }
    public static void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasData(
        new Topic
        {
          TopicId = "TP01a",
          ParentID = "TP01",
          NameTopic = "Family",
          TopicImage = "https://example.com/avatar.jpg",
          ImageURL = "https://example.com/avatar.jpg",
          TopicDesc = "lorem abc das das was we awen",
          TopicAlias = "aaa",
          ViewCount = 0
        },


      );
    }
  }







}
}