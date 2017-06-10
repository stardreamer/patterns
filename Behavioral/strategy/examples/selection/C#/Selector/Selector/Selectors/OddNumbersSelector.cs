using System;
using System.Collections.Generic;
using System.Text;

namespace Selector.Selectors
{
    public class OddNumbersSelector : IIntegerSelector
    {
        public IEnumerable<int> Select(IEnumerable<int> source)
        {
            var sourceEnumerator = source.GetEnumerator();
            while (sourceEnumerator.MoveNext())
            {
                if (sourceEnumerator.Current % 2 == 0)
                    continue;
                yield return sourceEnumerator.Current;
            }

            // Or using Linq
            //return source.Where(el => el % 2 != 0);
        }
    }
}
