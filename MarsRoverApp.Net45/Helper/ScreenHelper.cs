using MarsRoverApp.Model;
using MarsRoverApp.Model.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Helper
{
    class ScreenHelper
    {

        static char vehicleDirection;
        static ArrayList vehicleArray = new ArrayList();
        static Plateau originalPlateau;

        /// <summary>
        /// Write the main menu wich will displays always
        /// </summary>
        /// <returns>Returns Main Menu</returns>
        internal static char WriteMenu()
        {
            Console.WriteLine("Aşağıda ki menüden seçiminizi giriniz:");
            Console.WriteLine("1- Yeni Araç Ekleme");
            Console.WriteLine("2- Sonuçları Listele");
            Console.WriteLine("3- Ekranı Temizle");

            Console.WriteLine("ESC- Çıkış\n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Console.WriteLine();
            return key.KeyChar;

        }

        /// <summary>
        /// Clean processes in the screen. This only clean text in the screen not the data.
        /// </summary>
        internal static void CleanScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// Write the result of movements
        /// </summary>
        internal static void WriteResults()
        {
            foreach (IVehicle item in vehicleArray)
            {
                Plateau plateau = item.CurrentCoordinates();
                Console.WriteLine("Aracın Mevcut Koordinatları : {0}-{1} \n Aracın Yönü : {2}", plateau.XAxis, plateau.YAxis, item.CurrentDirection());
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Write wrong choice
        /// </summary>
        internal static void WrongChoice()
        {
            Console.WriteLine("Geçersiz Seçim");
        }

        /// <summary>
        /// Write the command which wants from user the data of plataeu
        /// </summary>
        public static void WriteBeginningMenu()
        {
            Console.WriteLine("Lütfen Mars Alanının Boyutunu Giriniz (Arada boşluk bırakarak giriniz. Ör: 4 5)");
            originalPlateau = GetPlateauField();
        }

        /// <summary>
        /// Write and get vehicle datas
        /// </summary>
        internal static void WriteAndReadVehicleMenu()
        {
            Console.WriteLine("Lütfen yeni aracın başlangıç koordinatlarını ve yönünü giriniz (Arada boşluk bırakarak giriniz. Ör: 4 5 E)");
            Plateau startingCoordinates = GetNewVehicleCoordinates();
            IVehicle vehicle = VehicleFactory.MakeVehicle(new RoboticRover(vehicleDirection, startingCoordinates));
            Console.WriteLine("Lütfen yeni aracın yol bilgisini giriniz");
            string rawData = Console.ReadLine();
            VehicleHelper.ProcessData(rawData, vehicle, originalPlateau);
            vehicleArray.Add(vehicle);
        }


        /// <summary>
        /// Gets vehicle coordinates
        /// </summary>
        /// <returns></returns>
        private static Plateau GetNewVehicleCoordinates()
        {
            string[] rawData = Console.ReadLine().Split(' ');
            Plateau plateau =new Plateau(0, 0);
            plateau.XAxis = Convert.ToInt32(rawData[0]);
            plateau.YAxis = Convert.ToInt32(rawData[1]);
            vehicleDirection = rawData[2].ToCharArray()[0];

            return plateau;
        }


        /// <summary>
        /// Calculate the plateau field.
        /// </summary>
        /// <returns></returns>
        private static Plateau GetPlateauField()
        {
            int[] plateauField = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            return new Plateau(plateauField[0], plateauField[1]);
        }
    }
}
