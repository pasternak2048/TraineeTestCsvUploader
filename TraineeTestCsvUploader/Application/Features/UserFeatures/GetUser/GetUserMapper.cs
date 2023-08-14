using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.GetUser
{
    public class GetUserMapper : Profile
    {
        public GetUserMapper()
        {
            CreateMap<GetUserResponse, User>().ReverseMap();
        }
    }
}
