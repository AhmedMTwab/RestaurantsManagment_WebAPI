using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantsApp.Application.RestaurantHandle.Commands;
using RestaurantsApp.Application.RestaurantHandle.DTOs;
using RestaurantsApp.Domain.Models;

namespace RestaurantsApp.Application.RestaurantHandle
{
    public class RestaurantProfiles : Profile
    {
        public RestaurantProfiles()
        {
            CreateMap<Restaurant, RestaurantsGetDTO>().ForMember(d => d.City, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.City)).
            ForMember(d => d.Country, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.Country))
            .ForMember(d => d.PostalCode, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Street, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

            CreateMap<AddRestaurantCommand, Restaurant>().ForMember(d => d.Address, opt => opt.MapFrom(
                src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                    Country = src.Country
                }));
            CreateMap<UpdateRestaurantCommand, Restaurant>().ForMember(d => d.Address, opt => opt.MapFrom(
               src => new Address
               {
                   City = src.City,
                   PostalCode = src.PostalCode,
                   Street = src.Street,
                   Country = src.Country
               }));
        }
    }
}
