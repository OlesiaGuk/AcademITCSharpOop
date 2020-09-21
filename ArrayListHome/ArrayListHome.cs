using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("..\\..\\input.txt"))
            {
                var list = new List<int>();
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    list.Add(Convert.ToInt32(currentLine));
                }

                //Console.WriteLine(list.to);
            }





            /*
             * ArrayList<Integer> list = new ArrayList<>();

        try (Scanner scanner = new Scanner(new FileInputStream("./ArrayListHome/src/guk/1.txt"))) {
            while (scanner.hasNext()) {
                list.add(scanner.nextInt());
            }
        } catch (FileNotFoundException e) {
            System.out.println("Файл не найден: " + e.getMessage());
        } catch (SecurityException e) {
            System.out.println("Доступ к файлу запрещен: " + e.getMessage());
        } catch (Exception e) {
            System.out.println("Ошибка при работе в файлом: " + e.getMessage());
        }
        System.out.println("Исходный список: " + list);

        for (int i = 0; i < list.size(); i++) {
            if (list.get(i) % 2 == 0) {
                list.remove(i);
                i--;
            }
        }
        System.out.println("Список без четных чисел: " + list);

        ArrayList<Integer> list2 = new ArrayList<>();
        for (Integer e : list) {
            if (!list2.contains(e)) {
                list2.add(e);
            }
        }
        System.out.println("Список list без повторений: " + list2);
             */
        }
    }
}
