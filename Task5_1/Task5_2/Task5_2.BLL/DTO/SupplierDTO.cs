using System.Collections.Generic;

namespace Task5_2.BLL.DTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}