namespace Task5_1.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }
    }
}