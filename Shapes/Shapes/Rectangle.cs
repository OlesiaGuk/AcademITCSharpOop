namespace Shapes.Shapes
{
    class Rectangle : IShape
    {
        public double Width { get; set; }

        public double Length { get; set; }

        public Rectangle(double width, double length)
        {
            Width = width;
            Length = length;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Length;
        }

        public double GetArea()
        {
            return Width * Length;
        }

        public double GetPerimeter()
        {
            return (Width + Length) * 2;
        }

        public override string ToString()
        {
            return $"Прямоугольник со сторонами {Width:f2} и {Length:f2}. Площадь = {GetArea():f2}, периметр = {GetPerimeter():f2}";
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

            var rectangle = (Rectangle)obj;

            return Width == rectangle.Width && Length == rectangle.Length;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Length.GetHashCode();

            return hash;
        }
    }
}