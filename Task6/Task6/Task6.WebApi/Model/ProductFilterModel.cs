namespace Task6.WebApi.Model
{
    public class ProductFilterModel
    {
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }
    }
}