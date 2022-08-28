using Microsoft.Extensions.DependencyInjection;
using Smashup.Application.Contracts.Providers;
using Smashup.Infrastructure.Providers.Headless;

namespace Smashup.Infrastructure
{
  public static class InfrastructureServicesRegistration
  {

    public static IServiceCollection ConfigureInfrastructureServices(IServiceCollection services)
    {
      services.AddSingleton<HeadlessProvider, PuppeteerHeadlessProvider>();
      return services;
    }

  }
}