using System;
using MbUtils.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TestConsoleApp
{
   class Program
   {
      static void Main(string[] args)
      {
         var wrapper = new CommandLineApplicationWrapper<Program>(args);
         
         wrapper.HostBuilder.ConfigureServices(services => services.AddSingleton<IQuaxService, QuaxService>());
         wrapper.HostBuilder.ConfigureServices((hostBuilderContext, services) => {
            var config = hostBuilderContext.Configuration.GetValue<QuaxServiceConfig>(nameof(QuaxService));
            services.AddSingleton(config);
         });

         wrapper.Execute();
      }
   }
}
