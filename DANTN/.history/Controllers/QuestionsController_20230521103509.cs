using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DANTN.Data.EF;
using DANTN.Data.Entities;
using DANTN.Helpers;
using DANTN.Models;
using DANTN.Utils.FileStorages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace DANTN.Controllers;
[Route("api/[controller]")]
[ApiController]

public class QuestionsController : ControllerBase
{
  private readonly DatabaseContext _context;
  private readonly IFileStorageService _fileService;
  private const string USER_CONTENT_FOLDER_NAME = "user-content";
  public QuestionsController(DatabaseContext context, IFileStorageService fileService)
  {
    _context = context;
    _fileService = fileService;
  }
  [HttpPost("addQuestion")]
  public async Task<IActionResult> AddQuestion([FromForm] QuestionRequest request)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    if (string.IsNullOrEmpty(request.QuestionString)) return BadRequest(new ApiBadRequestResponse("Please enter Question string"));
    if (request.ImageURL == null) return BadRequest(new ApiBadRequestResponse("Please input an image file"));
    var newQuestion = new Question();
    newQuestion.ImageURL = await _fileService.SaveFile(request.ImageURL);
    newQuestion.QuestionString = request.QuestionString;
    newQuestion.isTuluan = request.isTuluan;
    newQuestion.TopicId = request.TopicId;
    newQuestion.Answer_1 = request.Answer_1;
    newQuestion.Answer_2 = request.Answer_2;
    newQuestion.Answer_3 = request.Answer_3;
    newQuestion.Answer_4 = request.Answer_4;
    newQuestion.IsCorrect = request.IsCorrect;

    _context.Questions.Add(newQuestion);
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      // code : 201
      return CreatedAtAction("abc", new { newQuestion }, request);
    }
    return BadRequest(new ApiBadRequestResponse("not created failed"));

  }
  [HttpGet("getById")]
  public async Task<ApiResult<QuestionViewModel>> GetById(string id)
  {
    var question = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == Int32.Parse(id));
    if (question == null) return new ApiErrorResult<QuestionViewModel>("Câu  hỏi không tồn tại");
    var questionView = new QuestionViewModel()
    {
      QuestionId = question.QuestionId,
      QuestionString = question.QuestionString,
      Answer_1 = question.Answer_1,
      Answer_2 = question.Answer_2,
      Answer_3 = question.Answer_3,
      Answer_4 = question.Answer_4,

      TopicId = question.TopicId
    };
    return new ApiSuccessResult<QuestionViewModel>(questionView);
  }

  [HttpDelete("deleteById")]
  public async Task<ApiResult<int>> DeleteById([FromForm] string id)
  {
    var question = await _context.Questions.FindAsync(id);
    if (question == null) return new ApiErrorResult<int>("Câu hỏi không tồn tại");
    _context.Remove(question);
    var result = await _context.SaveChangesAsync();
    return new ApiSuccessResult<int>(result);
  }
  [HttpGet("getAll")]
  public async Task<ApiResult<IEnumerable<QuestionViewModel>>> GetAll()
  {
    var questions = await _context.Questions.Select(x => new QuestionViewModel()
    {
      QuestionId = x.QuestionId,
      QuestionString = x.QuestionString,

      Answer_1 = x.Answer_1,
      Answer_2 = x.Answer_2,
      Answer_3 = x.Answer_3,
      Answer_4 = x.Answer_4,

      TopicId = x.TopicId
    }).ToListAsync();
    return new ApiSuccessResult<IEnumerable<QuestionViewModel>>(questions);
  }
  [HttpPost("check_answer")]
  public async Task<ApiResult<List<CheckAnswerViewModel>>> checkQuizzes(List<CheckAnswerRequest> requests)
  {
    List<CheckAnswerViewModel> list = new List<CheckAnswerViewModel>();
    foreach (CheckAnswerRequest request in requests)
    {
      var question = await _context.Questions.FindAsync(request.QuestionId);
      if (question != null)
      {
        if (question.IsCorrect == request.IsCorrect)
        {
          var result = new CheckAnswerViewModel()
          {
            QuestionId = question.QuestionId,
            QuestionString = question.QuestionString,
            Answer = question.IsCorrect,
            AnswerUser = request.IsCorrect,
            IsCorrect = true
          };
          list.Add(result);
        }
        else
        {
          var result = new CheckAnswerViewModel()
          {
            QuestionId = question.QuestionId,
            QuestionString = question.QuestionString,
            Answer = question.IsCorrect,
            AnswerUser = request.IsCorrect,
            IsCorrect = false
          };
          list.Add(result);
        }
      }

    }
    return new ApiSuccessResult<List<CheckAnswerViewModel>>(list);
  }
  [HttpGet("getQuizzes")]
  public async Task<ApiResult<IEnumerable<QuizzesViewModel>>> GetQuizzes(bool isTuluan)
  {
    var quizzes = await _context.Questions.Where(q => q.isTuluan == isTuluan).Select(s => new QuizzesViewModel()
    {
      QuestionString = s.QuestionString,
      Answer_1 = s.Answer_1,
      Answer_2 = s.Answer_2,
      Answer_3 = s.Answer_3,
      Answer_4 = s.Answer_4,
      ImageURL = s.ImageURL,


    }).ToListAsync();
    return new ApiSuccessResult<IEnumerable<QuizzesViewModel>>(quizzes);
  }
  [HttpGet("getByTopicId")]
  public async Task<ApiResult<IEnumerable<QuestionViewModel>>> GetByTopicId(string tpId)
  {
    var quizzes = await _context.Questions.Where(q => q.TopicId == tpId).Select(s => new QuestionViewModel()
    {
      QuestionString = s.QuestionString,
      Answer_1 = s.Answer_1,
      Answer_2 = s.Answer_2,
      Answer_3 = s.Answer_3,
      Answer_4 = s.Answer_4,
      ImageURL = s.ImageURL,


    }).ToListAsync();
    return new ApiSuccessResult<IEnumerable<QuestionViewModel>>(quizzes);
  }
}
