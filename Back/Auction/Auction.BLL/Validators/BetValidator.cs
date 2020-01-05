using Auction.BLL.Models;

namespace Auction.BLL.Validators
{
    public class BetValidator
    {
        public static bool IsBetValid(BetDto bet)
        {
            return bet.LotId != null;
        }
    }
}