using System;
using System.Threading.Tasks;
using MbUtils.Extensions.CommandLineUtils;
using Microsoft.Extensions.CommandLineUtils;

namespace TestConsoleApp
{
   public class FooCommand : AsyncCommandBase
   {
      protected override string CommandName => "foo";
      private readonly Action<string> _logger;

      public FooCommand(Action<string> logger)
      {
         _logger = logger;
      }

      protected override Func<Task<int>> OnExecuteAsync(CommandLineApplication command)
      {
         var pathOption = command.Option("-p|--path", "Path to file", CommandOptionType.SingleValue);

         async Task<int> Ret()
         {
            _logger("Before delay");
            await Task.Delay(20);
            _logger("After delay");
            _logger($"Path: {pathOption.Value()}");

            return 0;
         }

         return Ret;
      }
   }
}
