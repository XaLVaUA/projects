using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task6.BLL.Interfaces.Services;
using Task6.BLL.Models;
using Task6.WebApi.Model;

namespace Task6.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        private Mapper _mapper;

        public ProductController(IProductService productService)
        {
            _productService = productService;
            InitMapper();
        }

        [HttpGet]
        public IEnumerable<ProductViewModel> GetProducts()
        {
            var productDtos = _productService.GetProducts();
            var productViewModels = _mapper.Map<ICollection<ProductViewModel>>(productDtos);
            return productViewModels;
        }

        [HttpGet("{id}")]
        public ProductViewModel GetProduct(int id)
        {
            var productDto = _productService.GetProduct(id);
            var productViewModel = _mapper.Map<ProductViewModel>(productDto);
            return productViewModel;
        }

        [HttpGet("filter")]
        public ICollection<ProductViewModel> GetProduct([FromQuery] ProductFilterModel filter)
        {
            IEnumerable<ProductDto> productDtos = _productService.GetProducts();
            productDtos = FilterProducts(productDtos, filter);
            var productViewModels = _mapper.Map<ICollection<ProductViewModel>>(productDtos);
            return productViewModels;
        }

        [HttpPost]
        public void CreateProduct([FromBody] ProductViewModel productViewModel)
        {
            var productDto = _mapper.Map<ProductDto>(productViewModel);
            _productService.CreateProduct(productDto);
        }

        [HttpPut]
        public void UpdateProduct([FromBody] ProductViewModel productViewModel)
        {
            var productDto = _mapper.Map<ProductDto>(productViewModel);
            _productService.UpdateProduct(productDto);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }

        private IEnumerable<ProductDto> FilterProducts(IEnumerable<ProductDto> productDtos, ProductFilterModel filter)
        {
            if (filter.Name != null)
            {
                productDtos = productDtos.Where(p => p.Name == filter.Name);
            }

            if (filter.CategoryId != null)
            {
                productDtos = productDtos.Where(p => p.CategoryId == filter.CategoryId);
            }

            if (filter.SupplierId != null)
            {
                productDtos = productDtos.Where(p => p.SupplierId == filter.SupplierId);
            }

            return productDtos;
        }

        private void InitMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<CategoryDto, CategoryViewModel>();
                    cfg.CreateMap<SupplierDto, SupplierViewModel>();
                    cfg.CreateMap<ProductDto, ProductViewModel>();
                    cfg.CreateMap<CategoryViewModel, CategoryDto>();
                    cfg.CreateMap<SupplierViewModel, SupplierDto>();
                    cfg.CreateMap<ProductViewModel, ProductDto>();
                });

            _mapper = new Mapper(config);
        }
    }
}
