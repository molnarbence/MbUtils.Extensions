using System;
using System.Collections.Generic;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace TestConsoleApp
{
   [Command("bar")]
   public class BarCommand
   {
      private readonly ILogger<BarCommand> _logger;

      [Option(CommandOptionType.MultipleValue, Description = "Baz values")]
      public List<string> Baz { get; set; }

      public BarCommand(ILogger<BarCommand> logger)
      {
         _logger = logger;
      }

      public int OnExecute()
      {
         Baz.ForEach(s => _logger.LogInformation($"Baz value: {s}"));
         return 0;
      }
   }
}
