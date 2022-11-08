using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace BusinessLogic.Helpers
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(t => t.TypeTransaction,
                           opt => opt.MapFrom(src => src.TypeTransaction.Name));
            CreateMap<TransactionDTO, Transaction>();
        }
    }
}
