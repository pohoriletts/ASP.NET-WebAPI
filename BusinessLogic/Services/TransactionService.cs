using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly MonobankDbContext context;
        private readonly IMapper mapper;
        public TransactionService(MonobankDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Create(TransactionDTO transaction)
        {
            context.Transactions.Add(mapper.Map<Transaction>(transaction));
            context.SaveChanges();
        }
        public void Edit(TransactionDTO transaction)
        {
            context.Transactions.Update(mapper.Map<Transaction>(transaction));
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var transaction = context.Transactions.Find(id);

            if (transaction == null) return;

            context.Transactions.Remove(transaction);
            context.SaveChanges();
        }
        public TransactionDTO? Get(int id)
        {
            var transaction = context.Transactions.Find(id);
            return mapper.Map<TransactionDTO>(transaction);
        }
        public IEnumerable<TransactionDTO> GetAll()
        {
            var allTransactions = context.Transactions.Include(p => p.TypeTransaction).ToList();
            return mapper.Map<IEnumerable<TransactionDTO>>(allTransactions);
        }
    }
}
