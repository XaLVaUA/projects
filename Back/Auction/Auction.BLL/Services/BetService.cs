using System.Collections.Generic;
using System.Linq;
using Auction.BLL.Interfaces.Services;
using Auction.BLL.Models;
using Auction.DAL.Interfaces.UnitOfWorks;
using Auction.DAL.Models;
using AutoMapper;

namespace Auction.BLL.Services
{
    public class BetService : IBetService
    {
        private IAuctionUnitOfWork _uow;
        private IMapper _mapper;

        public BetService(IAuctionUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<BetDto> GetAll()
        {
            var bets = _uow.BetRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<BetDto>>(bets);
        }

        public BetDto Get(int id)
        {
            var bet = _uow.BetRepository.Get(id);
            return _mapper.Map<BetDto>(bet);
        }

        public BetDto Create(BetDto item)
        {
            var bet = _mapper.Map<Bet>(item);
            bet = _uow.BetRepository.Create(bet);
            return _mapper.Map<BetDto>(bet);
        }

        public BetDto Update(int id, BetDto item)
        {
            item.Id = id;
            var bet = _mapper.Map<Bet>(item);
            bet = _uow.BetRepository.Update(bet);
            return _mapper.Map<BetDto>(bet);
        }

        public BetDto Delete(int id)
        {
            var bet = _uow.BetRepository.Delete(id);
            if (bet == null) return null;
            return _mapper.Map<BetDto>(bet);
        }
    }
}