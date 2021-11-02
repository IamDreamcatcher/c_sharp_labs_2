using System;
using System.Diagnostics;

namespace Calculating
{
    public class Computing
    {
        public delegate void EndHappened(double result, long time,
            double leftBorder, double rightBorder, string priority);
        public event EndHappened EndOfMethod;
        public void Integrate(double leftBorder, double rightBorder, string priority)
        {
            double step = 0.00000001;
            double totalFunctionValue = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (double currentValueX = leftBorder; currentValueX <= rightBorder; currentValueX += step)
            {
                totalFunctionValue += Math.Sin(currentValueX) * step;
            }
            stopwatch.Stop();
            EndOfMethod?.Invoke(Math.Round(totalFunctionValue, 5), stopwatch.ElapsedMilliseconds,
                leftBorder, rightBorder, priority);
        }
    }
}
