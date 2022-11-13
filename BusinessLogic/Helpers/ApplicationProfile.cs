using Core.DTOs;
using Core.Entities;

namespace Core.Helpers
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(t => t.TypeTransaction, opt => opt.MapFrom(src => src.TypeTransaction.Name));
            CreateMap<TransactionDTO, Transaction>();
        }
    }
}
