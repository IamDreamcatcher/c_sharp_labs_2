namespace FileService.Entities
{
    class Employee
    {
        public int Salary { get; set; }
        public string Name { get; set; }
        public bool IsIntern { get; set; }

        public Employee(int salary, string name, bool isIntern)
        {
            Salary = salary;
            Name = name;
            IsIntern = isIntern;
        }

        public override string ToString()
        {
            string isIntern = IsIntern ? "Intern " : "Permanent employee ";
            return isIntern + Name + " has salary -" + Salary;  
        }
    }
}
