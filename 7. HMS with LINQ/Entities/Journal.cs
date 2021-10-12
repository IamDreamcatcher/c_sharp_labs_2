using System;
using System.Collections.Generic;

namespace HMS.Entities
{
    class Journal
    {
        struct RegisteredEvents
        {
            public string EventName { get; set; }
            public string EventDescription { get; set; }
            public RegisteredEvents(string eventName, string eventDescription)
            {
                EventName = eventName;
                EventDescription = eventDescription;
            }
        }
        List<RegisteredEvents> events = new List<RegisteredEvents>();
        public void AddEvent(string eventName, string eventDescription)
        {
            events.Add(new RegisteredEvents(eventName, eventDescription));
        }

        public void PrintAllEvents()
        {
            Console.WriteLine("Events:");
            foreach (RegisteredEvents item in events)
            {
                Console.WriteLine(item.EventName + " - " + item.EventDescription);
            }
            Console.WriteLine();
        }
    }
}