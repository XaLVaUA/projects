using Task6.DAL.EF;
using Task6.DAL.Interfaces.UnitOfWorks;
using Task6.DAL.Repositories;

namespace Task6.DAL.UnitOfWorks
{
    public class StoreUnitOfWork : IStoreUnitOfWork
    {
        private StoreContext _context;

        private ProductRepository _products;

        private CategoryRepository _categories;

        private SupplierRepository _suppliers;

        public ProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_context);
                }

                return _products;
            }
        }

        public CategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(_context);
                }

                return _categories;
            }
        }

        public SupplierRepository Suppliers
        {
            get
            {
                if (_suppliers == null)
                {
                    _suppliers = new SupplierRepository(_context);
                }

                return _suppliers;
            }
        }

        public StoreUnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}