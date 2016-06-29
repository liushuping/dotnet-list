using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var directory = Directory.GetCurrentDirectory();
            var path = Path.Combine(directory, "project.json");
            var content = File.ReadAllText(path);
            var project = JObject.Parse(content);
            var dependencies = (JObject)project["dependencies"];
            var list = dependencies.Properties().Select(p => p.Name);
            var assembly = System.Reflection.Assembly.GetEntryAssembly();
            var packageName = assembly.GetName().Name;

            Console.WriteLine(packageName);

            var properties = dependencies.Properties().ToList();
            for (var i = 0; i < properties.Count() - 1; ++i)
            {
                var property = properties[i];
                Console.Write("├─");
                Console.WriteLine($"{property.Name}@{property.Value["version"]}");
            }
            
            Console.Write("└─");

            var last = properties.Last();
            if (last != null)
            {
                Console.WriteLine($"{last.Name}@{last.Value["version"]}");
            }
        }
    }
}
