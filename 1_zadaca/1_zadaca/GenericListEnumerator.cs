using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_zadaca
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private IGenericList<X> _collection;
        private int _count = -1;

        public GenericListEnumerator(IGenericList<X> collection)
        {
            _collection = collection;
        }

        public bool MoveNext()
        {
            _count++;
            return (_count < _collection.Count);
        }

        public X Current
        {
            get
            {
                return _collection.GetElement(_count);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {

        }

        public void Reset()
        {

        }
    }
}
