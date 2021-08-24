using System;
using TDDChallenge.Services;

namespace TDDChallenge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 3, 5, 53, 52, 55 };
            var service = new ArrayOutlierService(arr);

            var outlier = service.FindOutlier();

            Console.WriteLine($"The outlier is {outlier}");
            Console.ReadLine();
        }
    }
}
