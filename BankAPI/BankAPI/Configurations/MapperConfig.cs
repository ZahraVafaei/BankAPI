using AutoMapper;
using BankAPI.Data;
using BankAPI.Models.BankCustomers;

namespace BankAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<BankCustomerDto, BankCustomersTb>().ReverseMap();
        }
    }
}
