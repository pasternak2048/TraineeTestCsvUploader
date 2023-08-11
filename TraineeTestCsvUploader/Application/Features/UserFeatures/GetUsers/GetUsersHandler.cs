using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFeatures.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, PaginatedList<GetUsersResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetUsersResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var itemsQueryable = _context.Users.AsQueryable();

            itemsQueryable = request.SortState switch
            {
                UserSortStateEnum.NameDesc => itemsQueryable.OrderByDescending(x => x.Name),
                UserSortStateEnum.NameAsc => itemsQueryable.OrderByDescending(x => x.Name),
                UserSortStateEnum.DateOfBirthDesc => itemsQueryable.OrderByDescending(x => x.DateOfBirth),
                UserSortStateEnum.DateOfBirthAsc => itemsQueryable.OrderByDescending(x => x.DateOfBirth),
                UserSortStateEnum.MarriedDesc => itemsQueryable.OrderByDescending(x => x.Married),
                UserSortStateEnum.MarriedAsc => itemsQueryable.OrderByDescending(x => x.Married),
                UserSortStateEnum.SalaryDesc => itemsQueryable.OrderByDescending(x => x.Salary),
                UserSortStateEnum.SalaryAsc => itemsQueryable.OrderByDescending(x => x.Salary),
                _ => itemsQueryable
            };

            if (request.Name != null && request.Name != string.Empty)
            {
                itemsQueryable = itemsQueryable.Where(x => x.Name.Contains(request.Name));
            }

            if (request.MinDateOfBirth != null && request.MaxDateOfBirth != null)
            {
                itemsQueryable = itemsQueryable.Where(x => x.DateOfBirth >= request.MinDateOfBirth && x.DateOfBirth <= request.MaxDateOfBirth);
            }

            if (request.Married != null)
            {
                itemsQueryable = itemsQueryable.Where(x => x.Married == request.Married);
            }

            if (request.MinSalary != null && request.MaxSalary != null)
            {
                itemsQueryable = itemsQueryable.Where(x => x.Salary >= request.MinSalary && x.Salary <= request.MaxSalary);
            }

            var items = await itemsQueryable.ToListAsync(cancellationToken);

            return PaginatedList<GetUsersResponse>.Create(_mapper.Map<List<GetUsersResponse>>(items), request.PageNumber, request.PageSize);
        }
    }
}
