using System.Collections.Generic;
using System.Linq;
using Auction.BLL.Interfaces.Services;
using Auction.BLL.Models;
using Auction.DAL.Interfaces.UnitOfWorks;
using Auction.DAL.Models;
using AutoMapper;

namespace Auction.BLL.Services
{
    public class LotService : ILotService
    {
        private IAuctionUnitOfWork _uow;
        private IMapper _mapper;

        public LotService(IAuctionUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<LotDto> GetAll()
        {
            var lots = _uow.LotRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<LotDto>>(lots);
        }

        public LotDto Get(int id)
        {
            var lot = _uow.LotRepository.Get(id);
            return _mapper.Map<LotDto>(lot);
        }

        public LotDto Create(LotDto item)
        {
            var lot = _mapper.Map<Lot>(item);
            lot = _uow.LotRepository.Create(lot);
            return _mapper.Map<LotDto>(lot);
        }

        public LotDto Update(int id, LotDto item)
        {
            item.Id = id;
            var lot = _mapper.Map<Lot>(item);
            lot = _uow.LotRepository.Update(lot);
            return _mapper.Map<LotDto>(lot);
        }

        public LotDto Delete(int id)
        {
            var lot = _uow.LotRepository.Delete(id);
            return _mapper.Map<LotDto>(lot);
        }
    }
}