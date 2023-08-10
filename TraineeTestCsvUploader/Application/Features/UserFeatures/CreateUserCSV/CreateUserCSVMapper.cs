using Application.Common.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.CreateUserCSV
{
    public sealed class CreateUserCSVMapper : Profile
    {
        public CreateUserCSVMapper()
        {
            CreateMap<User, CreateUserCSVResponse>().ReverseMap();
            CreateMap<UserCSVDto, CreateUserCSVResponse>().ReverseMap();
            CreateMap<User, UserCSVDto>().ReverseMap();
        }
    }
}
