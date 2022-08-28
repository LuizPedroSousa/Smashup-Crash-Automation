using Smashup.Domain.Modules.Bets;
using Smashup.Application.DTOs.Users;
using Smashup.Application.DTOs.Rounds;
using Smashup.Application.DTOs.Shared;

namespace Smashup.Application.DTOs.Bets
{
  public class UpdateBetDTO : BaseDTO
  {
    public int amount { get; set; }
    public BetStatus? status { get; set; }
    public UserDTO? userDTO { get; set; }
    public RoundDTO? roundDTO { get; set; }
  }
}