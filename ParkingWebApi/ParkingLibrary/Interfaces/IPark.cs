using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLibrary.Interfaces
{
    public interface IPark
    {
        int TimeOut { get; set; }
        int LogTimeOut { get; set; }
        string LogPath { get; set; }
        Dictionary<CarType, double> Prices { get; set; }
        float Fine { get; set; }
        int ParkingSpace { get; set; }
        List<ICar> Cars { get; set; }
        List<ITransaction> Transactions { get; set; }
        bool AddCar(ICar car);
        bool RemoveCar(int id);
        bool AddToBalance(int id, double amount);
        string ShowTransactionsFor(int minute = 1);
        string ShowIncome();
        int ShowFreePlaces();
        string[] ShowLog();
        bool HasCar(int id);
    }
}
