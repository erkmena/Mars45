using MarsRoverApp.Helper;
using MarsRoverApp.Model;
using MarsRoverApp.Model.Implementations;
using System;

namespace MarsRoverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitFlag = false;
            ScreenHelper.WriteBeginningMenu();

            while (!exitFlag)
            {
                try
                {
                    char choice = ScreenHelper.WriteMenu();
                
                    switch (choice)
                    {
                        case '1':
                            ScreenHelper.WriteAndReadVehicleMenu();
                            break;
                        case '2':
                            ScreenHelper.WriteResults();
                            break;
                        case '3':
                            ScreenHelper.CleanScreen();
                            break;
                        default:
                            ScreenHelper.WrongChoice();
                            break;
                    }
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Hatalı veri girişi yaptınız. Lütfen tekrar deneyiniz.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Beklenmeyen bir hata aldık. Hata detayları aşağıdaki gibidir;\n{0}\n{1}", ex.Message, ex.StackTrace);
                }
               
            }
        }
    }
}
