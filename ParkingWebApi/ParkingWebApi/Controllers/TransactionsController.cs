using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary.Interfaces;
using ParkingLibrary.Classes;
using ParkingWebApi.Services;

namespace ParkingWebApi.Controllers
{
    [Route("api/Transactions/[Action]")]
    public class TransactionsController : Controller
    {
        private ParkingManagerService service { get; set; }

        public TransactionsController(ParkingManagerService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Вивести Transactions.log (GET)
        /// </summary>
        // GET: api/Transactions/GetLog
        [HttpGet]
        public string GetLog()
        {
            return service.Helper.GetLog();
        }

        /// <summary>
        /// Вивести транзакції за останню хвилину по одній конкретній машині (GET)
        /// </summary>
        // GET: api/Transactions/GetById/1234
        [Produces("application/json")]
        [HttpGet("{id}")]
        public List<ITransaction> GetById(int id)
        {
            return service.Helper.GetTransactionsById(id);
        }

        /// <summary>
        /// Вивести транзакції за останню хвилину (GET)
        /// </summary>
        // GET: api/Transactions/GetAll
        [Produces("application/json")]
        [HttpGet]
        public List<ITransaction> GetAll()
        {
            return service.Helper.GetTransactionsFor();
        }

        /// <summary>
        /// Поповнити баланс машини (PUT)
        /// </summary>
        // PUT: api/Transactions/Replenish/1234
        [Produces("application/json")]
        [HttpPut("{id}")]
        public ICar Replenish(int id, [FromBody]Car value)
        {
            return service.Helper.ReplenishBalanceById(id, value);
        }


    }
}