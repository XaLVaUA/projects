namespace Task6.BLL.Models
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public virtual CategoryDto Category { get; set; }

        public int? SupplierId { get; set; }

        public virtual SupplierDto Supplier { get; set; }
    }
}