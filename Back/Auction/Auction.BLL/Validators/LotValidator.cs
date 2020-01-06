using System;
using Auction.BLL.Models;

namespace Auction.BLL.Validators
{
    public class LotValidator
    {
        public static bool IsLotValid(LotDto lot)
        {
            return lot.UserName.Length > 0 && lot.Description.Length > 0;
        }
    }
}