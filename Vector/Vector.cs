﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private double[] _components;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть > 0");
            }

            _components = new double[n];
        }

        public Vector(Vector vector)
        {
            _components = (double[])vector._components.Clone();
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Размерность вектора должна быть > 0");
            }

            _components = (double[])array.Clone();
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть > 0");
            }

            _components = new double[n];
            Array.Copy(array, _components, array.Length);
        }

        public int GetSize()
        {
            return _components.Length;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append("{");

            for (var i = 0; i < _components.Length - 1; i++)
            {
                s.Append(_components[i]).Append(", ");
            }

            s.Append(_components[_components.Length - 1]).Append("}");

            return s.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            var vector = (Vector)obj;

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (var i = 0; i < GetSize(); i++)
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

            return prime * hash + _components.GetHashCode();
        }


    }
}
/*
 *public void add(Vector vector) {
        if (getSize() < vector.getSize()) {
            components = Arrays.copyOf(components, vector.getSize());
        }
        for (int i = 0; i < vector.getSize(); i++) {
            components[i] += vector.components[i];
        }
    }

    public void subtract(Vector vector) {
        if (getSize() < vector.getSize()) {
            components = Arrays.copyOf(components, vector.getSize());
        }
        for (int i = 0; i < vector.getSize(); i++) {
            components[i] -= vector.components[i];
        }
    }

    public void multiplyByScalar(double scalar) {
        for (int i = 0; i < getSize(); i++) {
            components[i] *= scalar;
        }
    }

    public void reverse() {
        multiplyByScalar(-1);
    }

    public double getLength() {
        double squaresSum = 0;
        for (double e : components) {
            squaresSum += Math.pow(e, 2);
        }
        return Math.sqrt(squaresSum);
    }

    public double getComponentByIndex(int index) {
        if (index < 0) {
            throw new IndexOutOfBoundsException("Индекс должен быть >= 0");
        }
        if (index >= components.length) {
            throw new IndexOutOfBoundsException("Введенный индекс превышает размерность вектора");
        }

        return components[index];
    }

    public void setComponentByIndex(double newComponent, int index) {
        if (index < 0) {
            throw new IndexOutOfBoundsException("Индекс должен быть >= 0");
        }
        if (index >= components.length) {
            throw new IndexOutOfBoundsException("Введенный индекс превышает размерность вектора");
        }

        components[index] = newComponent;
    }

    public static Vector getSum(Vector vector1, Vector vector2) {
        Vector newVector = new Vector(vector1);
        newVector.add(vector2);
        return newVector;
    }

    public static Vector getDifference(Vector vector1, Vector vector2) {
        Vector newVector = new Vector(vector1);
        newVector.subtract(vector2);
        return newVector;
    }

    public static double getScalarMultiplication(Vector vector1, Vector vector2) {
        int minArraySize = Math.min(vector1.getSize(), vector2.getSize());

        double scalarMultiplication = 0;
        for (int i = 0; i < minArraySize; i++) {
            scalarMultiplication += vector1.components[i] * vector2.components[i];
        }

        return scalarMultiplication;
    } 
 * */