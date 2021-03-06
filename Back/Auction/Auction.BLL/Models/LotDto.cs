﻿using System;
using System.Collections.Generic;

namespace Auction.BLL.Models
{
    public class LotDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CurrentBet { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public ICollection<BetDto> Bets { get; set; }
    }
}