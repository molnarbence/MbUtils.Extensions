using Microsoft.Extensions.CommandLineUtils;

namespace MbUtils.Extensions.CommandLineUtils
{
   public abstract class CommandBase : ICommand
   {
      protected abstract string CommandName { get; }

      public CommandLineApplication Setup(CommandLineApplication rootApp)
      {
         rootApp.Command(CommandName, SetupInternal);
         return rootApp;
      }

      protected virtual void SetupInternal(CommandLineApplication command)
      {
         command.HelpOption("-?|-h|--help");
      }
   }
}
