using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Task5_1.DAL;
using Task5_1.DAL.Entities;

namespace Task5_1.BLL.Services
{
    public class ProductService
    {
        private UnitOfWork _unitOfWork;

        public ProductService(string connectionString)
        {
            _unitOfWork = new UnitOfWork(connectionString);
        }

        public ICollection<Product> GetProductsByCategory(string categoryName)
        {
            var products = _unitOfWork.ProductGateway.FindAll();
            var categories = _unitOfWork.CategoryGateway.FindAll();

            var productsByCategory =
                from product in products
                join category in categories on product.CategoryId equals category.Id
                where category.Name == categoryName
                select product;

            return productsByCategory.ToList();
        }

        public ICollection<Product> GetProductsBySupplier(string supplierName)
        {
            var products = _unitOfWork.ProductGateway.FindAll();
            var suppliers = _unitOfWork.SupplierGateway.FindAll();

            var productsByCategory =
                from product in products
                join supplier in suppliers on product.CategoryId equals supplier.Id
                where supplier.Name == supplierName
                select product;

            return productsByCategory.ToList();
        }

        public ICollection<Supplier> GetSuppliersByCategory(string categoryName)
        {
            var suppliersByCategory = _unitOfWork.SupplierGateway.FindByCategory(categoryName);

            return suppliersByCategory;
        }

        public ICollection<Supplier> GetSuppliersWithProductsInMaxCategoryCount()
        {
            var suppliersResult = new Collection<Supplier>();

            var suppliers = _unitOfWork.SupplierGateway.FindAll();
            var categories = _unitOfWork.CategoryGateway.FindAll();
            var products = _unitOfWork.ProductGateway.FindAll();

            var productsCategoriesSuppliers =
                from product in products
                join category in categories on product.CategoryId equals category.Id
                join supplier in suppliers on product.SupplierId equals supplier.Id
                select new { product, category, supplier };

            var suppliersWithCount = new Collection<KeyValuePair<Supplier, int>>();
            var max = 0;
            foreach (var supplier in suppliers)
            {
                var curCount = 0;
                foreach (var category in categories)
                {
                    foreach (var item in productsCategoriesSuppliers)
                    {
                        if (item.category.Equals(category) && item.supplier.Equals(supplier))
                        {
                            ++curCount;
                            break;
                        }
                    }
                }

                if (curCount > max)
                {
                    max = curCount;
                }

                suppliersWithCount.Add(new KeyValuePair<Supplier, int>(supplier, curCount));
            }

            foreach (var pair in suppliersWithCount)
            {
                if (pair.Value == max)
                {
                    suppliersResult.Add(pair.Key);
                }
            }

            return suppliersResult;
        }
    }
}