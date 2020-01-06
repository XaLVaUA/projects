using System.Collections.Generic;
using System.Linq;
using Task6.DAL.EF;
using Task6.DAL.Interfaces.Repositories;
using Task6.DAL.Models;

namespace Task6.DAL.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private StoreContext _context;

        public SupplierRepository(StoreContext context)
        {
            _context = context;
        }

        public Supplier FindById(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> FindAll()
        {
            return _context.Suppliers.ToList();
        }

        public void Create(Supplier item)
        {
            _context.Suppliers.Add(item);
        }

        public void Update(Supplier item)
        {
            _context.Suppliers.Update(item);
        }

        public void Delete(int id)
        {
            var item = _context.Suppliers.Find(id);
            if (item != null)
            {
                _context.Suppliers.Remove(item);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}