using AutoMapper;
using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.Models;

namespace DYS.FinanceTracker.Shared.Settings
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto, Transaction>();
        }

    }
}
