using System;
using System.Collections.Generic;
using System.Text;
using MbUtils.Extensions.CommandLineUtils;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace TestConsoleApp
{
   public class BarCommand : SyncCommandBase
   {
      private readonly ILogger<BarCommand> _logger;

      protected override string CommandName => "bar";

      public BarCommand(ILogger<BarCommand> logger)
      {
         _logger = logger;
      }

      protected override Func<int> OnExecute(CommandLineApplication command)
      {
         var bazOption = command.Option("-b|--baz", "Baz value", CommandOptionType.MultipleValue);

         int Ret()
         {
            bazOption.Values.ForEach(s => _logger.LogInformation($"Baz value: {s}"));
            // _logger.LogInformation("Bar.baz was called");
            return 0;
         }

         return Ret;
      }
   }
}
