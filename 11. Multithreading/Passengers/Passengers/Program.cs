using System;
using Entities;
using Stream;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace Passengers
{
    class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Main started working in the thread " +
                 Thread.CurrentThread.ManagedThreadId);
            List<Passenger> passengers = new List<Passenger>();
            for (int i = 0; i < 100; i++)
            {
                passengers.Add(new Passenger("Passenger" + i, i < 40 ? true : false));
            }
            StreamService streamService = new StreamService();
            string fileName = @"C:\Users\olegv\Desktop\Labs\c_sharp_labs_2\11. Multithreading\Passengers\Passengers\Files\Passengers.xml";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var task1 = streamService.WriteToStream(memoryStream, passengers);
                await Task.Delay(100);
                var task2 = streamService.CopyFromStream(memoryStream, fileName);
                await Task.WhenAll(new Task[] { task1, task2 });
            }
            int count = streamService.GetStatisticsAsync(fileName,
                (passenger) => passenger.HaveBaggage).Result;
            Console.WriteLine("Number of passengers with baggage " + count);

            Console.WriteLine("Main ended working in the thread " +
                 Thread.CurrentThread.ManagedThreadId);
        }
    }
}
