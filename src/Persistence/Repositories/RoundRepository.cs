using Smashup.Application.Contracts.Persistence;
using Smashup.Domain.Modules.Rounds;

namespace Smashup.Persistence.Repositories;

public class RoundRepositorySQLite : GenericRepositorySQLite<Round>, RoundRepository
{
  private readonly SmashupDbContext _dbContext;

  public RoundRepositorySQLite(SmashupDbContext dbContext) : base(dbContext)
  {
    this._dbContext = dbContext;
  }
}
