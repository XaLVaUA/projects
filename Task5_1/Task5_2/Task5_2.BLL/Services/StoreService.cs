using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MoreLinq;
using Task5_2.BLL.DTO;
using Task5_2.DAL.Entities;
using Task5_2.DAL.Repositories;

namespace Task5_2.BLL.Services
{
    public class StoreService
    {
        private UnitOfWork _unitOfWork;

        private Mapper _mapper;

        public StoreService(string connectionString)
        {
            _unitOfWork = new UnitOfWork(connectionString);
            InitMapper();
        }

        private void InitMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Supplier, SupplierDTO>();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public ICollection<ProductDTO> GetProductsByCategory(string categoryName)
        {
            var products = 
                _unitOfWork.CategoryRepository
                    .GetAll()
                    .FirstOrDefault(c => c.Name == categoryName)
                    ?.Products;

            if (products == null)
            {
                return new List<ProductDTO>();
            }

            return _mapper.Map<ICollection<ProductDTO>>(products.ToList());
        }

        public ICollection<SupplierDTO> GetSuppliersByCategory(string categoryName)
        {
            var suppliersByCategory = 
                _unitOfWork.ProductRepository
                    .GetAll().ToList()
                    .Where(p => p.Category.Name == categoryName)
                    .DistinctBy(p => p.SupplierId)
                    .Select(p => p.Supplier);

            return _mapper.Map<ICollection<SupplierDTO>>(suppliersByCategory.ToList());
        }

        public ICollection<ProductDTO> GetProductsBySupplier(string supplierName)
        {
            var products =
                _unitOfWork.SupplierRepository
                    .GetAll()
                    .FirstOrDefault(s => s.Name == supplierName)
                    ?.Products;

            if (products == null)
            {
                return new List<ProductDTO>();
            }

            return _mapper.Map<ICollection<ProductDTO>>(products);
        }

        public ICollection<ProductDTO> GetProducts(Func<Product, bool> predicate)
        {
            var products =
                _unitOfWork.ProductRepository
                    .GetAll().ToList()
                    .Where(predicate);

            return _mapper.Map<ICollection<ProductDTO>>(products);
        }

        public ICollection<SupplierDTO> GetSuppliers(Func<Supplier, bool> predicate)
        {
            var suppliers =
                _unitOfWork.SupplierRepository
                    .GetAll().ToList()
                    .Where(predicate);

            return _mapper.Map<ICollection<SupplierDTO>>(suppliers);
        }

        public ICollection<CategoryDTO> GetCategories(Func<Category, bool> predicate)
        {
            var categories =
                _unitOfWork.CategoryRepository
                    .GetAll().ToList()
                    .Where(predicate);

            return _mapper.Map<ICollection<CategoryDTO>>(categories.ToList());
        }
    }
}