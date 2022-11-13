namespace Core.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public int Sum { get; set; }

        public int TypeTransactionID { get; set; }

        public string? TypeTransaction { get; set; }

        public DateTime DateTime { get; set; }

        public string SenderName { get; set; }

        public string RecipientName { get; set; }

        public string? Description { get; set; }
    }
}
