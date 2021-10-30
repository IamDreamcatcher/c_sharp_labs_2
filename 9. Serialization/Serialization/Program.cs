using System;
using System.Collections.Generic;
using Serializer;
using Serialization.Domain;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            MySerializer serializer = new MySerializer();
            List<Hospital> hospitals = new List<Hospital>();

            Hospital firstHospital = new Hospital("FirstHospital");
            firstHospital.AddDepartment(new Department("AdmissionDepartment", new Person("1Name")));
            firstHospital.AddDepartment(new Department("TreatmentDepartment", new Person("2Name")));
            firstHospital.AddDepartment(new Department("DiagnosticDepartment", new Person("3Name")));
            hospitals.Add(firstHospital);

            Hospital secondHospital = new Hospital("SecondHospital");
            secondHospital.AddDepartment(new Department("AdmissionDepartment", new Person("4Name")));
            secondHospital.AddDepartment(new Department("TreatmentDepartment", new Person("5Name")));
            secondHospital.AddDepartment(new Department("DiagnosticDepartment", new Person("6Name")));
            hospitals.Add(secondHospital);

            Hospital thirdHospital = new Hospital("ThirdHospital");
            thirdHospital.AddDepartment(new Department("AdmissionDepartment", new Person("7Name")));
            thirdHospital.AddDepartment(new Department("TreatmentDepartment", new Person("8Name")));
            thirdHospital.AddDepartment(new Department("DiagnosticDepartment", new Person("9Name")));
            hospitals.Add(thirdHospital);

            Hospital fourthHospital = new Hospital("FourthHospital");
            fourthHospital.AddDepartment(new Department("AdmissionDepartment", new Person("10Name")));
            fourthHospital.AddDepartment(new Department("TreatmentDepartment", new Person("11Name")));
            fourthHospital.AddDepartment(new Department("DiagnosticDepartment", new Person("12Name")));
            hospitals.Add(fourthHospital);

            Hospital fifthHospital = new Hospital("FifthHospital");
            fifthHospital.AddDepartment(new Department("AdmissionDepartment", new Person("13Name")));
            fifthHospital.AddDepartment(new Department("TreatmentDepartment", new Person("14Name")));
            fifthHospital.AddDepartment(new Department("DiagnosticDepartment", new Person("15Name")));
            hospitals.Add(fifthHospital);

            String pref = @"C:\Users\olegv\Desktop\Labs\c_sharp_labs_2\9. Serialization\Serialization\Files\";
            var newHospitals = serializer.DeSerializeByLINQ(pref + "LINQ-to-XML.xml");
            serializer.SerializeByLINQ(hospitals, pref + "LINQ-to-XML.xml");
            Console.WriteLine("LINQ-to-XML");
            foreach (Hospital hospital in newHospitals)
            {
                hospital.GetInfo();
            }
            Console.WriteLine("------------------------------");

            serializer.SerializeJSON(hospitals, pref + "JsonFile.json");
            newHospitals = serializer.DeSerializeJSON(pref + "JsonFile.json");
            Console.WriteLine("JSON");
            foreach (Hospital hospital in newHospitals)
            {
                hospital.GetInfo();
            }
            Console.WriteLine("------------------------------");

            serializer.SerializeXML(hospitals, pref + "HMLFile.xml");
            newHospitals = serializer.DeSerializeXML(pref + "HMLFile.xml");
            Console.WriteLine("HML");
            foreach (Hospital hospital in newHospitals)
            {
                hospital.GetInfo();
            }
            Console.WriteLine("------------------------------");
        }
    }
}
