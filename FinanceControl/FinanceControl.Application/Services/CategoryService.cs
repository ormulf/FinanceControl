using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;


namespace FinanceControl.Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo) => _repo = repo;

        public async Task<IEnumerable<Category>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Category?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task CreateAsync(Category c) => await _repo.AddAsync(c);
        public async Task UpdateAsync(Category c) => await _repo.UpdateAsync(c,c.Id);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
