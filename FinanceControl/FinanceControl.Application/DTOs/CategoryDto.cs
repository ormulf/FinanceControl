namespace FinanceControl.Application.DTOs
{
    public class CategoryDto
    {
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Limit { get; set; }
        public int Type { get; set; }  // enum convertido para int
    }
}
