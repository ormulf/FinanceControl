using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Application.DTOs
{
    public class CategoryMonthlySummaryListDto
    {
        public decimal TotalExpanses { get; set; }
        public decimal Budget { get; set; }
        public List<CategoryMonthlySummaryDto> Indispensable { get; set; } = new List<CategoryMonthlySummaryDto>();
        public List<CategoryMonthlySummaryDto> Signature { get; set; } = new List<CategoryMonthlySummaryDto>();
        public List<CategoryMonthlySummaryDto> Extra { get; set; } = new List<CategoryMonthlySummaryDto>();
    }
}
