using System.Collections.Generic;
using Task6.DAL.Models;

namespace Task6.BLL.Models
{
    public class SupplierDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}