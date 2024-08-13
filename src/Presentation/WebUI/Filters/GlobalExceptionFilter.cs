using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            Exception ex = context.Exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            Console.WriteLine(ex.Message);

            switch (context.Exception)
            {
                case NullReferenceException:
                case ArgumentNullException:
                    context.Result = new ContentResult
                    {
                        Content = File.ReadAllText("wwwroot/error-pages/404.html"),
                        ContentType = "text/html",
                        StatusCode = 200
                    };
                    break;
                default:
                    context.Result = new ContentResult
                    {
                        Content = File.ReadAllText("wwwroot/error-pages/404.html"),
                        ContentType = "text/html",
                        StatusCode = 200
                    };
                    break;
            }
        }
    }
}
