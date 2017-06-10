using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
