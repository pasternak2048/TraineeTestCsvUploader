using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFeatures.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var item = await _context.Users.FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken);

            if (item == null)
            {
                throw new NotFoundException($"Item with Id \" {request.Id} \" not wound.");
            }

            item.Name = request.Name;
            item.DateOfBirth = request.DateOfBirth;
            item.Salary = request.Salary;
            item.Phone = request.Phone;
            item.Married = request.Married;

            _context.Users.Update(item);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateUserResponse>(item);
        }
    }
}
