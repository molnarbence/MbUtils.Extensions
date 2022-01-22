using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace TestConsoleApp;

[Command("foo")]
public class FooCommand
{
   private readonly ILogger<FooCommand> _logger;
   private readonly IQuaxService _quax;

   [Option(Description = "Path to file")]
   public string Path { get; }

   public FooCommand(ILogger<FooCommand> logger, IQuaxService quax)
   {
      _logger = logger;
      _quax = quax;
   }

   public async Task<int> OnExecuteAsync()
   {
      _logger.LogInformation("Before delay");
      await Task.Delay(20);
      _logger.LogInformation("After delay");
      _logger.LogInformation($"Path: {Path}");
      _quax.Add();

      return 0;
   }
}
