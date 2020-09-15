using System;

namespace Shapes.Shapes
{
    class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return Radius * 2;
        }

        public double GetHeight()
        {
            return Radius * 2;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return string.Format($"Круг с радиусом {Radius:f}. Площадь = {GetArea():f}, длина окружности = {GetPerimeter():f}");
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

            var circle = (Circle)obj;

            return Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            return hash * prime + Radius.GetHashCode();
        }
    }
}