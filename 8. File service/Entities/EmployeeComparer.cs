using System.Collections.Generic;

namespace FileService.Entities
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Name.CompareTo(y.Name);
    }
}