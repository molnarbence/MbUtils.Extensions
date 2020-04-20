using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.CommandLineUtils
{
   public class CommandLineApplicationWrapper<TApp> where TApp : class
   {
      private readonly string[] _args;

      public IHostBuilder HostBuilder { get; }

      public CommandLineApplicationWrapper(string[] args)
      {
         _args = args;
         HostBuilder = Host.CreateDefaultBuilder(args);
      }

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
}
