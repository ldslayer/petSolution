using System;
using System.Collections.Generic;
using System.Text;

namespace petSolution.Model
{
    public interface IAnimalService
    {
        /// <summary>
        /// Adding one record to animal DataList from a formatted csv string
        /// CAT,Fluffy,M,20131231-­145934
        /// the Time stamp format is: <year><month><day>­<hour><minute><second>
        /// as the provided example: 20130129­-080903
        /// </summary>
        /// <param name="line">Type,Name,Gender,Timestamp(</param>
        /// <returns> recorded animal (Id)</returns>
        Animal Add(string line);

        /// <summary>
        /// Register a new Animal, the timeStam is generated at the moment 
        /// of saving the data
        /// </summary>
        /// <param name="Type">Animal Type Ex: "DOG" or "CAT"</param>
        /// <param name="Name">Animal Name: "Fluffy" </param>
        /// <param name="Gender">M for Male, F for Female</param>
        /// <returns></returns>
        Animal Create(string _AnimalType, string _Name, string _Gender, string _TimeStamp);

        /// <summary>
        /// Loads and Serch all results for passed Arguments
        /// if no argument then returns all pet in th list
        /// </summary>
        /// <param name="arguments">minimum argument es the filename</param>
        /// <returns></returns>
        List<Animal> Search();

        /// <summary>
        /// Return a list of all loaded animals
        /// </summary>
        /// <returns></returns>
        List<Animal> GetAll();
    }
}
