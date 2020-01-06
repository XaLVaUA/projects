using Task6.DAL.Repositories;

namespace Task6.DAL.Interfaces.UnitOfWorks
{
    public interface IStoreUnitOfWork
    {
        ProductRepository Products { get; }

        CategoryRepository Categories { get; }

        SupplierRepository Suppliers { get; }

        void Save();
    }
}