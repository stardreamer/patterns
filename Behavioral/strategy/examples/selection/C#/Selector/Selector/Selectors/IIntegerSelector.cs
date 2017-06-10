using System.Collections.Generic;

namespace Selector.Selectors
{
    public interface IIntegerSelector
    {
        IEnumerable<int> Select(IEnumerable<int> source);
    }
}
