using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_Dotnet_Explorando_Desafio.Models.HotelModels
{
    public static class HotelList 
    {
            private struct HotelRegisters(int totalReserves, int totalGuests, int totalSuites) {
                public int TotalReserves = totalReserves;
                public int TotalGuests = totalGuests;
                public int TotalSuites = totalSuites;

                public readonly void Deconstruct(out int totalReserves, out int totalGuests, out int totalSuites) {
                    totalReserves = TotalReserves;
                    totalGuests = TotalGuests;
                    totalSuites = TotalSuites;
                }
            }
            private const byte CharSeparatorRepetition = 51;

            public static void Suites(List<Suite> suites) {
                foreach (Suite suite in suites) {
                    Menu.WriteLine(
                        suite.ToString() +
                        Separator
                        );
                }
            }

            public static void Reserves(List<Reserve> reserves) {
                foreach (Reserve reserve in reserves) {
                    Menu.WriteLine(
                        reserve.ToString() +
                        Separator
                        );
                }
            }
            private static string Separator => "\n" + string.Concat(Enumerable.Repeat('-', CharSeparatorRepetition));
            public static void ShowHotelRegisters(List<Reserve> reserves, List<Suite> suites) {
                (int totalReserves, int totalGuests, int totalSuites) = GetHotelRegisters(reserves, suites);
                if (totalReserves == 0 && totalSuites == 0) {
                    Menu.WriteLine("No suites or reserves registered.");
                    return;
                }
                Menu.WriteLine(
                    $"Reserves number: {totalReserves} \n" +
                    $"Suites number: {totalSuites} \n" +
                    $"Guest number: {totalGuests} \n"
                );
            }
            
            private static HotelRegisters GetHotelRegisters(List<Reserve> reserves, List<Suite> suites) {
                int totalGuests = 0;
                int totalSuites = 0;
                int totalReserves = 0;
                
                foreach(Reserve reserve in reserves) {
                    totalReserves += 1;
                    totalGuests += reserve.GetNumberOfGuests();
                }
                foreach(Suite suite in suites) {
                    totalSuites += 1;
                }

                return new HotelRegisters(totalReserves, totalGuests, totalSuites);
            }            
        }
}