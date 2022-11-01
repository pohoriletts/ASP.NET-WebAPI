using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITransactionService
    {
        TransactionDTO? Get(int id);
        IEnumerable<TransactionDTO> GetAll();
        void Create(TransactionDTO phone);
        void Edit(TransactionDTO phone);
        void Delete(int id);
    }
}
