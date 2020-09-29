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
                throw new ArgumentException("Вместимость списка должна быть > 0", nameof(capacity));
            }

            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                CheckIndexBoundaries(index);

                return _items[index];
            }

            set
            {
                CheckIndexBoundaries(index);

                _items[index] = value;
                _modCount++;
            }
        }

        private static void CheckIndexLowerBound(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException($"Передан индекс = {index}. Индекс должен быть >= 0");
            }
        }

        private void CheckIndexBoundaries(int index)
        {
            CheckIndexLowerBound(index);

            if (index >= Count)
            {
                throw new IndexOutOfRangeException($"Значение индекса {index} должно быть меньше количества элементов в списке, равного {Count}");
            }
        }

        public bool IsReadOnly => false;

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
            CheckIndexLowerBound(index);

            if (index > Count)
            {
                throw new IndexOutOfRangeException($"Значение индекса {index} не должно быть больше количества элементов в списке, равного {Count}");
            }

            EnsureCapacity(Count);

            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = item;
            Count++;
            _modCount++;
        }

        public void RemoveAt(int index)
        {
            CheckIndexLowerBound(index);

            if (index > Count)
            {
                throw new IndexOutOfRangeException($"Значение индекса {index} не должно быть больше количество элементов в списке, равного {Count}");
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
            Insert(Count, item);
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
            CheckIndexLowerBound(arrayIndex);

            if (arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException($"Значение индекса {arrayIndex} превышает количество элементов в массиве, равное {array.Length}");
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException($"Число элементов в исходной коллекции ({Count}) больше доступного места от положения, " +
                                            $"заданного значением параметра arrayIndex ({arrayIndex}), до конца массива назначения array, размер которого = {array.Length}",
                    nameof(arrayIndex));
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
                    throw new InvalidOperationException("За время обхода коллекция изменилась");
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

            if (Count > 0)
            {
                for (var i = 0; i < Count - 1; i++)
                {
                    s.Append(_items[i]).Append(", ");
                }

                s.Append(_items[Count - 1]);
            }

            s.Append("]");
            return s.ToString();
        }
    }
}