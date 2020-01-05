using System.Collections.Generic;
using System.Security.Claims;
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
    public class LotsController : ControllerBase
    {
        private ILotService _lotService;
        private IMapper _mapper;

        public LotsController(ILotService lotService, IMapper mapper)
        {
            _lotService = lotService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllLots()
        {
            var lotDtos = _lotService.GetAll();

            return Ok(_mapper.Map<IEnumerable<LotViewModel>>(lotDtos));
        }

        [HttpGet("{id}")]
        public IActionResult GetLotById(int id)
        {
            var lotDto = _lotService.Get(id);

            if (lotDto == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LotViewModel>(lotDto));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateLot([FromBody] LotViewModel lotViewModel)
        {
            var lotDto = _mapper.Map<LotDto>(lotViewModel);
            lotDto.UserName = User.Identity.Name;
            lotDto = _lotService.Create(lotDto);

            if (lotDto == null)
            {
                return BadRequest();
            }

            return Created(Request.Path + "/" + lotDto.Id, _mapper.Map<LotViewModel>(lotDto));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateLot(int id, [FromBody] LotViewModel lotViewModel)
        {
            if (!IsUserOwnLot(id, User.Identity.Name))
            {
                return Forbid();
            }

            var lotDto = _mapper.Map<LotDto>(lotViewModel);
            lotDto = _lotService.Update(id, lotDto);

            return Ok(_mapper.Map<LotViewModel>(lotDto));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteLotById(int id)
        {
            if (!IsUserOwnLot(id, User.Identity.Name))
            {
                return Forbid();
            }

            var lotDto = _lotService.Delete(id);

            if (lotDto == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<LotViewModel>(lotDto));
        }

        private bool IsUserOwnLot(int lotId, string userName)
        {
            var lotDto = _lotService.Get(lotId);

            if (lotDto == null)
            {
                return false;
            }

            return lotDto.UserName == userName;
        }
    }
}
