using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingWebApi.Services;

namespace ParkingWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ParkingController : Controller
    {
        private ParkingManagerService service { get; set; }

        public ParkingController(ParkingManagerService service)
        {
            this.service = service;
        }

        // GET api/<controller>/<action>
        [HttpGet]
        public string GetFree()
        {
            return service.helper.FreePlaces();
        }

        // GET api/<controller>/<action>
        [HttpGet]
        public string GetEngaged()
        {
            return service.helper.EngagedPlaces();
        }

        // GET api/<controller>/<action>
        [HttpGet]
        public string GetIncome()
        {
            return service.helper.GetIncome();
        }

    }
}