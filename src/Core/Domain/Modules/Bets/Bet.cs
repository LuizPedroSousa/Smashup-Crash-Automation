using Smashup.Domain.Shared;
using Smashup.Domain.Modules.Users;
using Smashup.Domain.Modules.Rounds;
using Smashup.Domain.Exceptions.Bets;
using Smashup.Domain.DTOs.Bets;
using System.Text.Json;

namespace Smashup.Domain.Modules.Bets
{

  public enum BetStatus
  {
    winned,
    losed,
    pending,
  }
  public class Bet : BaseEntity
  {

    public int amount { get; private set; }
    public BetStatus status { get; private set; }
    public Round round { get; set; }
    public User? user { get; set; }

    public Bet(int amount, BetStatus status, Round round, User? user)
    {
      this.amount = amount;
      this.status = status;
      this.round = round;
      this.user = user;
    }

    public Bet()
    {
    }

    public static Either<CantBetInThisRoundException, Bet> Create(CreateBetDTO dto)
    {
      return new Bet(Bet.GetBetInRoundAmount(dto.bets, dto.amount), dto.status, dto.round, dto.user);
    }

    private static int GetBetInRoundAmount(List<Bet> bets, int betAmount)
    {
      int amount = betAmount;

      foreach (var bet in bets)
      {
        amount += bet.amount;
      }

      return amount;
    }
  }
}