using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_Dotnet_Explorando_Desafio.Structs
{
    public struct StringProps(string? first, string? second, string? third) {
        public string? First = first; 
        public string? Second = second;
        public string? Third = third;

        public readonly string?[] All => [First, Second, Third];
        public void Deconstruct(out (string?, string?, string?) stringProps) {
            stringProps.Item1 = First;
            stringProps.Item2 = Second;
            stringProps.Item3 = Third;
        }
    
        public bool IsAnyNull() {
            foreach(string? param in All) {
                if (string.IsNullOrWhiteSpace(param)) {
                    return true;
                }
            }
            return false;
        }
    }
}