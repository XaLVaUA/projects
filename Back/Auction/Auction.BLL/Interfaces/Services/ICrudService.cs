using System.Collections.Generic;

namespace Auction.BLL.Interfaces.Services
{
    public interface ICrudService<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Create(T item);

        T Update(int id, T item);

        T Delete(int id);
    }
}