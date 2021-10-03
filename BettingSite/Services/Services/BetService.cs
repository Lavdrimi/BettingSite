using AutoMapper;
using BettingSite.DTOs.Bet;
using BettingSite.Models;
using BettingSite.Repositories.Interfaces;
using BettingSite.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSite.Services.Services
{
    public class BetService : IBetService
    {
        private readonly IMapper _mapper;
        private readonly IBetRepository _betRepository;
        public BetService(IMapper mapper, IBetRepository betRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
        }
        public async Task<BetToReturnDto> Create(BetToCreateDto betToCreate)
        {
            var betData = _mapper.Map<Bet>(betToCreate);
            betData.CreatedOn = DateTime.Now;

            var betFromRepository = await _betRepository.CreateBet(betData);

            if(betFromRepository == null)
            {
                return new BetToReturnDto()
                {
                    Success = false,
                    Message = "Database error! Can not save to database."
                };
            }
            
            var betToReturnDto = _mapper.Map<BetToReturnDto>(betFromRepository);
            betToReturnDto.Success = true;
            betToReturnDto.Message = "";

            return betToReturnDto;
        }

        public async Task<Bet> GetById(int id)
        {
            var betFromRepository = await _betRepository.GetById(id);

            return betFromRepository;
        }

        public async Task<BetToReturnDto> Update(BetToUpdateDto betToUpdate)
        {
            var bet = await GetById(betToUpdate.Id);
            
            bet = _mapper.Map(betToUpdate, bet);

            var betFromRepository = await _betRepository.UpdateBet(bet);

            if (betFromRepository == null)
            {
                return new BetToReturnDto()
                {
                    Success = false,
                    Message = "Database error! Can not update."
                };
            }

            var betToReturnDto = _mapper.Map<BetToReturnDto>(betFromRepository);
            betToReturnDto.Success = true;
            betToReturnDto.Message = "";

            return betToReturnDto;
        }

        public async Task<BetToReturnDto> Delete(int id)
        {
            var betFromRepository = await _betRepository.DeleteBet(id);

            if (betFromRepository == null)
            {
                return new BetToReturnDto()
                {
                    Success = true,
                };
            }

            var betToReturnDto = _mapper.Map<BetToReturnDto>(betFromRepository);
            betToReturnDto.Success = false;
            betToReturnDto.Message = "Can not delete.";

            return betToReturnDto;
        }

        public async Task<List<BetToReturnDto>> GetAllBets()
        {
            var allBets = new List<BetToReturnDto>();

            var betsFromRepository = await _betRepository.GetAllBets();

            allBets = _mapper.Map<List<BetToReturnDto>>(betsFromRepository);

            return allBets;
        }

     
    }
}
