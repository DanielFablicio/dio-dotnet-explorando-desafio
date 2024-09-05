using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dio_Dotnet_Explorando_Desafio.Structs;

namespace Dio_Dotnet_Explorando_Desafio.Models.HotelModels
{
    public class Reserve(uint id, Suite suite, List<Person> guests, int daysReserved)
    {
        private Suite _suite = suite;
        private List<Person> _guests = guests;
        private int _daysReserved = daysReserved;
        public readonly uint ID = id;
        public Suite Suite => _suite;
        public List<Person> Guests => _guests;
        public int DaysReserved => _daysReserved;
        public readonly DateTime RegisterData = DateTime.Now;


        public int GetNumberOfGuests() {
            return Guests.Count;
        }

        public string GetGuestsNames() {
            string res = "";
            foreach (Person guest in Guests) {
                res += guest.ToString() + ", ";
            }
            return res;
        }

        public decimal CalculateDailyRate() {
            bool hasDiscount = DaysReserved >= 10;
            decimal value = Suite.DailyRate * DaysReserved * (hasDiscount ? 0.9M : 1M);

            return value;
        }

        public static bool IsGuestsAboveSuiteCapacity(Suite suite, List<Person> guests) {
            return suite.Capacity < guests.Count;
        }

        public static (uint suiteNumber, List<Person> guests, int daysReseved) TryConvertInputPropsToArgs(StringProps inputProps) {
            if (!inputProps.IsAnyNull()) {
                bool isStringsValid = true;
                #pragma warning disable CS8604 // Possible null reference argument.
                
                string[] guestsSepareted = Menu.SeparetePropertiesInput(inputProps.Second);


                foreach (string? input in guestsSepareted) {
                    isStringsValid &= InputPropValidation.IsValidStringPerson(input);
                }

                bool isAllValid = InputPropValidation.IsValidInteger(inputProps.First) &&
                                  isStringsValid &&
                                  InputPropValidation.IsValidInteger(inputProps.Third);

                #pragma warning restore CS8604 // Possible null reference argument.
                
                if (isAllValid) {
                    uint suiteNumber = Convert.ToUInt32(inputProps.First);
                    List<Person> guests = ConvertToPersons(guestsSepareted);
                    int daysReserved = Convert.ToInt32(inputProps.Third);

                    //string guests = inputProps[1];

                    return (suiteNumber, guests, daysReserved);
                }
            }
            throw new ArgumentException("User enter invalid value(s).");
        }

        private static List<Person> ConvertToPersons(string[] persons) {
            List<Person> res = [];
            foreach(string person in persons) {
                res.Add(Person.ConvertToPerson(person));
            }
            return res;
        }

        public override string ToString() {
            string exhibition = 
                        $"Reserve {ID:D8} | " +
                        $"Suite: Nº{Suite.Number:D3} | " +
                        $"Days reserved: {DaysReserved}" +
                        $"  [End Data: {RegisterData.AddDays(DaysReserved):yyyy/MM/dd}] \n" +
                        $"Guests: {GetGuestsNames()}" +
                        $"Total value: {CalculateDailyRate():C} \n" +
                        $"Register data: {RegisterData:yyyy/MM/dd HH:mm}";
            
            return exhibition;
            
            //--Reserve 00000001
            //  Suite: Nº017
            //  Guests: JOÃO IRINEU, LÚCIA CAVALO, MIRANHA DA SILVA, CAÇADOR DE MARTE
            //  Days reserved: 7 days  [End day: 2016/03/28]
            //  Register data: 2016/03/21
        }
    }
}