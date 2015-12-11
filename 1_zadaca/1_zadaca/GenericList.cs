using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_zadaca
{
    public interface IGenericList<X> : IEnumerable<X>
    {
        ///<summary>
        /// Adds an item to the collection
        /// </summary>
        void Add(X item);

        ///<summary>
        /// Removes first occurrence of an item from the collection.
        /// If the item was not found, method does nothing
        /// </summary>
        bool Remove(X item);

        ///<summary>
        /// Removes the item at the give index in the collection.
        /// </summary>
        bool RemoveAt(int index);

        ///<summary>
        /// Returns the item at the given index in the collection.
        /// </summary>
        X GetElement(int index);

        ///<summary>
        /// Returns the index of the item in the collection.
        /// If item is not found in the collection, method returns -1.
        /// </summary>
        int IndexOf(X item);

        ///<summary>
        /// Readonly property. Gets the number of items contained in the collection.
        /// </summary>
        int Count { get; }

        ///<summary>
        /// Removes all items from the collection.
        /// </summary>
        void Clear();

        ///<summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        bool Contains(X item);
    }

    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        public int ElementNumber;
        private int _elementCount = 0;

        public GenericList()
        {
            ElementNumber = 4;
            _internalStorage = new X[4];
        }

        public GenericList(int num)
        {
            ElementNumber = num;
            _internalStorage = new X[ElementNumber];
        }

        public void Add(X item)
        {
            if (_elementCount == ElementNumber)
            {
                ElementNumber *= 2;
                X[] temporaryArray = new X[ElementNumber];
                Array.Copy(_internalStorage, temporaryArray, _internalStorage.Length);
                _internalStorage = temporaryArray;
                Add(item);
            }
            else
            {
                _internalStorage[_elementCount] = item;
                _elementCount++;
            }
        }

        public bool Remove(X item)
        {
            if (_internalStorage.Contains(item))
            {
                for (int i = 0; i < ElementNumber; i++)
                {
                    if (_internalStorage[i].Equals(item))
                        return RemoveAt(i);
                }
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _elementCount)
                return false;
            else
            {
                for (int i = index; i < _elementCount - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                _elementCount--;
                return true;
            }
        }

        public X GetElement(int index)
        {

            if (index >= _elementCount)
            {
                throw new IndexOutOfRangeException();
            }
            return _internalStorage[index];

        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _elementCount; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }

            return -1;
        }

        public int Count
        {
            get
            {
                return _elementCount;
            }
        }

        public void Clear()
        {
            _elementCount = 0;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) > 0) return true;
            else return false;
        }
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
