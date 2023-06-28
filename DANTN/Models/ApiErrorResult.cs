namespace Models;

public class ApiErrorResult<T> : ApiResult<T>
{
  //public string[] ValidationErrors { get; set; }

  public ApiErrorResult()
  {
  }

  public ApiErrorResult(string message)
  {
    IsSuccess = false;
    Message = message;
  }
}