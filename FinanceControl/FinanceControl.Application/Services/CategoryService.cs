using AutoMapper;
using FinanceControl.Application.DTOs;
using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;


namespace FinanceControl.Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var cat = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(cat);
        }

        public async Task<CategoryDto?> GetByIdAsync(string id)
        {
            var cat = await _repo.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(cat);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _repo.AddAsync(entity);
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task UpdateAsync(CategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id) => await _repo.DeleteAsync(id);
    }
}
