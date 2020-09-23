using System;

namespace ArrayList
{
    class ArrayListMain
    {
        static void Main(string[] args)
        {
            var list = new MyArrayList<int>(10);
            list.Add(1);
            list.Insert(0, 2);
            list.Insert(1, 5);
            Console.WriteLine($"Исходный список: {list}, размер списка = {list.Count}");

            var index = 1;
            Console.WriteLine($"Элемент по индексу {index} = {list[index]}");

            list[index] = 10;
            Console.WriteLine($"Заменен элемент по индексу {index}: {list}");

            var item = 50;
            Console.WriteLine($"Список содержит число {item}? {list.Contains(item)}");

            var removingItem = 2;
            Console.WriteLine($"Элемент {removingItem} удален из списка? {list.Remove(2)}");
            Console.WriteLine($"Список: {list}");

            var array = new int[list.Count];
            list.CopyTo(array, 0);
            Console.WriteLine("Массив = " + string.Join(", ", array));
        }
    }
}