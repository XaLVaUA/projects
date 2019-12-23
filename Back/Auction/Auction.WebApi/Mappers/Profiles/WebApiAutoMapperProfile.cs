using Auction.BLL.Models;
using Auction.WebApi.Models;
using AutoMapper;

namespace Auction.WebApi.Mappers.Profiles
{
    public class WebApiAutoMapperProfile : Profile
    {
        public WebApiAutoMapperProfile()
        {
            CreateTwoWaysMap<LotDto, LotViewModel>();
            CreateTwoWaysMap<BetDto, BetViewModel>();
        }

        private void CreateTwoWaysMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}