using System;
using System.Collections.Generic;

namespace Serialization.Domain
{
    [Serializable]
    public class Hospital
    {
        public string Name { get; set; }
        private List<Department> departments = new List<Department>(); 
        public List<Department> listOfAdmissionDepartments
        {
            get { return departments; }
            set { departments = value; }
        }
        public Hospital()
        {

        }
        public Hospital(string name)
        {
            Name = name;
        }

        public Department this[int index]
        {
            get
            {
                if (index < 0 || index >= departments.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return departments[index];
            }
            set
            {
                if (index < 0 || index >= departments.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                departments[index] = value;
            }
        }
        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }
        public void RemoveDepartment(Department department)
        {
            if (!departments.Contains(department))
            {
                throw new ArgumentException("No such department");
            }
            departments.Remove(department);
        }
        public int Count() => departments.Count;
        public void Clear() => departments.Clear();
        public void GetInfo()
        {
            Console.WriteLine("Hospital-" + Name + " has departments:");
            foreach (Department dep in departments)
            {
                dep.GetInfo();
            }
        }
    }
}
