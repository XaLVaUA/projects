using System.Collections.Generic;

namespace Task6.BLL.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}