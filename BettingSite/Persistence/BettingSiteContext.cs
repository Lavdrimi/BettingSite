using BettingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace BettingSite.Persistence
{
    public class BettingSiteContext : DbContext
    {
        public BettingSiteContext(DbContextOptions<BettingSiteContext> options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
    }
}
