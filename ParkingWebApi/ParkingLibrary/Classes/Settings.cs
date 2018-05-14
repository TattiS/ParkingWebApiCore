using ParkingLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParkingLibrary.Classes
{
    public static class Settings
    {
        public static int TimeOut { get; private set; }
        public static Dictionary<CarType, double> Prices { get; private set; }
        public static float Fine { get; private set; }
        public static int ParkingSpace { get; private set; }
        public static int LogTimeOut { get; private set; }
        public static string LogPath { get; private set; }


        static Settings()
        {
            TimeOut = 3000;
            LogTimeOut = 6000;
            Fine = 0.3f;
            ParkingSpace = 100;
            Prices = new Dictionary<CarType, double>();
            Prices.Add(CarType.PASSANGER, 3);
            Prices.Add(CarType.MOTOCYCLE, 1);
            Prices.Add(CarType.BUS, 2);
            Prices.Add(CarType.TRUCK, 5);

            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderPath = Environment.CurrentDirectory;
            LogPath = Path.Combine(folderPath, "Transactions.log");
        }


        public static void SetSettings(IPark parking)
        {
            parking.TimeOut = TimeOut;
            parking.LogTimeOut = LogTimeOut;
            parking.LogPath = LogPath;
            parking.Fine = Fine;
            parking.ParkingSpace = ParkingSpace;
            parking.Prices = Prices;
        }
    }
}
