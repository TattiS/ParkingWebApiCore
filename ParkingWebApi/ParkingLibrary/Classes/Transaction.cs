using ParkingLibrary.Interfaces;
using System;

namespace ParkingLibrary.Classes
{
    public class Transaction : ITransaction
    {
        public DateTime Time { get; private set; }

        public int CarId { get; private set; }

        public double WrittenOffAmount { get; private set; }

        public Transaction(DateTime time, int id, double amount)
        {
            Time = time;
            CarId = id;
            WrittenOffAmount = amount;
        }
    }
}