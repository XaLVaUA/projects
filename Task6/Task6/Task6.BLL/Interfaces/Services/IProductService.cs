using System.Collections.Generic;
using Task6.BLL.Models;

namespace Task6.BLL.Interfaces.Services
{
    public interface IProductService
    {
        ICollection<ProductDto> GetProducts();

        ProductDto GetProduct(int id);

        void CreateProduct(ProductDto productDto);

        void UpdateProduct(ProductDto productDto);

        void DeleteProduct(int productId);
    }
}