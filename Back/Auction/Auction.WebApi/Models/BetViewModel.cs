namespace Auction.WebApi.Models
{
    public class BetViewModel
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public int? LotId { get; set; }

        public string UserName { get; set; }

        public LotViewModel Lot { get; set; }
    }
}