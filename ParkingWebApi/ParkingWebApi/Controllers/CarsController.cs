using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary.Classes;
using ParkingLibrary.Interfaces;
using ParkingWebApi.Services;

namespace ParkingWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private ParkingManagerService service { get; set; }
        public CarsController(ParkingManagerService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Список всіх машин (GET)
        /// </summary>
        // GET: api/<controller>
        [HttpGet]
        public List<ICar> GetAllCars()
        {
            return service.Helper.GetAllCars();
        }

        /// <summary>
        /// Деталі по одній машині (GET)
        /// </summary>
        // GET api/<controller>/1234
        [HttpGet("{id}")]
        public ICar Get(int id)
        {
            return service.Helper.GetAllCars().Find(c => c.CarId == id);
        }

        /// <summary>
        /// Додати машину(POST)
        /// </summary>
        // POST api/<controller>
        [HttpPost]
        public ICar AddCar([FromBody]Car car)
        {
            ICar addingCar = service.Helper.GetAllCars().Find(c => c.CarId == car.CarId);

            if (addingCar != null)
            {
                return null;
            }
            else
            {
                service.Helper.AddCar(car.CarType, car.CarId, car.CarBalance);

                return service.Helper.GetAllCars().Find(c => c.CarId == car.CarId);

            }

        }

        /// <summary>
        /// Видалити машину (DELETE)
        /// </summary>
        // DELETE api/<controller>/1234
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return service.Helper.DeleteCar(id);
        }
    }
}
