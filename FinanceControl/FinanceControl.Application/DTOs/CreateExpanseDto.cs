using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Application.DTOs
{
    public class CreateExpanseDto
    {
        public string CategoryId { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string ?Description { get; set; }
        public DateTime When { get; set; }
        public bool IsCreditCard { get; set; }
    }
}
