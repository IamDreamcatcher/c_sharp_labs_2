using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Entities;
using System.Xml.Serialization;

namespace Stream
{
    public class StreamService
    {
        object locker = new object();
        public Task WriteToStream(MemoryStream stream, List<Passenger> passengers)
        {

            return Task.Run(() => {
                lock (locker)
                {
                    Console.WriteLine("Writting to stream in the thread " +
                        Thread.CurrentThread.ManagedThreadId + " started");

                    XmlSerializer xmlFormatter = new XmlSerializer(passengers.GetType());
                    xmlFormatter.Serialize(stream, passengers);

                    Console.WriteLine("Writting to stream in the thread " +
                        Thread.CurrentThread.ManagedThreadId + " finished");
                }
            });
        }
        public Task CopyFromStream(MemoryStream stream, string fileName)
        {
            return Task.Run(() => {
                lock (locker)
                {

                    Console.WriteLine("Reading from stream in the thread " +
                        Thread.CurrentThread.ManagedThreadId + " started");

                    using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        stream.WriteTo(fileStream);
                    }

                    Console.WriteLine("Reading from stream in the thread " +
                        Thread.CurrentThread.ManagedThreadId + " finished");
                }
            });
        }
        public async Task<int> GetStatisticsAsync(string fileName,
            Func<Passenger, bool> filter)
        {
            int count = 0;
            await Task.Run(() => {
                Console.WriteLine("The counting in GetStatisticsAsync in the thread " +
                    Thread.CurrentThread.ManagedThreadId + " started");

                List<Passenger> passengers = new List<Passenger>();
                XmlSerializer xmlFormatter = new XmlSerializer(passengers.GetType());
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    passengers = (List<Passenger>)xmlFormatter.Deserialize(fileStream);
                }
                foreach (Passenger passenger in passengers)
                {
                    if (filter(passenger))
                    {
                        count++;
                    }
                }

                Console.WriteLine("The counting in GetStatisticsAsync in the thread " +
                    Thread.CurrentThread.ManagedThreadId + " finished");
            });
            return count;
        }
    }
}
