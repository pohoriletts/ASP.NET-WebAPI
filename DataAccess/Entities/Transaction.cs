using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Transaction
    {
        public Transaction() { }

        public int Id { get; set; }

        [Required]
        public int Sum { get; set; }

        public int TypeTransactionID { get; set; }

        [Required]
        public TypeTransaction TypeTransaction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required, MinLength(2)]
        public string SenderName { get; set; }

        [Required, MinLength(2)]
        public string RecipientName { get; set; }

        public string? Description { get; set; }
    }
}
