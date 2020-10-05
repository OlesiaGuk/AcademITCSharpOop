using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            try
            {
                using (var reader = new StreamReader("..\\..\\input.txt"))
                {
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        list.Add(Convert.ToInt32(currentLine));
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл не найден: " + e.FileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при работе в файлом: " + e.Message);
            }

            Console.Write("Исходный список: ");
            PrintList(list);
            Console.WriteLine();

            RemoveEvenNumbers(list);

            Console.Write("Список без четных чисел: ");
            PrintList(list);
            Console.WriteLine();

            var listWithoutDuplicates = GetListWithoutRepeatingNumbers(list);

            Console.Write("Список без повторений: ");
            PrintList(listWithoutDuplicates);
            Console.WriteLine();
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void PrintList(List<int> list)
        {
            Console.Write($"[{string.Join(", ", list)}]");
        }

        public static List<int> GetListWithoutRepeatingNumbers(List<int> list)
        {
            var newList = new List<int>(list.Count);

            foreach (var e in list)
            {
                if (!newList.Contains(e))
                {
                    newList.Add(e);
                }
            }

            return newList;
        }
    }
}