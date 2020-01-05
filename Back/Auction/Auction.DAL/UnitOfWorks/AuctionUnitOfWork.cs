using Auction.DAL.EF;
using Auction.DAL.Interfaces.Repositories;
using Auction.DAL.Interfaces.UnitOfWorks;
using Auction.DAL.Models;
using Auction.DAL.Repositories;

namespace Auction.DAL.UnitOfWorks
{
    public class AuctionUnitOfWork : IAuctionUnitOfWork
    {
        private AuctionContext _context;

        private LotRepository _lotRepository;

        private BetRepository _betRepository;

        public IRepository<Lot> LotRepository
        {
            get
            {
                if (_lotRepository == null)
                {
                    _lotRepository = new LotRepository(_context);
                }

                return _lotRepository;
            }
        }

        public IRepository<Bet> BetRepository
        {
            get
            {
                if (_betRepository == null)
                {
                    _betRepository = new BetRepository(_context);
                }

                return _betRepository;
            }
        }

        public AuctionUnitOfWork(AuctionContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}