using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Models;
using Services.Interfaces;
using WebApi.Filters;
using WebApi.SignalR;

namespace WebApi.Controllers
{
    [ServiceFilter(typeof(ConsoleLogFilter))]
    public class UsersController : CrudController<User>
    {
        private readonly ICrudService<User> _service;
        private readonly IHubContext<DemoHub> _signalR;

        public UsersController(ICrudService<User> service, IHubContext<DemoHub> signalR) : base(service)
        {
            _service = service;
            _signalR = signalR;
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

            var result = await base.Post(entity);

            entity = (User)((CreatedAtActionResult)result).Value!;

            await _signalR.Clients.All.SendAsync("NewUser", entity);

            return result;
        }
    }
}
