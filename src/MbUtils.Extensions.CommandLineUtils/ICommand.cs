using Microsoft.Extensions.CommandLineUtils;

namespace MbUtils.Extensions.CommandLineUtils
{
   public interface ICommand
   {
      CommandLineApplication Setup(CommandLineApplication rootApp);
   }
}
