using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace MbUtils.Extensions.SpectreConsole
{
   public class SpectreConsoleHost
   {
      private Action<IConfigurator> _configure = _ => { };
      public IServiceCollection Services { get; } = new ServiceCollection();

      public void Configure(Action<IConfigurator> configure) => _configure = configure;

      public Task<int> RunAsync(IEnumerable<string> args)
      {
         var registrar = new SimpleTypeRegistrar(Services);
         var commandApp = new CommandApp(registrar);
         
         commandApp.Configure(_configure);

         return commandApp.RunAsync(args);
      }
   }
}
