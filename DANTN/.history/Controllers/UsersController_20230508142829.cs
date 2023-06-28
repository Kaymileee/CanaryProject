using DANTN.Data.EF;
using DANTN.Data.Entities;
using DANTN.Helpers;
using DANTN.Models;
using DANTN.Utils;
using DANTN.Utils.FileStorages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DANTN.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
  private readonly DatabaseContext _context;
  private readonly IFileStorageService _fileService;
  private const string USER_CONTENT_FOLDER_NAME = "user-content";

  public UsersController(DatabaseContext context, IFileStorageService fileService)
  {
    _context = context;
    _fileService = fileService;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
    if (user != null) return BadRequest(new ApiBadRequestResponse("User already registered"));

    var checkEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
    if (user != null) return BadRequest(new ApiBadRequestResponse("Email already registered"));

    if (string.IsNullOrEmpty(request.Email)) return BadRequest(new ApiBadRequestResponse("Please enter a email"));

    if (string.IsNullOrEmpty(request.UserName))
      request.UserName = request.Email;

    if (string.IsNullOrEmpty(request.Password)) return BadRequest(new ApiBadRequestResponse("Please enter a password"));

    if (!request.Password.Equals(request.PasswordCF)) return BadRequest(new ApiBadRequestResponse("Confirmation password does not match"));

    var newUser = new User();
    newUser.FirstName = request.FirstName;
    newUser.LastName = request.LastName;
    newUser.Dob = request.Dob;
    newUser.LevelId = 0;
    newUser.UserName = SystemVariable.RemoveUnicode_ToLower(request.UserName);
    newUser.Email = request.Email;
    newUser.PasswordHash = MD5Encrypt.Encrypt(request.Password);
    string code = SystemVariable.GetRanDomCodeInt(5);
    newUser.Code = code;
    newUser.DateTimeCreated = DateTime.Now;

    _context.Users.Add(newUser);

    var result = await _context.SaveChangesAsync();

    if (result > 0)
    {
      SendMail.SendEmail(request.Email, "Dương Thành Phết",
            $"<!DOCTYPE html>\n" +
            $"<html lang=\"en\">\n" +
            $"<head>\n" +
            $"<meta charset=\"utf-8\" />\n" +
            $"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />\n" +
            $"<link\n" +
            $"href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css\"\n" +
            $"rel=\"stylesheet\"\n      " +
            $"integrity=\"sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65\"\n" +
            $"crossorigin=\"anonymous\"\n/>\n" +
            $"</head>\n" +
            $"<body class=\"container\">\n\n" +
            $"<h1>Xác nhận tài khoản</h1>\n" +
            $"<p>Bạn vừa gửi yêu cầu đăng ký tài khoản.</p>\n" +
            $"<p>Bạn vui lòng xác nhận tài khoản trước khi tiến hành đăng nhập.</p>\n" +
            $"<b class=\"text-danger\">Code: {code}</b>\n" +
            $"</body>\n" +
            $"</html>\n", "");
      // code : 201
      return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, request);
    }
    return BadRequest(new ApiBadRequestResponse("Register failed"));
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    if (string.IsNullOrEmpty(request.UserName)) return BadRequest(new ApiBadRequestResponse("Please enter a username"));

    if (string.IsNullOrEmpty(request.Password)) return BadRequest(new ApiBadRequestResponse("Please enter a password"));
    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == SystemVariable.RemoveUnicode_ToLower(request.UserName));
    if (user == null) return BadRequest(new ApiBadRequestResponse("Account does not exist"));

    var check_Password = await _context.Users.FirstOrDefaultAsync(u => u.UserName == SystemVariable.RemoveUnicode_ToLower(request.UserName) && u.PasswordHash == MD5Encrypt.Encrypt(request.Password));
    if (check_Password == null) return BadRequest(new ApiBadRequestResponse("Password is not match"));



    var getLevelName = _context.Levels.FirstOrDefault(x => x.LevelId == user.LevelId);

    var userViewModel = new UserViewModel()
    {
      UserId = user.UserId,
      UserName = user.UserName,
      Dob = user.Dob,
      Email = user.Email,
      PhoneNumber = user.PhoneNumber,
      FirstName = user.FirstName,
      LastName = user.LastName,
      DateTimeCreated = user.DateTimeCreated,
      LevelId = user.LevelId,
      Avatar = user.Avatar,
      LevelName = getLevelName.LevelName
    };
    return Ok(userViewModel);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUserById(Guid id)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    if (user == null)
      return NotFound(new ApiNotFoundResponse($"Cannot found user with id: {id}"));

    var userViewModel = new UserViewModel()
    {
      UserId = user.UserId,
      UserName = user.UserName,
      Dob = user.Dob,
      Email = user.Email,
      PhoneNumber = user.PhoneNumber,
      FirstName = user.FirstName,
      LastName = user.LastName,
      DateTimeCreated = user.DateTimeCreated
    };
    return Ok(userViewModel);
  }

  [HttpPost("confirmEmail")]
  public async Task<IActionResult> ConFirmEmail(ConfirmEmailRequest request)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
    if (user == null)
    {
      return NotFound(new ApiNotFoundResponse($"Cannot found user with email: {request.Email}"));
    }
    var check_code = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.Code == request.Code);
    if (check_code == null)
    {
      return BadRequest(new ApiBadRequestResponse("Code is not match"));
    }

    user.EmailConfirm = true;
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return NoContent();
    }
    return BadRequest(new ApiBadRequestResponse("Email has been confirmed"));
  }
  [HttpPost("resendCode")]
  public async Task<IActionResult> ResendCode(string email)
  {
    if (string.IsNullOrEmpty(email)) return BadRequest(new ApiBadRequestResponse("Please enter email"));
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email != null && u.Email.Equals(email));
    if (user == null) return NotFound(new ApiNotFoundResponse($"Cannot found user with {email} ")); ;
    string code = SystemVariable.GetRanDomCodeInt(5);

    user.Code = code;
    var result = await _context.SaveChangesAsync();

    if (result > 0)
    {
      SendMail.SendEmail(email, "Daisy Study",
            $"<!DOCTYPE html>\n" +
            $"<html lang=\"en\">\n" +
            $"<head>\n" +
            $"<meta charset=\"utf-8\" />\n" +
            $"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />\n" +
            $"<link\n" +
            $"href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css\"\n" +
            $"rel=\"stylesheet\"\n      " +
            $"integrity=\"sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65\"\n" +
            $"crossorigin=\"anonymous\"\n/>\n" +
            $"</head>\n" +
            $"<body class=\"container\">\n\n" +
            $"<h1>Xác nhận tài khoản</h1>\n" +
            $"<p>Bạn vừa gửi yêu cầu xác thực tài khoản.</p>\n" +
            $"<p>Bạn vui lòng xác nhận tài khoản trước khi tiến hành đăng nhập.</p>\n" +
            $"<b class=\"text-danger\">Code: {code}</b>\n" +
            $"</body>\n" +
            $"</html>\n", "");
      // code : 204
      return NoContent();
    }
    return BadRequest(new ApiBadRequestResponse("Resend code failed"));


  }
  [HttpPost("forgotPassword")]
  public async Task<IActionResult> ForgotPassword(string email)
  {
    if (string.IsNullOrEmpty(email)) return BadRequest(new ApiBadRequestResponse("Please enter email"));
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email != null && u.Email.Contains(email));
    if (user == null) return NotFound(new ApiNotFoundResponse($"Cannot found user with {email} ")); ;
    string code = SystemVariable.GetRanDomCodeInt(5);

    user.Code = code;
    var result = await _context.SaveChangesAsync();

    if (result > 0)
    {
      SendMail.SendEmail(email, "Duong Thanh Phet",
            $"<!DOCTYPE html>\n" +
            $"<html lang=\"en\">\n" +
            $"<head>\n" +
            $"<meta charset=\"utf-8\" />\n" +
            $"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />\n" +
            $"<link\n" +
            $"href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css\"\n" +
            $"rel=\"stylesheet\"\n      " +
            $"integrity=\"sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65\"\n" +
            $"crossorigin=\"anonymous\"\n/>\n" +
            $"</head>\n" +
            $"<body class=\"container\">\n\n" +
            $"<h1>Bạn quên mật khẩu ? </h1>\n" +
            $"<p>Bạn vừa gửi yêu cầu đặt lại mật khẩu.</p>\n" +
            $"<b class=\"text-danger\">Code: {code}</b>\n" +
            $"</body>\n" +
            $"</html>\n", "");
      // code : 204
      return NoContent();
    }
    return BadRequest(new ApiBadRequestResponse("Resend code failed"));

  }

  [HttpPost("resetPassword")]
  public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
    if (user == null)
    {
      return NotFound(new ApiNotFoundResponse($"Cannot found user with email: {request.Email}"));
    }
    var check_code = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.Code == request.Code);
    if (check_code == null)
    {
      return NotFound(new ApiNotFoundResponse("Code is not match"));
    }
    if (string.IsNullOrEmpty(request.Password)) return BadRequest(new ApiBadRequestResponse("Please enter a password"));

    if (!request.Password.Equals(request.PasswordCF)) return BadRequest(new ApiBadRequestResponse("Confirmation password does not match"));
    user.PasswordHash = MD5Encrypt.Encrypt(request.Password);
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return NoContent();
    }
    return BadRequest(new ApiBadRequestResponse("Reset password failed"));
  }

  [HttpPost("changePassword")]
  public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
    if (user == null)
    {
      return NotFound(new ApiNotFoundResponse($"Cannot found user with email: {request.Email}"));
    }
    if (string.IsNullOrEmpty(request.CurrentPassword)) return BadRequest(new ApiBadRequestResponse("Please enter a current password"));

    var check_code = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.PasswordHash == MD5Encrypt.Encrypt(request.CurrentPassword));
    if (check_code == null)
    {
      return NotFound(new ApiNotFoundResponse("Code is not match"));
    }
    if (string.IsNullOrEmpty(request.Password)) return BadRequest(new ApiBadRequestResponse("Please enter a new password"));

    if (!request.Password.Equals(request.PasswordCF)) return BadRequest(new ApiBadRequestResponse("Confirmation password does not match"));

    user.PasswordHash = MD5Encrypt.Encrypt(request.Password);
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return NoContent();
    }
    return BadRequest(new ApiBadRequestResponse("Change password failed"));
  }

  [HttpPost("changePhoneNumer")]
  public async Task<IActionResult> ChangePhoneNumer(ChangePhoneNumberRequest request)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
    if (user == null)
    {
      return NotFound(new ApiNotFoundResponse($"Cannot found user with email: {request.Email}"));
    }
    if (string.IsNullOrEmpty(request.PhoneNumber)) return BadRequest(new ApiBadRequestResponse("Please enter a current password"));

    user.PhoneNumber = request.PhoneNumber;
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return NoContent();
    }
    return BadRequest(new ApiBadRequestResponse("Change phone number failed"));
  }

  [HttpPost("uploadAvatar")]
  public async Task<IActionResult> UploadAvatar([FromForm] UploadAvatarRequest request)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
    if (user == null)
    {
      return NotFound(new ApiNotFoundResponse($"Cannot found user with email: {request.UserName}"));
    }

    if (request.ImageFile == null) return BadRequest(new ApiBadRequestResponse("Please input an image file"));


    user.Avatar = await _fileService.SaveFile(request.ImageFile);
    var result = await _context.SaveChangesAsync();
    if (result > 0)
    {
      return NoContent();
    }
    return BadRequest(new ApiBadRequestResponse("Upload avatar failed"));
  }


}