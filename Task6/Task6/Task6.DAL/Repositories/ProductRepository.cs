using System.Collections.Generic;
using System.Linq;
using Task6.DAL.EF;
using Task6.DAL.Interfaces.Repositories;
using Task6.DAL.Models;

namespace Task6.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public Product FindById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> FindAll()
        {
            return _context.Products.ToList();
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
        }

        public void Delete(int id)
        {
            var item = _context.Products.Find(id);
            if (item != null)
            {
                _context.Products.Remove(item);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}