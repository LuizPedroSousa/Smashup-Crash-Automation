using Smashup.Domain.Modules.Users;

namespace Smashup.Application.Contracts.Persistence;

public interface UserRepository : GenericRepository<User>
{
  Task<User?> FindOneByUsername(string username);
}
