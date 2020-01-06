using System.Collections.Generic;
using Auction.BLL.Models;

namespace Auction.BLL.Interfaces.Services
{
    public interface IBetService : ICrudService<BetDto>
    {
        IEnumerable<BetDto> GetAllByLotId(int lotId);
    }
}