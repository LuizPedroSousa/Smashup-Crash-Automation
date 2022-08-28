using Smashup.Domain.Modules.Users;

using Smashup.Application.Contracts.Persistence;

namespace Smashup.Persistence.Repositories
{
  public class UserRepositorySQLite : GenericRepositorySQLite<User>, UserRepository
  {
    private readonly SmashupDbContext _dbContext;

    public UserRepositorySQLite(SmashupDbContext dbContext) : base(dbContext)
    {
      this._dbContext = dbContext;
    }

    public async Task<User> FindOneByUsername(string username)
    {
      return await this._dbContext.Set<User>().FindAsync(
        username
      );
    }
  }
}