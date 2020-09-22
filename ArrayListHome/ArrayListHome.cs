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
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при работе в файлом: " + e);
            }

            Console.Write("Исходный список: ");
            PrintList(list);

            RemoveEvenNumbers(list);

            Console.Write("Список без четных чисел: ");
            PrintList(list);

            var listWithoutDuplicates = CopyListWithoutRepeatingNumbers(list);

            Console.Write("Список без повторений: ");
            PrintList(listWithoutDuplicates);
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
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
            Console.Write("[");

            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write(list[i] + ", ");
            }

            Console.WriteLine(list[list.Count - 1] + "]");
        }

        public static List<int> CopyListWithoutRepeatingNumbers(List<int> list)
        {
            List<int> newList = new List<int>();

            foreach (int e in list)
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