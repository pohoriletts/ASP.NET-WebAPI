using Core.Entities;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Infrastructure
{
    public class MonobankDbContext : IdentityDbContext
    {
        public MonobankDbContext()
        {

        }
        public MonobankDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedTypesTransactions();
            modelBuilder.SeedTransactions();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("workstation id=WebApiMonoDb.mssql.somee.com;packet size=4096;user id=someemail123_SQLLogin_3;pwd=kusg5mivbf;data source=WebApiMonoDb.mssql.somee.com;persist security info=False;initial catalog=WebApiMonoDb");
        }
        public virtual DbSet<TypeTransaction> TypeTransactions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}
