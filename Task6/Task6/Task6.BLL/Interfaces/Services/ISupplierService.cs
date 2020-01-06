using System.Collections.Generic;
using Task6.BLL.Models;

namespace Task6.BLL.Interfaces.Services
{
    public interface ISupplierService
    {
        ICollection<SupplierDto> GetSuppliers();

        SupplierDto GetSupplier(int id);

        ICollection<ProductDto> GetSupplierProducts(int supplierId);

        ICollection<SupplierDto> GetSuppliersByProductCategory(string categoryName);

        void CreateSupplier(SupplierDto supplierDto);

        void UpdateSupplier(SupplierDto supplierDto);

        void DeleteSupplier(int supplierId);
    }
}