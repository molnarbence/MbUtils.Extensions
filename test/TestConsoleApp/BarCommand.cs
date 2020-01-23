using System;
using System.Collections.Generic;
using System.Text;
using MbUtils.Extensions.CommandLineUtils;
using Microsoft.Extensions.CommandLineUtils;

namespace TestConsoleApp
{
   public class BarCommand : SyncCommandBase
   {
      private readonly Action<string> _logger;

      protected override string CommandName => "bar";

      public BarCommand(Action<string> logger)
      {
         _logger = logger;
      }

      protected override Func<int> OnExecute(CommandLineApplication command)
      {
         var bazOption = command.Option("-b|--baz", "Baz value", CommandOptionType.MultipleValue);

         int Ret()
         {
            bazOption.Values.ForEach(s => _logger($"Baz value: {s}"));
            return 0;
         }

         return Ret;
      }
   }
}
