using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Smashup.Application.Features.Rounds.Scraping.Handlers.Queries;

namespace Smashup.Application
{
  public static class ApplicationServicesRegistration
  {
    public static IServiceCollection ConfigureApplicationServices(IServiceCollection services)
    {
      services.AddMediatR(Assembly.GetExecutingAssembly());
      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      return services;
    }
  }
}