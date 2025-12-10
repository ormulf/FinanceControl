using FinanceControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Infrastructure.Mongo.Models
{
    internal class CategoryJoined : Category
    {
        public List<Expanse> Expanses { get; set; } = new();
        public List<Expanse> FilteredExpanses { get; set; } = new();
    }
}
