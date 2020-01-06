using System;
using System.Configuration;
using Task5_1.BLL.Services;

namespace Task5_1.ConsoleApp
{
    public class Demonstrator
    {
        private ProductService _productService;

        public void Start()
        {
            Init();
            DemonstrateAll();
            Console.ReadLine();
        }

        private void Init()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _productService = new ProductService(connectionString);
        }

        private void DemonstrateAll()
        {
            DemonstrateProductsByCategory();
            Console.WriteLine();
            DemonstrateProductsBySupplier();
            Console.WriteLine();
            DemonstrateSuppliersByCategory();
            Console.WriteLine();
            DemonstrateSuppliersWithProductsInMaxCategoryCount();
        }

        private void DemonstrateProductsByCategory()
        {
            Console.Write("Get products by category\nCategory name: ");
            var categoryName = Console.ReadLine();
            var productsByCategory = _productService.GetProductsByCategory(categoryName);
            foreach (var product in productsByCategory)
            {
                Console.Write(product.Name + " | ");
            }
            Console.WriteLine();
        }

        private void DemonstrateProductsBySupplier()
        {
            Console.Write("Get products by supplier\nSupplier name: ");
            var supplierName = Console.ReadLine();
            var productsBySupplier = _productService.GetProductsBySupplier(supplierName);
            foreach (var product in productsBySupplier)
            {
                Console.Write(product.Name + " ");
            }
            Console.WriteLine();
        }

        private void DemonstrateSuppliersByCategory()
        {
            Console.Write("Get suppliers by category\nCategory name: ");
            var categoryName = Console.ReadLine();
            var suppliersByCategory = _productService.GetSuppliersByCategory(categoryName);
            foreach (var supplier in suppliersByCategory)
            {
                Console.Write(supplier.Name + " ");
            }
            Console.WriteLine();
        }

        private void DemonstrateSuppliersWithProductsInMaxCategoryCount()
        {
            Console.Write("Get suppliers with products in max category count\n");
            var suppliers = _productService.GetSuppliersWithProductsInMaxCategoryCount();
            foreach (var supplier in suppliers)
            {
                Console.Write(supplier.Name + " ");
            }
            Console.WriteLine();
        }
    }
}