using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLibrary.Interfaces
{
    public enum CarType : byte { PASSANGER, TRUCK, BUS, MOTOCYCLE }

    public interface ICar
    {
        int CarId { get; }
        double CarBalance { get; }
        CarType CarType { get; }
        void PayRent(double rent);
        void AddToBalance(double money);
    }
}
