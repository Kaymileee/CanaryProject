using DANTN.Data.EF;
using DANTN.Data.Entities;
using DANTN.Helpers;
using DANTN.Models;
using DANTN.Utils;
using DANTN.Utils.FileStorages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DANTN.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicsController : ControllerBase
{
  private readonly DatabaseContext _context;
  private readonly IFileStorageService _fileService;
  private const string USER_CONTENT_FOLDER_NAME = "user-content";

  public TopicsController(DatabaseContext context, IFileStorageService fileService)
  {
    _context = context;
    _fileService = fileService;
  }

  [HttpGet("getAllTopics")]
  public async Task<ApiResult<IEnumerable<TopicViewModel>>> GetAll()
  {
    var topicViewModels = await _context.Topics.Select(x => new TopicViewModel()
    {
      TopicId = x.TopicId,
      NameTopic = x.NameTopic,

      TopicDesc = x.TopicDesc,
      TopicImage = x.TopicImage,



    }).ToListAsync();
    return new ApiSuccessResult<IEnumerable<TopicViewModel>>(topicViewModels);
  }
  [HttpGet("getTopicsByLevel")]
  public async Task<ApiResult<IEnumerable<TopicViewModelLevel>>> GetByLevel(int levelId)
  {
    var getlevel = await _context.Levels.FindAsync(levelId);

    var topicByLevel = await _context.Topics.FindAsync(getlevel.LevelName);

    var query = from j in _context.Topics
                where j.TopicId == topicByLevel.TopicId
                select new { j };

    var topic = await query
                .Select(x => new TopicViewModelLevel()
                {
                  TopicId = x.j.TopicId,
                  NameTopic = x.j.NameTopic,
                  TopicDesc = x.j.TopicDesc,
                  TopicImage = x.j.TopicImage,
                  LevelName = x.j.Level.LevelName
                }).ToListAsync();
    // var topicViewModels = await _context.Topics.Select(x => new TopicViewModelLevel()
    // {
    //   TopicId = x.TopicId,
    //   NameTopic = x.NameTopic,

    //   TopicDesc = x.TopicDesc,
    //   TopicImage = x.TopicImage,



    // }).ToListAsync();
    return new ApiSuccessResult<IEnumerable<TopicViewModelLevel>>(topic.ToList());

  }
  [HttpPost("addTopic")]
  public async Task<IActionResult> AddTopic([FromForm] AddTopicRequest request)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var topicId = await _context.Topics.FirstOrDefaultAsync(u => u.TopicId == request.TopicId);
    if (topicId != null) return BadRequest(new ApiBadRequestResponse("topicId already registered"));



    if (string.IsNullOrEmpty(request.NameTopic)) return BadRequest(new ApiBadRequestResponse("Please enter a email"));
    if (request.TopicImage == null) return BadRequest(new ApiBadRequestResponse("Please input an image file"));
    var newTopic = new Topic();
    newTopic.TopicImage = await _fileService.SaveFile(request.TopicImage);

    newTopic.TopicId = request.TopicId;
    newTopic.NameTopic = request.NameTopic;
    newTopic.ParentID = request.ParentID;
    newTopic.TopicAlias = request.TopicAlias;
    newTopic.TopicDesc = request.TopicDesc;

    newTopic.ViewCount = 0;




    _context.Topics.Add(newTopic);
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {

      // code : 201
      return CreatedAtAction(nameof(GetById), new { id = newTopic.TopicId }, request);
    }
    return BadRequest(new ApiBadRequestResponse("not created failed"));


  }
  [HttpGet("getById")]
  public async Task<ApiResult<TopicViewModel>> GetById(string id)
  {
    var topic = await _context.Topics.FirstOrDefaultAsync(x => x.TopicId == id);
    if (topic == null) return new ApiErrorResult<TopicViewModel>("Danh mục không tồn tại");
    var topicViewModel = new TopicViewModel()
    {
      TopicId = topic.TopicId,
      NameTopic = topic.NameTopic,
      TopicDesc = topic.TopicDesc
    };
    return new ApiSuccessResult<TopicViewModel>(topicViewModel);
  }

  [HttpDelete("deleteById")]
  public async Task<ApiResult<int>> DeleteById([FromForm] string id)
  {
    var topic = await _context.Topics.FindAsync(id);
    if (topic == null) return new ApiErrorResult<int>("Chủ đề không tồn tại");
    _context.Remove(topic);
    var result = await _context.SaveChangesAsync();
    return new ApiSuccessResult<int>(result);
  }
  [HttpPost("UpdateById")]
  public async Task<ApiResult<int>> UpdateById([FromBody] TopicViewModel request)
  {
    var topic = await _context.Topics.FindAsync(request.TopicId);
    if (topic == null) return new ApiErrorResult<int>("Chủ đề không tồn tại");
    if (string.IsNullOrEmpty(request.NameTopic) || string.IsNullOrWhiteSpace(request.NameTopic)) return new ApiErrorResult<int>("Vui lòng nhập tên chủ đề");

    topic.NameTopic = request.NameTopic;
    topic.TopicDesc = request.TopicDesc;
    var result = await _context.SaveChangesAsync();
    return new ApiSuccessResult<int>(result);
  }
}
