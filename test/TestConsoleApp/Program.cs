﻿using System.Threading.Tasks;
using MbUtils.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestConsoleApp;

[Command(Name = "test-utils", Description = "Test command line app for utils library")]
[Subcommand(typeof(FooCommand), typeof(BarCommand))]
class Program
{
   static Task<int> Main(string[] args)
   {
      var wrapper = new CommandLineApplicationWrapper<Program>(args);

      wrapper.HostBuilder
         .ConfigureServices(services => services.AddSingleton<IQuaxService, QuaxService>())
         .AddConfig<QuaxServiceConfig>(nameof(QuaxService));

      return wrapper.ExecuteAsync();
   }

   private int OnExecute(CommandLineApplication app, IConsole console)
   {
      console.WriteLine("You must specify at a subcommand.");
      app.ShowHelp();
      return 1;
   }
}
