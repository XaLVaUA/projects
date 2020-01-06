using System;
using System.Configuration;
using Task5_2.BLL.Services;

namespace Task5_2.ConsoleApp
{
    public class Demonstrator
    {
        private StoreService _storeService;

        public void Start()
        {
            Init();
            DemonstrateGetProductsByCategory();
            Console.WriteLine();
            DemonstrateGetSuppliersByCategory();
            Console.WriteLine();
            DemonstrateGetProductsBySupplier();
            Console.WriteLine();
            DemonstrateGetProductsByPrice();
            Console.WriteLine();
            DemonstrateGetSupplierByCity();
            Console.ReadLine();
        }

        private void Init()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _storeService = new StoreService(connectionString);
        }

        private void DemonstrateGetProductsByCategory()
        {
            Console.Write("Get products by category\nCategory name: ");
            var categoryName = Console.ReadLine();
            var products = _storeService.GetProductsByCategory(categoryName);
            foreach (var product in products)
            {
                Console.Write(product.Name + " | ");
            }
            Console.WriteLine();
        }

        private void DemonstrateGetSuppliersByCategory()
        {
            Console.Write("Get suppliers by category\nCategory name: ");
            var categoryName = Console.ReadLine();
            var suppliers = _storeService.GetSuppliersByCategory(categoryName);
            foreach (var supplier in suppliers)
            {
                Console.Write(supplier.Name + " | ");
            }
            Console.WriteLine();
        }

        private void DemonstrateGetProductsBySupplier()
        {
            Console.Write("Get products by supplier\nSupplier name: ");
            var supplierName = Console.ReadLine();
            var products = _storeService.GetProductsBySupplier(supplierName);
            foreach (var product in products)
            {
                Console.Write(product.Name + " | ");
            }
            Console.WriteLine();
        }

        private void DemonstrateGetProductsByPrice()
        {
            Console.Write("Get products by price\nProduct price: ");
            var productPrice = Decimal.Parse(Console.ReadLine());
            var products = _storeService.GetProducts(p => p.Price.Equals(productPrice));
            foreach (var product in products)
            {
                Console.Write(product.Name + " | ");
            }
            Console.WriteLine();
        }

        private void DemonstrateGetSupplierByCity()
        {
            Console.Write("Get products by supplier\nSupplier city: ");
            var supplierCity = Console.ReadLine();
            var products = _storeService.GetSuppliers(s => s.City == supplierCity);
            foreach (var product in products)
            {
                Console.Write(product.Name + " | ");
            }
            Console.WriteLine();
        }
    }
}