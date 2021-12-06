namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}