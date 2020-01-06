using System.Collections.Generic;
using System.Data.Entity;
using Task5_2.DAL.Entities;

namespace Task5_2.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _context.Products.Find(id);
            if (item != null)
            {
                _context.Products.Remove(item);
            }
        }
    }
}