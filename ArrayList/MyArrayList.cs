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

        public int Capacity
        {
            get => _items.Length;

            private set
            {
                if (value < _items.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Переданное значение емкости {value} меньше текущего размера, равного {_items.Length}");
                }

                if (value == _items.Length)
                {
                    return;
                }

                Array.Resize(ref _items, value);
            }
        }

        public MyArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Передано значение вместимости = {capacity}. Вместимость списка должна быть >= 0", nameof(capacity));
            }

            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return _items[index];
            }

            set
            {
                CheckIndex(index);

                _items[index] = value;
                _modCount++;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException($"Передан индекс = {index}. Индекс должен быть >= 0");
            }

            if (index >= Count)
            {
                throw new IndexOutOfRangeException($"Значение индекса {index} должно быть меньше количества элементов в списке, равного {Count}");
            }
        }

        public bool IsReadOnly => false;

        public void TrimToSize()
        {
            Capacity = Count;
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                for (var i = 0; i < Count; i++)
                {
                    if (_items[i] == null)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (var i = 0; i < Count; i++)
                {
                    if (_items[i] == null)
                    {
                        continue;
                    }

                    if (_items[i].Equals(item))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException($"Передан индекс = {index}. Индекс должен быть >= 0");
            }

            if (index > Count)
            {
                throw new IndexOutOfRangeException($"Значение индекса {index} не должно быть больше количества элементов в списке, равного {Count}");
            }

            Capacity = _items.Length == 0 ? 1 : (Count == _items.Length ? _items.Length * 2 : _items.Length);

            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = item;
            Count++;
            _modCount++;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            Array.Copy(_items, index + 1, _items, index, Count - index - 1);

            ref var removingElementReference = ref _items[Count - 1];
            removingElementReference = default;

            Count--;
            _modCount++;
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        public void Clear()
        {
            Array.Clear(_items, 0, Count);
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
                throw new IndexOutOfRangeException($"Передан индекс = {arrayIndex}. Индекс должен быть >= 0");
            }

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
            if (Count == 0)
            {
                return "[]";
            }

            var s = new StringBuilder();
            s.Append("[");

            for (var i = 0; i < Count - 1; i++)
            {
                s.Append(_items[i]).Append(", ");
            }

            s.Append(_items[Count - 1]);

            s.Append("]");
            return s.ToString();
        }
    }
}