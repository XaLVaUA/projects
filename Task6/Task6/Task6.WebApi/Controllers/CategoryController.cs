using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task6.BLL.Interfaces.Services;
using Task6.BLL.Models;
using Task6.WebApi.Model;

namespace Task6.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        private Mapper _mapper;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            InitMapper();
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var categoryDtos = _categoryService.GetCategories();
            var categoryViewModels = _mapper.Map<ICollection<CategoryViewModel>>(categoryDtos);
            return categoryViewModels;
        }

        [HttpGet("{id}")]
        public CategoryViewModel GetCategory(int id)
        {
            var categoryDto = _categoryService.GetCategory(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDto);
            return categoryViewModel;
        }

        [HttpGet("{categoryId}/products")]
        public ICollection<ProductViewModel> GetCategoryProducts(int categoryId)
        {
            var productDtos = _categoryService.GetCategoryProducts(categoryId);
            var productViewModels = _mapper.Map<ICollection<ProductViewModel>>(productDtos);
            return productViewModels;
        }

        [HttpPost]
        public void CreateCategory([FromBody] CategoryViewModel categoryViewModel)
        {
            var categoryDto = _mapper.Map<CategoryDto>(categoryViewModel);
            _categoryService.CreateCategory(categoryDto);
        }

        [HttpPut]
        public void UpdateCategory([FromBody] CategoryViewModel categoryViewModel)
        {
            var categoryDto = _mapper.Map<CategoryDto>(categoryViewModel);
            _categoryService.UpdateCategory(categoryDto);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
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
