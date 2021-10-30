using System;
using System.Collections.Generic;
using Assemblies.Entities;
using System.Reflection;

namespace Assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\olegv\Desktop\Labs\c_sharp_labs_2\10. Assemblies\Assemblies\Files\Employees.json";
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(1, "X", true));
            employees.Add(new Employee(10, "Xx", false));
            employees.Add(new Employee(100, "Xxx", true));
            employees.Add(new Employee(1000, "Xxxx", false));
            employees.Add(new Employee(10000, "Xxxxx", true));
            Type[] typeArgs = { typeof(Employee) };
            
            Assembly assembly = Assembly.LoadFrom("Lib.dll");
            Type t = assembly.GetType("Lib.FileService`1", true, true);
            t = t.MakeGenericType(typeArgs);
            object obj = Activator.CreateInstance(t);
            MethodInfo methodSaveData = t.GetMethod("SaveData");
            MethodInfo methodReadFile = t.GetMethod("ReadFile");
            methodSaveData.Invoke(obj, new object[] { employees, fileName});
            object data = methodReadFile.Invoke(obj, new object[] { fileName});
            List<Employee> newEmployees = (List<Employee>)data;
            foreach (Employee employee in newEmployees)
            {
                Console.WriteLine(employee);
            }
            
        }
    }
}
