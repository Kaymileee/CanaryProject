using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DANTN.Models;

namespace DANTN.Applications.Users
{
  public interface IUserService
  {
    Task<ApiResult<int>> Register(RegisterRequest request);
    Task<ApiResult<int>> ConfirmEmail(string? Email, int Code);
    Task<ApiResult<int>> Delete(string? Email);
    Task<ApiResult<UserViewModel>> Login(LoginRequest request);
    Task<ApiResult<IEnumerable<UserViewModel>>> GetAll();
    Task<ApiResult<UserViewModel>> GetByEmail(string Email);
    Task<ApiResult<UserViewModel>> GetById(int Id);
  }
}