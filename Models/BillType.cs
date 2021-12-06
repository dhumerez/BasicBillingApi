namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BillTypes")]
    public class BillType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
