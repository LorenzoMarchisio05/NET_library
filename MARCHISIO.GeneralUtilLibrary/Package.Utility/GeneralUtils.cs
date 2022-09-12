using System.Reflection;
using System.Text;

namespace Marchisio.GeneralUtilsLibrary
{
    public static class GeneralUtil
	{
        public static string serializeWithSeparator<T>(in T source, in string separator = ";") where T : notnull
		{
			PropertyInfo[] properties = source.GetType().GetProperties();
			if (properties.Length == 0) return string.Empty;

			var stringBuilder = new StringBuilder();

			foreach (PropertyInfo prop in properties)
			{
				stringBuilder
					.Append(prop.GetValue(source))
					.Append(separator);
			}
			return stringBuilder.ToString()[..^1];
		}

		public static void resetObject<T>(in T source) where T : notnull
        {
			PropertyInfo[] properties = source.GetType().GetProperties();
			if (properties.Length == 0) return;

			foreach (PropertyInfo prop in properties)
			{
				prop.SetValue(source, default);
			}
		}

        public static string ToJSONString<T>(this T source)
        {
            PropertyInfo[] properties = source.GetType().GetProperties();
            var sb = new StringBuilder();

            sb.Append("{\n");

            foreach (var property in properties)
            {
                sb.Append("\t").Append(property.Name).Append(": ").Append(property.GetValue(source)).Append("\n");
            }

            sb.Append("}\n");

            return sb.ToString();
        }

    }

}

