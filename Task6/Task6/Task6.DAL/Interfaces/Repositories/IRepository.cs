using System.Collections.Generic;

namespace Task6.DAL.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T FindById(int id);

        IEnumerable<T> FindAll();

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        void Save();
    }
}