using Spectre.Console;
using Spectre.Console.Cli;

namespace TestSpectreConsoleApp;

public class FooCommand(IBarService barService) : AsyncCommand
{
   public override async Task<int> ExecuteAsync(CommandContext context, CancellationToken cancellationToken)
   {
      await Task.Delay(1000, cancellationToken);

      var qux = barService.GetQux();
      
      AnsiConsole.MarkupLine($"Hello [green]{qux}[/]!");

      return 0;
   }
}
