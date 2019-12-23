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
    [Route("api/lots")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private ILotService _lotService;
        private IMapper _mapper;

        public LotController(ILotService lotService, IMapper mapper)
        {
            _lotService = lotService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<LotViewModel> Get()
        {
            var lotDtos = _lotService.GetAll();
            return _mapper.Map<IEnumerable<LotViewModel>>(lotDtos);
        }

        [HttpGet("{id}")]
        public LotViewModel Get(int id)
        {
            var lotDto = _lotService.Get(id);
            return _mapper.Map<LotViewModel>(lotDto);
        }

        [HttpPost]
        public LotViewModel Post([FromBody] LotViewModel lotViewModel)
        {
            var lotDto = _mapper.Map<LotDto>(lotViewModel);
            lotDto = _lotService.Create(lotDto);
            return _mapper.Map<LotViewModel>(lotDto);
        }

        [HttpPut("{id}")]
        public LotViewModel Put(int id, [FromBody] LotViewModel lotViewModel)
        {
            var lotDto = _mapper.Map<LotDto>(lotViewModel);
            lotDto = _lotService.Update(id, lotDto);
            return _mapper.Map<LotViewModel>(lotDto);
        }

        [HttpDelete("{id}")]
        public LotViewModel Delete(int id)
        {
            var lotDto = _lotService.Delete(id);
            if (lotDto == null) return null;
            return _mapper.Map<LotViewModel>(lotDto);
        }
    }
}
