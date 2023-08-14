using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.CreateUser
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<CreateUserResponse, User>().ReverseMap();
        }
    }
}
