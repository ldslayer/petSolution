using System;
using System.Collections.Generic;
using System.Text;

namespace petSolution.Model
{
    public class Arguments
    {
        public Arguments(string[] args)
        {
            // Get the current Directory 
            var currentDirectory = Environment.CurrentDirectory;
            // Parse the arguments to properties

            foreach (var arg in args)
            {
                if (arg.Contains("."))
                {
                    // There we can receive any extension file, 
                    // the content is what matters
                    this.Filepath = $@"{currentDirectory}\{ arg }";
                }

                // receiving the parameters from comand Line

                if (arg.ToUpperInvariant().Contains("type"))
                {
                    this.Type = arg.Split("=")[1];
                }
                if (arg.ToUpperInvariant().Contains("name"))
                {
                    this.Name = arg.Split("=")[1];
                }
                if (arg.ToUpperInvariant().Contains("gender"))
                {
                    this.Gender = arg.Split("=")[1];
                }
            }

            // Show The received Parameters 
            Console.WriteLine("Arguments Received: ");
            Console.WriteLine("---------------------");
            Console.WriteLine($"FileName:   {this.Filepath}");
            Console.WriteLine($"AnimalType:   {this.Type}");
            Console.WriteLine($"Name:   {this.Name}");
            Console.WriteLine($"Gender:   {this.Gender}");
            Console.WriteLine("---------------------");
            Console.WriteLine();

        }

        public string Filepath { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }


    }
}
