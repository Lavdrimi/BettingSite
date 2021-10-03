using BettingSite.DTOs.Bet;
using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSite.Services.Interfaces
{
    public interface IBetService
    {
        Task<BetToReturnDto> Create(BetToCreateDto betToCreate);
        Task<Bet> GetById(int id);
        Task<BetToReturnDto> Update(BetToUpdateDto betToUpdate);
        Task<BetToReturnDto> Delete(int id);
        Task<List<BetToReturnDto>> GetAllBets();
    }
}
