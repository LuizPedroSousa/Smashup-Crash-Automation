using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Smashup.Application;
using Smashup.Application.Contracts.Providers;
using Smashup.CLI.Commands;
using Smashup.Infrastructure;
using Smashup.Infrastructure.Providers.Headless;
using Smashup.Persistence;

namespace Smashup.CLI;

public class Program
{

    public static async Task<int> Main(string[] args)
    {

        IServiceCollection serviceCollection = new ServiceCollection();

        var appSettingsPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\appsettings.json";

        // var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //   .AddJsonFile(appSettingsPath)
        //   .AddEnvironmentVariables()
        //   .Build();

        Log.Logger = new LoggerConfiguration()
                 .Enrich.FromLogContext()
                 .CreateLogger();

        var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
        {
            services.AddLogging(config =>
        {
              config.AddSerilog();
          });
            InfrastructureServicesRegistration.ConfigureInfrastructureServices(services);
            PersistenceServicesRegistration.ConfigurePersistenceServices(services);
            ApplicationServicesRegistration.ConfigureApplicationServices(services);
        });

        return await builder.RunCommandLineApplicationAsync<SmashupCommand>(args);
    }

}