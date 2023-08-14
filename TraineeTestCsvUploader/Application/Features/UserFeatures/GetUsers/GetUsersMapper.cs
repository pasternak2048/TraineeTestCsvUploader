using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.GetUsers
{
    public class GetUsersMapper : Profile
    {
        public GetUsersMapper()
        {
            CreateMap<GetUsersResponse, User>().ReverseMap();
        }
    }
}
