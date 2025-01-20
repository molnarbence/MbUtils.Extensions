using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.CommandLineUtils;

public static class HostBuilderExtensions
{
   public static IHostBuilder AddConfig<TConfig>(this IHostBuilder hostBuilder, string configSectionName) where TConfig : class, new()
     => hostBuilder.ConfigureServices((hostBuilderContext, services)
        => services.AddOptions<TConfig>()
           .Bind(hostBuilderContext.Configuration.GetSection(configSectionName))
           .ValidateDataAnnotations()
           .ValidateOnStart());
   
   public static IHostBuilder AddHomeFolderConfigurationFile(this IHostBuilder hostBuilder, string folderName)
     => hostBuilder.ConfigureAppConfiguration((_, configurationBuilder)
        => configurationBuilder.AddJsonFile(
           GetHomeFolderConfigurationFile(folderName), 
           optional: true)
        );
   
   private static string GetHomeFolderConfigurationFile(string folderName)
   {
      var homeFolder = Environment.GetEnvironmentVariable("HOME")
                       ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
      return Path.Combine(homeFolder, folderName, "appsettings.json");
   }
}
