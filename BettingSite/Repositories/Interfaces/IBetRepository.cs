using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSite.Repositories.Interfaces
{
    public interface IBetRepository
    {
        Task<Bet> CreateBet(Bet betToCreate);
        Task<Bet> GetById(int id);
        Task<Bet> UpdateBet(Bet betToUpdate);
        Task<Bet> DeleteBet(int id);
        Task<List<Bet>> GetAllBets();
    }
}
