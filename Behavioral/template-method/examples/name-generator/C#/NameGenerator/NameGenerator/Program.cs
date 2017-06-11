using NameGenerator.Generators;
using System;
using System.Text;

namespace NameGenerator
{
    class Program
    {
        private static void PrintRandomName(BaseNameGenerator generator)
        {
            Console.WriteLine($"Generated name: {generator.GetName()}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine($"Generating russian name.");
            PrintRandomName(new RussianNameGenerator());
            Console.WriteLine($"Generating english name.");
            PrintRandomName(new EnglishNameGenerator());
            Console.WriteLine($"Generating german name.");
            PrintRandomName(new GermanNameGenerator());
        }
    }
}