using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Services.Interfaces;

namespace WebApi.Filters
{
    public class UniqueUserFilter : IAsyncActionFilter
    {

        private readonly ICrudService<User> _service;

        public UniqueUserFilter(ICrudService<User> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var entity = context.ActionArguments["entity"] as User;
            var duplicate = (await _service.ReadAsync()).Where(x => x.Name == entity.Name).SingleOrDefault();

            if (duplicate != null)
            {
                context.ModelState.AddModelError(nameof(Models.User.Name), "Username must be unique");
            }

            //sprawdzenie czy przesłany obiekt jest poprawnie wypełniony
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }


            await next();
        }
    }
}
