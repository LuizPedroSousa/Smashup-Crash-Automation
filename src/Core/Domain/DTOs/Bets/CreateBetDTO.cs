
using Smashup.Domain.Modules.Bets;
using Smashup.Domain.Modules.Rounds;
using Smashup.Domain.Modules.Users;

namespace Smashup.Domain.DTOs.Bets
{
  public class CreateBetDTO
  {
    public int amount { get; set; }
    public BetStatus status { get; set; }
    public Round round { get; set; }
    public User user { get; set; }


    public List<Bet> bets { get; set; }
    public int greensCount { get; set; }
  }
}