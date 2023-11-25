using System.Collections.Generic;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace TestConsoleApp;

[Command("bar")]
public class BarCommand(ILogger<BarCommand> logger)
{
   private readonly ILogger<BarCommand> _logger = logger;

   [Option(CommandOptionType.MultipleValue, Description = "Baz values")]
   public List<string> Baz { get; set; }

   public int OnExecute()
   {
      Baz.ForEach(s => _logger.LogInformation("Baz value: {s}", s));
      return 0;
   }
}
