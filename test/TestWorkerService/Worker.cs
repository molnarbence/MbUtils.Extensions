using Microsoft.Extensions.Options;

namespace TestWorkerService;

public class Worker(ILogger<Worker> logger, IOptions<FooConfig> fooConfig) : BackgroundService
{

   protected override async Task ExecuteAsync(CancellationToken stoppingToken)
   {
      logger.LogInformation("FooConfig: {foo}", fooConfig.Value.Bar);
      while (!stoppingToken.IsCancellationRequested)
      {
         if (logger.IsEnabled(LogLevel.Information))
         {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
         }

         await Task.Delay(1000, stoppingToken);
      }
   }
}
