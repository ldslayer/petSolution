using petSolution.Model;
using System;
using System.Collections.Generic;

namespace petSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Require the console Arguments
            var arguments = new Arguments(args);
            var animals = new List<Animal>();
            IAnimalService animalService = new AnimalService(animals, arguments);
            var resultList = animalService.GetAll();
            Console.WriteLine($"Search Results: \n");
            Console.WriteLine($"|   Type    |   Name    |   Gender  |   Date    |");
            foreach (var item in resultList)
            {
                Console.WriteLine($"|   {item.AnimalType}    |   {item.Name}    |   {item.Gender}  |   {item.TimeStamp}    |");
            }

            Console.ReadLine();

        }
    }
}
