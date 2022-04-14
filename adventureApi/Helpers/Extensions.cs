using System;
using System.Collections.Generic;
using System.Linq;

namespace adventureApi.Helpers
{
    public static class Extensions
    {
        public static decimal AverageOrDefault(this IEnumerable<decimal> source)
        {
            if (source.Any())
                return source.Average();
            else
                return default;
        }
    }
}
