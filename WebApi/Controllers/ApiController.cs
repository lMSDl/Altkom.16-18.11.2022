using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v2/[controller]")] //adnotacje są dziedziczone
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
    }
}
