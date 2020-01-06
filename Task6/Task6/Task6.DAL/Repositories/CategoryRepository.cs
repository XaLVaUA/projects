using System.Collections.Generic;
using System.Linq;
using Task6.DAL.EF;
using Task6.DAL.Interfaces.Repositories;
using Task6.DAL.Models;

namespace Task6.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private StoreContext _context;

        public CategoryRepository(StoreContext context)
        {
            _context = context;
        }

        public Category FindById(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> FindAll()
        {
            return _context.Categories.ToList();
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Update(Category item)
        {
            _context.Categories.Update(item);
        }

        public void Delete(int id)
        {
            var item = _context.Categories.Find(id);
            if (item != null)
            {
                _context.Categories.Remove(item);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}