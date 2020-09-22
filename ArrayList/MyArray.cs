using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    class MyArray<T> : IList<T>
    {
        private T[] items = new T[10];
        private int length;

        public MyArray(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Вместимость списка должна быть > 0");
            }

            items = new T[capacity];
        }

        public int Count
        {
            get { return length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentException("Индекс должен быть >= 0");
                }

                if (index >= length)
                {
                    throw new ArgumentException("Значение индекса превышает количество элементов в списке");
                }

                return items[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new ArgumentException("Индекс должен быть >= 0");
                }

                if (index >= length)
                {
                    throw new ArgumentException("Значение индекса превышает количество элементов в списке");
                }

                items[index] = value;
            }
        }

        public bool IsReadOnly { get; }//todo: ??????????????????????????????????????????????????????????????????????????????????

        private void EnsureCapacity(int requiredCapacity)
        {
            if (requiredCapacity < items.Length)
            {
                return;
            }

            Array.Resize(ref items, requiredCapacity);
        }

        private void TrimToSize()
        {
            if (items.Length > length)
            {
                Array.Resize(ref items, length);
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
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

            if (index > length)
            {
                throw new ArgumentException("Значение индекса превышает количество элементов в списке");
            }

            EnsureCapacity(length * 2);
            Array.Copy(items, index, items, index + 1, length - index);
            length++;
        }








        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
