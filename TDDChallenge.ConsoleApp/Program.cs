using System;
using System.Collections.Generic;
using TDDChallenge.Services;

namespace TDDChallenge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayOutlierExample();
            ListFilterExample();
            FormatWordsExample();

            Console.ReadLine();
        }

        public static void ArrayOutlierExample()
        {
            var arr = new int[] { 1, 3, 5, 53, 52, 55 };
            var service = new ArrayOutlierService(arr);

            var outlier = service.FindOutlier();

            Console.WriteLine($"The outlier is {outlier}");

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void ListFilterExample()
        {
            var arr = new  List<object> { "abc", "test", "loren", 1, 2, 3 };
            var service = new ListFilterService(arr);

            var filter = service.FilterList(ListFilterService.FilterType.Strings);

            Console.WriteLine($"List with only integers: ");
            filter.ForEach(item =>
            {
                Console.WriteLine($"{item}");
            });

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void FormatWordsExample()
        {
            var arr = new List<string> { "ninja", "samurai", "ronin" };
            var service = new FormatWordsService(arr.ToArray());

            var formatedWords = service.CommaSeparatedFormat();

            Console.WriteLine($"Words with comma separated: {formatedWords}");

            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
