using System.ComponentModel.DataAnnotations;


namespace DANTN.Models
{
  public class AddTopicRequest
  {
    public string TopicId { get; set; }
    public string ParentID { get; set; }
    public string NameTopic { get; set; }
    public string? TopicImage { get; set; }
    public string? ImageURL { get; set; }
    public string? TopicDesc { get; set; }
    public string? TopicAlias { get; set; }
    public int? ViewCount { get; set; }
  }
}