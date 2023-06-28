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

namespace DANTN.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VocabulariesController : ControllerBase
  {
    private readonly DatabaseContext _context;
    private readonly IFileStorageService _fileService;
    private const string USER_CONTENT_FOLDER_NAME = "user-content";
    public VocabulariesController(DatabaseContext context, IFileStorageService fileService)
    {
      _context = context;
      _fileService = fileService;
    }
    [HttpGet("getAllVocabularies")]
    public async Task<ApiResult<IEnumerable<VocabularyViewModel>>> GetAll()
    {
      var vocViewModels = await _context.Vocabularies.Select(x => new VocabularyViewModel()
      {
        VocId = x.VocId,
        TopicId = x.TopicId,
        WordVoc = x.WordVoc,
        vocIPA = x.vocIPA
      }).ToListAsync();
      return new ApiSuccessResult<IEnumerable<VocabularyViewModel>>(vocViewModels);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<VocabularyViewModel>> GetById(int id)
    {
      var vocabulary = await _context.Vocabularies.FindAsync(id);

      if (vocabulary == null)
      {
        return new ApiErrorResult<VocabularyViewModel>($"Vocabulary with ID {id} not found");
      }

      var vocabularyViewModel = new VocabularyViewModel()
      {
        TopicId = vocabulary.TopicId,
        WordVoc = vocabulary.WordVoc,
        vocIPA = vocabulary.vocIPA
      };

      return new ApiSuccessResult<VocabularyViewModel>(vocabularyViewModel);
    }


    [HttpPost("addVocabulary")]
    public async Task<IActionResult> AddVoc([FromForm] VocabularyRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (string.IsNullOrEmpty(request.WordVoc)) return BadRequest(new ApiBadRequestResponse("Please enter a Word Vocabulary"));
      if (string.IsNullOrEmpty(request.level.ToString())) return BadRequest(new ApiBadRequestResponse("Please enter a Level"));
      if (string.IsNullOrEmpty(request.TopicId)) return BadRequest(new ApiBadRequestResponse("Please enter a Topic ID"));
      if (string.IsNullOrEmpty(request.typeVoc)) return BadRequest(new ApiBadRequestResponse("Please enter a Type Vocabulary"));

      if (string.IsNullOrEmpty(request.vocExample)) return BadRequest(new ApiBadRequestResponse("Please enter a Example of Vocabulary"));
      if (string.IsNullOrEmpty(request.vocIPA)) return BadRequest(new ApiBadRequestResponse("Please enter a IPA Vocabulary"));
      var newVocabulary = new Vocabulary();
      newVocabulary.level = 1;
      newVocabulary.TopicId = request.TopicId;
      newVocabulary.typeVoc = request.typeVoc;
      newVocabulary.vocExample = request.vocExample;
      newVocabulary.vocImgUrl = request.vocImgUrl;
      newVocabulary.vocIPA = request.vocIPA;
      newVocabulary.WordVoc = request.WordVoc;

      _context.Vocabularies.Add(newVocabulary);


      var result = await _context.SaveChangesAsync();
      if (result > 0)
      {

        // code : 201
        return CreatedAtAction(nameof(GetById), new { id = newVocabulary.VocId }, request);
      }
      return BadRequest(new ApiBadRequestResponse("not created failed"));


    }

    [HttpGet("getVocablariesByTopicId")]
    public async Task<ApiResult<IEnumerable<VocabularyViewModel>>> GetVocabulariesByTopicId(string topicId)
    {
      var vocabularies = await _context.Vocabularies.Where(v => v.TopicId == topicId).Select(x => new VocabularyViewModel()
      {
        VocId = x.VocId,
        TopicId = x.TopicId,
        WordVoc = x.WordVoc,
        vocIPA = x.vocIPA,
        level = x.level,
        typeVoc = x.typeVoc,
        vocImgUrl = x.vocImgUrl,
        vocExample = x.vocExample
      }).ToListAsync();
      return new ApiSuccessResult<IEnumerable<VocabularyViewModel>>(vocabularies);
    }
  }

}