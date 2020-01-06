using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Task6.BLL.Interfaces;
using Task6.BLL.Interfaces.Services;
using Task6.BLL.Models;
using Task6.DAL.Interfaces.UnitOfWorks;
using Task6.DAL.Models;
using Task6.DAL.UnitOfWorks;

namespace Task6.BLL.Services
{
    public class SupplierService : ISupplierService
    {
        private IStoreUnitOfWork _uow;

        private Mapper _mapper;

        public SupplierService(IStoreUnitOfWork uow)
        {
            _uow = uow;
            InitMapper();
        }

        public ICollection<SupplierDto> GetSuppliers()
        {
            var suppliers = _uow.Suppliers.FindAll();
            var supplierDtos = _mapper.Map<ICollection<SupplierDto>>(suppliers);
            return supplierDtos;
        }

        public SupplierDto GetSupplier(int id)
        {
            var supplier = _uow.Suppliers.FindById(id);
            var supplierDto = _mapper.Map<SupplierDto>(supplier);
            return supplierDto;
        }

        public ICollection<ProductDto> GetSupplierProducts(int supplierId)
        {
            var supplier = _uow.Suppliers.FindById(supplierId);
            var productDtos = _mapper.Map<ICollection<ProductDto>>(supplier?.Products);
            return productDtos;
        }

        public ICollection<SupplierDto> GetSuppliersByProductCategory(string categoryName)
        {
            var suppliers = _uow.Suppliers.FindAll().Where(s => s.Products.Any(p => p.Category.Name == categoryName)).ToList();
            var supplierDtos = _mapper.Map<ICollection<SupplierDto>>(suppliers);
            return supplierDtos;
        }

        public void CreateSupplier(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            _uow.Suppliers.Create(supplier);
            _uow.Save();
        }

        public void UpdateSupplier(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            _uow.Suppliers.Update(supplier);
            _uow.Save();
        }

        public void DeleteSupplier(int supplierId)
        {
            _uow.Suppliers.Delete(supplierId);
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