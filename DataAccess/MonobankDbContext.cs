using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities
{
    public class MonobankDbContext : DbContext
    {
        public MonobankDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedTypesTransactions();
            modelBuilder.SeedTransactions();
        }
        public virtual DbSet<TypeTransaction> TypeTransactions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}
