using System.ComponentModel.DataAnnotations;

namespace DANTN.Models;


public class VocabularyViewModel
{
  public int VocId { get; set; }

  public string? TopicId { get; set; }
  public string? WordVoc { get; set; }
  public string? vocImgUrl { get; set; }
  public string? vocExample { get; set; }
  public string? vocIPA { get; set; }
  public int? level { get; set; }
  public string? typeVoc { get; set; }
}

public class VocabularyRequest
{
  public string? TopicId { get; set; }
  public string? WordVoc { get; set; }
  public string? vocImgUrl { get; set; }
  public string? vocExample { get; set; }
  public string? vocIPA { get; set; }
  public int? level { get; set; }
  public string? typeVoc { get; set; }
}
