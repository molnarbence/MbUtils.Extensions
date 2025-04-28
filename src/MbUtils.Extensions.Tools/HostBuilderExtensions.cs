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
      hostBuilder.Configuration.AddJsonFile(
         GetHomeFolderConfigurationFile(folderName),
         optional: true);
         
      return hostBuilder;
   }
   
   private static string GetHomeFolderConfigurationFile(string folderName)
   {
      var homeFolder = Environment.GetEnvironmentVariable("HOME")
                       ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
      return Path.Combine(homeFolder, folderName, "appsettings.json");
   }
}
