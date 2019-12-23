using System.Collections.Generic;

namespace Auction.BLL.Models
{
    public class LotDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BetDto> Bets { get; set; }
    }
}