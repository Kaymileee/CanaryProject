using DANTN.Helpers;

namespace DANTN.Extensions
{
  public static class MiddlewareExtensions
  {
    public static IApplicationBuilder UseErrorWrapping(
        this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<ErrorWrappingMiddleware>();
    }
  }
}