using System;

namespace Auction.DAL.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public int LotId { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public virtual Lot Lot { get; set; }
    }
}