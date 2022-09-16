using System;
using System.Collections.Generic;
using System.Linq;

namespace PunkApi
{
	public static class Helpers
	{
        /// <summary>
        /// Extension method for verify if list is null o empty
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="enumerable">List of item</param>
        /// <returns>True if list is empty or null</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}

