using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Auction.DAL.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Create(T item);

        T Update(T item);

        T Delete(int id);
    }
}