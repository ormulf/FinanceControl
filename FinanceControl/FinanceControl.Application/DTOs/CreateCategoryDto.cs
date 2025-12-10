namespace FinanceControl.Application.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Limit { get; set; }
        public int Type { get; set; }
    }
}
