using System;

namespace Serialization.Domain
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public Person()
        {

        }
        public Person(string name)
        {
            Name = name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person person = obj as Person;
            if (person == null)
                return false;
            return person.Name == Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
