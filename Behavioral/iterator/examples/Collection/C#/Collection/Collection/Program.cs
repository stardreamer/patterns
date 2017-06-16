using System;
using System.Collections.Generic;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectsOfInterest = new object[] { 1, "covfefe", 123.4, true };

            var genericCollection = new GenericCollection.GenericCollection(objectsOfInterest);
            var genericCollectionEnumerator = genericCollection.GetEnumerator();

            Console.WriteLine("Iterating through our GenericCollection");
            while (genericCollectionEnumerator.MoveNext())
            {
                Console.WriteLine(genericCollectionEnumerator.Current);
            }


            var builtInEnumerator = objectsOfInterest.GetEnumerator();
            Console.WriteLine("\nIterating through builtin collection");
            while (builtInEnumerator.MoveNext())
            {
                Console.WriteLine(builtInEnumerator.Current);
            }

            Console.WriteLine("\nIterating through builtin collection. (iterator blocks)");
            var iteratorBlocksEnumerator = new List<object>(objectsOfInterest).GetEnumerator();
            while (iteratorBlocksEnumerator.MoveNext())
            {
                Console.WriteLine(iteratorBlocksEnumerator.Current);
            }
        }
    }
}