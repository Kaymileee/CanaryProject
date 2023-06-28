using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DANTN.Data.EF;
using DANTN.Models;

namespace DANTN.Applications.Users
{
  public class UserService : IUserService
  {
    private readonly DatabaseContext _context;
    public UserService(DatabaseContext context)
    {
      _context = context;
    }
    public Task<ApiResult<int>> ConfirmEmail(string? Email, int Code)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<int>> Delete(string? Email)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<IEnumerable<UserViewModel>>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<UserViewModel>> GetByEmail(string Email)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<UserViewModel>> GetById(int Id)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<UserViewModel>> Login(LoginRequest request)
    {
      throw new NotImplementedException();
    }

    public Task<ApiResult<int>> Register(RegisterRequest request)
    {

    }
  }
}