using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TestConsoleApp
{
   public interface IQuaxService
   {
      void Add();
   }

   public class QuaxServiceConfig
   { 

   }

   public class QuaxService : IQuaxService
   {
      private readonly ILogger<QuaxService> _logger;

      public QuaxService(ILogger<QuaxService> logger)
      {
         _logger = logger;
      }
      public void Add()
      {
         _logger.LogInformation("Added");
      }
   }
}
