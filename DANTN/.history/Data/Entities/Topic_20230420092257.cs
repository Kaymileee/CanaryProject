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
    public string? ViewCount { get; set; }








  }
}