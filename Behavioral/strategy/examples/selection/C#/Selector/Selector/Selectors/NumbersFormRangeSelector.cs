using System;
using System.Collections.Generic;
using System.Text;

namespace Selector.Selectors
{
    public class NumbersFormRangeSelector : IIntegerSelector
    {
        public int RangeStart { get; }
        public int RangeEnd { get; }

        public NumbersFormRangeSelector(int rangeStart, int rangeEnd)
        {
            if (rangeStart >= rangeEnd)
                throw new ArgumentOutOfRangeException();

            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }

        public IEnumerable<int> Select(IEnumerable<int> source)
        {
            var sourceEnumerator = source.GetEnumerator();
            while (sourceEnumerator.MoveNext())
            {
                if (sourceEnumerator.Current >= RangeStart && sourceEnumerator.Current <= RangeEnd)
                    yield return sourceEnumerator.Current;
            }

            // Or using Linq
            //return source.Where(el => el >= RangeStart && el <= RangeEnd);
        }
    }
}
