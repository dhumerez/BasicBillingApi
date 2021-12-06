using System;

namespace Models
{
    public class ClientPaymentRequest
    {
        public int ClientId { get; set; }

        public string BillType { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
