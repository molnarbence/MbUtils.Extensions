using System;
using System.Threading.Tasks;
using MbUtils.Extensions.CommandLineUtils;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace TestConsoleApp
{
   public class FooCommand : AsyncCommandBase
   {
      protected override string CommandName => "foo";
      private readonly ILogger<FooCommand> _logger;
      private readonly IQuaxService _quax;

      public FooCommand(ILogger<FooCommand> logger, IQuaxService quax)
      {
         _logger = logger;
         _quax = quax;
      }

      protected override Func<Task<int>> OnExecuteAsync(CommandLineApplication command)
      {
         var pathOption = command.Option("-p|--path", "Path to file", CommandOptionType.SingleValue);

         async Task<int> Ret()
         {
            _logger.LogInformation("Before delay");
            await Task.Delay(20);
            _logger.LogInformation("After delay");
            _logger.LogInformation($"Path: {pathOption.Value()}");
            _quax.Add();

            return 0;
         }

         return Ret;
      }
   }
}
