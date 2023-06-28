using System.ComponentModel.DataAnnotations;

namespace DANTN.Models;

public class RegisterRequest
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public DateTime Dob { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; }
  public string? PasswordCF { get; set; }
}

public class LoginRequest
{
  public string? UserName { get; set; }
  public string? Password { get; set; }
}

public class ConfirmEmailRequest
{
  public string? Email { get; set; }
  public string? Code { get; set; }
}

public class UserViewModel
{
  public Guid UserId { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? UserName { get; set; }

  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
  public DateTime Dob { get; set; }
  public DateTime DateTimeCreated { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
  public string? Avatar { get; set; }
  public int? LevelId { get; set; }
  public int? LevelName { get; set; }



}

public class ResetPasswordRequest
{
  public string? Email { get; set; }
  public string? Code { get; set; }
  public string? Password { get; set; }
  public string? PasswordCF { get; set; }
}

public class ChangePasswordRequest
{
  public string? Email { get; set; }
  public string? CurrentPassword { get; set; }
  public string? Password { get; set; }
  public string? PasswordCF { get; set; }
}

public class ChangePhoneNumberRequest
{
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}

public class UploadAvatarRequest
{
  public string? UserName { get; set; }
  public IFormFile? ImageFile { get; set; }
}
