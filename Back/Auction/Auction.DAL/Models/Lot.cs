using System.Collections.Generic;

namespace Auction.DAL.Models
{
    public class Lot
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
