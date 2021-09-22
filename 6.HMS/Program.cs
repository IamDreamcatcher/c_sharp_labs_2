﻿using System;
using HMS.Entities;
using HMS.Collection;

namespace HMS
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing collection

            MyCustomCollection<int> collection = new MyCustomCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            collection.Add(5);

            collection.Remove(4);
            collection.Remove(1);

            collection.Reset();
            for (int i = 0; i < collection.Count; i++)
            {
                Console.Write(collection.Current() + " ");
                collection.Next();
            }
            Console.Write(collection[0]);
            Console.WriteLine();


            //testing HMS
            Journal journal = new Journal();
            MyHMS newHMS = new MyHMS();
            newHMS.NotifyRateChange += delegate (Rate newRate)
            {
                journal.AddEvent("Rate change", newRate.name + " cost is " + newRate.cost);
            };
            newHMS.NotifyTenantChange += delegate (Tenant newTenant)
            {
                journal.AddEvent("Tenant change", newTenant.name + " was registered");
            };

            newHMS.NotifyConsumption += (string tenantName, string rateName, int cost)
                => Console.WriteLine(tenantName + " spent " + cost + " on " + rateName);

            newHMS.AddTenant("Max");
            newHMS.AddTenant("Oleg");

            newHMS.AddRate("Gas", 10);
            newHMS.AddRate("Electricity", 15);
            newHMS.AddRate("Whater", 30);

            newHMS.AddServiceConsumption("Oleg", "Gas", 10);
            newHMS.AddServiceConsumption("Oleg", "Electricity", 10);
            newHMS.AddServiceConsumption("Oleg", "Whater", 15);

            newHMS.AddServiceConsumption("Max", "Electricity", 10);
            newHMS.AddServiceConsumption("Max", "Whater", 1);

            Console.WriteLine("Oleg - " + newHMS.GetAmountOfConsumedServicesByName("Oleg"));
            Console.WriteLine("Max - " + newHMS.GetAmountOfConsumedServicesByName("Max"));
            Console.WriteLine("Oleg+Max - " + newHMS.GetAmountOfConsumedServices());

            journal.PrintAllEvents();
        }
    }
}
