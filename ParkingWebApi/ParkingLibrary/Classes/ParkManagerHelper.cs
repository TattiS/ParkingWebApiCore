using ParkingLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ParkingLibrary.Classes
{
    public class ParkManagerHelper
    {
        private Parking carParking;
        public ParkManagerHelper()
        {
            carParking = Parking.Instance;
        }

        //-Список всіх машин (GET)
        public List<ICar> GetAllCars()
        {
         return carParking.Cars;
        }

        //-Деталі по одній машині (GET)
        public ICar GetThatCar(int id)
        {
            ICar thatCar = carParking.Cars.Find(c => c.CarId == id);

            return thatCar;
        }

        //-Видалити машину (DELETE)
        public string DeleteCar(int id)
        {
            //throw new NotImplementedException();
            string result = String.Empty;
            if (carParking.RemoveCar(id))
            {
                result = "The car was removed.";
            }
            else
            {
                ICar currentCar = carParking.Cars.Find(c => c.CarId == id);
                if (currentCar != null)
                {
                    result = String.Format(new CultureInfo("en-US"), "The car wasn't removed. You need to replenish your car balance. Your debt: {0:C2}.  You must pay not less than that!", currentCar.CarBalance);
                }
                else
                {
                    result = "Your car disappeared!";
                }
            }
            return result;
        }

        //-Додати машину (POST)
        public string AddCar(CarType type, int id, double balance)
        {
            string result = String.Empty;
            if (carParking.ShowFreePlaces() > 0)
            {
                if (carParking.HasCar(id))
                {
                    result = "Check your car id, because we have a car with such number!";
                    return result;
                }

                ICar newCar = new Car(type, id, balance);

                if (newCar != null && carParking.Cars != null)
                {
                    carParking.AddCar(newCar);
                    result = "Your car was parked successfully.";
                }
                else
                {
                    result = "There is a problem with your car, so we couldn't park it.";
                }
            }
            else
            {
                result = "We're sorry, but there is no free place for a car. Please, come later.";
            }

            return result;
        }

        //-Кількість вільних місць (GET)
        public string FreePlaces()
        {
            string freePlaces = String.Empty;
            freePlaces += String.Format("We have {0} free place(s).", carParking.ShowFreePlaces());
            return freePlaces;
        }

        //-Кількість зайнятих місць (GET)
        public string EngagedPlaces()
        {
            string engagedPlaces = String.Empty;
            engagedPlaces += String.Format("We have {0} engaged place(s).", (carParking.ParkingSpace - carParking.ShowFreePlaces()));
            return engagedPlaces;
        }

        //-Загальний дохід(GET)
        public string GetIncome()
        {
            return String.Format("Our {0} on {1:d} at {1:T}. ", carParking.ShowIncome(), DateTime.Now);

        }

        //-Вивести Transactions.log (GET)
        public string GetLog()
        {
            string[] log = carParking.ShowLog();
            string output = "There is no such file.";
            if (log == null)
            {
                return output;
            }
            else
            {
                output = String.Empty;
                for (int index = 0; index < log.Length; index++)
                {
                    output += String.Format("{0}\n", log[index]);
                }

                return output;
            }
        }

        //Вивести транзакції за останню хвилину (GET)
        public List<ITransaction> GetTransactionsFor(int minute = 1)
        {
            return carParking.GetTransactionsFor();
        }

        //-Вивести транзакції за останню хвилину по одній конкретній машині (GET)
        public List<ITransaction> GetTransactionsById(int id, int minute = 1)
        {
            return carParking.GetTransactionsFor().FindAll(t => t.CarId == id);
        }

        //-Поповнити баланс машини (PUT)
        public ICar ReplenishBalanceById(int id, ICar car)
        {

            ICar currentCar = carParking.Cars.Find(c => c.CarId == id);
            if (currentCar != null)
            {
                currentCar.AddToBalance(car.CarBalance);
                return currentCar;
            }
            else
            {
                return null;
            }
        }
    }
}
