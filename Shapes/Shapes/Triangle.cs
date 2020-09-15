using System;

namespace Shapes.Shapes
{
    class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return GetMaxValue(X1, X2, X3) - GetMinValue(X1, X2, X3);
        }

        public double GetHeight()
        {
            return GetMaxValue(Y1, Y2, Y3) - GetMinValue(Y1, Y2, Y3);
        }

        public double GetArea()
        {
            var halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - GetSideLength(X1, Y1, X2, Y2)) * (halfPerimeter - GetSideLength(X2, Y2, X3, Y3)) *
                             (halfPerimeter - GetSideLength(X1, Y1, X3, Y3)));
        }

        public double GetPerimeter()
        {
            return GetSideLength(X1, Y1, X2, Y2) + GetSideLength(X2, Y2, X3, Y3) + GetSideLength(X1, Y1, X3, Y3);
        }

        private static double GetMaxValue(double a, double b, double c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        private static double GetMinValue(double a, double b, double c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        private static double GetSideLength(double a1, double b1, double a2, double b2)
        {
            return Math.Sqrt(Math.Pow((a2 - a1), 2) + Math.Pow((b2 - b1), 2));
        }

        public override string ToString()
        {
            return string.Format(
                $"Треугольник с вершинами ({X1}; {Y1}) ({X2}; {Y2}) ({X3}; {Y3}). Площадь = {GetArea():f2}, периметр = {GetPerimeter():f2}");
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

            var triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2 && X3 == triangle.X3 && Y3 == triangle.Y3;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}