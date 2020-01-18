﻿using System;
using System.Collections.Generic;

namespace MbUtils.Extensions.Core
{
   public class ServiceFactory<TService> : Dictionary<string, Func<TService>>, IServiceFactory<TService>
   {
      public TService Get(string name)
      {
         return this[name]();
      }
   }
}
