using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace WebApi.Controllers
{
    public abstract class CrudController<T> : ApiController where T : Entity
    {
        private ICrudService<T> _service;

        public CrudController(ICrudService<T> service)
        {
            _service = service;
        }

        [HttpGet("/api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ReadAsync());
        }

        [HttpGet("/api/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.ReadAsync(id);
            if(result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost("/api/[controller]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<IActionResult> Post(T entity)
        {
            entity = await _service.CreateAsync(entity);

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("/api/[controller]/{id}")]
        [ApiExplorerSettings(IgnoreApi = true)] //pominięcie uwzględniania metody w OpenAPI
        public async Task<IActionResult> Put(int id, T entity)
        {
            var result = await _service.ReadAsync(id);
            if (result == null)
                return NotFound();

            await _service.UpdateAsync(id, entity);

            return NoContent();
        }

        [HttpDelete("/api/[controller]/{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _service.ReadAsync(id);
            if (result == null)
                return NotFound();
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
