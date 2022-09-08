using Smashup.Domain.Shared;
using Smashup.Domain.Modules.Rounds;
using Smashup.Domain.Modules.Bets;
using Smashup.Domain.Modules.Users;
using Smashup.Domain.Modules.Games;

namespace Smashup.Domain.Modules.Crashs
{
  public class Crash : BaseEntity
  {
    public List<Round> rounds { get; private set; } = new List<Round>();
    public List<Bet> bets { get; private set; } = new List<Bet>();
    public User user { get; set; }
    public int patternCount { get; set; } = 0;
    public GameConfiguration gameConfiguration { get; set; }

    public Crash(List<Round> rounds, List<Bet> bets, User user, GameConfiguration gameConfiguration)
    {
      this.rounds = rounds;
      this.bets = bets;
      this.user = user;
      this.gameConfiguration = gameConfiguration;
    }

    public Crash(GameConfiguration gameConfiguration)
    {
      this.gameConfiguration = gameConfiguration;
    }

    public string? GetLastRoundIdentifier()
    {
      if (rounds.Count == 0)
      {
        return null;
      }

      return rounds.Last().seed;
    }

    public void AddRound(Round round)
    {
      this.rounds.Add(round);
      if (round.color.name == "green")
      {
        this.patternCount += 1;
      }
      else
      {
        this.Reset("Quebra de cores");
      }
    }

    public void AddBet(Bet bet)
    {
      this.bets.Add(bet);
      this.Reset("Aposta realizada");
    }


    public bool CheckLimit(BetStatus status, int? limit)
    {
      var betsFiltered = this.bets.Where(bet => bet.status == status);
      var amount = 0;

      foreach (var bet in betsFiltered)
      {
        amount += bet.amount;
      }

      if (amount >= limit)
      {
        return true;
      }

      return false;
    }

    public bool CanBetInCurrentRound()
    {
      if (patternCount == 3)
      {
        return true;
      }

      return false;
    }

    public void Reset(string reason)
    {
      this.patternCount = 0;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine($"⚠️ Contagem resetada - {reason}");
    }

    public bool IsEndGame()
    {
      if (gameConfiguration.betIn is not null)
      {
        var hour = gameConfiguration.betIn?.stop.Hour;
        var minutes = gameConfiguration.betIn?.stop.Minute;

        var now = new DateTime();

        if (now.Hour >= hour && now.Minute >= minutes)
        {
          return true;
        }
      }

      if (CheckLimit(
        BetStatus.losed,
        gameConfiguration?.limit?.lose) ||
        CheckLimit(
        BetStatus.winned,
        gameConfiguration?.limit?.win))
      {
        return true;
      }

      return false;
    }
  }
}