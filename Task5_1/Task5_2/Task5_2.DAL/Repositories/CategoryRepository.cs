using System.Collections.Generic;
using System.Data.Entity;
using Task5_2.DAL.Entities;

namespace Task5_2.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private StoreContext _context;

        public CategoryRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Update(Category item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _context.Categories.Find(id);
            if (item != null)
            {
                _context.Categories.Remove(item);
            }
        }
    }
}