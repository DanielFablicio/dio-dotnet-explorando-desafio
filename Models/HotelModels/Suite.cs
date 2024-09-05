using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Dio_Dotnet_Explorando_Desafio.Structs;

namespace Dio_Dotnet_Explorando_Desafio.Models.HotelModels
{
    public class Suite(uint number, string type, int capacity, decimal dailyRate)
    {
        private uint _number = number;
        private string _type = type;
        private int _capacity = capacity;
        private decimal _dailyRate = dailyRate;
        private readonly DateTime RegisterData = DateTime.Now;
        
        public uint Number => _number;
        public string Type => _type;
        public int Capacity => _capacity;
        public decimal DailyRate => _dailyRate;
        public bool Ocuped;

        public void EditSuite(string type, int capacity, decimal dailyRate) {
            _type = type;
            _capacity = capacity;
            _dailyRate = dailyRate;
        }

        public static (string type, int capacity, decimal dailyRate) TryConvertInputPropsToArgs(StringProps inputProps) {
            if (!inputProps.IsAnyNull()) {
                #pragma warning disable CS8604 // Possible null reference argument.

                bool isAllValid = InputPropValidation.IsValidString(inputProps.First) &&
                                  InputPropValidation.IsValidInteger(inputProps.Second) &&
                                  InputPropValidation.IsValidDecimal(inputProps.Third);
                #pragma warning restore CS8604 // Possible null reference argument.
                
                if (isAllValid) {
                    string _type = inputProps.First;
                    int _capacity = Convert.ToInt32(inputProps.Second);
                    decimal _dailyRate = Convert.ToDecimal(inputProps.Third);

                    return (_type, _capacity, _dailyRate);
                }
            }
            throw new ArgumentException("User do not enter all values.");
        }

        public override string ToString() {
            string exhibition = 
                        $"--Suite {Number:D3}:\n" +
                        $"Type: {Type.ToUpper()}, Capacity: {Capacity}, Daily rate: {DailyRate:C}" +
                        (Ocuped == true ? "  [OCUPED]\n" : "\n") +
                        $"Register data: {RegisterData:yyyy/MM/dd HH:mm}";
            
            return exhibition;
            
            //--Suite 001 
            //  Type: PREMIUM, Capacity: 5, Daily rate: R$220,50
            //  Register data: 2020/07/11 
        }
    }
}