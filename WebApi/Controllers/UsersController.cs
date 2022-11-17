using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Services.Interfaces;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ServiceFilter(typeof(ConsoleLogFilter))]
    public class UsersController : CrudController<User>
    {
        private readonly ICrudService<User> _service;

        public UsersController(ICrudService<User> service) : base(service)
        {
            _service = service;
        }

        [ServiceFilter(typeof(UniqueUserFilter))]
        public override async Task<IActionResult> Post(User entity)
        {
           /* var duplicate = (await _service.ReadAsync()).Where(x => x.Name == entity.Name).SingleOrDefault();

            if (duplicate != null)
            {
                ModelState.AddModelError(nameof(Models.User.Name), "Username must be unique");
            }

            //sprawdzenie czy przesłany obiekt jest poprawnie wypełniony
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            return await base.Post(entity);
        }
    }
}
