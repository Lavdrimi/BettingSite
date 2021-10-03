using AutoMapper;
using BettingSite.DTOs.Bet;
using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSite.ProfilesAutomapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Bet, BetToCreateDto>().ReverseMap();
            CreateMap<Bet, BetToReturnDto>().ReverseMap();
            CreateMap<Bet, BetToUpdateDto>().ReverseMap();
        }
    }
}
