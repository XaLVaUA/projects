using System.Collections.Generic;
using System.Data.Entity;
using Task5_2.DAL.Entities;

namespace Task5_2.DAL.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private StoreContext _context;

        public SupplierRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers;
        }

        public Supplier GetById(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public void Create(Supplier item)
        {
            _context.Suppliers.Add(item);
        }

        public void Update(Supplier item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _context.Suppliers.Find(id);
            if (item != null)
            {
                _context.Suppliers.Remove(item);
            }
        }
    }
}