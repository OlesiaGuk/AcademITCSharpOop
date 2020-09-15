using System;
using Shapes.Shapes;

namespace Shapes.ShapesMain
{
    class ShapesMain
    {
        static void Main(string[] args)
        {
            var shapesArray = new IShape[5];
            shapesArray[0] = new Square(15);
            shapesArray[1] = new Square(20);
            shapesArray[2] = new Rectangle(5, 25);
            shapesArray[3] = new Triangle(1, 1, 2, 5, 5, 3);
            shapesArray[4] = new Circle(7);

            Console.WriteLine("Исходный список фигур: ");

            foreach (var s in shapesArray)
            {
                Console.WriteLine(s);
            }

            var shapesAreaComparator = new ShapesAreaComparator();
            Array.Sort(shapesArray, shapesAreaComparator);

            Console.WriteLine();
            Console.WriteLine("Фигура(ы) с максимальной площадью: ");

            foreach (var s in shapesArray)
            {
                if (s.GetArea() == shapesArray[0].GetArea())
                {
                    Console.WriteLine(s);
                }
            }

            var shapesPerimeterComparator = new ShapesPerimeterComparator();
            Array.Sort(shapesArray, shapesPerimeterComparator);

            Console.WriteLine();
            Console.WriteLine("Фигура(ы) со вторым по величине периметром: ");

            var secondMaxPerimeterShape = GetSecondMaxPerimeterShape(shapesArray);

            if (secondMaxPerimeterShape == null)
            {
                Console.WriteLine("отсутствует в списке");
            }
            else
            {
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
        }

        private static IShape GetSecondMaxPerimeterShape(IShape[] shapesArray)
        {
            var max = shapesArray[0].GetPerimeter();

            for (var i = 1; i < shapesArray.Length; i++)
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