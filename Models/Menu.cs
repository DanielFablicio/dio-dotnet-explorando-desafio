using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dio_Dotnet_Explorando_Desafio.Structs;

namespace Dio_Dotnet_Explorando_Desafio.Models
{
    
    public static class Menu
    {
        public const byte maxOption = 8;
        public static readonly (StringProps Suite, StringProps Reserve) NameProps = 
                                                        (new ("Type", "Capacity", "Daily rate"), 
                                                         new ("Suite number", "Guests", "Days Reserved"));
        
        public static void ShowInicialMenu() {
            Console.WriteLine(
                "Welcome to Hotel! \n".ToUpper() +
                "Select an option: \n\n" +
                "1 - Register reserve \n" +
                "2 - Edit reserve \n" + 
                "3 - List reserves \n" +
                "4 - Register suite \n" +
                "5 - Edit Suite \n" +
                "6 - List Suites \n" +
                "7 - Hotel Statics \n" +
                "8 - Exit \n"
                );
        }

        public static StringProps ReadInputProps(HelpInstruction helpMessage, StringProps nameProps) {
            const string twoPoints = ": ";
            Message.ShowMessage(helpMessage);
            
            WriteLine(nameProps.First + twoPoints);
            string first = ReadNotEmptyInput();
            WriteLine(nameProps.Second + twoPoints);
            string second = ReadNotEmptyInput();
            WriteLine(nameProps.Third + twoPoints);
            string third = ReadNotEmptyInput();

            return new (first, second, third);
        }

        public static byte ReadOption() {
            _ = byte.TryParse(ReadNotEmptyInput(), out byte option);
            return option;
        }

        public static bool IsValidOption(byte option) {
            return option <= maxOption && option > 0;
        }

        public static string? ReadInput() {
            string? res = Console.ReadLine();
            return !string.IsNullOrWhiteSpace(res) ? res.Trim() : null;
        }
        
        public static string ReadNotEmptyInput() {
            while (true) {
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) {
                    return input.Trim();
                }
                Console.WriteLine("User do not entered a value");
            }
        }

        public static string[] SeparetePropertiesInput(string propsInput) {
            string[] treatedPropsInput = propsInput.Split(',', StringSplitOptions.TrimEntries); 
            return treatedPropsInput;
        }

        public static void ClearConsole() {
            Console.Clear();
        }

        public static void Write(string value) {
            Console.Write(value);
        }

        public static void WriteLine(string value) {
            Console.WriteLine(value);
        }

        public static void JumpLine() {
            Console.WriteLine("\n");
        }

        public static void JumpLine(byte repeatNumber) {
            for (int i = 0; i < repeatNumber; i++) {
                Console.WriteLine("\n");
            }
        }

        public static void Exit() {
            Console.WriteLine("Progam finished.");
            Environment.Exit(0);
        }
    }

    
}