namespace BasicBilling.API.Controllers
{
    using BasicBilling.Service.Interfaces;
    using FluentValidation;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IBasicBillingService service;

        public ClientsController(IBasicBillingService service)
        {
            this.service = service;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public IActionResult GetClients()
        {
            var result = service.GetClientsAsync().Result;
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // GET <ClientsController>/5/bills
        [HttpGet("{id}/bills")]
        public IActionResult GetClientBills(int id, bool? paid = null)
        {
            var result = service.GetBillsByClientAsync(id, paid).Result;
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // POST <ClientsController>/1/payments
        [HttpPost("{id}/payments")]
        public IActionResult PostClientPayment(int id, ClientPaymentRequest payment)
        {
            try
            {
                payment.ClientId = id;
                return Ok(service.PostClientPaymentAsync(payment).Result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET <<ClientsController>/1/payments
        [HttpGet("{clientId}/payments")]
        public IActionResult GetClientPayments(int clientId)
        {
            var result = service.GetClientPaymentsAsync(clientId).Result;
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
    }
}
