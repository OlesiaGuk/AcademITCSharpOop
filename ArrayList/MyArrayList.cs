using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class MyArrayList<T> : IList<T>
    {
        private T[] _items;
        private int _modCount;

        public int Count { get; private set; }

        public MyArrayList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Вместимость списка должна быть > 0");
            }

            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentException("Индекс должен быть >= 0");
                }

                if (index >= Count)
                {
                    throw new ArgumentException("Значение индекса превышает количество элементов в списке");
                }

                return _items[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new ArgumentException("Индекс должен быть >= 0");
                }

                if (index >= Count)
                {
                    throw new ArgumentException("Значение индекса превышает количество элементов в списке");
                }

                _items[index] = value;
            }
        }

        public bool IsReadOnly { get; }

        private void EnsureCapacity(int requiredCapacity)
        {
            if (requiredCapacity < _items.Length)
            {
                return;
            }

            Array.Resize(ref _items, requiredCapacity * 2);
        }

        private void TrimToSize()
        {
            if (_items.Length > Count)
            {
                Array.Resize(ref _items, Count);
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
            {
                throw new ArgumentException("Индекс должен быть >= 0");
            }

            if (index > Count)
            {
                throw new ArgumentException("Значение индекса превышает количество элементов в списке");
            }

            EnsureCapacity(Count);

            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = item;
            Count++;
            _modCount++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Индекс должен быть >= 0");
            }

            if (index > Count)
            {
                throw new ArgumentException("Значение индекса превышает количество элементов в списке");
            }

            if (index < Count - 1)
            {
                Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            }

            Count--;
            _modCount++;
        }

        public void Add(T item)
        {
            EnsureCapacity(Count);
            _items[Count] = item;
            Count++;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _items.Length);
            Count = 0;
            _modCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentException("Индекс должен быть >= 0");
            }

            if (arrayIndex >= array.Length)
            {
                throw new ArgumentException("Значение индекса превышает количество элементов в массиве");
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException("Число элементов в исходной коллекции больше доступного места от положения, заданного значением параметра arrayIndex, до конца массива назначения array");
            }

            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
            }

            return index >= 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var savedModCount = _modCount;

            for (var i = 0; i < Count; i++)
            {
                if (_modCount != savedModCount)
                {
                    throw new InvalidOperationException("За время обхода в коллекции изменилось количество элементов");
                }

                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append("[");

            for (var i = 0; i < Count - 1; i++)
            {
                s.Append(_items[i] + ", ");
            }

            s.Append(_items[Count - 1] + "]");

            return s.ToString();
        }
    }
}