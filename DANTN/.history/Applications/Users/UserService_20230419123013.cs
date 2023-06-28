using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DANTN.Data.EF;
using DANTN.Data.Entities;
using DANTN.Models;

namespace DANTN.Applications.Users
{
  public async class UserService : IUserService
  {
    private readonly DatabaseContext _context;
    public async UserService(DatabaseContext context)
    {
      _context = context;
    }
    public async Task<ApiResult<int>> ConfirmEmail(string? Email, int Code)
    {
      throw new NotImplementedException();
    }

    public async Task<ApiResult<int>> Delete(string? Email)
    {
      throw new NotImplementedException();
    }

    public async Task<ApiResult<IEnumerable<UserViewModel>>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<ApiResult<UserViewModel>> GetByEmail(string Email)
    {
      throw new NotImplementedException();
    }

    public async Task<ApiResult<UserViewModel>> GetById(int Id)
    {
      throw new NotImplementedException();
    }

    public async Task<ApiResult<UserViewModel>> Login(LoginRequest request)
    {
      throw new NotImplementedException();
    }

    public async Task<ApiResult<User>> Register(RegisterRequest request)
    {
      if (request.Email == null) return new ApiErrorResult<User>("Please enter your email");
      if (request.Password == null) return new ApiErrorResult<User>("Please enter your password");
      if (request.PasswordCF == null) return new ApiErrorResult<User>("Please enter your password confirm");
      if (request.FirstName == null) return new ApiErrorResult<User>("Please enter your first name");
      if (request.LastName == null) return new ApiErrorResult<User>("Please enter your last name");
      var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
      if (user != null) return new ApiErrorResult<User>("User already registered");
      var check_Email = _context.Users.FirstOrDefault(u => u.Email == request.Email);
      if (user != null) return new ApiErrorResult<User>("Email already registered");
      if (!request.Password.Equals(request.PasswordCF)) return new ApiErrorResult<User>("Confirmation password does not match");
    }
  }
}