using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.CreateUserCSV
{
    public sealed class CreateUserCSVMapper : Profile
    {
        public CreateUserCSVMapper()
        {
            CreateMap<User, CreateUserCSVResponse>().ReverseMap();
        }
    }
}
