using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkingLibrary;
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

        // GET: api/<controller>
        [HttpGet]
        public List<ICar> GetAllCars()
        {
            return service.helper.GetAllCars();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ICar Get(int id)
        {
            return service.helper.GetAllCars().Find(c => c.CarId == id);
        }

        // POST api/<controller>
        [HttpPost]
        public ICar AddCar([FromBody]Car car)
        {
            ICar addingCar = service.helper.GetAllCars().Find(c => c.CarId == car.CarId);

            if (addingCar != null)
            {
                return null;
            }
            else
            {
                service.helper.AddCar(car.CarType, car.CarId, car.CarBalance);

                return service.helper.GetAllCars().Find(c => c.CarId == car.CarId);

            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return service.helper.DeleteCar(id);
        }
    }
}
