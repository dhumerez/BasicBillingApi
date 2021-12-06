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

namespace BasicBilling.API.Controllers.Tests
{
    public class ClientsControllerTests
    {
        private readonly ClientsController controller;
        private readonly Mock<IBasicBillingService> BasicBillingServiceMock;
        private readonly Mock<IBasicBillingRepository> BasicBillingRepositoryMock;
        private readonly BasicBillingService service;

        public ClientsControllerTests()
        {
            this.BasicBillingServiceMock = new Mock<IBasicBillingService>();
            this.BasicBillingRepositoryMock = new Mock<IBasicBillingRepository>();
            this.controller = new ClientsController(this.BasicBillingServiceMock.Object);
            this.service = new BasicBillingService(this.BasicBillingRepositoryMock.Object);
        }
        public static IEnumerable<object[]> ValidGetClientBills()
        {
            List<object[]> testCases = new List<object[]>();
            testCases.Add(new object[] { 1 });

            return testCases;
        }

        [Theory]
        [MemberData(nameof(ValidGetClientBills))]
        public void Get_ValidClientBills_ReturnsOK( int scheduleId)
        {
            this.BasicBillingServiceMock.Setup(x => x.GetBillsByClientAsync(It.IsAny<int>(), It.IsAny<bool>())).Returns(Task.FromResult(ValidBillsResultsResponse()));
            var result = this.controller.GetClientBills(scheduleId);

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [MemberData(nameof(ValidGetClientBills))]
        public void Get_ValidClientBills_ReturnsNoContent(int scheduleId)
        {
            IEnumerable<Bill> emptyResponse = null;
            this.BasicBillingServiceMock.Setup(x => x.GetBillsByClientAsync(It.IsAny<int>(), It.IsAny<bool>())).Returns(Task.FromResult(emptyResponse));
            var result = this.controller.GetClientBills(scheduleId);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ValidClients_ReturnsOK()
        {
            this.BasicBillingServiceMock.Setup(x => x.GetClientsAsync()).Returns(Task.FromResult(ValidClientsResultsResponse()));
            var result = this.controller.GetClients();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ValidClients_ReturnsNoContent()
        {
            IEnumerable<Client> emptyResponse = null;
            this.BasicBillingServiceMock.Setup(x => x.GetClientsAsync()).Returns(Task.FromResult(emptyResponse));
            var result = this.controller.GetClients();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ValidClientPayments_ReturnsOK()
        {
            this.BasicBillingServiceMock.Setup(x => x.GetClientPaymentsAsync(It.IsAny<int>())).Returns(Task.FromResult(ValidPaymentsResultsResponse()));
            var result = this.controller.GetClientPayments(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ValidClientPayments_ReturnsNoContent()
        {
            IEnumerable<Payment> emptyResponse = null;
            this.BasicBillingServiceMock.Setup(x => x.GetClientPaymentsAsync(It.IsAny<int>())).Returns(Task.FromResult(emptyResponse));
            var result = this.controller.GetClientPayments(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_ValidClientPayment_ReturnsOK()
        {
            this.BasicBillingServiceMock.Setup(x => x.PostClientPaymentAsync(It.IsAny<ClientPaymentRequest>())).Returns(Task.FromResult(ValidPaymentResultsResponse()));
            var result = this.controller.PostClientPayment(1, new ClientPaymentRequest() { Amount = 10, BillType ="Electricity", ClientId = 1, Date = DateTime.Now});

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ValidClientPayments_ReturnsBadRequest()
        {
            this.BasicBillingServiceMock.Setup(x => x.PostClientPaymentAsync(It.IsAny<ClientPaymentRequest>())).Throws(new ValidationException(string.Empty));
            var result = this.controller.PostClientPayment(1, new ClientPaymentRequest() { Amount = 10, BillType = "Electricity", ClientId = 1, Date = DateTime.Now });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        private static IEnumerable<Client> ValidClientsResultsResponse()
        {
            return new List<Client>() { new Client() };
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
