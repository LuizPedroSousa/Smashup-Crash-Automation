using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smashup.Application.DTOs.Users;
using Smashup.Domain.Modules.Bets;
using Smashup.Domain.Modules.Rounds;

namespace Smashup.Application.DTOs.Bets
{
  public class BetCrashRoundDTO
  {
    public int amount { get; set; }
    public BetStatus? status { get; set; }
    public List<Bet> bets { get; set; }
    public UserDTO? userDTO { get; set; }
    public Round? round { get; set; }
  }
}