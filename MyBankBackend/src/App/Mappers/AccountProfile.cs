using AutoMapper;
using MyBank.DTOs.Outputs;
using MyBank.Models;

namespace MyBank.Mappers
{
    public class AccountProfile :  Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountViewModel>();
        }
    }
}