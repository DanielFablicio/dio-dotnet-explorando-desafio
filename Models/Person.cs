using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_Dotnet_Explorando_Desafio.Models
{
    public class Person(string name, string surname)
    {
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string FullName => $"{Name} {Surname}".ToUpper();
        
        public static Person ConvertToPerson(string completeName) {
            string[] separetedName = completeName.Split(' ', 2, StringSplitOptions.TrimEntries);
            return new Person(separetedName[0], separetedName[1]);
        }

        public override string ToString()
        {
            return FullName;
        }

    }
}