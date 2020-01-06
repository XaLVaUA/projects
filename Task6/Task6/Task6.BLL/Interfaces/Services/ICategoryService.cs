using System.Collections.Generic;
using Task6.BLL.Models;

namespace Task6.BLL.Interfaces.Services
{
    public interface ICategoryService
    {
        ICollection<CategoryDto> GetCategories();

        CategoryDto GetCategory(int id);

        ICollection<ProductDto> GetCategoryProducts(int categoryId);

        void CreateCategory(CategoryDto categoryDto);

        void UpdateCategory(CategoryDto categoryDto);

        void DeleteCategory(int categoryId);
    }
}