using System.Collections.Generic;
using Auction.BLL.Models;

namespace Auction.BLL.Interfaces.Services
{
    public interface ILotService : ICrudService<LotDto>
    {
        IEnumerable<LotDto> GetPage(int pageNumber, int pageElementCount);
    }
}