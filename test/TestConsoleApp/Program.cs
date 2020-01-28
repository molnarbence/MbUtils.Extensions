using System;
using MbUtils.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TestConsoleApp
{
   class Program
   {
      static void Main(string[] args)
      {
         var wrapper = new CommandLineApplicationWrapper(args, "testapp", "Test app of CommandLineUtils library");
         wrapper
            .AddCommand<FooCommand>()
            .AddCommand<BarCommand>();

         wrapper.HostBuilder.ConfigureServices(services => services.AddSingleton<IQuaxService, QuaxService>());

         wrapper.Execute();
      }
   }
}
