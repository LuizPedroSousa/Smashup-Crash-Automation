using AutoMapper;
using Smashup.Domain.Modules.Users;
using Smashup.Application.DTOs.Users;
using Smashup.Domain.Modules.Bets;
using Smashup.Application.DTOs.Bets;
using Smashup.Domain.Modules.Rounds;
using Smashup.Application.DTOs.Games;
using Smashup.Application.DTOs.Rounds;
using Smashup.Application.DTOs.Colors;
using Smashup.Domain.Modules.Games;
using Smashup.Domain.Modules.Colors;

namespace Smashup.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<User, UserDTO>().ReverseMap();
      CreateMap<Bet, BetDTO>().ReverseMap();
      CreateMap<Smashup.Domain.DTOs.Bets.CreateBetDTO, BetCrashRoundDTO>().ReverseMap();
      CreateMap<Bet, UpdateBetDTO>().ReverseMap();
      CreateMap<Round, RoundDTO>().ReverseMap();
      CreateMap<Color, ColorDTO>().ReverseMap();
      CreateMap<Game, GameDTO>().ReverseMap();
    }
  }
}