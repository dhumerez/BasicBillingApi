namespace BasicBilling.Service
{
    using BasicBilling.DAL.Interfaces;
    using BasicBilling.Service.Interfaces;
    using BasicBilling.Services.Validators;
    using FluentValidation;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BasicBillingService : IBasicBillingService
    {
        private readonly IBasicBillingRepository repository;

        public BasicBillingService(IBasicBillingRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Payment>> GetBillPaymentsAsync(int billId)
        {
            return repository.GetBillPaymentsAsync(billId);
        }

        public Task<IEnumerable<Bill>> GetBillsAsync()
        {
            return repository.GetBillsAsync();
        }

        public Task<IEnumerable<Bill>> GetBillsByClientAsync(int id, bool? paid)
        {
            return repository.GetBillsByClientAsync(id, paid);
        }

        public Task<IEnumerable<Payment>> GetClientPaymentsAsync(int clientId)
        {
            return repository.GetClientPaymentsAsync(clientId);
        }

        public Task<IEnumerable<Client>> GetClientsAsync()
        {
            return repository.GetClientsAsync();
        }

        public async Task<Payment> PostBillPaymentAsync(Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            decimal remainingBalance = await this.repository.GetRemainingBalance(payment.BillId);
            var validator = new PaymentValidator(remainingBalance);
            validator.ValidateAndThrow(payment);
            return await repository.PostBillPaymentAsync(payment);
        }

        public async Task<Payment> PostClientPaymentAsync(ClientPaymentRequest request)
        {
            request.Date = new DateTime(request.Date.Year, request.Date.Month, 1);

            var billId = await this.repository.GetBillId(request);
            if(billId == 0)
            {
                return null;
            }
            decimal remainingBalance = await this.repository.GetRemainingBalance(billId);

            var validator = new ClientPaymentRequestValidator(remainingBalance);
            validator.ValidateAndThrow(request);

            var payment = new Payment() { BillId = billId, PaymentDate = DateTime.Now, Amount = request.Amount };

            return await repository.PostBillPaymentAsync(payment);
        }
    }
}