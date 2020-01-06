using Task5_2.DAL.Entities;

namespace Task5_2.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDTO Category { get; set; }

        public int SupplierId { get; set; }

        public virtual SupplierDTO Supplier { get; set; }
    }
}