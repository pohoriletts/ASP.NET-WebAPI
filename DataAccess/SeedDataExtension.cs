using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class SeedDataExtension
    {
        public static void SeedTypesTransactions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeTransaction>().HasData(new TypeTransaction[]
            {   
                new TypeTransaction() { Id = (int)EnumTypesTransactions.TransferToCard, Name = "TransferToCard" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.InternetPayment,Name = "InternetPayment" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.UtilityCompany, Name = "UtilityCompany" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.MobileTopUp,    Name = "MobileTopUp" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Restaurants,    Name = "Restaurants" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Clothing,       Name = "Clothing" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Pharmacy,       Name = "Pharmacy" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Charity,        Name = "Charity" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Cinema,         Name = "Cinema" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Game,           Name = "Game" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Salary,         Name = "Salary" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Fines,          Name = "Fines" },
                new TypeTransaction() { Id = (int)EnumTypesTransactions.Others,         Name = "Others" },
            });
        }

        public static void SeedTransactions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(new Transaction[]
            {
                new Transaction()
                {
                   Id=1,
                   Sum=370,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Kolya",
                   DateTime=new DateTime(2022, 7, 20, 18, 30, 25), // year - month - day - hour - minute - seconds
                   Description = "On tea",
                   RecipientName="Orest"
                },
                new Transaction()
                {
                   Id=2,
                   Sum=654,
                   TypeTransactionID=(int)EnumTypesTransactions.Clothing,
                   SenderName="Jack Wilston",
                   DateTime=new DateTime(2022, 10, 14, 14, 12, 1),
                   Description="Shop of clothing",
                   RecipientName="Shop"
                },
                new Transaction()
                {
                   Id=3,
                   Sum=1232,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Kolya"
                },
                new Transaction()
                {
                   Id=4,
                   Sum=25000,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Vlad",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Sasha"
                },
                new Transaction()
                {
                   Id=5,
                   Sum=654,
                   TypeTransactionID=(int)EnumTypesTransactions.Clothing,
                   SenderName="Jack Wilston",
                   DateTime=new DateTime(2022, 10, 14, 14, 12, 1),
                   Description="Shop of clothing",
                   RecipientName="Shop"
                },
                new Transaction()
                {
                   Id=6,
                   Sum=250,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Vlad"
                },
                new Transaction()
                {
                   Id=7,
                   Sum=1232,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Kolya"
                },
                new Transaction()
                {
                   Id=8,
                   Sum=1232,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Kolya"
                },
                new Transaction()
                {
                   Id=9,
                   Sum=25000,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Vlad",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Sasha"
                },
                new Transaction()
                {
                   Id=10,
                   Sum=250,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Vlad"
                },
                new Transaction()
                {
                   Id=11,
                   Sum=1232,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2015,7,15, 11, 43,33),
                   Description="On tea",
                   RecipientName="Kolya"
                },
                new Transaction()
                {
                   Id=12,
                   Sum=34,
                   TypeTransactionID=(int)EnumTypesTransactions.Cinema,
                   SenderName="Matt Colin",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="Payment tickets",
                   RecipientName="MultiplexUA"
                },
                new Transaction()
                {
                   Id=13,
                   Sum=34,
                   TypeTransactionID=(int)EnumTypesTransactions.Cinema,
                   SenderName="Matt Colin",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="Payment tickets",
                   RecipientName="MultiplexUA"
                },
                new Transaction()
                {
                   Id=14,
                   Sum=250,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Vlad"
                },
                new Transaction()
                {
                   Id=15,
                   Sum=654,
                   TypeTransactionID=(int)EnumTypesTransactions.Clothing,
                   SenderName="Jack Wilston",
                   DateTime=new DateTime(2022, 10, 14, 14, 12, 1),
                   Description="Shop of clothing",
                   RecipientName="Shop"
                },
                new Transaction()
                {
                   Id=16,
                   Sum=7900,
                   TypeTransactionID=(int)EnumTypesTransactions.InternetPayment,
                   SenderName="Matt Daymon",
                   DateTime=new DateTime(2022, 10, 14, 14, 12, 1),
                   Description="Transfer money to internet card",
                   RecipientName="apple.com"
                },
                new Transaction()
                {
                   Id=17,
                   Sum=1293,
                   TypeTransactionID=(int)EnumTypesTransactions.Charity,
                   SenderName="Jonny Deph",
                   DateTime=new DateTime(2022, 01, 11, 19, 23, 22),
                   Description="Charity transfer",
                   RecipientName="Charity Fund"
                },
                new Transaction()
                {
                   Id=18,
                   Sum=1232,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2015,7,15, 11, 43,33),
                   Description="On tea",
                   RecipientName="Kolya"
                },
                new Transaction()
                {
                   Id=19,
                   Sum=1293,
                   TypeTransactionID=(int)EnumTypesTransactions.Charity,
                   SenderName="Jonny Deph",
                   DateTime=new DateTime(2022, 01, 11, 19, 23, 22),
                   Description="Charity transfer",
                   RecipientName="Charity Fund"
                },
                new Transaction()
                {
                   Id=20,
                   Sum=34,
                   TypeTransactionID=(int)EnumTypesTransactions.Cinema,
                   SenderName="Matt Colin",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="Payment tickets",
                   RecipientName="MultiplexUA"
                },
                new Transaction()
                {
                   Id=21,
                   Sum=250,
                   TypeTransactionID=(int)EnumTypesTransactions.TransferToCard,
                   SenderName="Orest",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="On tea",
                   RecipientName="Vlad"
                },
                new Transaction()
                {
                   Id=22,
                   Sum=654,
                   TypeTransactionID=(int)EnumTypesTransactions.Clothing,
                   SenderName="Jack Wilston",
                   DateTime=new DateTime(2022, 10, 14, 14, 12, 1),
                   Description="Shop of clothing",
                   RecipientName="Shop"
                },
                new Transaction()
                {
                   Id=23,
                   Sum=34,
                   TypeTransactionID=(int)EnumTypesTransactions.Cinema,
                   SenderName="Matt Colin",
                   DateTime=new DateTime(2022, 3, 15, 23, 33, 33),
                   Description="Payment tickets",
                   RecipientName="MultiplexUA"
                },
            });
        }
    }
}
