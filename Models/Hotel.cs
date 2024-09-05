using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Security.Principal;
using System.Threading.Tasks;
using Dio_Dotnet_Explorando_Desafio.Models.HotelModels;
using Dio_Dotnet_Explorando_Desafio.Structs;

namespace Dio_Dotnet_Explorando_Desafio.Models
{
    public class Hotel
    { 
        private uint SuiteNumberDefiner = 1;
        private uint ReserveIDDefiner = 1;
        public List<Suite> Suites { get; set; } = [];
        public List<Reserve> Reserves { get; set; } = [];


        public void RegisterReserve((Suite suite, List<Person> guests, int daysReserved) reserve) {
            if (Reserve.IsGuestsAboveSuiteCapacity(reserve.suite, reserve.guests)) {
                throw new ArgumentOutOfRangeException(nameof(reserve.guests), "Suite capacity exceeded");
            }
            Reserves.Add(new Reserve(ReserveIDDefiner, reserve.suite, reserve.guests, reserve.daysReserved));
            reserve.suite.Ocuped = true;
            ReserveIDDefiner++;
            Menu.WriteLine("Sucessfully registered reserve.");
        }

        public void RegisterSuite((string type, int capacity, decimal dailyRate) suite) {
            if (suite.capacity <= 0 || suite.dailyRate <= 0) {
                string whichArgHasError = suite.dailyRate <= 0 ? "DailyRate": "Capacity";

                throw new ArgumentOutOfRangeException(whichArgHasError,$"{whichArgHasError} cannot be 0 or less than zero");
            }
            Suites.Add(new Suite(SuiteNumberDefiner, suite.type, suite.capacity, suite.dailyRate));
            SuiteNumberDefiner++;
            Menu.WriteLine("Sucessfully registered suite.");
        }
        
        public bool HasSuitesRegistered() {
            return Suites.Count > 0;
        }

        public bool HasReservesRegistered() {
            return Reserves.Count > 0;
        }

        public void ListSuites() {
           HotelList.Suites(Suites); 
        }
        public void ListReserves() {
            HotelList.Reserves(Reserves);
        }

        public void ShowHotelRegisters() {
            HotelList.ShowHotelRegisters(Reserves, Suites);
        }
        public void ShowEmptySuites() {
            Menu.WriteLine("Not ocuped suites: ");
            foreach(Suite suite in Suites) {
                Menu.Write($"{suite.Number:D3}  ");
            }
            Menu.JumpLine();
        }

        public (string type, int capacity, decimal dailyRate) TryConvertInputPropsToSuiteArgs(StringProps inputProps) {
            return Suite.TryConvertInputPropsToArgs(inputProps);
        }
        public (Suite suite, List<Person> guests, int daysReserved) TryConvertInputPropsToReserveArgs(StringProps inputProps) {
            var (suiteNumber, guests, daysReserved) = Reserve.TryConvertInputPropsToArgs(inputProps);
            return (ChoiceSuiteByNumber(suiteNumber), guests, daysReserved);
        }

        private Suite ChoiceSuiteByNumber(uint suiteNumber) {
            Suite? res = Suites.Find(suite => suite.Number == suiteNumber);
            if (res != null) {
                return res;
            }
            throw new ArgumentOutOfRangeException(nameof(suiteNumber), "Non existent suite.");
        }
    }
}