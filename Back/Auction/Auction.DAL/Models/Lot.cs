using System;
using System.Collections.Generic;

namespace Auction.DAL.Models
{
    public class Lot
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CurrentBet { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
