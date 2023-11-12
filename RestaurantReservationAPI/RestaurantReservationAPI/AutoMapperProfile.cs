using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.DTO;
using RestaurantReservation.DTO.CustomerDto;

namespace RestaurantReservationAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<AuthenticationRequestBody, User>();
            CreateMap<User, AuthenticationRequestBody>();
        }
    }
}
