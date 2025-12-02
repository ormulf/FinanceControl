namespace FinanceControl.Application.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public float Limit { get; set; }
        public int Type { get; set; }
    }
}
