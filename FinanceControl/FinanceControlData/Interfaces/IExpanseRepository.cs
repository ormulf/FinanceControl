using FinanceControl.Domain.Entities;

namespace FinanceControl.Domain.Interfaces
{
    public interface IExpanseRepository : IRepositoryBase<Expanse>
    {
        Task<IEnumerable<Expanse>> GetByCategoryIdAsync(string categoryId);
    }
}
