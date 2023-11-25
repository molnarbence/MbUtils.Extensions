using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace TestConsoleApp;

[Command("foo")]
public class FooCommand(ILogger<FooCommand> logger, IQuaxService quax)
{
   private readonly ILogger<FooCommand> _logger = logger;
   private readonly IQuaxService _quax = quax;

   [Option(Description = "Path to file")]
   public string Path { get; }

   public async Task<int> OnExecuteAsync()
   {
      _logger.LogInformation("Before delay");
      await Task.Delay(20);
      _logger.LogInformation("After delay");
      _logger.LogInformation("Path: {Path}", Path);
      _quax.Add();

      return 0;
   }
}
