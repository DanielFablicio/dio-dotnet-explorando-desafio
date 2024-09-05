using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_Dotnet_Explorando_Desafio.Models
{
    public enum HelpInstruction {
            ReserveRegister, SuiteRegister,
            Edition, 
            HotelEmptySuites, HotelEmptyReserves,
            EnterNothingToCancel,
            ExpandQuestion,
            PressAnyKeyToContinue,
            NotImplementedYet
    }
    public static class Message
    {   
        private const string CommaSeparetedMessage = " separated by comma (_, _, _): ";
        private static readonly Dictionary<HelpInstruction, string> Messages = new Dictionary<HelpInstruction, string>(){
            { HelpInstruction.ReserveRegister, 
            $"Enter suite number, guests[{CommaSeparetedMessage}] and days reserved" + CommaSeparetedMessage },

            { HelpInstruction.SuiteRegister, 
            "Enter suite type, capacity and daily rate" + CommaSeparetedMessage },

            { HelpInstruction.Edition, 
            "Enter information would you like to modify:" },

            { HelpInstruction.HotelEmptySuites, 
            "Hotel have no suites registered."},

            { HelpInstruction.HotelEmptyReserves,
            "Hotel have no reserves registered."},

            { HelpInstruction.EnterNothingToCancel,
            "Enter nothing if you want to cancel/pass."},

            { HelpInstruction.ExpandQuestion,
            "Expand? [y/yes or n/no]"},
            
            { HelpInstruction.PressAnyKeyToContinue,
            "Press any key to continue..."},

            { HelpInstruction.NotImplementedYet,
            "Sorry, method not implemented yet :/"}
        };
        public static void ShowMessage(HelpInstruction message) {
            Menu.WriteLine(Messages[message]);
            if((int)message < 2) {
                Menu.WriteLine(Messages[HelpInstruction.EnterNothingToCancel]);
            }
        }

        public static void ShowException(Exception ex) {
            Menu.WriteLine(ex.Message);
        }
       
    }
}