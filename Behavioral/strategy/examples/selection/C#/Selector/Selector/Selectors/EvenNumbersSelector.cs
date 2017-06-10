using System.Collections.Generic;

namespace Selector.Selectors
{
    public class EvenNumbersSelector : IIntegerSelector
    {
        public IEnumerable<int> Select(IEnumerable<int> source)
        {
            var sourceEnumerator = source.GetEnumerator();
            while (sourceEnumerator.MoveNext())
            {
                if (sourceEnumerator.Current % 2 == 0)
                    yield return sourceEnumerator.Current;
            }

            // Or using Linq
            //return source.Where(el => el % 2 == 0);
        }
    }
}
