using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.CommandLineUtils;

public class CommandLineApplicationWrapper<TApp>(string[] args) where TApp : class
{
   private readonly string[] _args = args;

   public IHostBuilder HostBuilder { get; } = Host.CreateDefaultBuilder(args);

   public async Task<int> ExecuteAsync()
   {
      try
      {
         return await HostBuilder.RunCommandLineApplicationAsync<TApp>(_args);
      }
      catch (CommandParsingException ex)
      {
         Console.WriteLine(ex.Message);
         return 1;
      }
   }
}
