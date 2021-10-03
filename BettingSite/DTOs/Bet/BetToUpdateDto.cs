using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSite.DTOs.Bet
{
    public class BetToUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
    }
}
