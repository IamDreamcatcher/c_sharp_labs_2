using FileService.Interfaces;
using System.Collections.Generic;
using System.IO;


namespace FileService.Entities
{
    class MyFileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("There is no file: " + fileName);
            }
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    int salary = reader.ReadInt32();
                    bool isIntern = reader.ReadBoolean();

                    yield return new Employee(salary, name, isIntern);
                }
            }
        }
        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                foreach (Employee employee in data)
                {
                    writer.Write(employee.Name);
                    writer.Write(employee.Salary);
                    writer.Write(employee.IsIntern);
                }
            }
        }
    }
}
