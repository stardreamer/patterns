using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.GenericCollection
{
    interface IGenericEnumerator
    {
        object Current { get; }
        bool MoveNext();
        void Reset();
    }
}
