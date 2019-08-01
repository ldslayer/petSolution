using System;
using System.Collections.Generic;
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
            // Create an animal with passed parameters
            Animal animal = new Animal()
            {
                AnimalType = _AnimalType,
                Name = _Name,
                Gender = _Gender,
                TimeStamp = _TimeStamp
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
            throw new NotImplementedException();
        }
    }
}
