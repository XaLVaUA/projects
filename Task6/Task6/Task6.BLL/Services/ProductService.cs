using System.Collections.Generic;
using AutoMapper;
using Task6.BLL.Interfaces;
using Task6.BLL.Interfaces.Services;
using Task6.BLL.Models;
using Task6.DAL.Interfaces.UnitOfWorks;
using Task6.DAL.Models;
using Task6.DAL.UnitOfWorks;

namespace Task6.BLL.Services
{
    public class ProductService : IProductService
    {
        private ILogService _log;

        private IStoreUnitOfWork _uow;

        private Mapper _mapper;

        public ProductService(IStoreUnitOfWork uow, ILogService logService)
        {
            _uow = uow;
            InitMapper();
            _log = logService;
        }

        public ICollection<ProductDto> GetProducts()
        {
            var products = _uow.Products.FindAll();
            var productDtos = _mapper.Map<ICollection<ProductDto>>(products);
            return productDtos;
        }

        public ProductDto GetProduct(int id)
        {
            var product = _uow.Products.FindById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public void CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _uow.Products.Create(product);
            _uow.Save();
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _uow.Products.Update(product);
            _uow.Save();
        }

        public void DeleteProduct(int productId)
        {
            _uow.Products.Delete(productId);
            _uow.Save();
        }

        private void InitMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Category, CategoryDto>();
                    cfg.CreateMap<Supplier, SupplierDto>();
                    cfg.CreateMap<Product, ProductDto>();
                    cfg.CreateMap<CategoryDto, Category>();
                    cfg.CreateMap<SupplierDto, Supplier>();
                    cfg.CreateMap<ProductDto, Product>();
                });

            _mapper = new Mapper(config);
        }
    }
}