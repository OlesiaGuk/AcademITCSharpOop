﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambdas
{
    class LambdasMain
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person("Иван", 24),
                new Person("Иван", 17),
                new Person("Сергей", 22),
                new Person("Мария", 16),
                new Person("Алексей", 30)
            };

            Console.WriteLine("Исходный список:");
            persons.ForEach(Console.WriteLine);
            Console.WriteLine();

            var distinctNames = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            Console.WriteLine("Уникальные имена: " + string.Join(", ", distinctNames) + ".");
            Console.WriteLine();

            var under18Persons = persons
                .Where(p => p.Age < 18)
                .ToList();

            var averageAge = under18Persons
                .Select(p => p.Age)
                .Average();

            Console.WriteLine("Список людей, младше 18: ");
            under18Persons.ForEach(Console.WriteLine);

            Console.WriteLine($"Их средний возраст = {averageAge}");
            Console.WriteLine();

            var averageAgesByNames = persons
                .GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, g => g.Average(p => p.Age));

            Console.WriteLine("Сгруппировано по именам:");
            averageAgesByNames.Select(i => $"{i.Key} : средний возраст = {i.Value}")
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();

            var personsFrom20To45 = persons
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .ToList();

            Console.WriteLine("Люди в возрасте от 20 до 45 лет:");
            personsFrom20To45.ForEach(Console.WriteLine);

            var personsFrom20To45NamesDescending = string.Join(", ", personsFrom20To45
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name));

            Console.WriteLine("Их имена в порядке убывания возраста: " + personsFrom20To45NamesDescending);
        }
    }
}