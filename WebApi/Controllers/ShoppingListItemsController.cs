using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApi.Controllers
{
    [Route($"api/{nameof(ShoppingList)}s/{{parentId}}/[controller]")]
    public class ShoppingListItemsController : CrudController<ShoppingListItem>
    {
        private readonly IShoppingListItemsService _service;
        public ShoppingListItemsController(IShoppingListItemsService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShoppingListItem>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetColletion(int parentId)
        {
            return Ok(await _service.ReadFromParentAsync(parentId));
        }

        [NonAction] // wyłączenie akcji z obsługi - tak jakby nigdy nie była zaimplementowana w danym kontrolerze
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
