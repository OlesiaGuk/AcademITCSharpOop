using System;

namespace Vectors
{
    class VectorMain
    {
        static void Main(string[] args)
        {
            var vector1 = new Vector(3);
            Console.WriteLine($"Пустой вектор vector1 = {vector1}");

            var array = new double[] { -3, 4 };
            var vector2 = new Vector(2, array);
            Console.WriteLine($"Вектор vector2 = {vector2}");
            Console.WriteLine("Длина вектора vector2 = {0}", vector2.GetLength());

            var index = 0;
            Console.WriteLine("Компонента вектора vector2 по индексу {0} = {1}", index, vector2[index]);
            Console.WriteLine();

            var vector3 = new Vector(new double[] { 5, 10, 20 });
            Console.WriteLine($"Вектор vector2 = {vector2}");
            Console.WriteLine($"Вектор vector3 = {vector3}");

            vector2.Add(vector3);
            Console.WriteLine($"Сумма vector2 и vector3 = {vector2}");

            vector2.Subtract(vector3);
            Console.WriteLine($"Разность vector2 и vector3 = {vector2}");
            Console.WriteLine();

            var vector4 = new Vector(vector2);
            Console.WriteLine($"Вектор vector4 (копия vector2) = {vector4}");

            vector4[0] = 10;
            Console.WriteLine($"Вектор vector4 после установки компоненты 10 по индексу 0 = {vector4}");
            Console.WriteLine();

            Console.WriteLine($"Вектор vector3 = {vector3}");
            Console.WriteLine($"Вектор vector4 = {vector4}");
            Console.WriteLine("Сумма векторов vector3 и vector4 = {0}", Vector.GetSum(vector3, vector4));
            Console.WriteLine("Разность векторов vector3 и vector4 = {0}", Vector.GetDifference(vector3, vector4));
            Console.WriteLine("Скалярное произведениe vector3 и vector4 = {0}", Vector.GetScalarProduct(vector3, vector4));
            Console.WriteLine();

            vector3.Reverse();
            Console.WriteLine($"Разворот вектора vector3: {vector3}");

            vector4.MultiplyByScalar(2);
            Console.WriteLine($"Умножение вектора vector4 на 2: {vector4}");
        }
    }
}