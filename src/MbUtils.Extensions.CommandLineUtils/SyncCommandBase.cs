using System;
using Microsoft.Extensions.CommandLineUtils;

namespace MbUtils.Extensions.CommandLineUtils
{
   public abstract class SyncCommandBase : CommandBase
   {
      protected override void SetupInternal(CommandLineApplication command)
      {
         base.SetupInternal(command);

         command.OnExecute(OnExecute(command));
      }

      protected abstract Func<int> OnExecute(CommandLineApplication command);
   }
}
