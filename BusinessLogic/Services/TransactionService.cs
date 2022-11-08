using System.Net;
using DataAccess;
using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using BusinessLogic.Resources;
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
            if (transaction == null) throw new HttpException(ErrorMessages.TransactionIsNullOrEmpy, HttpStatusCode.NoContent);

            context.Transactions.Add(mapper.Map<Transaction>(transaction));
            context.SaveChanges();
        }
        public void Edit(TransactionDTO transaction)
        {
            if(transaction == null) throw new HttpException(ErrorMessages.TransactionIsNullOrEmpy, HttpStatusCode.NoContent);

            context.Transactions.Update(mapper.Map<Transaction>(transaction));
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var transaction = context.Transactions.Find(id);

            if (transaction == null) throw new HttpException(ErrorMessages.TransactionNotFound, HttpStatusCode.NotFound);

            context.Transactions.Remove(transaction);
            context.SaveChanges();
        }
        public TransactionDTO? Get(int id)
        {
            var transaction = context.Transactions.Find(id);

            if (transaction == null) { throw new HttpException(ErrorMessages.TransactionNotFound, HttpStatusCode.NotFound); }
            return mapper.Map<TransactionDTO>(transaction);
        }
        public IEnumerable<TransactionDTO> GetAll()
        {
            var allTransactions = context.Transactions.Include(p => p.TypeTransaction).ToList();
            return mapper.Map<IEnumerable<TransactionDTO>>(allTransactions);
        }
    }
}
