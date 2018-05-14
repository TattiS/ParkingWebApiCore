using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLibrary.Interfaces
{
    public interface ITransaction
    {
        DateTime Time { get; }
        int CarId { get; }
        double WrittenOffAmount { get; }
    }
}
