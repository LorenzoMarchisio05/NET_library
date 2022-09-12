using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Marchisio.GeneralUtilsLibrary
{
	public static class ExtensionClass
	{
		public static T copy<T>(this T source, bool deepCopy = true) where T : notnull
        {
			return deepCopy ?
                (T)JsonSerializer.Deserialize(JsonSerializer.Serialize(source), source.GetType()) :
				source;
		}

		public static void ForEach<T>(this T[] array, Action<T> action)
		{
			Array.ForEach(array, action);
		}

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach(T data in collection)
            {
				action(data);
            }
        }
    }
}

