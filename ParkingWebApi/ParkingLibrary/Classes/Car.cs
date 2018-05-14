using Newtonsoft.Json;
using ParkingLibrary.Interfaces;

namespace ParkingLibrary.Classes
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Car : ICar
    {
        public Car(CarType type, int id, double balance = 0.0)
        {
            CarId = id;
            CarBalance = balance;
            CarType = type;
        }

        #region ICar Members
        [JsonProperty("CarId")]
        public int CarId { get; private set; }
        [JsonProperty("CarBalance")]
        public double CarBalance { get; private set; }
        [JsonProperty("CarType")]
        public CarType CarType { get; private set; }

        public void PayRent(double rent)
        {
            CarBalance -= rent;
        }

        public void AddToBalance(double money)
        {
            CarBalance += money;
        }

        #endregion
    }
}
