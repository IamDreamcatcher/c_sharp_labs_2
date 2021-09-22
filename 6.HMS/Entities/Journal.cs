using System;
using HMS.Collection;

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
        MyCustomCollection<RegisteredEvents> events = new MyCustomCollection<RegisteredEvents>();
        public void AddEvent(string eventName, string eventDescription)
        {
            events.Add(new RegisteredEvents(eventName, eventDescription));
        }

        public void PrintAllEvents()
        {
            events.Reset();
            Console.WriteLine("Events:");
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine(events.Current().EventName + " - " 
                    + events.Current().EventDescription);
                events.Next();
            }
            Console.WriteLine();
        }
    }
}