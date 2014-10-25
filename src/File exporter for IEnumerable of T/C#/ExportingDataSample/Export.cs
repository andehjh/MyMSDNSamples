using System;
using System.Collections.Generic;
using System.Text;

namespace ExportingDataSample
{
    /// <summary>
    /// Define the Export File.
    /// </summary>
    public static class Export
    {
        /// <summary>
        /// Exporters the list of items that can include the specified include header line.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="includeHeaderLine">If set to <c>true</c> [include header line].</param>
        /// <param name="separator">The separator.</param>
        /// <param name="items">The items.</param>
        /// <returns>The content file.</returns>
        public static string Exporter<T>(bool includeHeaderLine, string separator, IEnumerable<T> items) where T : class
        {
            var sb = new StringBuilder();

            // Get properties using reflection. 
            var properties = typeof(T).GetProperties();

            if (includeHeaderLine)
            {
                // add header line
                foreach (var property in properties)
                {
                    sb.Append(property.Name).Append(separator);
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            // add value for each property. 
            foreach (T item in items)
            {
                foreach (var property in properties)
                {
                    sb.Append(MakeValueFriendly(property.GetValue(item, null))).Append(separator);
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Makes the value friendly.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The string converted.</returns>
        private static string MakeValueFriendly(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                {
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                }
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            var output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
            {
                output = '"' + output.Replace("\"", "\"\"") + '"';
            }

            return output;
        } 
    }
}
