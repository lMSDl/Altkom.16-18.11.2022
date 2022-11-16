using Models;
using Services.Interfaces;

namespace WebApi.Controllers
{
    public class UsersController : CrudController<User>
    {
        public UsersController(ICrudService<User> service) : base(service)
        {
        }
    }
}
