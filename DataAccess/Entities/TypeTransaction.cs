namespace DataAccess.Entities
{
    public class TypeTransaction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }

    public enum EnumTypesTransactions:int
    {
        TransferToCard = 1,
        InternetPayment,
        UtilityCompany,
        MobileTopUp,
        Restaurants,
        Clothing,
        Pharmacy,
        Charity,
        Cinema,
        Game,
        Salary,
        Fines,
        Others
    }  
}
