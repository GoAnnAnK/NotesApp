using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Persistence
{
    public class FileClient : IFileClient
    {
        /*        private readonly string _fileName;
                public FileClient(string fileName)
                {
                    _fileName = fileName;
                    File.Create(_fileName);
                }*/
        public IEnumerable<T> ReadAll<T>(string fileName)
        {
            var jsonItems = File.ReadAllLines(fileName);

            return jsonItems.Select(jsonItems => JsonSerializer.Deserialize<T>(jsonItems));

        }
        public void WriteAll<T>(string fileName, IEnumerable<T> items)
        {
            var jsonItems = items.Select(item => JsonSerializer.Serialize(item));
            File.WriteAllLines(fileName, jsonItems);
        }

        public void Append<T>(string FileName, T item)
        {
            var jsonItem = JsonSerializer.Serialize(item);
            File.AppendAllLines(FileName, new[] { jsonItem });
        }

        public void DeleteFileContents(string fileName)
        {
            File.WriteAllLines(fileName, Array.Empty<string>());
        }



    }
}
