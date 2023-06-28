using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DANTN.Models
{
  public class QuestionViewModel
  {
    public int QuestionId { get; set; }


    public string? QuestionString { get; set; }
    public string? Answer { get; set; }
    public string? TopicId { get; set; }
    public string? ImageURL { get; set; }
    public bool isTuluan { get; set; }

  }
  public class QuestionRequest
  {
    public int QuestionId { get; set; }


    public string? QuestionString { get; set; }
    public string? Answer { get; set; }
    public string? TopicId { get; set; }
    public string? ImageURL { get; set; }
    public bool isTuluan { get; set; }

  }
}