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
            // var resultList = animalService.GetAll();
            var resultList = animalService.Search();
            Console.WriteLine($"Search Results:");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"_________________________________________________");
            Console.WriteLine($"|   Type    |   Name    |   Gender  |   Date    |");
            Console.WriteLine($"-------------------------------------------------");
            foreach (var item in resultList)
            {
                Console.WriteLine($"|   {item.AnimalType}    |   {item.Name}    |   {item.Gender}  |   {item.TimeStamp.ToLongDateString()}    |");
            }
            Console.WriteLine($"_________________________________________________");

            Console.WriteLine();
            Console.WriteLine("Solved By: Luis Delfin Briceño Gordy");
            Console.WriteLine("email: luis.delfin.bg@gmail.com");
            Console.WriteLine("Thank you !");

            Console.WriteLine();

            Console.WriteLine("Press Enter To Exit. ");
            Console.ReadLine();
        }
    }
}
