using System.Collections.Generic;
using System.Linq;
using Auction.DAL.EF;
using Auction.DAL.Interfaces.Repositories;
using Auction.DAL.Models;

namespace Auction.DAL.Repositories
{
    public class LotRepository : IRepository<Lot>
    {
        private AuctionContext _context;

        public LotRepository(AuctionContext context)
        {
            _context = context;
        }


        public IQueryable<Lot> GetAll()
        {
            return _context.Lots;
        }

        public Lot Get(int id)
        {
            return _context.Lots.Find(id);
        }

        public Lot Create(Lot item)
        {
            return _context.Lots.Add(item).Entity;
        }

        public Lot Update(Lot item)
        {
            return _context.Update(item).Entity;
        }

        public Lot Delete(int id)
        {
            var item = _context.Lots.Find(id);
            if (item == null) return null;

            _context.Remove(item);
            return item;
        }
    }
}