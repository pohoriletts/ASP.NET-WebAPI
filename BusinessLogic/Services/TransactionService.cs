using System.Net;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Resources;

namespace Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionService(IRepository<Transaction> repository, IMapper mapper)
        {
           _transactionRepository = repository;
           _mapper = mapper;
        }
        public void Create(TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) 
                throw new HttpException(ErrorMessages.TransactionIsNullOrEmpy, HttpStatusCode.NoContent);

            _transactionRepository.Insert(_mapper.Map<Transaction>(transactionDTO));
            _transactionRepository.Save();
        }
        public void Edit(TransactionDTO transactionDTO)
        {
            _transactionRepository.Update(_mapper.Map<Transaction>(transactionDTO));
            _transactionRepository.Save();
        }
        public void Delete(int id)
        {
            var transaction = _transactionRepository.GetByID(id);

            if (transaction == null) 
                throw new HttpException(ErrorMessages.TransactionNotFound, HttpStatusCode.NotFound);

            _transactionRepository.Delete(transaction);
            _transactionRepository.Save();
        }
        public TransactionDTO? Get(int id)
        {
            var transaction = _transactionRepository.GetByID(id);

            if (transaction == null) 
                throw new HttpException(ErrorMessages.TransactionNotFound, HttpStatusCode.NotFound);

            return _mapper.Map<TransactionDTO>(transaction);
        }
        public IEnumerable<TransactionDTO> GetAll()
        {
            var allTransaction = _transactionRepository.Get(includeProperties: $"{nameof(Transaction.TypeTransaction)}");

            return _mapper.Map<IEnumerable<TransactionDTO>>(allTransaction);
        }
    }
}
