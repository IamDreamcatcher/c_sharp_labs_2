using System;
using Calculating;
using System.Threading.Tasks;
using System.Threading;

namespace Integral
{
    class Program
    {
        static void Main(string[] args)
        {
            Computing computing = new Computing();
            double leftBorder = 0;
            double rightBorder = 5;
            computing.EndOfMethod += (result, time, leftBorder, rightBorder, priority) => 
                Console.WriteLine("The result of calculating the integral of the sin(x) function in the interval between " +
                leftBorder + " and " + rightBorder + " is " + result + " time spent: " + time + ", priority: " + priority);

            Parallel.Invoke(() =>
                            {
                                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                                Console.WriteLine("Thread with highest priority start");
                                computing.Integrate(leftBorder, rightBorder, "Highest");
                                Console.WriteLine("Thread with highest priority end");
                            },
                            () =>
                            {
                                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                                Console.WriteLine("Thread with lowest priority start");
                                computing.Integrate(leftBorder, rightBorder, "Lowest");
                                Console.WriteLine("Thread with lowest priority end");
                            }
            );  
        }
    }
}
