using Smashup.Application.DTOs.Shared;
using Smashup.Application.DTOs.Users;
using Smashup.Application.DTOs.Rounds;
using Smashup.Domain.Modules.Bets;

namespace Smashup.Application.DTOs.Bets
{
  public class BetDTO : BaseDTO
  {
    public int amount { get; set; }
    public BetStatus status { get; set; }

    public UserDTO? userDTO { get; set; }
    public string userId { get; set; }
    public RoundDTO? roundDTO { get; set; }
    public string roundId { get; set; }

  }
}