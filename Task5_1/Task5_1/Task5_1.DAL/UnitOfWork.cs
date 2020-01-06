using System.Data.SqlClient;
using Task5_1.DAL.TableDataGateways;

namespace Task5_1.DAL
{
    public class UnitOfWork
    {
        private string _connectionString;

        private ProductGateway _productGateway;

        private SupplierGateway _supplierGateway;

        private CategoryGateway _categoryGateway;

        public ProductGateway ProductGateway
        {
            get
            {
                if (_productGateway == null)
                {
                    _productGateway = new ProductGateway(_connectionString);
                }

                return _productGateway;
            }
        }

        public SupplierGateway SupplierGateway
        {
            get
            {
                if (_supplierGateway == null)
                {
                    _supplierGateway = new SupplierGateway(_connectionString);
                }

                return _supplierGateway;
            }
        }

        public CategoryGateway CategoryGateway
        {
            get
            {
                if (_categoryGateway == null)
                {
                    _categoryGateway = new CategoryGateway(_connectionString);
                }

                return _categoryGateway;
            }
        }

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}