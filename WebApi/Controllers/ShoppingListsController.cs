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
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ReadAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.ReadAsync(id);
            if(result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(ShoppingList shoppingList)
        {
            shoppingList = await _service.CreateAsync(shoppingList);

            return CreatedAtAction(nameof(Get), new { id = shoppingList.Id }, shoppingList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ShoppingList shoppingList)
        {
            var result = await _service.ReadAsync(id);
            if (result == null)
                return NotFound();

            await _service.UpdateAsync(id, shoppingList);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.ReadAsync(id);
            if (result == null)
                return NotFound();
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
