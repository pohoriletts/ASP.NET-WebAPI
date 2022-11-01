using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
