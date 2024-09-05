using System.Runtime.InteropServices;
using Dio_Dotnet_Explorando_Desafio.Models;
using Dio_Dotnet_Explorando_Desafio.Structs;

Hotel hotel = new Hotel();
while (true) {
    Menu.ShowInicialMenu();

    byte option = Menu.ReadOption();
    if (Menu.IsValidOption(option)) {
        StringProps inputProps;
        
        switch (option) {
            case 1: //Register reserve
                if (hotel.HasSuitesRegistered()) {
                    hotel.ShowEmptySuites();
                    inputProps = Menu.ReadInputProps(HelpInstruction.ReserveRegister, 
                                                    Menu.NameProps.Reserve);
                    try {
                        hotel.RegisterReserve(hotel.TryConvertInputPropsToReserveArgs(inputProps));
                    } catch(Exception ex) {
                        Message.ShowException(ex);
                    }
                    break;
                }
                Message.ShowMessage(HelpInstruction.HotelEmptySuites);
                break;
                
            case 2: //Edit reserve
                if (hotel.HasReservesRegistered()) {
                    Message.ShowMessage(HelpInstruction.NotImplementedYet);
                    break;    
                }
                Message.ShowMessage(HelpInstruction.HotelEmptyReserves);
                break;
            
            case 3: //List Reserves
                if (hotel.HasReservesRegistered()) {
                    hotel.ListReserves();
                    break;
                }
                Message.ShowMessage(HelpInstruction.HotelEmptyReserves);
                break;

            case 4: //Register suite
                inputProps = Menu.ReadInputProps(HelpInstruction.SuiteRegister, Menu.NameProps.Suite);
                
                try {
                    hotel.RegisterSuite(hotel.TryConvertInputPropsToSuiteArgs(inputProps));
                }
                catch(Exception ex) {Message.ShowException(ex);}

                break;

            case 5: //Edit suite
                Message.ShowMessage(HelpInstruction.NotImplementedYet);    
                break;

            case 6: //List Suites 
                hotel.ListSuites();
                break;
            
            case 7: //Hotel Statics
                hotel.ShowHotelRegisters();
                break;
            
            case 8: //Exit
                Menu.Exit();
                break;
        }
        Message.ShowMessage(HelpInstruction.PressAnyKeyToContinue);
        Console.ReadLine();
        Menu.ClearConsole();
    }
}