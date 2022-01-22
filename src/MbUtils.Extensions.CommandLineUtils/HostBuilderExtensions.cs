using MbUtils.Extensions.Infrastructure;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.CommandLineUtils;

public static class HostBuilderExtensions
{
   public static IHostBuilder AddConfig<TConfig>(this IHostBuilder hostBuilder, string configSectionName) where TConfig : class, new()
     => hostBuilder.ConfigureServices((hostBuilderContext, services)
        => services.ConfigurePOCO<TConfig>(hostBuilderContext.Configuration.GetSection(configSectionName)));
}
