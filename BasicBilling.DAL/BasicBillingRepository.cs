namespace BasicBilling.DAL
{
    using BasicBilling.DAL.Context;
    using BasicBilling.DAL.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class BasicBillingRepository : IBasicBillingRepository
    {
        private CompanyContext companyContext;

        public BasicBillingRepository(CompanyContext companyContext)
        {
            this.companyContext = companyContext;
        }

        public async Task<IEnumerable<Payment>> GetBillPaymentsAsync(int billId)
        {
            return await this.companyContext.Payments
                .Where(s => s.BillId == billId)
                .Include("Bill")
                .OrderByDescending(s => s.PaymentDate)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Bill>> GetBillsAsync()
        {
            return this.companyContext.Bills
                .Include("BillType")
                .Include("State")
                .Include("Client");
        }

        public async Task<IEnumerable<Bill>> GetBillsByClientAsync(int id, bool? paid)
        {
            if(paid.HasValue)
            {
                int stateId;
                if(paid == true)
                {
                    stateId = this.companyContext.States
                        .Where(s => s.Name == "Paid")
                        .FirstOrDefault().Id;
                }
                else
                {
                    stateId = this.companyContext.States
                        .Where(s => s.Name == "Pending ")
                        .FirstOrDefault().Id;
                }
                
                return await this.companyContext.Bills
                    .Where(s => s.ClientId == id && s.StateId == stateId)
                    .Include("Client")
                    .Include("State")
                    .Include("BillType")
                    .OrderByDescending(s => s.Date)
                    .ToArrayAsync();
            }

            return await this.companyContext.Bills
                .Where(s => s.ClientId == id)
                .Include("Client")
                .Include("State")
                .Include("BillType")
                .OrderByDescending(s => s.Date)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Payment>> GetClientPaymentsAsync(int clientId)
        {
            var bills = this.companyContext.Bills
                .Where(s => s.ClientId == clientId)
                .ToList();

            List<Payment> result = new List<Payment>();

            foreach(var bill in bills)
            {
                var payment = this.companyContext.Payments
                .Where(s => s.BillId == bill.Id)
                .Include("Bill")
                .ToList();

                if(payment.Count>0)
                {
                    result.AddRange(payment);
                }
            }
            return result;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return this.companyContext.Clients;
        }

        public async Task<decimal> GetRemainingBalance(int billId)
        {
            return companyContext.Bills
                .Where(s => s.Id == billId).FirstOrDefault().RemainingBalance;
        }

        public async Task<Payment> PostBillPaymentAsync(Payment payment)
        {
            companyContext.Payments.Add(payment);
            companyContext.SaveChanges();
            var bill = companyContext.Bills
                .Where(s => s.Id == payment.BillId).FirstOrDefault();

            if (bill != null)
            {
                int stateId;

                if (bill.RemainingBalance - payment.Amount == 0)
                {
                    stateId = this.companyContext.States
                        .Where(s => s.Name == "Paid")
                        .FirstOrDefault().Id;
                }
                else
                {
                    stateId = this.companyContext.States
                        .Where(s => s.Name == "Pending")
                        .FirstOrDefault().Id;
                }

                var updateBill = new Bill()
                {
                    ClientId = bill.ClientId,
                    BillTypeId = bill.BillTypeId,
                    Date = bill.Date,
                    Id = bill.Id,
                    StateId = stateId,
                    Total = bill.Total,
                    RemainingBalance = bill.RemainingBalance - payment.Amount
                };

                companyContext.Entry(bill).CurrentValues.SetValues(updateBill);
                companyContext.SaveChanges();
            }
            return payment;
        }

        public async Task<int> GetBillId(ClientPaymentRequest request)
        {
            var billTypeId = companyContext.BillTypes
                .Where(s => s.Name == request.BillType)
                    .FirstOrDefault().Id;

            var billId = companyContext.Bills
                .Where(s => s.ClientId == request.ClientId && s.BillTypeId == billTypeId && s.Date == request.Date)
                    .FirstOrDefault().Id;
            return billId;
        }
    }
}
