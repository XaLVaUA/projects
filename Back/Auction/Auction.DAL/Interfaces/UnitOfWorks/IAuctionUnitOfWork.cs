using Auction.DAL.Interfaces.Repositories;
using Auction.DAL.Models;
using Auction.DAL.Repositories;

namespace Auction.DAL.Interfaces.UnitOfWorks
{
    public interface IAuctionUnitOfWork
    {
        public IRepository<Lot> LotRepository { get; }

        public IRepository<Bet> BetRepository { get; }

        public int Save();
    }
}