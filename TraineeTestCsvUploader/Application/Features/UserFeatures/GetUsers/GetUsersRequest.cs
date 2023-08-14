using Application.Common.Models;
using Domain.Enums;
using MediatR;

namespace Application.Features.UserFeatures.GetUsers
{
    public class GetUsersRequest : IRequest<PaginatedList<GetUsersResponse>>
    {
        public UserSortStateEnum SortState { get; set; } = UserSortStateEnum.None;
        public string Name { get; set; }
        public DateTime? MinDateOfBirth { get; set; }
        public DateTime? MaxDateOfBirth { get; set; }
        public bool? Married { get; set; }
        public string Phone { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}