using System;
using HMS.Entities;

namespace HMS
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing HMS
            Journal journal = new Journal();
            MyHMS newHMS = new MyHMS();
            newHMS.NotifyRateChange += journal.AddEvent;
            newHMS.NotifyTenantChange += journal.AddEvent;
            newHMS.NotifyConsumption += (string eventName, string eventDescription)
                => Console.WriteLine(eventName + eventDescription);

            newHMS.AddTenant("Max");
            newHMS.AddTenant("Oleg");

            newHMS.AddRate("Gas", 10);
            newHMS.AddRate("Electricity", 15);
            newHMS.AddRate("Whater", 30);

            newHMS.AddServiceConsumption("Oleg", "Gas", 10);
            newHMS.AddServiceConsumption("Oleg", "Gas", 10);
            newHMS.AddServiceConsumption("Oleg", "Electricity", 10);
            newHMS.AddServiceConsumption("Oleg", "Whater", 15);

            newHMS.AddServiceConsumption("Max", "Electricity", 10);
            newHMS.AddServiceConsumption("Max", "Whater", 1);

            Console.WriteLine("Oleg - " + newHMS.GetAmountOfConsumedServicesByName("Oleg"));
            Console.WriteLine("Max - " + newHMS.GetAmountOfConsumedServicesByName("Max"));
            Console.WriteLine("Oleg+Max - " + newHMS.GetAmountOfConsumedServices());

            newHMS.PrintOrdersOfTenant("Oleg");
            var rates = newHMS.GetSortedRates();

            Console.WriteLine("List of rates:");
            foreach(string item in rates)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Most cost tenant is " + newHMS.GetMostCostTenant());
            Console.WriteLine("Number of clients that paid more than 200 - " 
                + newHMS.GetNumberOfClientsWithLargerAmount(200));
            journal.PrintAllEvents();
        }
    }
}
