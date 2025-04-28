using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MbUtils.Extensions.Tools;

public static class HostBuilderExtensions
{
   public static IHostApplicationBuilder AddConfig<TConfig>(this IHostApplicationBuilder builder, string configSectionName) where TConfig : class, new()
   {
      builder.Services.AddOptions<TConfig>()
         .Bind(builder.Configuration.GetSection(configSectionName))
         .ValidateDataAnnotations()
         .ValidateOnStart();
      
      return builder;
   }

   public static IHostApplicationBuilder AddHomeFolderConfigurationFile(this IHostApplicationBuilder hostBuilder,
      string folderName)
   {
      var appDataFolder = Environment.GetEnvironmentVariable("HOME")
                       ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
      
      var appHomeFolderConfigurationFile = Path.Combine(appDataFolder, folderName, "appsettings.json");
      
      hostBuilder.Configuration
         .AddJsonFile(appHomeFolderConfigurationFile, optional: true)
         .AddInMemoryCollection([
            new KeyValuePair<string, string?>("AppDataFolder", appDataFolder),
         ]);
         
      return hostBuilder;
   }
}
