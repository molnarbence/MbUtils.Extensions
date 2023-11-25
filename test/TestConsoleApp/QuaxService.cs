using Microsoft.Extensions.Logging;

namespace TestConsoleApp;

public interface IQuaxService
{
   void Add();
}

public class QuaxServiceConfig
{
   public int Config1 { get; set; }
   public string Config2 { get; set; }
}

public class QuaxService(ILogger<QuaxService> logger) : IQuaxService
{
   private readonly ILogger<QuaxService> _logger = logger;

   public void Add()
   {
      _logger.LogInformation("Added");
   }
}
