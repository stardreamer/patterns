using Selector.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selector
{
    class Program
    {
        public static void PrintSelectedElements(List<int> source, IIntegerSelector selector)
        {
            Console.WriteLine($"[{source.Select(el => el.ToString()).Aggregate((one, two) => one + ", " + two)}]");
            foreach (var element in selector.Select(source))
            {
                Console.WriteLine($"Selected element: {element}");
            }
        }

        static void Main(string[] args)
        {
            var sourceList = new List<int>() { 1, 2, 3, 4, 5, 6, -4, -1, -455, 2, 1, 456, 783, 12, 45, 90, 24 };

            Console.WriteLine("Selecting even numbers");
            PrintSelectedElements(sourceList, new EvenNumbersSelector());

            Console.WriteLine("Selecting odd numbers");
            PrintSelectedElements(sourceList, new OddNumbersSelector());

            Console.WriteLine("Selecting numbers in range [1, 20]");
            PrintSelectedElements(sourceList, new NumbersFormRangeSelector(1, 20));
        }
    }
}