namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("States")]
    public class State
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } // Posible states are "Pending & Paid"
    }
}
