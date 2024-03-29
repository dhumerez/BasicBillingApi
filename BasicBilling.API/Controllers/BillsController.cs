﻿namespace BasicBilling.API.Controllers
{
    using BasicBilling.Service.Interfaces;
    using FluentValidation;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Collections.Generic;

    [Route("[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBasicBillingService service;

        public BillsController(IBasicBillingService service)
        {
            this.service = service;
        }

        // GET: api/<BillsController>
        [HttpGet]
        public IActionResult GetBills()
        {
            var result = service.GetBillsAsync().Result;
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // GET <BillsController>/1/payments
        [HttpGet("{billId}/payments")]
        public IActionResult GetBillPayments(int billId)
        {
            var result = service.GetBillPaymentsAsync(billId).Result;
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // POST <BillsController>/1/payments
        [HttpPost("{billId}/payments")]
        public IActionResult PostBillPayment(int billId, Payment payment)
        {
            try
            {
                payment.BillId = billId;
                return Ok(service.PostBillPaymentAsync(payment).Result);
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
    }
}
