using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DANTN.Data.EF;
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

    public async Task<ApiResult<int>> Register(RegisterRequest request)
    {
      var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
      if (user != null) return new ApiErrorResult<int>("User already registered");
      var check_Email = _context.Users.FirstOrDefault(u => u.Email == request.Email);
      if (user != null) return new ApiErrorResult<int>("Email already registered");

    }
  }
}