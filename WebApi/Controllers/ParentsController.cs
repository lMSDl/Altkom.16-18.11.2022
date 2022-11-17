using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {

        public IActionResult Get()
        {
            var parent = new Parent();

            parent.Name = "Parent";
            parent.DateTime = DateTime.Now;


            var child = new Child { Name = "Child1", Age = 12, /*Parent = parent*/ };
            
            parent.Children = new List<Child>
            {
                child,
                child,
                child,
                child,
                new Child { Name = "Child2", Age = 15, DefaultNumber = float.NaN }
            };

            return Ok(parent);
        }

    }
}
