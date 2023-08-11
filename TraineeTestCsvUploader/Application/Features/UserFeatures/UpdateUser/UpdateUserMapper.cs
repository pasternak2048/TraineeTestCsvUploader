using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.UpdateUser
{
    public class UpdateUserMapper : Profile
    {
        public UpdateUserMapper() 
        {
            CreateMap<UpdateUserRequest, User>().ReverseMap();
            CreateMap<UpdateUserResponse, User>().ReverseMap();
        }
    }
}
