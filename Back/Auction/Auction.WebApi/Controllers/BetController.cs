using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.BLL.Interfaces.Services;
using Auction.BLL.Models;
using Auction.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.WebApi.Controllers
{
    [Route("api/bets")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private IBetService _betService;
        private IMapper _mapper;

        public BetController(IBetService betService, IMapper mapper)
        {
            _betService = betService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<BetViewModel> Get()
        {
            var betDtos = _betService.GetAll();
            return _mapper.Map<IEnumerable<BetViewModel>>(betDtos);
        }

        [HttpGet("{id}")]
        public BetViewModel Get(int id)
        {
            var betDto = _betService.Get(id);
            return _mapper.Map<BetViewModel>(betDto);
        }

        [HttpPost]
        public BetViewModel Post([FromBody] BetViewModel betViewModel)
        {
            var betDto = _mapper.Map<BetDto>(betViewModel);
            betDto = _betService.Create(betDto);
            return _mapper.Map<BetViewModel>(betDto);
        }

        [HttpPut("{id}")]
        public BetViewModel Put(int id, [FromBody] BetViewModel betViewModel)
        {
            var betDto = _mapper.Map<BetDto>(betViewModel);
            betDto = _betService.Update(id, betDto);
            return _mapper.Map<BetViewModel>(betDto);
        }

        [HttpDelete("{id}")]
        public BetViewModel Delete(int id)
        {
            var betDto = _betService.Delete(id);
            if (betDto == null) return null;
            return _mapper.Map<BetViewModel>(betDto);
        }
    }
}
