using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.GenericCollection
{
    class GenericEnumerator : IGenericEnumerator
    {
        private int _currentIndex { get; set; }
        private object[] _readOnlyCollection { get; }

        public object Current
        {
            get
            {
                if (_currentIndex < 0)
                    throw new InvalidOperationException("Call MoveNext() first!");

                return _readOnlyCollection[_currentIndex];
            }

        }


        public GenericEnumerator(object[] readOnlyCollection)
        {
            _readOnlyCollection = readOnlyCollection;
            _currentIndex = -1;
        }

        public bool MoveNext()
        {
            if (_currentIndex == _readOnlyCollection.Length-1)
                return false;

            _currentIndex++;
            return true;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}
