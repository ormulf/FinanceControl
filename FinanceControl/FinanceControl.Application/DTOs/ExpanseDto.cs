namespace FinanceControl.Application.DTOs
{
    public class ExpanseDto
    {
        public string? Id { get; set; }
        public string CategoryId { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime When { get; set; }
        public bool IsCreditCard { get; set; }
    }
}

