using System;
using Shapes.Shapes;
using Shapes.ShapesComparers;

namespace Shapes
{
    class ShapesMain
    {
        static void Main(string[] args)
        {
            var shapesArray = new IShape[]
            {
                new Square(15), 
                new Square(20), 
                new Rectangle(5, 25), 
                new Triangle(1, 1, 2, 5, 5, 3), 
                new Circle(7)
            };

            Console.WriteLine("Исходный список фигур: ");

            foreach (var s in shapesArray)
            {
                Console.WriteLine(s);
            }

            Array.Sort(shapesArray, new ShapesAreaComparer());

            Console.WriteLine();
            Console.WriteLine("Фигура(ы) с максимальной площадью: ");

            foreach (var s in shapesArray)
            {
                if (s.GetArea() == shapesArray[shapesArray.Length - 1].GetArea())
                {
                    Console.WriteLine(s);
                }
            }

            Array.Sort(shapesArray, new ShapesPerimeterComparer());

            Console.WriteLine();
            Console.WriteLine("Фигура(ы) со вторым по величине периметром: ");

            var secondMaxPerimeterShape = GetSecondMaxPerimeterShape(shapesArray);

            if (secondMaxPerimeterShape == null)
            {
                Console.WriteLine("отсутствует в списке");
            }
            else
            {
                foreach (var s in shapesArray)
                {
                    if (s.GetPerimeter() == secondMaxPerimeterShape.GetPerimeter())
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }

        private static IShape GetSecondMaxPerimeterShape(IShape[] shapesArray)
        {
            var max = shapesArray[shapesArray.Length - 1].GetPerimeter();

            for (var i = shapesArray.Length - 2; i >= 0; i--)
            {
                if (shapesArray[i].GetPerimeter() < max)
                {
                    return shapesArray[i];
                }
            }

            return null;
        }
    }
}