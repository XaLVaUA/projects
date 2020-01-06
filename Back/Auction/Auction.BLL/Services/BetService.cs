using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Auction.BLL.Interfaces.Services;
using Auction.BLL.Models;
using Auction.BLL.Validators;
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

        public IEnumerable<BetDto> GetAllByLotId(int lotId)
        {
            var bets = _uow.BetRepository.GetAll()
                .Where(b => b.LotId == lotId)
                .ToList();

            return _mapper.Map<IEnumerable<BetDto>>(bets);
        }

        public BetDto Get(int id)
        {
            var bet = _uow.BetRepository.Get(id);

            return _mapper.Map<BetDto>(bet);
        }

        public BetDto Create(BetDto item)
        {
            if (!BetValidator.IsBetValid(item))
            {
                return null;
            }

            var lot = _uow.LotRepository.Get((int) item.LotId);
            if (lot == null)
            {
                return null;
            }

            if (item.Value < lot.CurrentBet)
            {
                return null;
            }

            var bet = _mapper.Map<Bet>(item);
            bet = _uow.BetRepository.Create(bet);
            lot.CurrentBet = bet.Value;
            _uow.LotRepository.Update(lot);
            _uow.Save();

            return _mapper.Map<BetDto>(bet);
        }

        public BetDto Update(int id, BetDto item)
        {
            if (!BetValidator.IsBetValid(item))
            {
                return null;
            }

            if (_uow.LotRepository.Get((int)item.LotId) == null)
            {
                return null;
            }

            item.Id = id;
            var bet = _mapper.Map<Bet>(item);
            bet = _uow.BetRepository.Update(bet);
            _uow.Save();

            return _mapper.Map<BetDto>(bet);
        }

        public BetDto Delete(int id)
        {
            var bet = _uow.BetRepository.Delete(id);
            _uow.Save();

            return _mapper.Map<BetDto>(bet);
        }
    }
}