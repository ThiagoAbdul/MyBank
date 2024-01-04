using AutoMapper;
using MyBank.DTOs.Inputs;
using MyBank.DTOs.Outputs;
using MyBank.Models;

namespace MyBank.Mappers
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<string, DateOnly>().ConstructUsing(src => DateOnly.ParseExact(src, "yyyy-MM-dd"));
            // CreateMap<DateOnly, string>().ConstructUsing(src => src.ToString());
            CreateMap<CustomerInputModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}