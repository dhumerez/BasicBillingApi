using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicBilling.DAL.Interfaces
{
    public interface IBasicBillingRepository
    {
        Task<IEnumerable<Bill>> GetBillsAsync();

        Task<IEnumerable<Client>> GetClientsAsync();

        Task<IEnumerable<Bill>> GetBillsByClientAsync(int id, bool? paid);

        Task<IEnumerable<Payment>> GetBillPaymentsAsync(int billId);

        Task<IEnumerable<Payment>> GetClientPaymentsAsync(int clientId);

        Task<Payment> PostBillPaymentAsync(Payment payment);

        Task<decimal> GetRemainingBalance(int billId);

        Task<int> GetBillId(ClientPaymentRequest request);
    }
}
