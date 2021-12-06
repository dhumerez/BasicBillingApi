using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicBilling.Service.Interfaces
{
    public interface IBasicBillingService
    {
        Task<IEnumerable<Bill>> GetBillsAsync();

        Task<IEnumerable<Client>> GetClientsAsync();

        Task<IEnumerable<Bill>> GetBillsByClientAsync(int id, bool? paid);

        Task<IEnumerable<Payment>> GetBillPaymentsAsync(int billId);

        Task<IEnumerable<Payment>> GetClientPaymentsAsync(int clientId);

        Task<Payment> PostBillPaymentAsync(Payment payment);

        Task<Payment> PostClientPaymentAsync(ClientPaymentRequest payment);
    }
}
