using FileService.Entities;
using System.Collections.Generic;

namespace FileService.Interfaces
{
    interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}
