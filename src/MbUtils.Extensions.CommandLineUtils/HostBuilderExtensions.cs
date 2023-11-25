using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.CommandLineUtils;

public static class HostBuilderExtensions
{
   public static IHostBuilder AddConfig<TConfig>(this IHostBuilder hostBuilder, string configSectionName) where TConfig : class, new()
     => hostBuilder.ConfigureServices((hostBuilderContext, services)
        => services.Configure<TConfig>(hostBuilderContext.Configuration.GetSection(configSectionName)));
}
