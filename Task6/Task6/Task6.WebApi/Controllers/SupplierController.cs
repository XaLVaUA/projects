using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task6.BLL.Interfaces.Services;
using Task6.BLL.Models;
using Task6.WebApi.Model;

namespace Task6.WebApi.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierService _supplierService;

        private Mapper _mapper;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
            InitMapper();
        }

        [HttpGet]
        public IEnumerable<SupplierViewModel> GetSuppliers()
        {
            var supplierDtos = _supplierService.GetSuppliers();
            var supplierViewModels = _mapper.Map<ICollection<SupplierViewModel>>(supplierDtos);
            return supplierViewModels;
        }

        [HttpGet("{id}")]
        public SupplierViewModel GetSupplier(int id)
        {
            var supplierDto = _supplierService.GetSupplier(id);
            var supplierViewModel = _mapper.Map<SupplierViewModel>(supplierDto);
            return supplierViewModel;
        }

        [HttpGet("{supplierId}/products")]
        public ICollection<ProductViewModel> GetCategoryProducts(int supplierId)
        {
            var productDtos = _supplierService.GetSupplierProducts(supplierId);
            var productViewModels = _mapper.Map<ICollection<ProductViewModel>>(productDtos);
            return productViewModels;
        }

        [HttpGet("category")]
        public ICollection<SupplierViewModel> GetSuppliersByProductCategory([FromQuery] string categoryName)
        {
            var supplierDtos = _supplierService.GetSuppliersByProductCategory(categoryName);
            var supplierViewModels = _mapper.Map<ICollection<SupplierViewModel>>(supplierDtos);
            return supplierViewModels;
        }

        [HttpPost]
        public void CreateSupplier([FromBody] SupplierViewModel supplierViewModel)
        {
            var supplierDto = _mapper.Map<SupplierDto>(supplierViewModel);
            _supplierService.CreateSupplier(supplierDto);
        }

        [HttpPut]
        public void UpdateSupplier([FromBody] SupplierViewModel supplierViewModel)
        {
            var supplierDto = _mapper.Map<SupplierDto>(supplierViewModel);
            _supplierService.UpdateSupplier(supplierDto);
        }

        [HttpDelete("{id}")]
        public void DeleteSupplier(int id)
        {
            _supplierService.DeleteSupplier(id);
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
