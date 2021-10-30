using System;

namespace Serialization.Domain
{
    [Serializable]
    public class Department
    {
        
        public string DepartmentName { get; set; }
        public Person HeadOfDepartment { get; set; }
        public Department()
        {

        }
        public Department(string departmentName, Person headOfDepartment)
        {
            DepartmentName = departmentName;
            HeadOfDepartment = headOfDepartment;
        }
        public override int GetHashCode()
        {
            return DepartmentName.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Department dep = obj as Department;
            if (dep == null)
                return false;
            return dep.DepartmentName == DepartmentName
                && dep.HeadOfDepartment == HeadOfDepartment;
        }

        public void GetInfo()
        {
            Console.WriteLine("Department: " + DepartmentName +
                "\nHead of department: " + HeadOfDepartment);
        }
    }
}
