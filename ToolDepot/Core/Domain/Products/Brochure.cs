namespace ToolDepot.Core.Domain.Products
{
    public class Brochure : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Ordinal { get; set; }
        public bool IsActive { get; set; }
    }
}