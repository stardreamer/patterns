using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.GenericCollection
{
    class GenericCollection : IGenericEnumerable
    {
        private object[] _array;
        public GenericCollection(object[] array)
        {
            _array = array;
        }

        public IGenericEnumerator GetEnumerator()
        {
            return new GenericEnumerator(_array);
        }
    }
}
