using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Smashup.CLI.Commands
{
    [Command(name: "smashup")]
    [Subcommand(typeof(CrashCommand))]
    public class SmashupCommand : BaseCommand
    {
        private static string GetVersion() => typeof(SmashupCommand).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

        protected async override Task<int> OnExecute(CommandLineApplication app)
        {

            app.ShowHelp();

            return await Task.FromResult(0);
        }
    }
}