using FinanceControl.Domain.Entities;
using FinanceControl.Domain.ReadModel;

namespace FinanceControl.Domain.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<IEnumerable<CategoryMonthlySummaryReadModel>> GetCategorySummaryAsync(DateTime monthToReport);
    }
}
