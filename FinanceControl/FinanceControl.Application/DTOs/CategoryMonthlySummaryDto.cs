using FinanceControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Application.DTOs
{
    public class CategoryMonthlySummaryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Limit { get; set; }
        public CategoryType Type { get; set; }
        public decimal TotalExpanses { get; set; }
    }
}
