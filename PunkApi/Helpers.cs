using System;
using System.Collections.Generic;
using System.Linq;

namespace PunkApi
{
	public static class Helpers
	{
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}

