using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var item = await _context.Users.FirstOrDefaultAsync(x =>x.Id == request.Id, cancellationToken);

            if (item == null)
            {
                throw new NotFoundException($"Item with Id \" {request.Id} \" not wound.");
            }

            _context.Users.Remove(item);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
