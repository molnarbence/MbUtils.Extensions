using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.CommandLineUtils
{
   public static class HostBuilderExtensions
   {
      public static IHostBuilder AddConfig<TConfig>(this IHostBuilder hostBuilder, string configSectionName) where TConfig : class
        => hostBuilder.ConfigureServices((hostBuilderContext, services)
           => services.AddSingleton(hostBuilderContext.Configuration.GetValue<TConfig>(configSectionName)));
   }
}
