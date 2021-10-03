using BettingSite.Models;
using BettingSite.Persistence;
using BettingSite.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSite.Repositories.Repositories
{
    public class BetRepository : IBetRepository
    {
        private BettingSiteContext _context;
        public BetRepository(BettingSiteContext context)
        {
            _context = context;
        }
        public async Task<Bet> CreateBet(Bet betToCreate)
        {
            var betToReturn = new Bet();

            await _context.Bets.AddAsync(betToCreate);

            if (await _context.SaveChangesAsync() >= 1)
            {
                betToReturn = betToCreate;

                return betToReturn;
            }

            return null;
        }

        public async Task<Bet> GetById(int id)
        {
            var betToReturn = new Bet();
            betToReturn = await _context.Bets.FirstOrDefaultAsync(x => x.Id == id);

            return betToReturn;

        }

        public async Task<Bet> UpdateBet(Bet betToUpdate)
        {
            var betToReturn = new Bet();

            _context.Bets.Update(betToUpdate);

            if(await _context.SaveChangesAsync() >= 1)
            {
                betToReturn = betToUpdate;

                return betToReturn;
            }

            return null;
        }

        public async Task<Bet> DeleteBet(int id)
        {
            var betToDelete = await _context.Bets.FirstOrDefaultAsync(a => a.Id == id);
            if(betToDelete != null)
            {
                _context.Bets.Remove(betToDelete);

                if (await _context.SaveChangesAsync() >= 1)
                {
                    return null;
                }
            }

            return betToDelete;
        }

        public async Task<List<Bet>> GetAllBets()
        {
            var allBets = new List<Bet>();

            allBets = await _context.Bets.ToListAsync();

            return allBets;
        }

        
    }
}
