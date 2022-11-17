using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ModelStateLoggerFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();

            if(!context.ModelState.IsValid)
                Console.WriteLine(string.Join("\n", context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
        }
    }
}
