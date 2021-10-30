using System.Collections.Generic;
using Assemblies.Interfaces;
using System.Text.Json;
using System.IO;

namespace Lib
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            string data = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<IEnumerable<T>>(data);
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            string convertData = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, convertData);
        }
    }
}
