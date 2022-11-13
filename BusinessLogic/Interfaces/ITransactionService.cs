using Core.DTOs;

namespace Core.Interfaces
{
    public interface ITransactionService
    {
        void Create(TransactionDTO phone);

        void Edit(TransactionDTO phone);

        void Delete(int id);

        TransactionDTO? Get(int id);
        IEnumerable<TransactionDTO> GetAll();
    }
}
