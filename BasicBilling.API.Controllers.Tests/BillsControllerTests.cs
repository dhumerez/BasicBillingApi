namespace BasicBilling.API.Controllers.Tests
{
    using BasicBilling.DAL.Interfaces;
    using BasicBilling.Service;
    using BasicBilling.Service.Interfaces;
    using FluentValidation;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;


    public class BillsControllerTests
    {
        private readonly BillsController controller;
        private readonly Mock<IBasicBillingService> BasicBillingServiceMock;
        private readonly Mock<IBasicBillingRepository> BasicBillingRepositoryMock;
        private readonly BasicBillingService service;

        public BillsControllerTests()
        {
            this.BasicBillingServiceMock = new Mock<IBasicBillingService>();
            this.BasicBillingRepositoryMock = new Mock<IBasicBillingRepository>();
            this.controller = new BillsController(this.BasicBillingServiceMock.Object);
            this.service = new BasicBillingService(this.BasicBillingRepositoryMock.Object);
        }

        [Fact]
        public void Get_ValidBills_ReturnsOK()
        {
            this.BasicBillingServiceMock.Setup(x => x.GetBillsAsync()).Returns(Task.FromResult(ValidBillsResultsResponse()));
            var result = this.controller.GetBills();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ValidBills_ReturnsNoContent()
        {
            IEnumerable<Bill> emptyResponse = null;
            this.BasicBillingServiceMock.Setup(x => x.GetBillsAsync()).Returns(Task.FromResult(emptyResponse));
            var result = this.controller.GetBills();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ValidBillPayments_ReturnsOK()
        {
            this.BasicBillingServiceMock.Setup(x => x.GetBillPaymentsAsync(It.IsAny<int>())).Returns(Task.FromResult(ValidPaymentsResultsResponse()));
            var result = this.controller.GetBillPayments(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ValidBillPayments_ReturnsNoContent()
        {
            IEnumerable<Payment> emptyResponse = null;
            this.BasicBillingServiceMock.Setup(x => x.GetBillPaymentsAsync(It.IsAny<int>())).Returns(Task.FromResult(emptyResponse));
            var result = this.controller.GetBillPayments(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_ValidBillPayment_ReturnsOK()
        {
            this.BasicBillingServiceMock.Setup(x => x.PostBillPaymentAsync(It.IsAny<Payment>())).Returns(Task.FromResult(ValidPaymentResultsResponse()));
            var result = this.controller.PostBillPayment(1, new Payment() { Amount = 100});

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ValidBillPayment_ReturnsBadRequest()
        {
            this.BasicBillingServiceMock.Setup(x => x.PostBillPaymentAsync(It.IsAny<Payment>())).Throws(new ValidationException(string.Empty));
            var result = this.controller.PostBillPayment(1, It.IsAny<Payment>());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        private static IEnumerable<Bill> ValidBillsResultsResponse()
        {
            return new List<Bill>() { new Bill() };
        }

        private static IEnumerable<Payment> ValidPaymentsResultsResponse()
        {
            return new List<Payment>() { new Payment() };
        }

        private static Payment ValidPaymentResultsResponse()
        {
            return new Payment() { Amount = 10, BillId = 1, Id = 1, PaymentDate = DateTime.Now };
        }
    }
}
