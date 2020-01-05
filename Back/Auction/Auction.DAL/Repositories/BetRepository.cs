using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Bet> GetAsync(int id)
        {
            var result = await _context.Bets.FindAsync(id);
            return result;
        }

        public Bet Create(Bet item)
        {
            return _context.Bets.Add(item).Entity;
        }

        public async Task<Bet> CreateAsync(Bet item)
        {
            var result = await _context.Bets.AddAsync(item);
            return result.Entity;
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