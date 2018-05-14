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

        /// <summary>
        /// Кількість вільних місць (GET)
        /// </summary>
        // GET api/<controller>/<action>
        [HttpGet]
        public string GetFree()
        {
            return service.Helper.FreePlaces();
        }

        /// <summary>
        /// Кількість зайнятих місць (GET)
        /// </summary>
        // GET api/<controller>/<action>
        [HttpGet]
        public string GetEngaged()
        {
            return service.Helper.EngagedPlaces();
        }

        /// <summary>
        /// Загальний дохід (GET)
        /// </summary>
        // GET api/<controller>/<action>
        [HttpGet]
        public string GetIncome()
        {
            return service.Helper.GetIncome();
        }

    }
}