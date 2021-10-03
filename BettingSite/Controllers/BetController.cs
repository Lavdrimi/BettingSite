using BettingSite.DTOs.Bet;
using BettingSite.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;
        public BetController(IBetService betService)
        {
            _betService = betService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var betsToReturn = new List<BetToReturnDto>();

            betsToReturn = await _betService.GetAllBets();

            if(betsToReturn == null)
            {
                return BadRequest();
            }

            return Ok(betsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var betToReturn = await _betService.GetById(id);

            if (betToReturn == null)
            {
                return BadRequest();
            }

            return Ok(betToReturn);
        }



        [HttpPost]
        public async Task<IActionResult> CreateBet(BetToCreateDto betToCreateDto)
        {
            var betToReturn = new BetToReturnDto();

            if (betToCreateDto == null)
            {
                betToReturn.Success = false;
                betToReturn.Message = "Invalid";
                return BadRequest(betToReturn);
            }

            if (!ModelState.IsValid)
            {
                betToReturn.Success = false;
                betToReturn.Message = "Invalid";
                return BadRequest(betToReturn);
            }    

            var response = await _betService.Create(betToCreateDto);

            if(response.Message != "" && response.Success == false)
            {
                return BadRequest(response);
            }

            betToReturn = response;

            return Ok(betToReturn);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBet(BetToUpdateDto betToUpdateDto)
        {
            var betToReturn = new BetToReturnDto();

            if (betToUpdateDto == null)
            {
                betToReturn.Success = false;
                betToReturn.Message = "Invalid";
                return BadRequest(betToReturn);
            }

            if (!ModelState.IsValid)
            {
                betToReturn.Success = false;
                betToReturn.Message = "Invalid";
                return BadRequest(betToReturn);
            }

            var response = await _betService.Update(betToUpdateDto);

            if (response.Message != "" && response.Success == false)
            {
                return BadRequest(response);
            }

            betToReturn = response;

            return Ok(betToReturn);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBet(int id)
        {
            var response = await _betService.Delete(id);

            if(response != null)
            {
                return BadRequest(response);
            }

            return NoContent();
        }
    }
}
