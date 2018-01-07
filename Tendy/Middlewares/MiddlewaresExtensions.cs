using Microsoft.AspNetCore.Builder;

namespace Tendy.Middlewares
{
  public static class MiddlewaresExtensions
  {
    /// <summary>
    /// Use global error handling as middleware
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<GlobalErrorHandling>();
    }
  }
}
