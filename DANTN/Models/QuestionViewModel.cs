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
    public string? quesURL { get; set; }

  }
  public class QuestionRequest
  {
    public string? QuestionString { get; set; }
    public string? TopicId { get; set; }
    public string? Answer_1 { get; set; }
    public string? Answer_2 { get; set; }
    public string? Answer_3 { get; set; }
    public string? Answer_4 { get; set; }
    public IsCorrect IsCorrect { get; set; }
    public IFormFile? ImageURL { get; set; }
    public bool isTuluan { get; set; }
    public string QuesURL { get; set; }

  }
  public class CheckAnswerRequest
  {
    public int QuestionId { get; set; }
    public IsCorrect IsCorrect { get; set; }
  }

  public class CheckAnswerViewModel
  {
    public int QuestionId { get; set; }
    public string? QuestionString { get; set; }
    public IsCorrect? Answer { get; set; }
    public IsCorrect? AnswerUser { get; set; }
    public bool IsCorrect { get; set; }
  }
  public class QuizzesViewModel
  {
    public string? QuestionString { get; set; }
    public string? Answer_1 { get; set; }
    public string? Answer_2 { get; set; }
    public string? Answer_3 { get; set; }
    public string? Answer_4 { get; set; }
    public IsCorrect IsCorrect { get; set; }
    public string? ImageURL { get; set; }
    public bool isTuluan { get; set; }

  }
}