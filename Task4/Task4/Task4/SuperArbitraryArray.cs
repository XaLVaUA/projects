using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Task4
{
    public class SuperArbitraryArray<T> : IEnumerable<T>
    {
        private T[] _items;

        private int _leftIndex;

        private int _rightIndex;

        public int Capacity => _rightIndex - _leftIndex + 1;

        public SuperArbitraryArray()
        {
            _items = new T[1];
            _leftIndex = 0;
            _rightIndex = 0;
        }

        public T GetValue(int index)
        {
            if (!IsValidIndex(index))
            {
                return default;
            }

            var innerIndex = index - _leftIndex;
            return _items[innerIndex];
        }

        public bool SetValue(int index, T value)
        {
            if (!IsValidIndex(index))
            {
                AdaptCapacityToIndex(index);
            }

            var innerIndex = index - _leftIndex;
            _items[innerIndex] = value;

            return true;
        }

        public T this[int index]
        {
            get { return GetValue(index); }
            set { SetValue(index, value); }
        }

        private void AdaptCapacityToIndex(int index)
        {
            if (index < _leftIndex)
            {
                AdaptLeft(index);
            }
            else
            {
                AdaptRight(index);
            }
        }

        private void AdaptLeft(int index)
        {
            var offset = _leftIndex - index;
            _leftIndex = index;

            var newItems = new T[Capacity];
            Array.Copy(_items, 0, newItems, offset, _items.Length);
            _items = newItems;
        }

        private void AdaptRight(int index)
        {
            _rightIndex = index;

            var newItems = new T[Capacity];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }

        private bool IsValidIndex(int index)
        {
            return !((index < _leftIndex) || (index > _rightIndex));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _leftIndex, size = _rightIndex + 1; i < size; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}