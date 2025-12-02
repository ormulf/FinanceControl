using AutoMapper;
using FinanceControl.Application.DTOs;
using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;

namespace FinanceControl.Application.Services
{
    public class ExpanseService
    {
        private readonly IExpanseRepository _repo;
        private readonly IMapper _mapper;
        public ExpanseService(IExpanseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpanseDto>> GetAllAsync() {
            var ret = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ExpanseDto>>(ret);
        }
        public async Task<ExpanseDto?> GetByIdAsync(string id) {
            var ret = await _repo.GetByIdAsync(id);
            return _mapper.Map<ExpanseDto>(ret);
        }
        public async Task CreateAsync(CreateExpanseDto dto) {
            var entity = _mapper.Map<Expanse>(dto);
            await _repo.AddAsync(entity);
        }
        public async Task UpdateAsync(ExpanseDto dto) {
            await _repo.UpdateAsync(_mapper.Map<Expanse>(dto));
        }

        public async Task DeleteAsync(string id) {
            await _repo.DeleteAsync(id);
        }
        public async Task<IEnumerable<ExpanseDto>> GetByCategoryIdAsync(string categoryId) {
            var ret = await _repo.GetByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<ExpanseDto>>(ret);
        }
        
    }
}
