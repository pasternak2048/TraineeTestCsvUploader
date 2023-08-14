using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFeatures.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var item = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (item == null)
            {
                throw new NotFoundException($"Item with Id \" {request.Id} \" not wound.");
            }

            return _mapper.Map<GetUserResponse>(item);
        }
    }
}
