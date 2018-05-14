using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Transactions/GetLog
        [HttpGet]
        public string GetLog()
        {
            return service.helper.GetLog();
        }

        // GET: api/Transactions/GetById/1234
        [Produces("application/json")]
        [HttpGet("{id}")]
        public List<ITransaction> GetById(int id)
        {
            return service.helper.GetTransactionsById(id);
        }

        // GET: api/Transactions/GetAll
        [Produces("application/json")]
        [HttpGet]
        public List<ITransaction> GetAll()
        {
            return service.helper.GetTransactionsFor();
        }

        // PUT: api/Transactions/Replenish/1234
        [Produces("application/json")]
        [HttpPut("{id}")]
        public ICar Replenish(int id, [FromBody]Car value)
        {
            return service.helper.ReplenishBalanceById(id, value);
        }


    }
}