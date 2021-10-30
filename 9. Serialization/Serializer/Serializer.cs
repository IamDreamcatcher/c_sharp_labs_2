using System;
using Serialization.Domain;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;

namespace Serializer
{
    public class MySerializer : ISerializer 
    {
        public IEnumerable<Hospital> DeSerializeByLINQ(string fileName)
        {
            XDocument document = XDocument.Load(fileName);
            List<Hospital> hospitals = new List<Hospital>();
            foreach (XElement elementHospital in document.Root.Elements("Hospital"))
            {
                Hospital hospital = new Hospital((string)elementHospital.Attribute("Name"));
                foreach (XElement elementDepartment in 
                    elementHospital.Element("Departments").Elements("Department"))
                {
                    string departmentName = (string)elementDepartment.Attribute("Name");
                    Person headOfDepartment = 
                        new Person((string)elementDepartment.Element("HeadOfDepartment").Attribute("Name"));
                    Department department = new Department(departmentName, headOfDepartment);
                    hospital.AddDepartment(department);
                }
                hospitals.Add(hospital);
            }
            return hospitals;
        }
        public IEnumerable<Hospital> DeSerializeXML(string fileName)
        {
            XmlSerializer formater = new XmlSerializer(typeof(List<Hospital>));
            using (FileStream fileStream =  new FileStream(fileName, FileMode.Open))
            {
                return (List<Hospital>)formater.Deserialize(fileStream);
            }
        }
        public IEnumerable<Hospital> DeSerializeJSON(string fileName)
        {
            string data = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Hospital>>(data);
        }
        public void SerializeByLINQ(IEnumerable<Hospital> hospitals, string fileName)
        {
            XDocument document = new XDocument();
            XElement elementHospitals = new XElement("Hospitals");
            foreach (Hospital hospital in hospitals)
            {
                XElement elementHospital = new XElement("Hospital", new XAttribute("Name", hospital.Name));
                XElement departments = new XElement("Departments");
                for (int i = 0; i < hospital.Count(); i++)
                {
                    XElement department = new XElement("Department",
                        new XAttribute("Name", hospital[i].DepartmentName),
                        new XElement("HeadOfDepartment",
                            new XAttribute("Name", hospital[i].HeadOfDepartment.Name)));
                    departments.Add(department);
                }
                elementHospital.Add(departments);
                elementHospitals.Add(elementHospital);
            }
            document.Add(elementHospitals);
            document.Save(fileName);
        }
        public void SerializeXML(IEnumerable<Hospital> hospitals, string fileName)
        {
            XmlSerializer formater = new XmlSerializer(typeof(List<Hospital>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                formater.Serialize(fileStream, hospitals);
            }
        }
        public void SerializeJSON(IEnumerable<Hospital> hospitals, string fileName)
        {
            string data = JsonSerializer.Serialize(hospitals);
            File.WriteAllText(fileName, data);
        }
    }
}
