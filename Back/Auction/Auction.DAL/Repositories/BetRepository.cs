using System.Collections.Generic;
using Auction.DAL.EF;
using Auction.DAL.Interfaces.Repositories;
using Auction.DAL.Models;

namespace Auction.DAL.Repositories
{
    public class BetRepository : IRepository<Bet>
    {
        private AuctionContext _context;

        public BetRepository(AuctionContext context)
        {
            _context = context;
        }

        public IEnumerable<Bet> GetAll()
        {
            return _context.Bets;
        }

        public Bet Get(int id)
        {
            return _context.Bets.Find(id);
        }

        public Bet Create(Bet item)
        {
            return _context.Bets.Add(item).Entity;
        }

        public Bet Update(Bet item)
        {
            return _context.Bets.Update(item).Entity;
        }

        public Bet Delete(int id)
        {
            var item = _context.Bets.Find(id);
            if (item == null) return null;

            _context.Bets.Remove(item);
            return item;
        }
    }
}