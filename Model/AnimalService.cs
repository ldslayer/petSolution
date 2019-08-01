using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace petSolution.Model
{
    public class AnimalService : IAnimalService
    {
        private readonly List<Animal> animals;
        private readonly Arguments arguments;

        public AnimalService(List<Animal> animals, Arguments arguments)
        {
            this.animals = animals;
            this.arguments = arguments;
            LoadFromfile();
        }
        private void LoadFromfile()
        {
            try
            {
                Console.WriteLine("Loading Data From file ... ");

                List<string> lines = File.ReadAllLines(arguments.Filepath).ToList();
                foreach (var line in lines)
                {
                    Add(line);
                }

                Console.WriteLine("Data Loaded Successfully ... ");

            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: { ex.Message }");
            }
        }
        public Animal Add(string line)
        {
            var entries = line.Split(',');
            return Create(entries[0], entries[1], entries[2], entries[3]);

        }

        public Animal Create(string _AnimalType, string _Name, string _Gender, string _TimeStamp)
        {

            // DateTime Formatting
            var formatTimeStamp = $"{_TimeStamp.Substring(0,4)}/{_TimeStamp.Substring(4, 2)}/{_TimeStamp.Substring(6,2)} {_TimeStamp.Substring(10,2)}:{_TimeStamp.Substring(12, 2)}:{_TimeStamp.Substring(12, 2)}";
            var date = DateTime.ParseExact(formatTimeStamp, "yyyy/MM/dd HH:mm:ss", null);
            // Test if Date is correct 
            // Console.WriteLine($"Fecha { date }");
            // Create an animal with passed parameters
            Animal animal = new Animal()
            {
                AnimalType = _AnimalType,
                Name = _Name,
                Gender = _Gender,
                TimeStamp = date
            };

            animals.Add(animal);

            return animal;
        }

        public List<Animal> GetAll()
        {
            return animals;
        }

        public List<Animal> Search()
        {
            Console.WriteLine("Search Start ...");
            var resultList = animals.Where(animal => animal.AnimalType == arguments.Type
                                                    || animal.Name == arguments.Name
                                                    || animal.Gender == arguments.Gender).ToList();
            Console.WriteLine("Search request has been completed");
            return resultList;
        }
    }
}
