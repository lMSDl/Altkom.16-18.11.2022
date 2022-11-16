using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace WebApi.Controllers
{
    public class ShoppingListsController : ApiController
    {
        private IShoppingListService _service;

        public ShoppingListsController(IShoppingListService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<ShoppingList>> Get()
        {
            return _service.ReadAsync();
        }

        [HttpGet("{id}")]
        public Task<ShoppingList?> Get(int id)
        {
            var result = _service.ReadAsync(id);

            return result;
        }
    }
}
