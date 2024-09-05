using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_Dotnet_Explorando_Desafio.Models
{
    public static class InputPropValidation
    {
        public static bool IsValidString(string inputProp) {
            if (!string.IsNullOrWhiteSpace(inputProp) && inputProp.All(char.IsLetter)) {
                return true;
            }
            throw new ArgumentException($"Invalid name '{inputProp}'");
        }
        
        public static bool IsValidStringPerson(string inputProp) {
            if (!string.IsNullOrWhiteSpace(inputProp) && inputProp.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))) {
                return true;
            }
            throw new ArgumentException($"Invalid person name {inputProp}");
        }

        public static bool IsValidInteger(string inputProp) {
            if (int.TryParse(inputProp, out _)) {
                return true;
            }
            throw new ArgumentException($"Invalid integer number '{inputProp}'");
        }

        public static bool IsValidDecimal(string inputProp) {
            if (decimal.TryParse(inputProp, out _)) {
                return true;
            }
            throw new ArgumentException($"Invalid price '{inputProp}'");
        }
    }
}