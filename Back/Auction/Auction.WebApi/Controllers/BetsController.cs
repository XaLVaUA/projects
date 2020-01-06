using System;
using System.Collections.Generic;
using Auction.BLL.Interfaces.Services;
using Auction.BLL.Models;
using Auction.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetsController : ControllerBase
    {
        private IBetService _betService;
        private IMapper _mapper;

        public BetsController(IBetService betService, IMapper mapper)
        {
            _betService = betService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBets([FromQuery] int? lotId)
        {
            IEnumerable<BetDto> betDtos;

            if (lotId.HasValue)
            {
                betDtos = _betService.GetAllByLotId(lotId.Value);
            }
            else
            {
                betDtos = _betService.GetAll();
            }

            return Ok(_mapper.Map<IEnumerable<BetViewModel>>(betDtos));
        }

        [HttpGet("{id}")]
        public IActionResult GetBetById(int id)
        {
            var betDto = _betService.Get(id);

            if (betDto == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BetViewModel>(betDto));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateBet([FromBody] BetViewModel betViewModel)
        {
            var betDto = _mapper.Map<BetDto>(betViewModel);
            betDto.UserName = User.Identity.Name;
            betDto.Date = DateTime.Now;
            betDto = _betService.Create(betDto);

            if (betDto == null)
            {
                return BadRequest();
            }

            return Created(Request.Path + "/" + betDto.Id, _mapper.Map<BetViewModel>(betDto));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateBet(int id, [FromBody] BetViewModel betViewModel)
        {
            if (!IsUserOwnBet(id, User.Identity.Name))
            {
                return Forbid();
            }

            var betDto = _mapper.Map<BetDto>(betViewModel);

            if (betDto == null)
            {
                return NotFound();
            }

            betDto = _betService.Update(id, betDto);

            return Ok(_mapper.Map<BetViewModel>(betDto));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBetById(int id)
        {
            if (!IsUserOwnBet(id, User.Identity.Name))
            {
                return Forbid();
            }

            var betDto = _betService.Delete(id);
            
            if (betDto == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BetViewModel>(betDto));
        }

        private bool IsUserOwnBet(int betId, string userName)
        {
            var betDto = _betService.Get(betId);

            if (betDto == null)
            {
                return false;
            }

            return betDto.UserName == userName;
        }
    }
}
