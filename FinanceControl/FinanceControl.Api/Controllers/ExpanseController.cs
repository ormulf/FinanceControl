using FinanceControl.Application.Services;
using FinanceControl.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpanseController : Controller
    {
        private readonly ExpanseService _service;
        public ExpanseController(ExpanseService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId) => Ok(await _service.GetByCategoryIdAsync(categoryId));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Expanse e)
        {
            await _service.CreateAsync(e);
            return CreatedAtAction(nameof(Get), new { id = e.Id }, e);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Expanse e)
        {
            if (id != e.Id) return BadRequest();
            await _service.UpdateAsync(e);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
