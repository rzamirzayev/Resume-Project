using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebUI.Filters
{
    public class ValidationActionFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = new ViewResult
                {
                    ViewName = context.RouteData.Values["action"]?.ToString(),
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState),
                };

                context.Result = result;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}