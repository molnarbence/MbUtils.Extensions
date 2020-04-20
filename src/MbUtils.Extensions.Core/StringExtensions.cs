﻿namespace MbUtils.Extensions
{
   public static class StringExtensions
   {
      public static bool HasValue(this string s)
      {
         return !string.IsNullOrEmpty(s);
      }

      public static bool IsNullOrEmpty(this string s)
      {
         return string.IsNullOrEmpty(s);
      }
   }
}
