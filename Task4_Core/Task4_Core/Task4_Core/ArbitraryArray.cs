using System;
using System.Collections;
using System.Collections.Generic;

namespace Task4_Core
{
    public class ArbitraryArray<T> : IEnumerable<T>
    {
        private T[] _items;

        private int _leftIndex;

        private int _rightIndex;

        public int Count => _items.Length;

        public ArbitraryArray(int leftIndex, int rightIndex)
        {
            _items = new T[rightIndex - leftIndex + 1];
            _leftIndex = leftIndex;
            _rightIndex = rightIndex;
        }

        public ArbitraryArray(int leftIndex, T[] array)
        {
            var length = array.Length;
            _items = new T[length];
            _leftIndex = leftIndex;
            _rightIndex = _leftIndex + length - 1;
            Array.Copy(array, _items, length);
        }

        public T GetElement(int index)
        {
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            var innerIndex = index - _leftIndex;

            return _items[innerIndex];
        }

        public bool SetElement(int index, T item)
        {
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            var innerIndex = index - _leftIndex;

            _items[innerIndex] = item;

            return true;
        }

        public T this[int index]
        {
            get { return GetElement(index); }
            set { SetElement(index, value); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0, size = _items.Length; i < size; ++i)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool ValidIndex(int index)
        {
            return !(index < _leftIndex || index > _rightIndex);
        }
    }
}