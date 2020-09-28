namespace Shapes.Shapes
{
    class Rectangle : IShape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public Rectangle(double width, double length)
        {
            Width = width;
            Height = length;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return (Width + Height) * 2;
        }

        public override string ToString()
        {
            return $"Прямоугольник со сторонами {Width:f2} и {Height:f2}. Площадь = {GetArea():f2}, периметр = {GetPerimeter():f2}";
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

            return Width == rectangle.Width && Height == rectangle.Height;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();

            return hash;
        }
    }
}