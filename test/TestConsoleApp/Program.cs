using System;
using MbUtils.Extensions.CommandLineUtils;

namespace TestConsoleApp
{
   class Program
   {
      static void Main(string[] args)
      {
         var wrapper = new CommandLineApplicationWrapper("testapp", "Test app of CommandLineUtils library");
         var logger = new Action<string>(Console.WriteLine);

         wrapper
            .SetupCommand(new FooCommand(logger))
            .SetupCommand(new BarCommand(logger));

         wrapper.Execute(args);
      }
   }
}
