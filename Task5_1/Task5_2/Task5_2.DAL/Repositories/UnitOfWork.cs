namespace Task5_2.DAL.Repositories
{
    public class UnitOfWork
    {
        private StoreContext _context;

        private ProductRepository _productRepository;

        private CategoryRepository _categoryRepository;
        
        private SupplierRepository _supplierRepository;

        public ProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }

                return _productRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }

                return _categoryRepository;
            }
        }

        public SupplierRepository SupplierRepository
        {
            get
            {
                if (_supplierRepository == null)
                {
                    _supplierRepository = new SupplierRepository(_context);
                }

                return _supplierRepository;
            }
        }

        public UnitOfWork(string connectionString)
        {
            _context = new StoreContext(connectionString);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}