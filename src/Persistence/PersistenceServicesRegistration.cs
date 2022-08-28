using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Smashup.Application.Contracts.Persistence;
using Smashup.Persistence.Repositories;

namespace Smashup.Persistence;

public static class PersistenceServicesRegistration
{
  public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
  {

    services.AddDbContext<SmashupDbContext>();
    services.AddScoped(typeof(GenericRepository<>), typeof(GenericRepositorySQLite<>));
    services.AddScoped<UserRepository, UserRepositorySQLite>();
    services.AddScoped<RoundRepository, RoundRepositorySQLite>();
    services.AddScoped<BetRepository, BetRepositorySQLite>();

    return services;
  }
}
