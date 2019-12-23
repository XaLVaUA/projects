using Auction.DAL.Repositories;

namespace Auction.DAL.Interfaces.UnitOfWorks
{
    public interface IAuctionUnitOfWork
    {
        public LotRepository LotRepository { get; }

        public BetRepository BetRepository { get; }

        public int Save();
    }
}