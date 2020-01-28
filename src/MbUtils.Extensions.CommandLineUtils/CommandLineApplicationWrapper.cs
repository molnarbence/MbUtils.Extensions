using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.CommandLineUtils
{
   public class CommandLineApplicationWrapper
   {
      private readonly CommandLineApplication _app;
      private readonly string[] _args;
      private readonly List<Type> _commandTypes = new List<Type>();

      public IHostBuilder HostBuilder { get; }


      public CommandLineApplicationWrapper(string[] args, string name, string description)
      {
         _args = args;

         _app = new CommandLineApplication
         {
            Name = name,
            Description = description
         };

         _app.HelpOption("-?|-h|--help");

         _ = _app.VersionOption("-v|--version", () =>
         {
            return $"Version {Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}";
         });

         HostBuilder = Host.CreateDefaultBuilder(args);
      }

      public CommandLineApplicationWrapper AddCommand<TCommand>() where TCommand : ICommand
      {
         _commandTypes.Add(typeof(TCommand));         
         return this;
      }

      public void Execute()
      {
         try
         {
            Console.WriteLine("Executing app...");

            // Register commands
            HostBuilder.ConfigureServices(services => {
               _commandTypes.ForEach(commandType =>
               {
                  services.AddTransient(commandType);
               });
            });

            var host = HostBuilder.Build();

            // Setup commands
            _commandTypes.ForEach(commandType => {
               var command = host.Services.GetService(commandType) as ICommand;
               command.Setup(_app);
            });

            var result = _app.Execute(_args);
            Console.WriteLine(string.Empty);
         }
         catch (CommandParsingException ex)
         {
            Console.WriteLine(ex.Message);
         }         
      }
   }
}
