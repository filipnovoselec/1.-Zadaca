using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_zadaca
{

    public interface IIntegerList
    {
        /// <summary>
        /// Adds an item to the collection. /// 
        ///</summary> 
        void Add(int item);

        /// <summary> 
        /// Removes the first occurrence of an item from the collection. 
        /// If the item was not found, method does nothing. 
        /// </summary> 
        bool Remove(int item);

        /// <summary> 
        /// Removes the item at the given index in the collection. 
        /// </summary> 
        bool RemoveAt(int index);

        /// <summary>
        /// Returns the item at the given index in the collection. 
        /// </summary> 
        int GetElement(int index);

        /// <summary> 
        /// Returns the index of the item in the collection.
        /// If item is not found in the collection, method returns -1. 
        /// </summary>
        int IndexOf(int item);

        /// <summary> 
        /// Readonly property. Gets the number of items contained in the collection. 
        /// </summary> 
        int Count { get; }

        /// <summary>
        /// Removes all items from the collection. 
        /// </summary> 
        void Clear();

        /// <summary> 
        /// Determines whether the collection contains a specific value. 
        /// </summary> 
        bool Contains(int item);
    }
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        public int ElementNumber;
        private int _elementCount = 0;

        public IntegerList()
        {
            ElementNumber = 4;
            _internalStorage = new int[ElementNumber];
        }

        public IntegerList(int initialSize)
        {
            ElementNumber = initialSize;
            _internalStorage = new int[ElementNumber];
        }

        public void Add(int item)
        {
            if (_elementCount == ElementNumber)
            {
                ElementNumber *= 2;
                int[] temporaryArray = new int[ElementNumber];
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

        public bool Remove(int item)
        {
            if (_internalStorage.Contains(item))
            {
                for (int i = 0; i < ElementNumber; i++)
                {
                    if (_internalStorage[i] == item)
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

        public int GetElement(int index)
        {
            if (index >= _elementCount)
                throw new IndexOutOfRangeException();
            else
                return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < ElementNumber; i++)
            {
                if (_internalStorage[i] == item)
                    return i;
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

        public bool Contains(int item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }
            else
                return true;
        }
    }
}
