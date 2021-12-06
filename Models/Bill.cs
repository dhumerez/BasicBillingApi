namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Bills")]
    public class Bill
    {
        [Key]
        public int Id { get; set; }        

        public DateTime Date { get; set; }

        [JsonIgnore]
        public int ClientId { get; set; }

        [JsonIgnore]
        public int BillTypeId { get; set; }

        [JsonIgnore]
        public int StateId { get; set; }

        public decimal Total { get; set; }

        public decimal RemainingBalance { get; set; }
        
        public BillType BillType { get; set; }

        public State State { get; set; }

        public Client Client { get; set; }
    }
}
