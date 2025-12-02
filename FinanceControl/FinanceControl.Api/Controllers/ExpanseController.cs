using FinanceControl.Application.DTOs;
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
        public async Task<IActionResult> Get(string id) => Ok(await _service.GetByIdAsync(id));

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(string categoryId) => Ok(await _service.GetByCategoryIdAsync(categoryId));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateExpanseDto e)
        {
            await _service.CreateAsync(e);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ExpanseDto e)
        {
            if (id != e.Id) return BadRequest();
            await _service.UpdateAsync(e);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
