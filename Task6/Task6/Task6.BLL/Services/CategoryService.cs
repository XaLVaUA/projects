using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Task6.BLL.Interfaces.Services;
using Task6.BLL.Models;
using Task6.DAL.Interfaces.UnitOfWorks;
using Task6.DAL.Models;
using Task6.DAL.UnitOfWorks;

namespace Task6.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private IStoreUnitOfWork _uow;

        private Mapper _mapper;

        public CategoryService(IStoreUnitOfWork uow)
        {
            _uow = uow;
            InitMapper();
        }

        public ICollection<CategoryDto> GetCategories()
        {
            var categories = _uow.Categories.FindAll();
            var categoryDtos = _mapper.Map<ICollection<CategoryDto>>(categories);
            return categoryDtos;
        }

        public CategoryDto GetCategory(int id)
        {
            var category = _uow.Categories.FindById(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public ICollection<ProductDto> GetCategoryProducts(int categoryId)
        {
            var category = _uow.Categories.FindById(categoryId);
            var productDtos = _mapper.Map<ICollection<ProductDto>>(category?.Products);
            return productDtos;
        }

        public void CreateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _uow.Categories.Create(category);
            _uow.Save();
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _uow.Categories.Update(category);
            _uow.Save();
        }

        public void DeleteCategory(int categoryId)
        {
            _uow.Categories.Delete(categoryId);
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