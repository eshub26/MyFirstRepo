using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadFromExcelSB.Helpers
{
    internal class Utilities
    {
        private const string _namespace = "ReadFromExcelSB";
        public static string ReadResourceContent(string resourceName)
        {
            // Determine path
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Format: "{Namespace}.{Folder}.{filename}.{Extension}"

            var resourcePath = $"{_namespace}.Resources.{resourceName}.html";


            using (Stream? stream = assembly.GetManifestResourceStream(resourcePath))
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    return String.Empty;
                }
        }

    }
}
