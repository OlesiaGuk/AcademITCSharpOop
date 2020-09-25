using System;
using System.Text;

namespace Vectors
{
    class Vector
    {
        private double[] _components;

        public int Size => _components.Length;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Передана размерность = {size}. Размерность вектора должна быть > 0", nameof(size));
            }

            _components = new double[size];
        }

        public Vector(Vector vector)
        {
            _components = (double[])vector._components.Clone();
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Передан массив размером {array.Length}. Размерность вектора должна быть > 0", nameof(array));
            }

            _components = (double[])array.Clone();
        }

        public Vector(int size, double[] array)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Передана размерность = {size}. Размерность вектора должна быть > 0", nameof(size));
            }

            _components = new double[size];

            if (size < array.Length)
            {
                Array.Copy(array, 0, _components, 0, size);
                return;
            }

            Array.Copy(array, _components, array.Length);
        }

        public double this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException($"Передано значение индекса = {index}. Индекс должен быть >= 0");
                }

                if (index >= Size)
                {
                    throw new IndexOutOfRangeException($"Введенный индекс {index} превышает верхнюю границу индексов, равную {Size - 1}");
                }

                return _components[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException($"Передано значение индекса = {index}. Индекс должен быть >= 0");
                }

                if (index >= Size)
                {
                    throw new IndexOutOfRangeException($"Введенный индекс {index} превышает верхнюю границу индексов, равную {Size - 1}");
                }

                _components[index] = value;
            }
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append("{");

            for (var i = 0; i < Size - 1; i++)
            {
                s.Append(_components[i]).Append(", ");
            }

            s.Append(_components[Size - 1]).Append("}");

            return s.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            var vector = (Vector)obj;

            if (Size != vector.Size)
            {
                return false;
            }

            for (var i = 0; i < Size; i++)
            {
                if (_components[i] != vector._components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            foreach (double e in _components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public void Add(Vector vector)
        {
            if (Size < vector.Size)
            {
                Array.Resize(ref _components, vector.Size);
            }

            for (var i = 0; i < vector.Size; i++)
            {
                _components[i] += vector._components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (Size < vector.Size)
            {
                Array.Resize(ref _components, vector.Size);
            }

            for (var i = 0; i < vector.Size; i++)
            {
                _components[i] -= vector._components[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (var i = 0; i < Size; i++)
            {
                _components[i] *= scalar;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double squaresSum = 0;

            foreach (var e in _components)
            {
                squaresSum += e * e;
            }

            return Math.Sqrt(squaresSum);
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            var resultantVector = new Vector(vector1);
            resultantVector.Add(vector2);

            return resultantVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            var resultantVector = new Vector(vector1);
            resultantVector.Subtract(vector2);

            return resultantVector;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            var minArraySize = Math.Min(vector1.Size, vector2.Size);
            double scalarMultiplication = 0;

            for (var i = 0; i < minArraySize; i++)
            {
                scalarMultiplication += vector1._components[i] * vector2._components[i];
            }

            return scalarMultiplication;
        }
    }
}