using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;

namespace FinanceControl.Application.Services
{
    public class ExpanseService
    {
        private readonly IExpanseRepository _repo;
        public ExpanseService(IExpanseRepository repo) => _repo = repo;

        public async Task<IEnumerable<Expanse>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Expanse?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task CreateAsync(Expanse e) => await _repo.AddAsync(e);
        public async Task UpdateAsync(Expanse e) => await _repo.UpdateAsync(e, e.Id);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
        public async Task<IEnumerable<Expanse>> GetByCategoryIdAsync(int categoryId) => await _repo.GetByCategoryIdAsync(categoryId);
    }
}
