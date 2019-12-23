namespace Auction.DAL.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public int LotId { get; set; }

        public virtual Lot Lot { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}