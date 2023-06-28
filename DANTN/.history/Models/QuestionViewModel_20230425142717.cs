using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DANTN.Data.Entities.Enums;

namespace DANTN.Models
{
  public class QuestionViewModel
  {
    public int QuestionId { get; set; }
    public string? QuestionString { get; set; }
    public string? TopicId { get; set; }
    public string? Answer_1 { get; set; }
    public string? Answer_2 { get; set; }
    public string? Answer_3 { get; set; }
    public string? Answer_4 { get; set; }
    public IsCorrect IsCorrect { get; set; }
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