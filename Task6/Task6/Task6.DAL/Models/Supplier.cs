using System.Collections.Generic;

namespace Task6.DAL.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}