namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Payments")]
    public  class Payment
    {
        [Key]
        public int Id { get; set; }

        public int BillId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public Bill Bill { get; set; }
    }
}
