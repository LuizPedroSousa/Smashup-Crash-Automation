using Smashup.Application.Contracts.Persistence;
using Smashup.Domain.Modules.Bets;

namespace Smashup.Persistence.Repositories
{
  public class BetRepositorySQLite : GenericRepositorySQLite<Bet>, BetRepository
  {
    public BetRepositorySQLite(SmashupDbContext dbContext) : base(dbContext)
    {
    }
  }
}