using System;

namespace Auction.BLL.Models
{
    public class BetDto
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public int? LotId { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public LotDto Lot { get; set; }
    }
}