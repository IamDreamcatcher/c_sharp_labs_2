using System;
using System.Collections.Generic;
using FileService.Entities;
using System.IO;
using System.Linq;

namespace FileService
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(1, "X", true));
            employees.Add(new Employee(10, "Xx", false));
            employees.Add(new Employee(100, "Xxx", true));
            employees.Add(new Employee(1000, "Xxxx", false));
            employees.Add(new Employee(10000, "Xxxxx", true));

            MyFileService fileService = new MyFileService();

            fileService.SaveData(employees, @"C:\Users\olegv\Desktop\Labs\c_sharp_labs_2\8. File service\Files\ListWithEmployes.txt");

            File.Move(@"C:\Users\olegv\Desktop\Labs\c_sharp_labs_2\8. File service\Files\ListWithEmployes.txt",
                 @"C:\Users\olegv\Desktop\Labs\c_sharp_labs_2\8. File service\Files\NewListWithEmployes.txt", true);

            IEnumerable<Employee> newEmployess = new List<Employee>();

            newEmployess = fileService.ReadFile(@"C:\Users\olegv\Desktop\Labs\c_sharp_labs_2\8. File service\Files\NewListWithEmployes.txt");
        
            var sortedEmployess = newEmployess.OrderBy(employee => employee, new EmployeeComparer());

            foreach (var employee in sortedEmployess)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
