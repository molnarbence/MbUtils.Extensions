using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace MbUtils.Extensions.CommandLineUtils
{
   public class CommandLineApplicationWrapper
   {
      private readonly CommandLineApplication _app;

      public CommandLineApplicationWrapper(string name, string description)
      {
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
      }

      public CommandLineApplicationWrapper SetupCommand(ICommand command)
      {
         command.Setup(_app);
         return this;
      }

      public void Execute(string[] args)
      {
         try
         {
            Console.WriteLine("Executing app...");
            _app.Execute(args);
         }
         catch (CommandParsingException ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
   }
}
