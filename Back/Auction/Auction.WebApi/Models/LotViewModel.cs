using System.Collections.Generic;

namespace Auction.WebApi.Models
{
    public class LotViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BetViewModel> Bets { get; set; }
    }
}