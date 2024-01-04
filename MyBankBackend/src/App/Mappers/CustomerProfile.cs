using AutoMapper;
using MyBank.DTOs.Inputs;
using MyBank.Models;

namespace MyBank.Mappers
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<string, DateOnly>().ConstructUsing(src => DateOnly.ParseExact(src, "yyyy-MM-dd"));
            CreateMap<CustomerInputModel, Customer>();
        }
    }
}