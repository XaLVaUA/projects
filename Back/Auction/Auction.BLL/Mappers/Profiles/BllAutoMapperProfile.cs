using Auction.BLL.Models;
using Auction.DAL.Models;
using AutoMapper;

namespace Auction.BLL.Mappers.Profiles
{
    public class BllAutoMapperProfile : Profile
    {
        public BllAutoMapperProfile()
        {
            CreateTwoWaysMap<Lot, LotDto>();
            CreateTwoWaysMap<Bet, BetDto>();
        }

        private void CreateTwoWaysMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}