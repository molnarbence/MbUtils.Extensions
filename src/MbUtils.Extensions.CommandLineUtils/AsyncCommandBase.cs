using System;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace MbUtils.Extensions.CommandLineUtils
{
   public abstract class AsyncCommandBase : CommandBase
   {
      protected override void SetupInternal(CommandLineApplication command)
      {
         base.SetupInternal(command);

         command.OnExecute(OnExecuteAsync(command));
      }

      protected abstract Func<Task<int>> OnExecuteAsync(CommandLineApplication command);
   }
}
