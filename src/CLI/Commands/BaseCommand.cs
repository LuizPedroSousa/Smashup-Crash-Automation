using McMaster.Extensions.CommandLineUtils;

namespace Smashup.CLI.Commands
{
    public class BaseCommand
    {
        protected virtual async Task<int> OnExecute(CommandLineApplication app)
        {
            return await Task.FromResult(0);
        }
    }
}