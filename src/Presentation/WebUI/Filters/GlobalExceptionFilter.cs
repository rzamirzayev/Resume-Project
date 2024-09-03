using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            GenerateHttpResponse(context);
            GenerateAjaxResponse(context);
            Exception ex = context.Exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            Console.WriteLine(ex.Message);

            if ("XMLHttpRequest".Equals(context.HttpContext.Request.Headers["X-Requested-With"]))
            {
                GenerateAjaxResponse(context);
                return;
            }
            GenerateHttpResponse(context);

            
        }

        private void GenerateAjaxResponse(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NullReferenceException:
                case ArgumentNullException:
                    context.Result = new JsonResult(new
                    {
                        error = true,
                        message=context.Exception.Message
                    }); ;
                    break;
            }
        }

        private void GenerateHttpResponse(ExceptionContext context)
        {
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
