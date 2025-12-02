using FinanceControl.Application.DTOs;
using FinanceControl.Application.Services;
using FinanceControl.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        public CategoryController(CategoryService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CategoryDto c)
        {
            if (id != c.Id) return BadRequest();
            await _service.UpdateAsync(c);
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
