using System;
using System.Collections.Generic;
using System.IO;

namespace ExportingDataSample
{
    /// <summary>
    /// Define the Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var people = GetPeople();
            var basePath = Directory.GetCurrentDirectory();

            var fullPath = Path.Combine(basePath, "mycsvfile_includeHeader.csv");

            // to cvs file
            File.WriteAllText(fullPath, Export.Exporter(true, System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator, people));

            fullPath = Path.Combine(basePath, "myfile_includeHeader.txt");

            // to a txt file
            File.WriteAllText(fullPath, Export.Exporter(true, "+", people));

            fullPath = Path.Combine(basePath, "mycsvfile.csv");

            // to cvs file
            File.WriteAllText(fullPath, Export.Exporter(true, System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator, people));

            fullPath = Path.Combine(basePath, "myfile.txt");

            // to a txt file
            File.WriteAllText(fullPath, Export.Exporter(true, "|", people));
        }

        /// <summary>
        /// Gets the people.
        /// </summary>
        /// <returns>The IEnumerable&lt;Person&gt;.</returns>
        private static IEnumerable<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person { Name = "Mary", Age = 22, Birthday = new DateTime(1992, 03, 24), Country = "Ireland" },
                new Person { Name = "Peter", Age = 10, Birthday = new DateTime(2004, 01, 05), Country = "Portugal" },
                new Person { Name = "Anne", Age = 50, Birthday = new DateTime(1964, 11, 03), Country = "Spain" }
            };
        }
    }
}
